using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class OptionsMenu : MonoBehaviour
{
    public GameObject optionsMenu;

    public AudioMixer audioMixer;

    public void OpenMenu()
    {
        if(optionsMenu.activeSelf == false)
        {
            optionsMenu.SetActive(true);
        }

        else
        {
            optionsMenu.SetActive(false);
        }

    }

    public void SetVolume (float volume)
    {
        audioMixer.SetFloat("Volume", volume);
    }
}
