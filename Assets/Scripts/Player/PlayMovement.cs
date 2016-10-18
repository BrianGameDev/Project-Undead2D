using UnityEngine;
using System.Collections;

public class PlayMovement : MonoBehaviour
{

    public float maxSpeed = 2f;
    Animator playerAnimator;
    Rigidbody2D playerBody;

    // Use this for initialization
    void Start()
    {
        playerAnimator = GetComponent<Animator>();
        playerBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<PlayerShoot>().isPlayerShooting)
        {
            maxSpeed = 0;
        }
        else
        {
            maxSpeed = 2;
        }

        GetPlayerDirection();
    }

    void FixedUpdate()
    {
        var movementVector = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        playerBody.MovePosition(playerBody.position + movementVector * maxSpeed * Time.fixedDeltaTime);

    }

    void GetPlayerDirection()
    {
        var movementVector = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        if(GetComponent<PlayerShoot>().isPlayerShooting == false)
        {
            if (movementVector == Vector2.zero)
            {
                playerAnimator.SetBool("isWalking", false);
            }
            else
            {
                playerAnimator.SetBool("isWalking", true);
                playerAnimator.SetFloat("MoveX", movementVector.x);
                playerAnimator.SetFloat("MoveY", movementVector.y);
            }
        }
        else
        {
            playerAnimator.SetBool("isWalking", false);
        }
    }
}