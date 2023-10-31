using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public float force = 10f;
    public float upwardForce = 2f;
    private Rigidbody rb;
    private float lunarGravity = -1.62f; // Aproximadamente 1/6 de la gravedad terrestre
    private float lanzamiento = 0f;
    private float timeAtRest = 0f;

    AudioSource audio1;

    [SerializeField] AudioClip pelota;
    [SerializeField] AudioClip ladrido;
    [SerializeField] AudioClip lanzar;

    void Start()
    {

        rb = GetComponent<Rigidbody>();
        audio1 = GetComponent<AudioSource>();

        if (rb == null)
        {
            Debug.LogError("No se encontr� un componente Rigidbody en este objeto. Por favor, a�ade uno.");
        }
        InvokeRepeating("Repetir", 0, 5f);
    }

    void FixedUpdate()
    {
        // Aplica la gravedad lunar
        rb.AddForce(0, lunarGravity * rb.mass, 0);
    }

    void Repetir()
    {
        lanzamiento = 0f;
    }

    bool IsInCameraView()
    {
        Vector3 viewPos = Camera.main.WorldToViewportPoint(transform.position);
        return viewPos.x >= 0 && viewPos.x <= 1 && viewPos.y >= 0 && viewPos.y <= 1 && viewPos.z > 0;
        audio1.PlayOneShot(pelota);
    }

    void Update()
    {
        Renderer rend = GetComponent<Renderer>();
        if (rb.velocity.magnitude < 1)
        {
            timeAtRest += Time.deltaTime;
        }
        else
        {
            timeAtRest = 0;
        }
        if (lanzamiento == 1)
        {
            // rend.material.color = Color.white;
        }

        // Agrega una condici�n para verificar si el objeto con el tag "RobotTag" est� a menos de 10 unidades de distancia
        GameObject robut = GameObject.FindGameObjectWithTag("RobutTag");
        if (robut != null && Vector3.Distance(transform.position, robut.transform.position) < 10f)
        {
            
            if (timeAtRest > 2 && IsInCameraView() && lanzamiento < 1f)
            {

                if (lanzamiento < 1f)
                {
                    rend.material.color = Color.blue;
                }
               
            }
        }
            
            
    }
}

