using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootTower : MonoBehaviour
{
    public Transform projSpawnPoint;
    public int atkTime;
    public SphereCollider atkArea;
    private GameObject target;
    private int timer;
    public GameObject projPrefab;
    public bool isFast; //TODO
    
    // Start is called before the first frame update
    void Start()
    {
        timer = atkTime;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        timer--;
        print(target);

        if (timer <= 0 && target != null)
        {
            fireProjectile();
            timer = atkTime;
        }
        
    }

    private void OnTriggerStay(Collider collision)
    {
        if (target == null)
        {
            target = collision.gameObject;
        }  
    }

    private void fireProjectile()
    {
        // target.receiveDamage
        GameObject projInstance = Instantiate(projPrefab);
        projInstance.GetComponent<projectileScript>().target = target.transform;
        print("fireProjectile");
    }

}
