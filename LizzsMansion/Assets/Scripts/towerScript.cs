using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class towerScript : MonoBehaviour
{
    public float health;
    public bool asBuff;
    public bool dmBuff;
    public int attackRadius;
   // public AllTowars allTowers;
    public GridCell cellPt { get; set; }
    public List<GridCell> occupiedGridCells { get; set; }


    // Start is called before the first frame update
    void Start()
    {
        occupiedGridCells = new List<GridCell>();
        cellPt = WorldGrid.GetClosestGrid(transform.position.x, transform.position.z);
        transform.position = cellPt.worldPosition;
        cellPt.occupied = true;
        GetComponent<SphereCollider>().radius = attackRadius;
    }

    // Update is called once per frame
    void FixedUpdate()
    {

    }

    public void receiveDamage(float damageAmout)
    {
        print("Tower damage " + damageAmout);
        health -= damageAmout;
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
        foreach(GridCell cell in occupiedGridCells)
        {
            cell.occupied = false;
        }
        Destroy(gameObject);
    }
}
