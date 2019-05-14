using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SkeletonPatrol : MonoBehaviour
{
    public float moveSpeed;
    public Transform[] moveSpots;
    private int randomSpot;
    private float waitTime;
    public float startWaitTime;
    private Animator skeletonAnimator;

    private bool isMoving;
    private bool isDead;

    public float waitToReload;
    private bool reloading;
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        waitTime = startWaitTime;

        randomSpot = Random.Range(0, moveSpots.Length);

        skeletonAnimator = GetComponent<Animator>();

        isDead = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (moveSpots.Length == 0)
            return;

        transform.position = Vector2.MoveTowards(transform.position, moveSpots[randomSpot].position, moveSpeed * Time.deltaTime);

        if(!isDead)
            skeletonAnimator.SetBool("IsMoving", isMoving);

        if(moveSpots[randomSpot].position.x < transform.position.x)
        {
            skeletonAnimator.SetFloat("MoveX", -1f);
            skeletonAnimator.SetFloat("LastMoveX", -1f);
            skeletonAnimator.SetFloat("LastMoveY", 0f);
        }

        if(moveSpots[randomSpot].position.x > transform.position.x)
        {
            skeletonAnimator.SetFloat("MoveX", 1f);
            skeletonAnimator.SetFloat("LastMoveX", 1f);
            skeletonAnimator.SetFloat("LastMoveY", 0f);
        }

        if (moveSpots[randomSpot].position.y < transform.position.y)
        {
            skeletonAnimator.SetFloat("MoveY", -1f);
            skeletonAnimator.SetFloat("LastMoveX", 0f);
            skeletonAnimator.SetFloat("LastMoveY", -1f);
        }

        if (moveSpots[randomSpot].position.y > transform.position.y)
        {
            skeletonAnimator.SetFloat("MoveY", 1f);
            skeletonAnimator.SetFloat("LastMoveX", 0f);
            skeletonAnimator.SetFloat("LastMoveY", 1f);
        }

        if (Vector2.Distance(transform.position, moveSpots[randomSpot].position) < 0.2f)
        {
            if (waitTime <= 0)
            {
                randomSpot = Random.Range(0, moveSpots.Length);
                waitTime = startWaitTime;
                isMoving = true;
            }
            else
            {
                waitTime -= Time.deltaTime;
                isMoving = false;
            }
        }

        if (reloading)
        {
            waitToReload -= Time.deltaTime;

            if (waitToReload < 0)
            {
                SceneManager.LoadScene(Application.loadedLevelName);
                player.SetActive(true);
            }
        }

        CheckDoorTransition(); // Checks if the door can be opened
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name == "GirlPlayer")
        {
            other.gameObject.SetActive(false);
            reloading = true;
            player = other.gameObject;
        }
    }

    private void CheckDoorTransition()
    {
        GameObject[] skeletons = GameObject.FindGameObjectsWithTag("Skeleton");
        if (skeletons.Length == 1)
        {
            GameObject door = GameObject.Find("Door 1");
            door.GetComponent<LoadNewArea>().ReadyToLoad();
        }
    }
}
