using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AudioSource audioSource;
    public List<AudioClip> audioClips = new List<AudioClip>();

    public int songCount;

    public bool isFocused;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = audioClips[songCount];
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnApplicationFocus(bool focus)
    {
        isFocused = focus;
    }

    public void ChangeSong(string newSong)
    {
        float prevSongTime = audioSource.time;
        audioSource.Stop();

        for (int i = 0; i < audioClips.Count; i++)
        {
            if (audioClips[i].name == newSong)
            {
                audioSource.clip = audioClips[i];
                audioSource.time = prevSongTime;
                audioSource.Play();
                break;
            }
        }
    }
}
