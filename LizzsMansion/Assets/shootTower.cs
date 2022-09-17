using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootTower : MonoBehaviour
{
    public Transform projSpawnPoint;
    public int fireRate;
    public SphereCollider atkArea;
    private GameObject target;
    private int timer;
    
    // Start is called before the first frame update
    void Start()
    {
        timer = fireRate;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        timer--;
        if (timer <= 0)
        {
            fireProjectile();
            timer = fireRate;
        }
        
    }

    private void OnCollisionStay(Collision collision)
    {
        if (target == null)
        {
            target = collision.gameObject;
        }  
    }

    private void fireProjectile()
    {
        // target.receiveDamage();
        print("fireProjectile");
    }

}
