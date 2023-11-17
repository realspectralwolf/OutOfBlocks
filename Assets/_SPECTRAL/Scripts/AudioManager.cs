using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    private void Awake()
    {

        Instance = this;
    }

    public void PlayAudioClip(AudioClip clip)
    {
        AudioSource.PlayClipAtPoint(clip, transform.position);
    }

    public void StartGameplayMusic()
    {
        GetComponent<AudioSource>().clip = GameManager.Instance.GetMusicTrack();
        GetComponent<AudioSource>().Play();
    }
}
