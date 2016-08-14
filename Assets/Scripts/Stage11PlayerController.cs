using UnityEngine;
using System.Collections;

public class Stage11PlayerController : MonoBehaviour
{
	Vector3 PlayerPos;

	void Start()
	{
		
	}

	void Update()
	{
		PlayerPos = GetComponent<Transform> ().position;

		if (PosCheck(8, 2) && Input.GetKeyDown (KeyCode.RightArrow))
			RightTeleportMove (6);
		else if (PosCheck(16, 2) && Input.GetKeyDown (KeyCode.LeftArrow))
			LeftTeleportMove (6);
		else if (PosCheck(24, 2) && Input.GetKeyDown (KeyCode.RightArrow))
			RightTeleportMove (2);
		else if (PosCheck(28, 2) && Input.GetKeyDown (KeyCode.LeftArrow))
			LeftTeleportMove (2);
		else if (PosCheck(28, 2) && Input.GetKeyDown (KeyCode.UpArrow))
			UpTeleportMove (4);
		else if (PosCheck(28, 10) && Input.GetKeyDown (KeyCode.DownArrow))
			DownTeleportMove (4);
		else if (PosCheck(30, 2) && Input.GetKeyDown (KeyCode.UpArrow))
			UpTeleportMove (4);
		else if (PosCheck(30, 10) && Input.GetKeyDown (KeyCode.DownArrow))
			DownTeleportMove (4);
		else if (PosCheck(30, 2) && Input.GetKeyDown (KeyCode.RightArrow))
			RightTeleportMove (8);
		else if (PosCheck(40, 2) && Input.GetKeyDown (KeyCode.LeftArrow))
			LeftTeleportMove (8);
		else if (PosCheck(42, 2) && Input.GetKeyDown (KeyCode.RightArrow))
			Stop ();
		else
			NormalMove ();
	}

	void NormalMove()
	{
		if (Input.GetKeyDown (KeyCode.RightArrow))
		{
			GetComponent<Transform> ().position = new Vector3 (PlayerPos.x + 2, PlayerPos.y, -1);
		}
		else if (Input.GetKeyDown (KeyCode.LeftArrow))
		{
			GetComponent<Transform> ().position = new Vector3 (PlayerPos.x - 2, PlayerPos.y, -1);
		}
	}

	void RightTeleportMove(int a)
	{
		GetComponent<Transform> ().position = new Vector3 (PlayerPos.x + a + 2, PlayerPos.y, -1);
	}

	void LeftTeleportMove(int a)
	{
		GetComponent<Transform> ().position = new Vector3 (PlayerPos.x - a - 2, PlayerPos.y, -1);
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
