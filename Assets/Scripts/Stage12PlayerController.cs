using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Stage12PlayerController : MonoBehaviour
{
	Animator Anim;
	bool IsMoving;
    bool IsClear;
	float NowTime;
	float StartTime;
	float StartXPosition;
    SEManager SeManager;

    Vector3 PlayerPos;
    Vector3 Dest;

	void Start()
	{
		Anim = GetComponent<Animator> ();
        SeManager = GetComponent<SEManager>();
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

        if (PosCheck (4, 2) && Input.GetKeyDown (KeyCode.RightArrow))
			RightTeleportMove (4);
		else if (PosCheck (6, 6) && Input.GetKeyDown (KeyCode.RightArrow))
			Stop ();
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
		else if (PosCheck (6, 6) && Input.GetKeyDown (KeyCode.LeftArrow))
			GetComponent<Transform> ().position = new Vector3 (4, 2, -1);
		else if (PosCheck (8, 12) && Input.GetKeyDown (KeyCode.LeftArrow))
			GetComponent<Transform> ().position = new Vector3 (6, 6, -1);
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

		else if (PosCheck (8, 12) && Input.GetKeyDown (KeyCode.DownArrow))
			DownTeleportMove (6);
		else if (PosCheck (16, 12) && Input.GetKeyDown (KeyCode.DownArrow))
			DownTeleportMove (6);
		else if (PosCheck (18, 12) && Input.GetKeyDown (KeyCode.DownArrow))
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
            SeManager.Play(SEManager.Sounds.Move1);
        }
		else if (Input.GetKeyDown (KeyCode.LeftArrow))
		{
			GetComponent<Transform> ().position = new Vector3 (PlayerPos.x - 2, PlayerPos.y, -1);
			GetComponent<Transform> ().rotation = new Quaternion (0, 180, 0, GetComponent<Transform> ().rotation.w);
			IsMoving = true;
            SeManager.Play(SEManager.Sounds.Move2);
        }
        else if (Input.GetKeyDown(KeyCode.LeftBracket)) { SceneManager.LoadScene("Stage 1-1"); }
        else if (Input.GetKeyDown(KeyCode.RightBracket)) { SceneManager.LoadScene("Stage 1-3"); }
        else if (Input.GetKeyDown(KeyCode.R)) { GetComponent<Transform>().position = new Vector3(2, 2, -1); }
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
