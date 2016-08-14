using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class NextLevel : MonoBehaviour {

    public string titleScene;
    public string settingScene;
    public string levelSelect;

    public NextLevel()
    {
        titleScene = "Title";
        settingScene = "Settings";
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
        SceneManager.LoadScene(levelSelect);
    }

    public void gotoLevel(string name)
    {
        SceneManager.LoadScene(name);
    }

}
