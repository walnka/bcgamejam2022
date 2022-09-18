using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootTower : MonoBehaviour
{
    public Transform projSpawnPoint;
    public float atkTime;
    public SphereCollider atkArea;
    private GameObject target;
    private float timer;
    public GameObject projPrefab;
    public bool isFast; //TODO
    
    // Start is called before the first frame update
    void Start()
    {
        timer = 0f;
        target = null;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //timer--;
        //print(target);

        if (timer <= 0 && target != null)
        {
            fireProjectile();
            timer = atkTime;
        }
        
    }

    private void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.GetComponent<EnemyController>() && collision.GetType().Name != "SphereCollider")
        {
            print(collision.gameObject);
            if(target == null)
                target = collision.gameObject;
            print(target);
            timer -= Time.deltaTime;
            if(timer <= 0f)
            {
                fireProjectile();
                timer = atkTime;
            }
        }  
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == target)
        {
            target = null;
        }
    }

    private void fireProjectile()
    {
        // target.receiveDamage
        GameObject projInstance = Instantiate(projPrefab, projSpawnPoint.transform.parent.position, Quaternion.identity);
        projInstance.GetComponent<projectileScript>().target = target.transform;
        print("fireProjectile");
    }

}
