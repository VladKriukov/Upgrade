using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float health = 20f;
    [SerializeField] float damage = 10f;
    Damagemanager DM;
    Rigidbody2D enemyRB;
    [SerializeField] float enemywalkspeed = 3f;
    // Start is called before the first frame update
    void Start()
    {
        DM = GetComponent<Damagemanager>();
        enemyRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isfacingright())
        {
            enemyRB.velocity = new Vector2(enemywalkspeed, 0f);
        }
        else
        {
            enemyRB.velocity = new Vector2(-enemywalkspeed, 0f);
        }
    }

    private void OnCollisionHit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
           
            Debug.Log("Damage Player");
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag=="ground")
        {
            transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
        }
    }
    public void enemyhealth(float damage)
    {
        health = health - damage;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
    bool isfacingright()
    {
        return transform.localScale.x > 0;
    }
}

