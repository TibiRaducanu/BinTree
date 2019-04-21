using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    private Animator playerAnimator;
    private Rigidbody2D playerRigidBody;
    private bool isMoving;
    public Vector2 lastMove;

    public Transform firePoint;
    public GameObject star;

    // Start is called before the first frame update
    void Start()
    {
        playerAnimator = GetComponent<Animator>();
        playerRigidBody = GetComponent<Rigidbody2D>();
        lastMove = new Vector2();
    }

    // Update is called once per frame
    void Update()
    {
        isMoving = false;

        if(Input.GetAxisRaw("Horizontal") > 0.5f || Input.GetAxisRaw("Horizontal") < -0.5)
        {
            playerRigidBody.velocity = new Vector3(Input.GetAxisRaw("Horizontal") * moveSpeed, 0f, 0f);
            isMoving = true;
            lastMove.x = Input.GetAxisRaw("Horizontal");
            lastMove.y = 0f;
        }

        if (Input.GetAxisRaw("Vertical") > 0.5f || Input.GetAxisRaw("Vertical") < -0.5f)
        {
            
            playerRigidBody.velocity = new Vector2(playerRigidBody.velocity.x, Input.GetAxisRaw("Vertical") * moveSpeed);
            isMoving = true;
            lastMove.x = 0f;
            lastMove.y = Input.GetAxisRaw("Vertical");
        }

        if (Input.GetAxisRaw("Horizontal") < 0.5f && Input.GetAxisRaw("Horizontal") > -0.5f)
        {
            playerRigidBody.velocity = new Vector2(0f, playerRigidBody.velocity.y);
        }

        if (Input.GetAxisRaw("Vertical") < 0.5f && Input.GetAxisRaw("Vertical") > -0.5f)
        {
            playerRigidBody.velocity = new Vector2(playerRigidBody.velocity.x, 0f);
        }

        playerAnimator.SetFloat("MoveX", Input.GetAxisRaw("Horizontal"));
        playerAnimator.SetFloat("MoveY", Input.GetAxisRaw("Vertical"));
        playerAnimator.SetBool("IsMoving", isMoving);
        playerAnimator.SetFloat("LastMoveX", lastMove.x);
        playerAnimator.SetFloat("LastMoveY", lastMove.y);


        if (Input.GetKeyDown(KeyCode.Return))
        {
            Instantiate(star, firePoint.position, firePoint.rotation);
        }
    }
}
