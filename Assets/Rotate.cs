using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public float rotationspeed;
    bool isdragging = false;
    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void OnMouseDrag()
    {
        isdragging = true;
    }

    private void Update()
    {
        if(Input.GetMouseButtonUp(0))
        {
            isdragging = false;
        }
    }

    private void FixedUpdate()
    {
        if (isdragging)
        {
            float x = Input.GetAxis("Mouse X") * rotationspeed * Time.fixedDeltaTime;
            float y = Input.GetAxis("Mouse Y") * rotationspeed * Time.fixedDeltaTime;

            transform.Rotate(Vector3.down * x);
            //rb.AddTorque(Vector3.down * x, ForceMode.Impulse);
            //rb.AddTorque(Vector3.right * y, ForceMode.Impulse);
        }
       
    }
}
