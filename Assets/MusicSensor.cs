using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicSensor : MonoBehaviour
{
    public MusicController musicController;
    public int newSongIndex;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        //Debug.Log("Enabled Gravity?");
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            musicController.changeSong(newSongIndex);
        }

    }

    private void OnTriggerStay2D(Collider2D other)
    {
        //Debug.Log("Enabled Gravity?");
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            musicController.changeSong(newSongIndex);
        }

    }
}
