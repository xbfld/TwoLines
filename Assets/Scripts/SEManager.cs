using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SEManager : MonoBehaviour {

    public enum Sounds
    {
        Move1,
        Move2,
        Blink,
        Click,
        StageClear
    }

    public List<AudioClip> SEList;

    public void Play(Sounds sounds)
    {
        AudioSource audiosource = gameObject.AddComponent<AudioSource>();
        audiosource.loop = false;
        audiosource.clip = SEList[(int)sounds];
        audiosource.Play();
    }
}
