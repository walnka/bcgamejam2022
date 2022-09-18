using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMaterilHandles : MonoBehaviour
{
    // Start is called before the first frame update
    public Material[] materialList;
    public int switchTime;
    public GameObject enemyVisuals;
    private int timer;
    private int maxMaterialIndex;
    private int i;

    void Start()
    {
        timer = switchTime;
        i = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        timer--;
        if (timer <= 0)
        {
            shuffleMaterial();
            timer = switchTime;
        }
        bounce();

    }

    private void shuffleMaterial()
    {
        if (i >= materialList.Length)
        {
            i = -1;
        }
        i++;
        enemyVisuals.GetComponent<Renderer>().material = materialList[i];
    }

    private void bounce()
    {

    }
}
