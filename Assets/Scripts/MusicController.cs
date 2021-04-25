using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{

    public AudioClip[] songs;

    private AudioSource audioSource;
    private int songIndex;

    // Start is called before the first frame update
    void Start()
    {
        songIndex = 0;
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = songs[songIndex];
        audioSource.loop = true;
        audioSource.PlayScheduled(Time.time+1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void changeSong(int index)
    {
        if (songIndex != index)
        {
            songIndex = index;
            audioSource.clip = songs[songIndex];
            audioSource.Play();
        }

    }


}
