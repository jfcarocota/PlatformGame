using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    Audios audios;

    public static GameManager instance;

    AudioSource aud;
    [SerializeField]
    Health heath;

    [SerializeField]
    Character character;

    [SerializeField]
    PlayableDirector pd;

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

    public bool PlayerIsActing
    {
        get { return character.IsOnCinematic; }
        set { character.IsOnCinematic = value; }
    }

    public Animator PlayerAnim
    {
        get { return character.Anim; }
    }

    public PlayableDirector Pd
    {
        get
        {
            return pd;
        }
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
