using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseController : MonoBehaviour
{
    public GameObject clickedTower;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
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
