using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] Rigidbody2D rb;

    [SerializeField] float speed;
    [SerializeField] float jumpPower;
    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask GroundMask;

    [SerializeField] Collider2D ground;

    int direction = 1;

    bool isGrounded, isFacingRight = true;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        float groundLeftBound = ground.bounds.min.x;
        float groundRightBound = ground.bounds.max.x;

        if (transform.position.x >= groundRightBound - (transform.localScale.x / 2) && direction == 1 || transform.position.x <= groundLeftBound - (transform.localScale.x / 2) && direction == -1)
        {
            direction *= -1;
            speed *= -1;
        }

        Flip();
    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(speed, rb.velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground" || collision.gameObject.tag == "Spike")
        {
            direction *= -1;
            speed *= -1;
        }
    }

    private void Flip()
    {
        if (isFacingRight && speed < 0f || !isFacingRight && speed > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }


}
