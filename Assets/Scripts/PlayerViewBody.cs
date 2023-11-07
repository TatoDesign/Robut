using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerViewBody : MonoBehaviour
{
    public float velocidadRotacion = 2.0f;
    private bool isGrabbing = false;
    private Rigidbody grabbedObject = null;

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X");
     

        Vector3 currentRotation = transform.rotation.eulerAngles;
        currentRotation.z = 0;
        transform.rotation = Quaternion.Euler(currentRotation);

        transform.Rotate(Vector3.up * mouseX * 2 * velocidadRotacion);

    }
}


