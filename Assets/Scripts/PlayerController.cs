using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float velocidad = 1f; // Velocidad de movimiento del cilindro


    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
      if( UIcontroller.playerCanMove== true)
        {
            // Movimiento relativo al objeto
            float movimientoHorizontal = Input.GetAxis("Horizontal");
            float movimientoVertical = Input.GetAxis("Vertical");

            Vector3 movimiento = new Vector3(movimientoHorizontal, 0, movimientoVertical) * velocidad * Time.fixedDeltaTime;
            rb.MovePosition(transform.position + (transform.rotation * movimiento));
        }
        
            

    }

}
