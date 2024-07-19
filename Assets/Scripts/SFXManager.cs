using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{
    public List<AudioClip> sfxClips = new List<AudioClip>();
    public AudioSource sfxSource;

    public void PlaySFX(string sFXName)
    {
        for (int i = 0; i < sfxClips.Count; i++)
        {
            if (sfxClips[i].name == sFXName)
            {
                sfxSource.clip = sfxClips[i];
                sfxSource.Play();
                break;
            }
        }
    }
}
