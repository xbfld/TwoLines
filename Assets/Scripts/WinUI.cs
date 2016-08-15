using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class WinUI : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnNextButton()
    {

    }

    public void OnMenuButton()
    {
        SceneManager.LoadScene("LevelSelect");
    }
}
