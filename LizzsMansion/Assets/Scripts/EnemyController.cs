using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    #region Public Vars
    public float health;
    public bool wet;
    public bool onFire;
    public float movespeed;
    public float msModifier;
    public GameObject lizzy;
    public float damage;
    public float atkTime;
    public float moveTime;
    public int attackRange;
    public float bounceForce;
    #endregion

    #region Private Vars
    float timer, walkTimer;
    GridCell curCell, targetCell;
    #endregion

    // Start is called before the first frame update

    private void Awake()
    {
        lizzy = GameObject.FindGameObjectWithTag("Lizzy"); //TODO add the object Lizzy
    }
    void Start()
    {
        wet = false;
        onFire = false;
        msModifier = 1;
        curCell = WorldGrid.GetClosestGrid(transform.position.x, transform.position.z);
        transform.position = curCell.worldPosition;
        targetCell = lizzy.GetComponent<towerScript>().cellPt;
        walkTimer = 0f;
        timer = 0f;
        GetComponent<SphereCollider>().radius = attackRange;
    }

    

    // Update is called once per frame
    void FixedUpdate()
    {
        // TODO: check if a better solution exist
        if (targetCell == null)
            targetCell = lizzy.GetComponent<towerScript>().cellPt;
        timer -= Time.deltaTime;
        //print(timer);

        if(walkTimer <= 0f)
        {
            transform.position = curCell.worldPosition;
            SelectMoveCell();
            GetComponent<Rigidbody>().AddForce(Vector3.up * bounceForce, ForceMode.Impulse);
            walkTimer = moveTime;
        }
        Move();
        walkTimer -= Time.deltaTime;
    }

    private void Move()
    {
        Vector3 moveDir = curCell.worldPosition - transform.position;
        moveDir.Normalize();
        transform.position = transform.position + moveDir * Time.deltaTime * movespeed;
    }

    private void SelectMoveCell()
    {
        print("enemy target " + targetCell);
        print("enemy cell " + curCell);
        int di = targetCell.listPosition.x - curCell.listPosition.x;
        int dj = targetCell.listPosition.y - curCell.listPosition.y;

        int targetI = curCell.listPosition.x;
        int targetJ = curCell.listPosition.y;
        if(Mathf.Max(di, dj) == 1f)
        {
            return;
        }
        if(di != 0f && dj != 0f)
        {
            if(Random.Range(0, 2) == 0)
            {
                targetI += (int)(di / Mathf.Abs(di)); 
            }
            else
            {
                targetJ += (int)(dj / Mathf.Abs(dj));
            }
        }
        else if(di != 0f)
        {
            targetI += (int)(di / Mathf.Abs(di));
        }
        else if(dj != 0f)
        {
            targetJ += (int)(dj / Mathf.Abs(dj));
        }
        if (WorldGrid.gridCellList[targetI, targetJ].occupied)
            return;
        curCell = WorldGrid.gridCellList[targetI, targetJ];
    }

    public void receiveDamage(float damageAmount, bool isWet, bool isFire)
    {
        health -= damageAmount;
        wet = isWet;
        onFire = isFire;
        if(health <= 0)
        {
            WorldGrid.RegisterDeath();
            Destroy(gameObject);
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.GetComponent<towerScript>() != null && timer <= 0 && other.GetType().Name != "SphereCollider")
        {
            //print(other.GetType().Name);
            print("enemy dot");
            timer = atkTime;
            other.gameObject.GetComponent<towerScript>().receiveDamage(damage);
        }
    }
}

struct PotentialStep
{
    public float point;
    public GridCell cellPt;
    
    public PotentialStep(GridCell cellPt, float distance, float movementPossibility)
    {
        this.cellPt = cellPt;
        this.point = distance + movementPossibility;
    }
}