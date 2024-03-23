using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    Rigidbody2D rb;

    [SerializeField] float damageHorizontalImpulse;
    [SerializeField] float damageVerticalImpulse;

    [SerializeField] public int health;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Die();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy" && tag == "Player")
        {
            if ((transform.position.x - collision.collider.transform.position.x) < 0 && (transform.position.y - collision.collider.transform.position.y) < transform.localScale.y / 2)
            {
                health -= 1;
            }
            else if ((transform.position.x - collision.collider.transform.position.x) > 0 && (transform.position.y - collision.collider.transform.position.y) < transform.localScale.y / 2)
            {
                health -= 1;
            }
            else if ((transform.position.y - collision.collider.transform.position.y) < 0)
            {
                health -= 1;
            }
        }

        if (collision.gameObject.tag == "Player" && tag == "Enemy")
        {
            if ((collision.collider.transform.position.y - transform.position.y) > transform.localScale.y)
            {
                health -= 1;
            }
        }

        if (collision.gameObject.tag == "DeathTrigger")
        {
            health = 0;
        }
    }

    private void Die()
    {
        if (health <= 0 && this.tag != "Player")
        {
            Destroy(this.gameObject);
        }
        else if (health <= 0 && this.tag == "Player")
        {
            this.gameObject.GetComponent<Player>().RespawnPlayer();
            this.health = 3;
        }
    }
}
