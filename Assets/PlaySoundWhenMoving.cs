using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundWhenMoving : MonoBehaviour
{
    public AudioClip audioClip;

    private AudioSource audioSource;
    private Rigidbody2D rb2D;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        rb2D = GetComponent<Rigidbody2D>();
        audioSource.clip = audioClip;
    }

    // Update is called once per frame
    void Update()
    {
        if(!audioSource.isPlaying)
            if(rb2D.velocity.magnitude > 0)
            {
                audioSource.Play();
            }
        
    }
}
