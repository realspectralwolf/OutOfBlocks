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
    public AudioClip smashClip;
    public void PlaySmashed()
    {
        AudioSource.PlayClipAtPoint(smashClip, transform.position);
    }

    public void StartGameplayMusic()
    {
        GetComponent<AudioSource>().Play();
    }
}
