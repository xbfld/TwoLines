using UnityEngine;
using System.Collections;

public class TimeVelocity : MonoBehaviour
{
	public float DeltaTime;

	Animator Anim;
	bool IsMoving;
	bool GoRight;
	bool GoLeft;
	float StartXPosition;

	float NowTime;
	float StartTime;

	void Start()
	{
		NowTime = 0;
		StartTime = 0;
		GoRight = false;
		GoLeft = false;

		Anim = GetComponent<Animator> ();
	}

	void Update ()
	{
		Anim.SetBool ("Move", IsMoving);

		if (Input.GetKeyDown (KeyCode.RightArrow) && IsMoving == false)
		{
			Debug.Log ("RightArrow");
			StartTime = Time.time;
			StartXPosition = GetComponent<Transform> ().position.x;
			GoRight = true;
		}
		else if (Input.GetKeyDown (KeyCode.LeftArrow) && IsMoving == false)
		{
			StartTime = Time.time;
			StartXPosition = GetComponent<Transform> ().position.x;
			GoLeft = true;
		}

		if (GoRight == true)
			AnimatedRightMove ();
		else if (GoLeft == true)
			AnimatedLeftMove ();
	}

	void AnimatedRightMove()
	{
		NowTime = Time.time;
		GetComponent<Rigidbody2D> ().velocity = new Vector3 (10, 0, 0);
		IsMoving = true;

		if (NowTime - StartTime > DeltaTime)
		{
			GetComponent<Rigidbody2D> ().velocity = new Vector3 (0, 0, 0);
			IsMoving = false;
			GoRight = false;
			GetComponent<Transform> ().position = new Vector3 (StartXPosition + 2, GetComponent<Transform> ().position.y, GetComponent<Transform> ().position.z);
		}
	}

	void AnimatedLeftMove()
	{
		NowTime = Time.time;
		GetComponent<Rigidbody2D> ().velocity = new Vector3 (-10, 0, 0);
		IsMoving = true;

		if (NowTime - StartTime > DeltaTime)
		{
			GetComponent<Rigidbody2D> ().velocity = new Vector3 (0, 0, 0);
			IsMoving = false;
			GoLeft = false;
			GetComponent<Transform> ().position = new Vector3 (StartXPosition - 2, GetComponent<Transform> ().position.y, GetComponent<Transform> ().position.z);
		}
	}
}
