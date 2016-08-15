using UnityEngine;
using System.Collections;

public class GameStateManager : MonoBehaviour {

    Vector3 PlayerPos;
    Vector3 PortalPos;
    Stage11PlayerController player;
	
	void Start () {
        player = FindObjectOfType<Stage11PlayerController>();
	}
	
	// Update is called once per frame
	void Update () {
        
        PlayerPos = player.PlayerPos;
        PortalPos = GameObject.FindGameObjectWithTag("Portal").transform.position;

        if (PlayerPos.x == PortalPos.x && PlayerPos.y == PortalPos.y)
        {
            player.IsMovable = false;
            player.StopAnimation();
        }
    }
    
}
