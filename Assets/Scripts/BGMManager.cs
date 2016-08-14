using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class BGMManager : MonoBehaviour {

    public enum Sounds
    {
        Title,
        Hanamura,
        Forest,
        City
    }
    private Sounds sound;

    public List<AudioClip> SEList;

    public void Awake()
    {
        string scenename = SceneManager.GetActiveScene().name;
        if (scenename == "Stage 1-1" || scenename == "Stage 1-2" || scenename == "Stage 1-3") sound = Sounds.Hanamura;
        else if (scenename == "Stage 2-1" || scenename == "Stage 2-2" || scenename == "Stage 2-3") sound = Sounds.Forest;
        else if (scenename == "Stage 3-1" || scenename == "Stage 3-2" || scenename == "Stage 3-3") sound = Sounds.City;
        else if (scenename == "Title" || scenename == "Settings") sound = Sounds.Title;
        Debug.Log("BGMMANAGER");
        Play(sound);
    }

    public void Play(Sounds sounds)
    {
        AudioSource audiosource = gameObject.AddComponent<AudioSource>();
        audiosource.loop = true;
        audiosource.clip = SEList[(int)sounds];
        audiosource.Play();
    }
}
