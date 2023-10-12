using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResorteraController2 : MonoBehaviour
{
    public GameObject proyectilPrefab1;
    public Transform puntoLanzamiento1;
    public float fuerzaLanzamiento1 = 10f;

    private MeshRenderer meshRenderer2;
    private bool isCharging;
    private float chargeStartTime;
    private Renderer objectRenderer;
    void Start()
    {
        objectRenderer = GetComponent<Renderer>();

        if (objectRenderer == null)
        {
            Debug.LogError("El objeto no tiene un componente Renderer.");
        }
        meshRenderer2 = GetComponent<MeshRenderer>();

        if (meshRenderer2 == null)
        {
            Debug.LogError("El GameObject no tiene un componente MeshRenderer.");
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            meshRenderer2.enabled = true;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            meshRenderer2.enabled = false;
        }

        if (meshRenderer2 != null && meshRenderer2.enabled)
        {
            
            if (Input.GetMouseButtonDown(0))
            {
                objectRenderer.material.color = Color.blue;
                Invoke("Listo", 1f);
                isCharging = true;
                chargeStartTime = Time.time;
            }
            else if (Input.GetMouseButtonUp(0) && isCharging)
            {

                if (Time.time - chargeStartTime >= 1f)
                {
                    objectRenderer.material.color = Color.white;
                    LanzarProyectil1();
                }
                isCharging = false;
            }
        }

        // Lanza un raycast para encontrar un punto en la dirección de mira
        if (meshRenderer2 != null && meshRenderer2.enabled)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit))
            {
                // Utiliza Debug.DrawLine para mostrar la línea en el modo juego
                Debug.DrawLine(transform.position, hit.point, Color.green);
            }
        }

        // Apunta el objeto hacia la posición del mouse
        ApuntarHaciaMouse();
    }

    void LanzarProyectil1()
    {
        GameObject proyectil = Instantiate(proyectilPrefab1, puntoLanzamiento1.position, Quaternion.identity);
        Rigidbody rb = proyectil.GetComponent<Rigidbody>();

        if (rb != null)
        {
            Vector3 direccionLanzamiento = transform.forward;
            rb.AddForce(direccionLanzamiento * fuerzaLanzamiento1, ForceMode.Impulse);
        }
    }
    public void Listo()
    {
        objectRenderer.material.color = Color.red;
    }
    void ApuntarHaciaMouse()
    {
        // Obtiene la posición del mouse en el mundo
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            // Apunta el objeto hacia la posición del mouse
            transform.LookAt(hit.point);
        }
    }
}
    