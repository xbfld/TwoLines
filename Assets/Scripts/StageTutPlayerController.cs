using UnityEngine;
using System.Collections;

public class StageTutPlayerController : MonoBehaviour
{
	Animator Anim;
	bool IsMoving;
    public bool IsMovable { get; set; }
	float NowTime;
	float StartTime;
	float StartXPosition;
    SEManager SeManager;

	public Vector3 PlayerPos;

	void Start()
	{
		Anim = GetComponent<Animator> ();
        SeManager = GetComponent<SEManager>();
        IsMovable = true;
	}

	void Update()
	{
		PlayerPos = GetComponent<Transform> ().position;

        if (IsMovable)
        {
			if (PosCheck (4, 2) && Input.GetKeyDown (KeyCode.RightArrow))
				RightTeleportMove (2);
			else if (PosCheck (8, 2) && Input.GetKeyDown (KeyCode.LeftArrow))
				LeftTeleportMove (2);
			else if (PosCheck (8, 2) && Input.GetKeyDown (KeyCode.UpArrow))
				UpTeleportMove (4);
			else if (PosCheck (8, 10) && Input.GetKeyDown (KeyCode.DownArrow))
				DownTeleportMove (4);
			else if (PosCheck (10, 2) && Input.GetKeyDown (KeyCode.UpArrow))
				UpTeleportMove (4);
			else if (PosCheck (10, 10) && Input.GetKeyDown (KeyCode.DownArrow))
				DownTeleportMove (4);
			else if (PosCheck (10, 2) && Input.GetKeyDown (KeyCode.RightArrow))
				Stop ();
			else if (PosCheck (10, 10) && Input.GetKeyDown (KeyCode.RightArrow))
				GetComponent<Transform> ().position = new Vector3 (12, 2, -1);
			else if (PosCheck (6, 10) && Input.GetKeyDown (KeyCode.LeftArrow))
				GetComponent<Transform> ().position = new Vector3 (4, 2, -1);
			else if (PosCheck (12, 2) && Input.GetKeyDown (KeyCode.LeftArrow))
				LeftTeleportMove (4);
			else if (PosCheck (6, 2) && Input.GetKeyDown (KeyCode.RightArrow))
				RightTeleportMove (4);
			else if (PosCheck (6, 2) && Input.GetKeyDown (KeyCode.LeftArrow))
				Stop ();
            else
                NormalMove();
        }
        else Anim.SetBool("Move", IsMoving);
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
}
