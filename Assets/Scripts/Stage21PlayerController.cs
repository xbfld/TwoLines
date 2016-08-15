using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Stage21PlayerController : MonoBehaviour
{
	Animator Anim;
	bool IsMoving;
    bool IsMovable { get; set; }
	float NowTime;
	float StartTime;
	float StartXPosition;
    SEManager SeManager;

	public Vector3 PlayerPos;

	void Start()
	{
		Anim = GetComponent<Animator> ();
        SeManager = GetComponent<SEManager>();
        if (SeManager != null) Debug.Log("Component Get");
        else Debug.Log("Failed to Get SEManager");
        IsMovable = true;
	}

	void Update()
	{
		PlayerPos = GetComponent<Transform> ().position;

        if (IsMovable)
        {
			if (PosCheck (6, 2) && Input.GetKeyDown (KeyCode.RightArrow))
				RightTeleportMove (6);
			else if (PosCheck (8, 2) && Input.GetKeyDown (KeyCode.LeftArrow))
				Stop ();
			else if (PosCheck (8, 6) && Input.GetKeyDown (KeyCode.LeftArrow))
				GetComponent<Transform> ().position = new Vector3 (6, 2, -1);
			else if (PosCheck (12, 6) && Input.GetKeyDown (KeyCode.RightArrow))
				Stop ();
			else if (PosCheck (12, 2) && Input.GetKeyDown (KeyCode.RightArrow))
				RightTeleportMove (2);
			else if (PosCheck (14, 2) && Input.GetKeyDown (KeyCode.LeftArrow))
				LeftTeleportMove (6);
			else if (PosCheck (14, 2) && Input.GetKeyDown (KeyCode.UpArrow))
				UpTeleportMove (6);
			else if (PosCheck (14, 12) && Input.GetKeyDown (KeyCode.DownArrow))
				DownTeleportMove (6);
			else if (PosCheck (14, 2) && Input.GetKeyDown (KeyCode.RightArrow))
				RightTeleportMove (2);
			else if (PosCheck (14, 12) && Input.GetKeyDown (KeyCode.LeftArrow))
				GetComponent<Transform> ().position = new Vector3 (12, 6, -1);
			else if (PosCheck (16, 2) && Input.GetKeyDown (KeyCode.RightArrow))
				RightTeleportMove (2);
			else if (PosCheck (16, 2) && Input.GetKeyDown (KeyCode.LeftArrow))
				LeftTeleportMove (2);
			else if (PosCheck (16, 12) && Input.GetKeyDown (KeyCode.RightArrow))
				Stop ();
			else if (PosCheck (18, 2) && Input.GetKeyDown (KeyCode.RightArrow))
				RightTeleportMove (2);
			else if (PosCheck (18, 2) && Input.GetKeyDown (KeyCode.LeftArrow))
				LeftTeleportMove (2);
			else if (PosCheck (18, 2) && Input.GetKeyDown (KeyCode.UpArrow))
				UpTeleportMove (2);
			else if (PosCheck (18, 8) && Input.GetKeyDown (KeyCode.UpArrow))
				UpTeleportMove (2);
			else if (PosCheck (18, 8) && Input.GetKeyDown (KeyCode.DownArrow))
				DownTeleportMove (2);
			else if (PosCheck (18, 8) && Input.GetKeyDown (KeyCode.LeftArrow))
				GetComponent<Transform> ().position = new Vector3 (12, 6, -1);
			else if (PosCheck (18, 8) && Input.GetKeyDown (KeyCode.RightArrow))
				GetComponent<Transform> ().position = new Vector3 (24, 6, -1);
			else if (PosCheck (18, 14) && Input.GetKeyDown (KeyCode.DownArrow))
				DownTeleportMove (2);
			else if (PosCheck (18, 14) && Input.GetKeyDown (KeyCode.LeftArrow))
				GetComponent<Transform> ().position = new Vector3 (16, 12, -1);
			else if (PosCheck (20, 2) && Input.GetKeyDown (KeyCode.RightArrow))
				Stop ();
			else if (PosCheck (20, 2) && Input.GetKeyDown (KeyCode.LeftArrow))
				LeftTeleportMove (2);
			else if (PosCheck (20, 2) && Input.GetKeyDown (KeyCode.UpArrow))
				UpTeleportMove (8);
			else if (PosCheck (20, 14) && Input.GetKeyDown (KeyCode.DownArrow))
				DownTeleportMove (8);
			else if (PosCheck (22, 2) && Input.GetKeyDown (KeyCode.LeftArrow))
				LeftTeleportMove (2);
			else if (PosCheck (22, 2) && Input.GetKeyDown (KeyCode.UpArrow))
				UpTeleportMove (8);
			else if (PosCheck (22, 2) && Input.GetKeyDown (KeyCode.RightArrow))
				Stop ();
			else if (PosCheck (22, 14) && Input.GetKeyDown (KeyCode.DownArrow))
				DownTeleportMove (8);
			else if (PosCheck (22, 14) && Input.GetKeyDown (KeyCode.RightArrow))
				GetComponent<Transform> ().position = new Vector3 (24, 12, -1);
			else if (PosCheck (24, 6) && Input.GetKeyDown (KeyCode.RightArrow))
				GetComponent<Transform> ().position = new Vector3 (26, 2, -1);
			else if (PosCheck (24, 6) && Input.GetKeyDown (KeyCode.LeftArrow))
				Stop ();
			else if (PosCheck (26, 2) && Input.GetKeyDown (KeyCode.LeftArrow))
				Stop ();
			else if (PosCheck (26, 2) && Input.GetKeyDown (KeyCode.RightArrow))
				Stop ();
			else if (PosCheck (24, 12) && Input.GetKeyDown (KeyCode.LeftArrow))
				Stop ();
			else if (PosCheck (28, 12) && Input.GetKeyDown (KeyCode.RightArrow))
				GetComponent<Transform> ().position = new Vector3 (30, 4, -1);
			else if (PosCheck (30, 4) && Input.GetKeyDown (KeyCode.RightArrow))
				GetComponent<Transform> ().position = new Vector3 (32, 2, -1);
			else if (PosCheck (30, 4) && Input.GetKeyDown (KeyCode.LeftArrow))
				Stop ();
			else if (PosCheck (32, 2) && Input.GetKeyDown (KeyCode.LeftArrow))
				Stop ();
            else
                NormalMove();
        }
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
        else if (Input.GetKeyDown (KeyCode.LeftBracket)) { SceneManager.LoadScene("Stage 1-3"); }
        else if (Input.GetKeyDown(KeyCode.RightBracket)) { SceneManager.LoadScene("Stage 2-2"); }
        else if (Input.GetKeyDown(KeyCode.R)) { SceneManager.LoadScene("Stage 2-1"); }
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
}
