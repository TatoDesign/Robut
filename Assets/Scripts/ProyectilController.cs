using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProyectilController : MonoBehaviour
{
    private Rigidbody rb;
    public float velocidadInicial = 10f; // Velocidad inicial del proyectil
    public float gravedad = -9.81f; // Gravedad (puedes ajustarla según tus necesidades)

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        if (rb == null)
        {
            Debug.LogError("El GameObject del proyectil no tiene un componente Rigidbody.");
        }
    }

    void FixedUpdate()
    {
        // Aplicar la gravedad al proyectil
        rb.AddForce(Vector3.up * gravedad, ForceMode.Acceleration);
    }
}


