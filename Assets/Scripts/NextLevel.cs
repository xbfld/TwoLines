using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class NextLevel : MonoBehaviour {

    public string titleScene;
    public string settingScene;
    public string levelSelect;

    void Start()
    {
        if (PlayerPrefs.GetInt("Tutorial") == 0)
        {
            PlayerPrefs.SetInt("Tutorial", 1);
        }
    }
    public NextLevel()
    {
        titleScene = "Title";
        settingScene = "Setting";
        levelSelect = "LevelSelect";
    }

	public void gotoLevel(int index)
    {
        SceneManager.LoadScene(index);
    }

    public void loadMainMenu()
    {
        SceneManager.LoadScene(titleScene);
    }

    public void loadLevelSelect()
    {
        if (PlayerPrefs.GetInt("Tutorial") == 1)
        {
            PlayerPrefs.SetInt("Tutorial", 2);
            SceneManager.LoadScene("Tutorial");
        }
        else
        {
            SceneManager.LoadScene(levelSelect);
        }
    }

    public void gotoLevel(string name)
    {
        SceneManager.LoadScene(name);
    }

}
