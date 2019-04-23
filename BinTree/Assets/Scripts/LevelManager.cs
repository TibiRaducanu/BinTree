using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    private bool finished;
    private GameObject[] doors;
    // Start is called before the first frame update
    void Start()
    {
        finished = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (finished)
        {
            doors = GameObject.FindGameObjectsWithTag("Door");
            foreach(GameObject door in doors)
            {
                door.GetComponent<LoadNewArea>().ReadyToLoad();
            }
        }
    }

    public void ReadyToLoad()
    {
        finished = true;
    }
}
