using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseController : MonoBehaviour
{
    public GameObject clickedTower;
    int layermask;
    // Start is called before the first frame update
    void Start()
    {
        layermask = 1 << 0;
        //layermask = ~layermask;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit,Mathf.Infinity, layermask))
            {
                print("the raycast hit" + hit.transform.gameObject);
                if (hit.transform.gameObject.GetComponent<DragController>())
                {
                    if(hit.transform.gameObject.tag == "Hittable")
                    {
                        hit.transform.gameObject.tag = "Untagged";
                        hit.transform.gameObject.GetComponent<Animator>().SetBool("Clicked", true);
                    }
                }
                else if (hit.transform.gameObject.GetComponent<towerScript>())
                {
                    Debug.Log(hit.transform.gameObject);
                    if(hit.transform.gameObject.tag == "Hittable")
                    {
                        clickedTower = hit.transform.gameObject;
                    }
                }
            }
        }
    }
}
