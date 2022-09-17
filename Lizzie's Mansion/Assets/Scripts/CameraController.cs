using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();   
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");

        Debug.Log(string.Format("(dx, dy) -> ({0}, {1})", horizontal, vertical));

        transform.position = new Vector3(transform.position.x + horizontal, 
            transform.position.y,
            transform.position.z + vertical);
    }
}
