using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragController : MonoBehaviour
{
    public float bobTimer;
    public bool canBeMoved;
    public GameObject referenceTower;
    public int i, j;
    public int gridSize;
    public MouseController mouse;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = WorldGrid.gridCellList[i, j].worldPosition;
        canBeMoved = true;
        transform.GetChild(0).localScale *= gridSize;
    }

    public void Intialize()
    {
        Start();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
