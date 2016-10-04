using UnityEngine;
using System.Collections;

public class PlayMovement : MonoBehaviour
{

    public float maxSpeed;
    Animator PlayerAnimator;
    Rigidbody2D PlayerBody;

    // Use this for initialization
    void Start()
    {
        PlayerAnimator = GetComponent<Animator>();
        PlayerBody = GetComponent<Rigidbody2D>();
        maxSpeed = 2f;
    }

    // Update is called once per frame
    void Update()
    {
        if(GetComponent<PlayerShoot>().isPlayerShooting == true)
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
        Vector2 movement_vector = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        PlayerBody.MovePosition(PlayerBody.position + movement_vector * maxSpeed * Time.deltaTime);

    }

    void GetPlayerDirection()
    {

        Vector2 movement_vector = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        if(GetComponent<PlayerShoot>().isPlayerShooting == false)
        {
            if (movement_vector == Vector2.zero)
            {
                PlayerAnimator.SetBool("isWalking", false);
            }
            else
            {
                PlayerAnimator.SetBool("isWalking", true);
                PlayerAnimator.SetFloat("MoveX", movement_vector.x);
                PlayerAnimator.SetFloat("MoveY", movement_vector.y);
            }
        }
        else
        {
            PlayerAnimator.SetBool("isWalking", false);
        }
    }
}