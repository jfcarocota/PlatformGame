using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    Audios audios;

    public static GameManager instance;

    AudioSource aud;
    [SerializeField]
    Health heath;

    public Health Heath
    {
        get
        {
            return heath;
        }
    }

    private void Awake()
    {
        instance = this;
        aud = GetComponent<AudioSource>();
    }

    public void PlaySFX(int index)
    {
        index = index < 0 ? 0 : index > audios.AudioClips.Length - 1 ?
                                 audios.AudioClips.Length - 1 : index;
        aud.PlayOneShot(audios.AudioClips[index]);
    }

    public void PlaySFX(int index, float volume)
    {
        index = index < 0 ? 0 : index > audios.AudioClips.Length - 1 ?
                                 audios.AudioClips.Length - 1 : index;
        aud.PlayOneShot(audios.AudioClips[index], volume);
    }

    public void PlaySFXContinius(int index)
    {
        index = index < 0 ? 0 : index > audios.AudioClips.Length - 1 ?
                                 audios.AudioClips.Length - 1 : index;
        aud.clip = audios.AudioClips[index];
        if (!aud.isPlaying)
        {
            aud.Play();
        }
    }

    public void PlaySFXContinius(int index, float volume)
    {
        index = index < 0 ? 0 : index > audios.AudioClips.Length - 1 ?
                                 audios.AudioClips.Length - 1 : index;
        aud.clip = audios.AudioClips[index];
        aud.volume = volume;
        if (!aud.isPlaying)
        {
            aud.Play();
        }
    }
}
