using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayerEnemy : MonoBehaviour
{
    private GameObject followTarget;
    private Vector3 targetPos;
    public float moveSpeed;
    public float biteSpeed;
    public float distToBite;
    // Start is called before the first frame update
    void Start()
    {
        followTarget = GameObject.FindGameObjectsWithTag("Player")[0];
        targetPos = new Vector3(followTarget.transform.position.x, followTarget.transform.position.y, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        targetPos.x = followTarget.transform.position.x;
        targetPos.y = followTarget.transform.position.y;
        targetPos.z = transform.position.z;
        float distance = Vector3.Distance(targetPos, transform.position);
        if (distance < distToBite) transform.position = Vector3.Lerp(transform.position, targetPos, biteSpeed * moveSpeed * Time.deltaTime);
        else transform.position = Vector3.Lerp(transform.position, targetPos, moveSpeed * Time.deltaTime);
    }
}
