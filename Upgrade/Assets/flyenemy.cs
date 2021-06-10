using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flyenemy : MonoBehaviour
{
    [SerializeField] float enemymovespeed = 5f;
    Rigidbody2D flyenemyRB;
    [SerializeField] float health = 20f;
    [SerializeField] float damage = 10f;
    Damagemanager DM;

    private Transform target;
    public bool enemyshouldfollow;
    // Start is called before the first frame update
    void Start()
    {
        flyenemyRB = GetComponent<Rigidbody2D>();
        this.target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();// this sets the object with the player tag to become the transform target
        //'this' is used to get a reference to the transform.target classallow the use of transform as a variable  
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyshouldfollow)
        {
            //flyenemy.setbool("isattack", enemyshouldfollow);
            this.transform.position = Vector2.MoveTowards(this.transform.position, this.target.position, this.enemymovespeed * Time.deltaTime);
            // this gets the enemy to move towards the target when the enemyshould follow is true

        }



    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Health>().ChangeHealth(-damage);
            //DM.playerdamage(damage);
            Debug.Log("Damage Player");
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            enemyshouldfollow = true;
    }
    public void enemyhealth(float damage)
    {
        health = health - damage;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}

