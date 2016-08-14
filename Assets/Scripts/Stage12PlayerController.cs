using UnityEngine;
using System.Collections;

public class Stage12PlayerController : MonoBehaviour
{
	Animator Anim;
	bool IsMoving;
	float NowTime;
	float StartTime;
	float StartXPosition;

	Vector3 PlayerPos;

	void Start()
	{
		Anim = GetComponent<Animator> ();
	}

	void Update()
	{
		PlayerPos = GetComponent<Transform> ().position;

		if (PosCheck (4, 2) && Input.GetKeyDown (KeyCode.RightArrow))
			RightTeleportMove (4);
		else if (PosCheck (8, 2) && Input.GetKeyDown (KeyCode.RightArrow))
			RightTeleportMove (2);
		else if (PosCheck (10, 2) && Input.GetKeyDown (KeyCode.RightArrow))
			RightTeleportMove (6);
		else if (PosCheck (12, 6) && Input.GetKeyDown (KeyCode.RightArrow))
			RightTeleportMove (2);
		else if (PosCheck (12, 12) && Input.GetKeyDown (KeyCode.RightArrow))
			GetComponent<Transform> ().position = new Vector3 (14, 2, -1);
		else if (PosCheck (16, 2) && Input.GetKeyDown (KeyCode.RightArrow))
			Stop ();
		else if (PosCheck (18, 2) && Input.GetKeyDown (KeyCode.RightArrow))
			Stop ();
		else if (PosCheck (18, 6) && Input.GetKeyDown (KeyCode.RightArrow))
			RightTeleportMove (3);
		else if (PosCheck (18, 12) && Input.GetKeyDown (KeyCode.RightArrow))
			GetComponent<Transform> ().position = new Vector3 (20, 10, -1);
		else if (PosCheck (24, 2) && Input.GetKeyDown (KeyCode.RightArrow))
			RightTeleportMove (2);
		else if (PosCheck (24, 6) && Input.GetKeyDown (KeyCode.RightArrow))
			RightTeleportMove (3);
		else if (PosCheck (24, 10) && Input.GetKeyDown (KeyCode.RightArrow))
			GetComponent<Transform> ().position = new Vector3 (26, 2, -1);
		else if (PosCheck (26, 2) && Input.GetKeyDown (KeyCode.RightArrow))
			RightTeleportMove (4);
		else if (PosCheck (30, 2) && Input.GetKeyDown (KeyCode.RightArrow))
			RightTeleportMove (2);
		else if (PosCheck (30, 6) && Input.GetKeyDown (KeyCode.RightArrow))
			RightTeleportMove (6);
		else if (PosCheck (32, 2) && Input.GetKeyDown (KeyCode.RightArrow))
			RightTeleportMove (4);
		
		else if (PosCheck (6, 2) && Input.GetKeyDown (KeyCode.LeftArrow))
			Stop ();
		else if (PosCheck (10, 2) && Input.GetKeyDown (KeyCode.LeftArrow))
			LeftTeleportMove (4);
		else if (PosCheck (12, 2) && Input.GetKeyDown (KeyCode.LeftArrow))
			LeftTeleportMove (2);
		else if (PosCheck (16, 12) && Input.GetKeyDown (KeyCode.LeftArrow))
			GetComponent<Transform> ().position = new Vector3 (14, 2, -1);
		else if (PosCheck (18, 2) && Input.GetKeyDown (KeyCode.LeftArrow))
			LeftTeleportMove (6);
		else if (PosCheck (20, 10) && Input.GetKeyDown (KeyCode.LeftArrow))
			Stop ();
		else if (PosCheck (24, 2) && Input.GetKeyDown (KeyCode.LeftArrow))
			Stop ();
		else if (PosCheck (26, 2) && Input.GetKeyDown (KeyCode.LeftArrow))
			Stop ();
		else if (PosCheck (28, 2) && Input.GetKeyDown (KeyCode.LeftArrow))
			LeftTeleportMove (2);
		else if (PosCheck (32, 2) && Input.GetKeyDown (KeyCode.LeftArrow))
			LeftTeleportMove (4);
		else if (PosCheck (34, 2) && Input.GetKeyDown (KeyCode.LeftArrow))
			LeftTeleportMove (2);
		else if (PosCheck (38, 2) && Input.GetKeyDown (KeyCode.LeftArrow))
			LeftTeleportMove (4);
		else if (PosCheck (42, 2) && Input.GetKeyDown (KeyCode.LeftArrow))
			LeftTeleportMove (4);

		else if (PosCheck (8, 2) && Input.GetKeyDown (KeyCode.UpArrow))
			UpTeleportMove (6);
		else if (PosCheck (12, 2) && Input.GetKeyDown (KeyCode.UpArrow))
			UpTeleportMove (6);
		else if (PosCheck (16, 2) && Input.GetKeyDown (KeyCode.UpArrow))
			UpTeleportMove (6);
		else if (PosCheck (18, 2) && Input.GetKeyDown (KeyCode.UpArrow))
			UpTeleportMove (6);
		else if (PosCheck (28, 2) && Input.GetKeyDown (KeyCode.UpArrow))
			UpTeleportMove (6);
		else if (PosCheck (30, 2) && Input.GetKeyDown (KeyCode.UpArrow))
			UpTeleportMove (6);

		else if (PosCheck (16, 12) && Input.GetKeyDown (KeyCode.DownArrow))
			DownTeleportMove (6);
		else if (PosCheck (28, 12) && Input.GetKeyDown (KeyCode.DownArrow))
			DownTeleportMove (6);
		else if (PosCheck (30, 12) && Input.GetKeyDown (KeyCode.DownArrow))
			DownTeleportMove (6);
		else
			NormalMove ();
	}

	void NormalMove()
	{

		Anim.SetBool ("Move", IsMoving);

		if (Input.GetKeyDown (KeyCode.RightArrow))
		{
			GetComponent<Transform> ().position = new Vector3 (PlayerPos.x + 2, PlayerPos.y, -1);
			GetComponent<Transform> ().rotation = new Quaternion (0, 0, 0, GetComponent<Transform> ().rotation.w);
			IsMoving = true;
		}
		else if (Input.GetKeyDown (KeyCode.LeftArrow))
		{
			GetComponent<Transform> ().position = new Vector3 (PlayerPos.x - 2, PlayerPos.y, -1);
			GetComponent<Transform> ().rotation = new Quaternion (0, 180, 0, GetComponent<Transform> ().rotation.w);
			IsMoving = true;
		}
		else
		{
			IsMoving = false;
		}
	}

	void RightTeleportMove(int a)
	{
		GetComponent<Transform> ().position = new Vector3 (PlayerPos.x + a + 2, PlayerPos.y, -1);
		GetComponent<Transform> ().rotation = new Quaternion (0, 0, 0, GetComponent<Transform> ().rotation.w);
	}

	void LeftTeleportMove(int a)
	{
		GetComponent<Transform> ().position = new Vector3 (PlayerPos.x - a - 2, PlayerPos.y, -1);
		GetComponent<Transform> ().rotation = new Quaternion (0, 180, 0, GetComponent<Transform> ().rotation.w);
	}

	void UpTeleportMove(int a)
	{
		GetComponent<Transform> ().position = new Vector3 (PlayerPos.x, PlayerPos.y + a + 4, -1);
	}

	void DownTeleportMove(int a)
	{
		GetComponent<Transform> ().position = new Vector3 (PlayerPos.x, PlayerPos.y - a - 4, -1);
	}

	void Stop()
	{
	}

	bool PosCheck(int a, int b)
	{
		if (PlayerPos == new Vector3 (a, b, -1))
			return true;
		else
			return false;
	}
}
