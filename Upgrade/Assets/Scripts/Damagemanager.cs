using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damagemanager : MonoBehaviour
{
    PlayerManager PM;
    Health health;
    HeathDisplay HD;
    Enemy enemy;
    float reducedhealth;

    // Start is called before the first frame update
    void Start()
    {
        PM = GetComponent<PlayerManager>();
        health = GetComponent<Health>();
        HD = GetComponent<HeathDisplay>();
        enemy = GetComponent<Enemy>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void enemydamage(float damage)
    {
        enemy.enemyhealth(damage);
    }

}
