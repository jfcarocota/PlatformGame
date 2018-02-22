using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class Audios
{
    [SerializeField]
    AudioClip[] audioClips;

    public AudioClip[] AudioClips
    {
        get
        {
            return audioClips;
        }
    }
}
