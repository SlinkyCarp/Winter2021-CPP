using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMovement))] 

public class PlayerCollision : MonoBehaviour
{

    Rigidbody2D rb;
    PlayerMovement pm;

    public float bounceForce;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        pm = GetComponent<PlayerMovement>();

        if(bounceForce <=0)
        {
            bounceForce = 100.0f;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Squished")
        {
            if (pm.isGrounded == false)
            {
                collision.gameObject.GetComponentInParent<EnemyWalker>().isSquished();
                rb.velocity = Vector2.zero;
                rb.AddForce(Vector2.up* bounceForce);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}