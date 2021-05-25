using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float health = 20f;
    [SerializeField] float damage = 10f;
    Damagemanager DM;
    // Start is called before the first frame update
    void Start()
    {
        DM = GetComponent<Damagemanager>();
    }

    // Update is called once per frame
    void Update()
    {

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

    public void enemyhealth(float damage)
    {
        health = health - damage;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}

