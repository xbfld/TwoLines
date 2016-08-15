using UnityEngine;
using System.Collections;

public class GameStateManager : MonoBehaviour {

    Vector3 PlayerPos;
    Vector3 PortalPos;
	
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        
        PlayerPos = FindObjectOfType<Stage11PlayerController>().PlayerPos;
        PortalPos = GameObject.FindGameObjectWithTag("Portal").transform.position;

        if (PlayerPos == PortalPos) Debug.Log("Stage Clear!");
    }
    
}
