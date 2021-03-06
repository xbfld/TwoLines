﻿using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Stage11PlayerController : MonoBehaviour
{
	Animator Anim;
	bool IsMoving;
    public bool IsMovable { get; set; }
    bool IsClear;
	float NowTime;
	float StartTime;
	float StartXPosition;
    SEManager SeManager;

	public Vector3 PlayerPos;
    Vector3 Dest;

	void Start()
	{
		Anim = GetComponent<Animator> ();
        SeManager = GetComponent<SEManager>();
        IsMovable = true;
        Dest = GameObject.FindGameObjectWithTag("Portal").transform.position;
    }

	void Update()
	{
		PlayerPos = GetComponent<Transform> ().position;

        if (!IsClear && Arrive())
        {
            SeManager.Play(SEManager.Sounds.StageClear);
            IsClear = true;
        }

        if (IsMovable)
        {
            if (PosCheck(8, 2) && Input.GetKeyDown(KeyCode.RightArrow))
                RightTeleportMove(6);
            else if (PosCheck(10, 2) && Input.GetKeyDown(KeyCode.LeftArrow))
                Stop();
            else if (PosCheck(14, 2) && Input.GetKeyDown(KeyCode.RightArrow))
                RightTeleportMove(10);
            else if (PosCheck(16, 2) && Input.GetKeyDown(KeyCode.LeftArrow))
                LeftTeleportMove(6);
            else if (PosCheck(24, 2) && Input.GetKeyDown(KeyCode.RightArrow))
                RightTeleportMove(2);
            else if (PosCheck(26, 2) && Input.GetKeyDown(KeyCode.LeftArrow))
                LeftTeleportMove(10);
            else if (PosCheck(26, 2) && Input.GetKeyDown(KeyCode.RightArrow))
                RightTeleportMove(4);
            else if (PosCheck(26, 10) && Input.GetKeyDown(KeyCode.LeftArrow))
                GetComponent<Transform>().position = new Vector3(24, 2, -1);
            else if (PosCheck(28, 2) && Input.GetKeyDown(KeyCode.LeftArrow))
                LeftTeleportMove(2);
            else if (PosCheck(28, 2) && Input.GetKeyDown(KeyCode.UpArrow))
                UpTeleportMove(4);
            else if (PosCheck(28, 10) && Input.GetKeyDown(KeyCode.DownArrow))
                DownTeleportMove(4);
            else if (PosCheck(30, 2) && Input.GetKeyDown(KeyCode.UpArrow))
                UpTeleportMove(4);
            else if (PosCheck(30, 10) && Input.GetKeyDown(KeyCode.RightArrow))
                GetComponent<Transform>().position = new Vector3(32, 2, -1);
            else if (PosCheck(30, 10) && Input.GetKeyDown(KeyCode.DownArrow))
                DownTeleportMove(4);
            else if (PosCheck(30, 2) && Input.GetKeyDown(KeyCode.RightArrow))
                RightTeleportMove(8);
            else if (PosCheck(32, 2) && Input.GetKeyDown(KeyCode.LeftArrow))
                LeftTeleportMove(4);
            else if (PosCheck(38, 2) && Input.GetKeyDown(KeyCode.RightArrow))
                RightTeleportMove(4);
            else if (PosCheck(40, 2) && Input.GetKeyDown(KeyCode.LeftArrow))
                LeftTeleportMove(8);
            else if (PosCheck(42, 2) && Input.GetKeyDown(KeyCode.RightArrow))
                Stop();
            else if (PosCheck(44, 2) && Input.GetKeyDown(KeyCode.LeftArrow))
                LeftTeleportMove(4);
            else if (PosCheck(0, 2) && Input.GetKeyDown(KeyCode.LeftArrow))
                Stop();
            else
                NormalMove();
        }
        else Anim.SetBool("Move", IsMoving);
	}

	void NormalMove()
	{

		Anim.SetBool ("Move", IsMoving);

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            GetComponent<Transform>().position = new Vector3(PlayerPos.x + 2, PlayerPos.y, -1);
            GetComponent<Transform>().rotation = new Quaternion(0, 0, 0, GetComponent<Transform>().rotation.w);
            IsMoving = true;
            SeManager.Play(SEManager.Sounds.Move1);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            GetComponent<Transform>().position = new Vector3(PlayerPos.x - 2, PlayerPos.y, -1);
            GetComponent<Transform>().rotation = new Quaternion(0, 180, 0, GetComponent<Transform>().rotation.w);
            IsMoving = true;
            SeManager.Play(SEManager.Sounds.Move2);
        }
        else if (Input.GetKeyDown(KeyCode.RightBracket)) { SceneManager.LoadScene("Stage 1-2"); }
        else if (Input.GetKeyDown(KeyCode.R)) { GetComponent<Transform>().position = new Vector3(4, 2, -1); }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (Arrive()) SceneManager.LoadScene("LevelSelect");
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
        SeManager.Play(SEManager.Sounds.Blink);
    }

	void LeftTeleportMove(int a)
	{
		GetComponent<Transform> ().position = new Vector3 (PlayerPos.x - a - 2, PlayerPos.y, -1);
		GetComponent<Transform> ().rotation = new Quaternion (0, 180, 0, GetComponent<Transform> ().rotation.w);
        SeManager.Play(SEManager.Sounds.Blink);
    }

	void UpTeleportMove(int a)
	{
		GetComponent<Transform> ().position = new Vector3 (PlayerPos.x, PlayerPos.y + a + 4, -1);
        SeManager.Play(SEManager.Sounds.Blink);
    }

	void DownTeleportMove(int a)
	{
		GetComponent<Transform> ().position = new Vector3 (PlayerPos.x, PlayerPos.y - a - 4, -1);
        SeManager.Play(SEManager.Sounds.Blink);
    }
    

	public void StopAnimation()
	{
        IsMoving = false;
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

    bool Arrive() { return (PlayerPos.x == Dest.x && PlayerPos.y == Dest.y); }
}
