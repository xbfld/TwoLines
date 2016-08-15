using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Stage22PlayerController : MonoBehaviour
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
        else if (Input.GetKeyDown(KeyCode.LeftBracket)) { SceneManager.LoadScene("Stage 2-1"); }
        else if (Input.GetKeyDown(KeyCode.RightBracket)) { /*SceneManager.LoadScene("Stage 2-3");*/ }
        else if (Input.GetKeyDown(KeyCode.R)) { SceneManager.LoadScene("Stage 2-2"); }
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
