using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Portal : MonoBehaviour {

    GameObject player;
    public GameObject winUI;
	// Use this for initialization
	void Start () {
        player = GameObject.Find("Player");
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if((Vector2)(player.transform.position) == (Vector2)(this.transform.position))
        {
            winUI.SetActive(true);
        }
	}
}
