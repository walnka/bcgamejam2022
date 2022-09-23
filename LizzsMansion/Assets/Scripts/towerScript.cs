using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class towerScript : MonoBehaviour
{
    public float health;
    public bool asBuff;
    public bool dmBuff;
    public int attackRadius;
    public float yLevel;
   // public AllTowars allTowers;
    public GridCell cellPt { get; set; }
    public List<GridCell> occupiedGridCells { get; set; }


    // Start is called before the first frame update
    void Start()
    {
        occupiedGridCells = new List<GridCell>();
        cellPt = WorldGrid.GetClosestGrid(transform.position.x, transform.position.z);
        transform.position = cellPt.worldPosition + new Vector3(0, yLevel, 0);
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
            if (GetComponent<LizzieDeath>())
            {
                gameObject.transform.GetChild(2).gameObject.SetActive(false);
                GetComponent<LizzieDeath>().BuckinghamPalace();
            }
            else
            {
                Die();
            }
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
