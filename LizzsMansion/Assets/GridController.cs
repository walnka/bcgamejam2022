using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridController : MonoBehaviour
{
    #region Serialized fields
    [SerializeField] GameObject testObj;
    [SerializeField] int numXCells, numYCells;
    [SerializeField] float sizeX, sizeY;
    #endregion

    #region Public Vars
    public GridCell[,] gridCellList;
    public GameObject cameraObj;
    #endregion

    #region Private Vars
    Vector3 gridCenter;
    #endregion


    // Start is called before the first frame update
    void Start()
    {
        gridCellList = new GridCell[numXCells, numYCells];
        InitializeGrid();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }

    void InitializeGrid()
    {
        for (int i = 0; i < numXCells; i++)
        {
            for (int j = 0; j < numYCells; j++)
            {
                gridCellList[i, j] = new GridCell(sizeX * i, sizeY * i, sizeX, sizeY);
                Instantiate(testObj,
                    new Vector3(sizeX * i, 0, sizeY * j),
                    Quaternion.identity).SetActive(true);
            }
        }
        WorldGrid.Initialize(gridCellList, numXCells, numYCells);
        Instantiate(testObj,
            new Vector3(WorldGrid.centerPoint.x,
            WorldGrid.centerPoint.y + 3,
            WorldGrid.centerPoint.z), Quaternion.identity).SetActive(true);

        float camX = gridCellList[numXCells - 1, 0].x / 2.0f;
        float camZ = numYCells * sizeY * 1.5f;
        cameraObj.transform.position = new Vector3(camX, 10, camZ);
    }
}

public class GridCell
{
    public float x, y, xSize, ySize;
    public bool canMove;
    public GridCell(float x, float y, float xSize, float ySize)
    {
        this.x = x;
        this.y = y;
        this.xSize = xSize;
        this.ySize = ySize;
        canMove = true;
    }
}

public static class WorldGrid
{
    public static Vector2 gridSize;
    public static GridCell[,] gridCellList;
    public static Vector2 numCells;
    public static Vector2 cellSize;
    public static Vector3 centerPoint;

    public static void Initialize(GridCell[,] gridCellList, int numXCells, int numYCells)
    {
        WorldGrid.gridCellList = gridCellList;
        WorldGrid.numCells = new Vector2Int(numXCells, numYCells);
        WorldGrid.cellSize = new Vector2(gridCellList[0, 0].xSize, gridCellList[0, 0].ySize);
        WorldGrid.centerPoint = new Vector3((numXCells) * WorldGrid.cellSize.x / 2.0f,
           0, 
           (numYCells) * WorldGrid.cellSize.y / 2.0f);
        WorldGrid.gridSize = new Vector2((numXCells) * WorldGrid.cellSize.x,
            (numYCells) * WorldGrid.cellSize.y);

        
    }
}
