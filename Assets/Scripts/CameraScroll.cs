using UnityEngine;
using System.Collections;

public class CameraScroll : MonoBehaviour
{
	public int CameraStartPosition;
	public int CameraEndPosition;

    GameObject player = null;
    Vector3 playerPos;

	void Start ()
	{
        player = GameObject.Find("Player");
		this.transform.position = new Vector3(CameraStartPosition, 8, -10);
	}

	void Update () 
	{
        playerPos = player.transform.position;
		if(CameraStartPosition > playerPos.x)
			this.transform.position = new Vector3(CameraStartPosition, 8, -10);
		else if(playerPos.x < CameraEndPosition)
			this.transform.position = new Vector3(playerPos.x, 8, -10);
		else
			this.transform.position = new Vector3(CameraEndPosition, 8, -10);
    }
}
