using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] float speed;
    Camera minimap;

    // Start is called before the first frame update
    void Start()
    {
        minimap = GetComponent<Camera>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float vertical = Input.GetAxisRaw("Vertical");
        transform.position = new Vector3(transform.position.x, 
            transform.position.y + vertical * speed,
            transform.position.z);
        transform.RotateAround(WorldGrid.centerPoint, Vector3.up,
            Input.GetAxisRaw("Horizontal"));
    }
}
