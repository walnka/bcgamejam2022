using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class towerScript : MonoBehaviour
{
    public float health;
    public bool asBuff;
    public bool dmBuff;
    public GridCell cellPt { get; set; }


    // Start is called before the first frame update
    void Start()
    {
        cellPt = WorldGrid.GetClosestGrid(transform.position.x, transform.position.z);
    }

    // Update is called once per frame
    void FixedUpdate()
    {

    }

    public void receiveDamage(float damageAmout)
    {
        health =- damageAmout;
        checkHealth();
    }

    private void checkHealth()
    {
        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
