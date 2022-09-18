using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectileScript : MonoBehaviour
{
    private Transform projPosition;
    public Transform target;
    public float speed;


    // Start is called before the first frame update
    void Start()
    {
        projPosition = gameObject.transform;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        Vector3 moveDirection = (target.position - projPosition.position).normalized;
        float distance = speed * Time.deltaTime;
        projPosition.transform.position = projPosition.position + moveDirection * distance;
        gameObject.transform.position = projPosition.transform.position;
    }

    private void OnTriggerEnter(Collider collision)
    {
        print("entered collision");
        if (collision.gameObject.GetComponent<EnemyController>() != null)
        {
            print("damage");
            Destroy(gameObject);
        }

    }

}   
