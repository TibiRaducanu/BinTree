using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class EnemyStarController : MonoBehaviour
{
    public float moveSpeed;
    private Rigidbody2D enemyStaRigidBody;

    // Start is called before the first frame update
    void Start()
    {
        enemyStaRigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        enemyStaRigidBody.velocity = new Vector2(moveSpeed, enemyStaRigidBody.velocity.y);
    }

    public void ChangeStarDirection()
    {
        moveSpeed *= -1f;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            SceneManager.LoadScene(Application.loadedLevelName);
        }

        Destroy(gameObject);
    }
}
