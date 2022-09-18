using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragController : MonoBehaviour
{
    public float bobTimer;
    public bool canBeMoved;
    public GameObject referenceTower;
    public int i, j;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = WorldGrid.gridCellList[i, j].worldPosition;
        canBeMoved = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
