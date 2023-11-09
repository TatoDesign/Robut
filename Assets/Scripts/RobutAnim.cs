using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class RobutAnim : MonoBehaviour
{
    private Animator animator;
    private Rigidbody rb; // Variable para guardar el rigid body del objeto
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>(); // Obtiene el rigid body del objeto
    }

    // Update is called once per frame
    void Update()
    {
       // Asigna la magnitud de la velocidad del rigid body al parámetro Speed
    }
}
