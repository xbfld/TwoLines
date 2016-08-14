﻿using UnityEngine;
using System.Collections;

public class Stage13PlayerController : MonoBehaviour
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
			RightTeleportMove (2);
		else if (PosCheck (6, 2) && Input.GetKeyDown (KeyCode.RightArrow))
			RightTeleportMove (4);
		else if (PosCheck (10, 2) && Input.GetKeyDown (KeyCode.RightArrow))
			RightTeleportMove (12);
		else if (PosCheck (22, 2) && Input.GetKeyDown (KeyCode.RightArrow))
			RightTeleportMove (4);
		else if (PosCheck (24, 8) && Input.GetKeyDown (KeyCode.RightArrow))
			RightTeleportMove (10);
		else if (PosCheck (26, 2) && Input.GetKeyDown (KeyCode.RightArrow))
			RightTeleportMove (8);
		else if (PosCheck (30, 12) && Input.GetKeyDown (KeyCode.RightArrow))
			RightTeleportMove (2);
		else if (PosCheck (34, 2) && Input.GetKeyDown (KeyCode.RightArrow))
			RightTeleportMove (10);
		else if (PosCheck (34, 12) && Input.GetKeyDown (KeyCode.RightArrow))
			RightTeleportMove (14);
		else if (PosCheck (44, 2) && Input.GetKeyDown (KeyCode.RightArrow))
			RightTeleportMove (2);
		else if (PosCheck (46, 2) && Input.GetKeyDown (KeyCode.RightArrow))
			RightTeleportMove (6);
		else if (PosCheck (52, 2) && Input.GetKeyDown (KeyCode.RightArrow))
			RightTeleportMove (2);
		else if (PosCheck (54, 2) && Input.GetKeyDown (KeyCode.RightArrow))
			RightTeleportMove (4);
		else if (PosCheck (58, 2) && Input.GetKeyDown (KeyCode.RightArrow))
			RightTeleportMove (4);
		else if (PosCheck (62, 2) && Input.GetKeyDown (KeyCode.RightArrow))
			Stop ();
		
		else if (PosCheck (8, 2) && Input.GetKeyDown (KeyCode.LeftArrow))
			Stop ();
		else if (PosCheck (22, 8) && Input.GetKeyDown (KeyCode.LeftArrow))
			Stop ();
		else if (PosCheck (24, 2) && Input.GetKeyDown (KeyCode.LeftArrow))
			LeftTeleportMove (12);
		else if (PosCheck (26, 8) && Input.GetKeyDown (KeyCode.LeftArrow))
			LeftTeleportMove (4);
		else if (PosCheck (28, 2) && Input.GetKeyDown (KeyCode.LeftArrow))
			LeftTeleportMove (4);
		else if (PosCheck (36, 2) && Input.GetKeyDown (KeyCode.LeftArrow))
			LeftTeleportMove (8);
		else if (PosCheck (36, 8) && Input.GetKeyDown (KeyCode.LeftArrow))
			LeftTeleportMove (10);
		else if (PosCheck (46, 2) && Input.GetKeyDown (KeyCode.LeftArrow))
			LeftTeleportMove (10);
		else if (PosCheck (48, 2) && Input.GetKeyDown (KeyCode.LeftArrow))
			LeftTeleportMove (2);

		else if (PosCheck (8, 2) && Input.GetKeyDown (KeyCode.UpArrow))
			UpTeleportMove (4);
		else if (PosCheck (24, 2) && Input.GetKeyDown (KeyCode.UpArrow))
			UpTeleportMove (2);
		else if (PosCheck (26, 2) && Input.GetKeyDown (KeyCode.UpArrow))
			UpTeleportMove (6);
		else if (PosCheck (44, 2) && Input.GetKeyDown (KeyCode.UpArrow))
			UpTeleportMove (6);
		else if (PosCheck (48, 2) && Input.GetKeyDown (KeyCode.UpArrow))
			UpTeleportMove (6);

		else if (PosCheck (8, 10) && Input.GetKeyDown (KeyCode.DownArrow))
			DownTeleportMove (4);
		else if (PosCheck (24, 8) && Input.GetKeyDown (KeyCode.DownArrow))
			DownTeleportMove (2);
		else if (PosCheck (44, 12) && Input.GetKeyDown (KeyCode.DownArrow))
			DownTeleportMove (6);
		else if (PosCheck (48, 12) && Input.GetKeyDown (KeyCode.DownArrow))
			DownTeleportMove (6);

		else
			NormalMove ();
	}

	void NormalMove()
	{

		Anim.SetBool ("Move", IsMoving);

		if(Grounded == false)
		{
			GetComponent<Transform> ().position = new Vector3 (PlayerPos.x, PlayerPos.y - 2, -1);
		}
		else
		{
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
			//GetComponent<Transform> ().position = new Vector3 (PlayerPos.x, PlayerPos.y, -1);
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


	public Transform GroundCheck;
	public float GroundCheckRadius;
	public LayerMask WhatIsGround;
	private bool Grounded;

	void FixedUpdate()
	{
		Grounded = Physics2D.OverlapCircle (GroundCheck.position, GroundCheckRadius, WhatIsGround);
	}
}