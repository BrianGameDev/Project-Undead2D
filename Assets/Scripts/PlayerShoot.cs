using UnityEngine;
using System.Collections;

public class PlayerShoot : MonoBehaviour
{

    public GameObject bulletPrefab;
    Animator PlayerAnimator;

    public float fireDelay = 0.25f;
    public bool isPlayerShooting;
    float cooldownTimer = 0f;

    // Use this for initialization
    void Start()
    {
        PlayerAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        cooldownTimer -= Time.deltaTime;

        if(Input.GetButton("Fire1"))
        {
            if (Input.GetButton("Fire1") && cooldownTimer <= 0)
            {
                isPlayerShooting = true;

                cooldownTimer = fireDelay;
                if (PlayerAnimator.GetFloat("MoveX") == 1)
                {
                    Quaternion BulletRot = new Quaternion(0, 0, 270, -270);
                    Vector3 BulletPos = transform.rotation * new Vector3(0.4f, 0.19f, 0);
                    Instantiate(bulletPrefab, transform.position + BulletPos, BulletRot);
                }
                else if (PlayerAnimator.GetFloat("MoveX") == -1)
                {
                    Quaternion BulletRot = new Quaternion(0, 0, 90, 90);
                    Vector3 BulletPos = transform.rotation * new Vector3(-0.4f, 0.23f, 0);
                    Instantiate(bulletPrefab, transform.position + BulletPos, BulletRot);
                }
                else if (PlayerAnimator.GetFloat("MoveY") == 1)
                {
                    Quaternion BulletRot = new Quaternion(0, 0, 0, 0);
                    Vector3 BulletPos = transform.rotation * new Vector3(0.05f, 0.48f, 0);
                    Instantiate(bulletPrefab, transform.position + BulletPos, BulletRot);
                }
                else if (PlayerAnimator.GetFloat("MoveY") == -1)
                {
                    Quaternion BulletRot = new Quaternion(0, 0, 180, -0);
                    Vector3 BulletPos = transform.rotation * new Vector3(-0.075f, -0.22f, 0);
                    Instantiate(bulletPrefab, transform.position + BulletPos, BulletRot);
                }
            }

        }
        else
        {
            isPlayerShooting = false;
        }
    }
}
