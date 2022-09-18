using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    // Start is called before the first frame update
    public float health;
    public bool wet;
    public bool onFire;
    public float movespeed;
    public float msModifier;
    public GameObject lizzy;
    public float damage;
    public int atkTime;
    private int timer;

    void Start()
    {
        wet = false;
        onFire = false;
        msModifier = 1;
        lizzy = GameObject.FindGameObjectWithTag("Lizzy"); //TODO add the object Lizzy
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // enemy walking to the lizzy
        timer--;

    }

    public void receiveDamage(float damageAmount, bool isWet, bool isFire)
    {
        health -= damageAmount;
        wet = isWet;
        onFire = isFire;
        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerStay(Collider other)
    {
        
        if(other.gameObject.GetComponent<towerScript>() != null && timer <= 0)
        {
            print("enemy dot");

            timer = atkTime;
            other.gameObject.GetComponent<towerScript>().receiveDamage(damage);
        }
    }

}
