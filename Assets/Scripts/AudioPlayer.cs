using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [Header("Click Sound")]
    [SerializeField] AudioClip clickSound;
    [SerializeField][Range(0f, 1f)] float clickSoundVolume = 1f;

    public static AudioPlayer instance;
    void Awake()
    {
        instance = this;
    }

    public void PLayClickSound()
    {
        PlayClip(clickSound, clickSoundVolume);
    }

    public void PlayClip(AudioClip clip, float volume)
    {
        if (clip != null)
        {
            Vector3 cameraPosition = Camera.main.transform.position;
            AudioSource.PlayClipAtPoint(clip, cameraPosition, volume);
        }
    }
}
