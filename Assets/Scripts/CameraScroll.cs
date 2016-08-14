using UnityEngine;
using System.Collections;

public class CameraScroll : MonoBehaviour {
    GameObject player = null;
    Vector3 playerPos;

    // 카메라의 position은 기본적으로 y-value를 8로 유지(돌바닥이 0에 깔려있고 높이가 2).
    // 왼쪽으로는 17까지, 오른쪽으로는 캐릭터가 움직이는 곳까지(포탈이 맵의 중간에 있을 수 있음)

	// Use this for initialization
	void Start () {
        player = GameObject.Find("Player"); // find player using its name
        playerPos = player.transform.position;
        this.transform.position = new Vector3((17 > playerPos.x ? 17 : playerPos.x), 8, -10);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        playerPos = player.transform.position;
        this.transform.position = new Vector3((17 > playerPos.x ? 17 : playerPos.x), 8, -10);
    }
}
