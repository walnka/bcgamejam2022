using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceSpawnController : MonoBehaviour
{
    public float lowerSpawnTimer, upperSpawnTimer;
    float timer;
    public GameObject[] DroppableList;

    // Start is called before the first frame update
    void Start()
    {
        timer = 0f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        timer -= Time.deltaTime;
        if(timer <= 0f)
        {
            Spawn();
            timer = Random.Range(lowerSpawnTimer, upperSpawnTimer + 1f);
        }
    }

    void Spawn()
    {
        int i = Random.Range(0, WorldGrid.numCells.x);
        int j = Random.Range(0, WorldGrid.numCells.y);

        while (WorldGrid.gridCellList[i, j].occupied)
        {
            i = Random.Range(0, WorldGrid.numCells.x);
            j = Random.Range(0, WorldGrid.numCells.y);
        }

        DragController dc = Instantiate(DroppableList[Random.Range(0, DroppableList.Length)]).GetComponent<DragController>();
        dc.i = i;
        dc.j = j;
        dc.gameObject.SetActive(true);
        dc.Intialize();
    }
}
