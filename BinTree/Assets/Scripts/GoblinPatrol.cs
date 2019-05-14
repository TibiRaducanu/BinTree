using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoblinPatrol : MonoBehaviour
{
    public Transform targetPosition;
    public float chaseRadius;
    public float attackRadius;
    public Transform homePosition;
    private Animator goblinAnimator;
    private Rigidbody2D goblinRigidBody;
    public float starCoolDown;
    private float starCoolDownCounter;
    public Transform firePoint;
    public Transform firePoint2;
    public GameObject star;
    public float moveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        targetPosition = FindObjectOfType<PlayerController>().transform;
        goblinAnimator = GetComponent<Animator>();
        goblinRigidBody = GetComponent<Rigidbody2D>();
        starCoolDownCounter = starCoolDown;
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(targetPosition.position, transform.position) <= chaseRadius && Vector3.Distance(targetPosition.position, transform.position) > attackRadius)
        {
            goblinAnimator.SetBool("IsMoving", true);
            Vector3 aux = Vector3.MoveTowards(transform.position, targetPosition.position, moveSpeed * Time.deltaTime);
            ChangeAnim(aux - transform.position);

            if(starCoolDownCounter < 0f)
            {
                starCoolDownCounter = -1f;
            }
            else
            {
                starCoolDownCounter -= Time.deltaTime;
            }

            if(starCoolDownCounter < 0f)
            {
                float moveDirection = goblinAnimator.GetFloat("MoveX");
                if (moveDirection > 0f)
                {
                    Instantiate(star, firePoint.position, firePoint.rotation);
                }
                else /// The star direction changes when the enemy changes his position to the left
                {
                    GameObject auxStar = Instantiate(star, firePoint2.position, firePoint2.rotation);
                    auxStar.GetComponent<EnemyStarController>().ChangeStarDirection();
                }
                starCoolDownCounter = starCoolDown;
            }

            goblinRigidBody.MovePosition(aux);
        }
        else
        {
            goblinAnimator.SetBool("IsMoving", false);
        }

        CheckDoorTransition(); // Checks if the door can be opened
    }

    private void SetAnimFloat(Vector2 setVector)
    {
        goblinAnimator.SetFloat("MoveX", setVector.x);
        goblinAnimator.SetFloat("MoveY", setVector.y);
    }

    private void ChangeAnim(Vector2 direction)
    {
        if(Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
        {
            if(direction.x > 0f)
            {
                SetAnimFloat(Vector2.right);
            }
            else if(direction.x < 0f)
            {
                SetAnimFloat(Vector2.left);
            }
        }
        else if(Mathf.Abs(direction.x) < Mathf.Abs(direction.y))
        {
            if(direction.y > 0f)
            {
                SetAnimFloat(Vector2.up);
            }
            else if(direction.y < 0f)
            {
                SetAnimFloat(Vector2.down);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(Application.loadedLevelName);
        }
    }

    private void CheckDoorTransition()
    {
        GameObject[] goblins = GameObject.FindGameObjectsWithTag("Goblin");
        if(goblins.Length == 1)
        {
            GameObject door = GameObject.Find("Door 1");
            door.GetComponent<LoadNewArea>().ReadyToLoad();
        }
    }
}
