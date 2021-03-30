using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    float health = 20f;
    float damage = 10f;
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
      if (collision.tag=="Player")
        {
            DM.playerdamage(damage);
        }
    }
    public void enemyhealth(float damage)
    {
        health = health - damage;
        if(health<=0)
        {
            Destroy(gameObject);
        }
    }
}
