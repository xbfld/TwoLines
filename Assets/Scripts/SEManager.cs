using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SEManager : MonoBehaviour {

    public enum Sounds
    {
        Blink,
        Move1,
        Move2,       
        Click,
        StageClear
    }

    public List<AudioClip> ClipList;
    public List<AudioSource> SEList;

    public void Awake()
    {
       foreach(AudioClip c in ClipList)
        {
            if (c != null)
            {
                AudioSource audiosource = gameObject.AddComponent<AudioSource>();
                audiosource.loop = false;
                audiosource.clip = c;
                SEList.Add(audiosource);
            }
        }
    }

    public void Play(Sounds sounds)
    {
        if (SEList[(int)sounds] != null)
            SEList[(int)sounds].Play();
    }
}
