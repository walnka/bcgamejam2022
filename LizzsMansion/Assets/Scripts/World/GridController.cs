using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridController : MonoBehaviour
{
    #region Serialized fields
    [SerializeField] GameObject testObj;
    [SerializeField] int numXCells, numYCells;
    [SerializeField] float sizeX, sizeY, cameraDistance;
    [SerializeField] CameraController camControl;
    #endregion

    #region Public Vars
    public GridCell[,] gridCellList;
    public GameObject cameraObj;
    #endregion

    #region Private Vars
    Vector3 gridCenter;
    #endregion


    // Start is called before the first frame update
    void Awake()
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
        WorldGrid.gridCellDict = new Dictionary<GameObject, GridCell>();
        for (int i = 0; i < numXCells; i++)
        {
            for (int j = 0; j < numYCells; j++)
            {
                GridCell gc = new GridCell(sizeX * i, sizeY * j, sizeX, sizeY, i, j);
                gridCellList[i, j] = gc;
                GameObject gridCellObj = Instantiate(testObj,
                    new Vector3(sizeX * i, -0.5f, sizeY * j),
                    Quaternion.identity);
                gridCellObj.SetActive(true);
                WorldGrid.gridCellDict.Add(gridCellObj, gc);
            }
        }

        WorldGrid.Initialize(gridCellList, numXCells, numYCells);
        //Instantiate(testObj,
         //   new Vector3(WorldGrid.centerPoint.x,
         //   WorldGrid.centerPoint.y + 3,
         //   WorldGrid.centerPoint.z), Quaternion.identity).SetActive(true);

        float camX = gridCellList[numXCells - 1, 0].worldPosition.x / 2.0f;
        float camZ = numYCells * sizeY * cameraDistance;
        float camY = camZ * Mathf.Tan(Mathf.Deg2Rad * camControl.cameraAngle);
        cameraObj.transform.position = new Vector3(camX, camY, camZ);
        camControl.zoomLowerBound = new Vector2(camZ, camY).magnitude / camControl.cameraZoomFactor;
        camControl.zoomUpperBound = new Vector2(camZ, camY).magnitude * camControl.cameraZoomFactor;
    }
}

public class GridCell
{
    //public float x, y, xSize, ySize;
    public Vector3 worldPosition;
    public Vector2 size;
    public Vector2Int listPosition;
    public bool occupied;
    public GridCell(float x, float y, float xSize, float ySize, int i, int j)
    {
        worldPosition = new Vector3(x, 0, y);
        size = new Vector2(xSize, ySize);
        listPosition = new Vector2Int(i, j);
        occupied = false;
    }
}

public static class WorldGrid
{
    public static Vector2 gridSize;
    public static GridCell[,] gridCellList;
    public static Dictionary<GameObject, GridCell> gridCellDict;
    public static Vector2 numCells;
    public static Vector2 cellSize;
    public static Vector3 centerPoint;

    public static void Initialize(GridCell[,] gridCellList, int numXCells, int numYCells)
    {
        WorldGrid.gridCellList = gridCellList;

        numCells = new Vector2Int(numXCells, numYCells);

        cellSize = gridCellList[0, 0].size;

        centerPoint = new Vector3((numXCells) * cellSize.x / 2.0f,
           0, 
           (numYCells) * WorldGrid.cellSize.y / 2.0f);

        gridSize = new Vector2((numXCells) * cellSize.x,
            (numYCells) * cellSize.y);
    }

    public static Vector3 GetMouseToWorldPos()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            if (hit.transform.gameObject.tag == "Hittable")
                return hit.point;
            else
                return Vector3.zero;
        }
        else
        {
            return Vector3.zero;
        }
    }

    public static GridCell GetGridSnap(Vector3 currentPos)
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            if (hit.transform.gameObject.tag == "Hittable")
            {
                Debug.Log(hit.transform.gameObject);
                if (hit.transform.gameObject.GetComponent<towerScript>())
                {
                    return hit.transform.gameObject.GetComponent<towerScript>().cellPt;
                }
                return gridCellDict[hit.transform.gameObject];
            }
            else
                return null;
        }
        else
        {
            return null;
        }
    }

    public static GridCell GetClosestGrid(float x, float y)
    {
        int i = Mathf.FloorToInt(Mathf.Clamp(x / cellSize.x, 0, numCells.x-1));
        int j = Mathf.FloorToInt(Mathf.Clamp(y / cellSize.y, 0, numCells.y-1));
        return gridCellList[i, j];
    }
}
