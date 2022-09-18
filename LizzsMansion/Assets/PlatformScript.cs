using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformScript : MonoBehaviour
{
    // Start is called before the first frame update
    public int lifetime;
    private int timer;
    public float damage;
    public bool isWet;
    public bool isFire;
    public int atkTime;

    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        timer--;
        lifetime--;
        checkLifetime();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.GetComponent<EnemyController>() != null && timer <= 0)
        {
            timer = atkTime;
            other.gameObject.GetComponent<EnemyController>().receiveDamage(damage, isWet, isFire);
        }
    }
    
    private void checkLifetime()
    {
        if (lifetime <= 0)
        {
            Destroy(gameObject);
        }
    }
}
