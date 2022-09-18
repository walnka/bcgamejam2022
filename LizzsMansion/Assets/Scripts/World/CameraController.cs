using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] float rotateSpeed, moveSpeed;
    
    public float cameraAngle, cameraZoomFactor;

    public float zoomLowerBound { get; set; }
    public float zoomUpperBound { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float vertical = Input.GetAxisRaw("Vertical");
        float horizontal = Input.GetAxisRaw("Horizontal");

        transform.RotateAround(WorldGrid.centerPoint, Vector3.up,
            horizontal * rotateSpeed);

        Vector3 grid2Camera = transform.position - WorldGrid.centerPoint;
        Vector3 newPos = transform.position + grid2Camera.normalized * vertical * moveSpeed; 

        if(vertical < 0 && newPos.magnitude > zoomLowerBound + moveSpeed)
        {
            transform.position = transform.position + grid2Camera.normalized * vertical * moveSpeed;
        }
        else if(vertical > 0 && newPos.magnitude < zoomUpperBound - moveSpeed)
        {
            transform.position = transform.position + grid2Camera.normalized * vertical * moveSpeed;
        }
        
    }
}
