using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleDemoObjects : MonoBehaviour
{
    static private bool createdTree;
    static private bool createdGoldMoney;
    static private bool createdGoldTree;
    static private bool finished;

    // Start is called before the first frame update
    void Start()
    {
        createdTree = false;
        createdGoldMoney = false;
        createdGoldTree = false;
        finished = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (this.gameObject.tag == "TreeTrunk" && other.gameObject.tag == "TreeCrown" && !createdTree)
        {
            GameObject tree = Resources.Load<GameObject>("PuzzlePrefabs/Tree");
            Instantiate(tree, transform.position, Quaternion.identity);
            createdTree = true;
            Destroy(this.gameObject);
            Destroy(other.gameObject);
            return;
        }

        if (this.gameObject.tag == "Fire" && other.gameObject.tag == "GoldBricks" && !createdGoldMoney)
        {
            GameObject goldMoney = Resources.Load<GameObject>("PuzzlePrefabs/GoldMoney");
            Instantiate(goldMoney, transform.position, Quaternion.identity);
            createdGoldMoney = true;
            Destroy(this.gameObject);
            Destroy(other.gameObject);
            return;
        }

        if (this.gameObject.tag == "GoldMoney" && other.gameObject.tag == "Tree" && !createdGoldTree)
        {
            GameObject goldTree = Resources.Load<GameObject>("PuzzlePrefabs/GoldTree");
            Instantiate(goldTree, transform.position, Quaternion.identity);
            createdGoldTree = true;
            Destroy(this.gameObject);
            Destroy(other.gameObject);

            GameObject exitSign = Resources.Load<GameObject>("PuzzlePrefabs/ExitSign");
            GameObject exitPoint = GameObject.Find("ExitPoint");
            Instantiate(exitSign, exitPoint.transform.position, Quaternion.identity);
            finished = true;
            return;
        }

        if (finished)
        {
            GameObject room = GameObject.FindGameObjectWithTag("Room");
            room.GetComponent<LevelManager>().ReadyToLoad();
        }
    }
}
