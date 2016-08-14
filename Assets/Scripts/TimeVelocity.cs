using UnityEngine;
using System.Collections;

public class TimeVelocity : MonoBehaviour
{
	public float DeltaTime;

	Animator Anim;
	bool IsMoving;
	float StartXPosition;

	float NowTime;
	float StartTime;

	void Start()
	{
		NowTime = 0;
		StartTime = 0;

		Anim = GetComponent<Animator> ();
	}

	void Update ()
	{
		Anim.SetBool ("Move", IsMoving);

		if (Input.GetKeyDown (KeyCode.RightArrow))
		{
			StartTime = Time.time;
			StartXPosition = GetComponent<Transform> ().position.x;
		}

		AnimatedMove ();
	}

	void AnimatedMove()
	{
		NowTime = Time.time;
		GetComponent<Rigidbody2D> ().velocity = new Vector3 (10, 0, 0);
		IsMoving = true;

		if (NowTime - StartTime > DeltaTime)
		{
			GetComponent<Rigidbody2D> ().velocity = new Vector3 (0, 0, 0);
			IsMoving = false;
			GetComponent<Transform> ().position = new Vector3 (StartXPosition + 2, GetComponent<Transform> ().position.y, GetComponent<Transform> ().position.z);
		}
	}
}
