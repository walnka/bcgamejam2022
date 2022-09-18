using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    public GameObject[] spawnEnemies;
    //public int[] spawnProbabilities;
    public float spawnTimer;
    float timer;
    public Vector2Int gridPos;
    public int spawnLimit;
    GridCell currentCell;
    // Start is called before the first frame update
    void Start()
    {
        timer = 0f;
        currentCell = WorldGrid.gridCellList[gridPos.x, gridPos.y];
        transform.position = currentCell.worldPosition;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        timer -= Time.deltaTime;
        if(timer <= 0f)
        {
            Spawn();
            timer = spawnTimer;
        }
    }

    void Spawn()
    {
        if (spawnLimit <= 0)
            return;
        int spawnIdx = Random.Range(0, spawnEnemies.Length);
        int i = Random.Range(gridPos.x - 1, gridPos.x + 2);
        int j = Random.Range(gridPos.y - 1, gridPos.y + 2);
        while (!CheckValidSpawnPoint(i, j))
        {
            i = Random.Range(gridPos.x - 1, gridPos.x + 2);
            j = Random.Range(gridPos.y - 1, gridPos.y + 2);
        }

        GridCell targetcell = WorldGrid.gridCellList[i, j];
        Instantiate(spawnEnemies[spawnIdx], targetcell.worldPosition, Quaternion.identity).SetActive(true);
        spawnLimit--;
    }

    bool CheckValidSpawnPoint(int i, int j)
    {
        if (i < 0 || j < 0)
            return false;
        if (i >= WorldGrid.numCells.x || j >= WorldGrid.numCells.y)
            return false;
        return !WorldGrid.gridCellList[i, j].occupied;
    }
}
