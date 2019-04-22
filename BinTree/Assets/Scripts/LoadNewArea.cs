using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadNewArea : MonoBehaviour
{
    public string levelToLoad;
    private bool readyToLoad;

    // Start is called before the first frame update
    void Start()
    {
        readyToLoad = true;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void ReadyToLoad()
    {
        readyToLoad = true;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" && readyToLoad)
        {
            Application.LoadLevel(levelToLoad);
        }
    }
}
