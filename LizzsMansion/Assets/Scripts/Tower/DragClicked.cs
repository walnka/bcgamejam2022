using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragClicked : StateMachineBehaviour
{
    DragController dc;
    GridCell curGc;
    MouseController mc;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        dc = animator.gameObject.GetComponent<DragController>();
        mc = dc.mouse;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        GridCell gc = WorldGrid.GetGridSnap(animator.gameObject.transform.position);
        
        if(gc != null) 
        {
            animator.gameObject.transform.position = gc.worldPosition;
            curGc = gc;
        }

        if (Input.GetMouseButtonDown(0))
        {
            //animator.SetBool("Clicked", false);
            if (!curGc.occupied)
            {
                GameObject tower = Instantiate(dc.referenceTower, 
                    animator.gameObject.transform.position, 
                    Quaternion.identity);
                tower.transform.GetChild(1).localScale = new Vector3(20, 20, 20);
                tower.tag = "Hittable";
                tower.SetActive(true);
                tower.transform.localScale *= dc.gridSize;
                towerScript ts = tower.GetComponent<towerScript>();
                Debug.Log(ts);
                ts.occupiedGridCells = new List<GridCell>();
                
                int occupiedCells = dc.gridSize % 2 == 0 ? dc.gridSize + 1 : dc.gridSize;
                for(int i = -occupiedCells / 2; i <= occupiedCells / 2; i++)
                {
                    for(int j = -occupiedCells / 2; j <= occupiedCells / 2; j++)
                    {
                        GridCell gcHold = WorldGrid.gridCellList[curGc.listPosition.x + i, curGc.listPosition.y + j];
                        gcHold.occupied = true;
                        ts.occupiedGridCells.Add(gcHold);
                    }
                }
                curGc.occupied = true;
                Destroy(dc);
                Destroy(animator.gameObject.GetComponent<SphereCollider>());
                Destroy(animator);
            }
            else if(mc.clickedTower != null)
            {
                Debug.Log("checking new tower");
                GameObject newtower = AllTowers.CheckCombination(mc.clickedTower, dc.referenceTower);
                Debug.Log(newtower);
                if (newtower != null)
                {
                    Destroy(mc.clickedTower);
                    GameObject tower = Instantiate(newtower,
                    animator.gameObject.transform.position,
                    Quaternion.identity);
                    tower.transform.GetChild(1).localScale = new Vector3(20, 20, 20);
                    tower.tag = "Hittable";
                    tower.SetActive(true);
                    tower.transform.localScale *= dc.gridSize;
                    towerScript ts = tower.GetComponent<towerScript>();
                    Debug.Log(ts);
                    ts.occupiedGridCells = new List<GridCell>();

                    int occupiedCells = dc.gridSize % 2 == 0 ? dc.gridSize + 1 : dc.gridSize;
                    for (int i = -occupiedCells / 2; i <= occupiedCells / 2; i++)
                    {
                        for (int j = -occupiedCells / 2; j <= occupiedCells / 2; j++)
                        {
                            GridCell gcHold = WorldGrid.gridCellList[curGc.listPosition.x + i, curGc.listPosition.y + j];
                            gcHold.occupied = true;
                            ts.occupiedGridCells.Add(gcHold);
                        }
                    }
                    curGc.occupied = true;
                    Destroy(dc);
                    Destroy(animator.gameObject.GetComponent<SphereCollider>());
                    Destroy(animator);
                }
            }
            
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
