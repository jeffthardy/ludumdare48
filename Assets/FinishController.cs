using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FinishController : MonoBehaviour
{
    public string menuScene;
    public float delay = 5.0f;

    private float switchTime;

    // Start is called before the first frame update
    void Start()
    {
        switchTime = Time.time + delay;
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time > switchTime)
        {
            SceneManager.LoadScene(menuScene);
        }
        
    }
}
