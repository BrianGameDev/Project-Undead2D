using UnityEngine;
using System.Collections;

public class MoveForward : MonoBehaviour {

    float maxSpeed = 16f;
    Animator PlayerAnimator;

    // Use this for initialization
    void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        Vector3 pos = transform.position;

        Vector3 velocity = new Vector3(0, maxSpeed * Time.deltaTime);

        pos += transform.rotation * velocity;

        transform.position = pos;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Wall")
        {
            Destroy(gameObject);
        }
    }
}
