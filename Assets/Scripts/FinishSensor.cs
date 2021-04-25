using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FinishSensor : MonoBehaviour
{

    public string winScene;
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
            Debug.Log("You Win!!!!");
            SceneManager.LoadScene(winScene);
        }

    }

    private void OnTriggerStay2D(Collider2D other)
    {
        //Debug.Log("Enabled Gravity?");
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            Debug.Log("You Win!!!!");
            SceneManager.LoadScene(winScene);
        }

    }
}
