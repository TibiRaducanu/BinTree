using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarController : MonoBehaviour
{
    public float moveSpeed;
    private Rigidbody2D starRigidBody;
    private PlayerController player;

    // Start is called before the first frame update
    void Start()
    {
        starRigidBody = GetComponent<Rigidbody2D>();
        player = FindObjectOfType<PlayerController>();

        if(player.lastMove.x < 0f)
        {
            moveSpeed = -moveSpeed;
        }
    }

    // Update is called once per frame
    void Update()
    {
        starRigidBody.velocity = new Vector2(moveSpeed, starRigidBody.velocity.y);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            Destroy(other.gameObject);
        }

        if (other.tag == "Boss")
        {
            GameObject boss = other.gameObject;
            boss.GetComponent<SpawnAnnoyingEnemy>().DecreaseHealth();
            if(boss.GetComponent<SpawnAnnoyingEnemy>().health < 0.001f)
            {
                Destroy(other.gameObject);
            }
        }

        if (other.tag == "Skeleton")
        {
            other.GetComponent<Animator>().SetBool("IsDead", true);
            other.GetComponent<Animator>().SetBool("IsMoving", false);
            Destroy(other.gameObject, 0.7f);
        }

        Destroy(gameObject);
    }
}
