using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridController : MonoBehaviour
{
    #region Serialized fields
    [SerializeField] GameObject testObj;
    [SerializeField] int numXCells, numYCells, sizeX, sizeY;
    #endregion

    #region Public Vars
    public GridCell[,] gridCellList;
    #endregion


    // Start is called before the first frame update
    void Start()
    {
        gridCellList = new GridCell[numXCells, numYCells];
        InitializeGrid();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void InitializeGrid()
    {
        for(int i = 0; i < numXCells; i++)
        {
            for(int j = 0; j < numYCells; j++)
            {
                gridCellList[i, j] = new GridCell(sizeX*i, sizeY*i, sizeX, sizeY);
                Instantiate(testObj, 
                    new Vector3(sizeX*i, 0, sizeY*j), 
                    Quaternion.identity).SetActive(true);
            }
        }
    }
}

public class GridCell
{
    int x, y, xSize, ySize;
    bool canMove;
    public GridCell(int x, int y, int xSize, int ySize)
    {
        this.x = x;
        this.y = y;
        this.xSize = xSize;
        this.ySize = ySize;
        canMove = true;
    }
}
