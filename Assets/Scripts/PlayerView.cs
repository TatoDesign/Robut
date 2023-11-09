using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerView : MonoBehaviour
{
    public float velocidadRotacion = 2.0f;
    private bool isGrabbing = false;
    private Rigidbody grabbedObject = null;
    private bool resorteraMano = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            resorteraMano = false;
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            resorteraMano = true;
        }
        float mouseY = Input.GetAxis("Mouse Y");

        Vector3 currentRotation = transform.rotation.eulerAngles;
        currentRotation.z = 0;
        transform.rotation = Quaternion.Euler(currentRotation);

        transform.Rotate(Vector3.left * mouseY * velocidadRotacion);
        if (resorteraMano == false)
            {
               


                // Raycast para ver si estamos apuntando a un objeto con el tag "BallTag" y está a una distancia menor que 2f
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit) && hit.collider.CompareTag("BallTag") && hit.distance < 2f)
                {
                    // Cambia el color del objeto a azul
                    Renderer renderer = hit.collider.GetComponent<Renderer>();
                    renderer.material.color = Color.blue;

                    // Detecta si el jugador hizo clic izquierdo
                    if (Input.GetMouseButtonDown(0))
                    {
                        // Comienza a agarrar el objeto
                        isGrabbing = true;
                        grabbedObject = hit.collider.GetComponent<Rigidbody>();

                    }
                }
                else
                {
                    // Si no estamos mirando un objeto con el tag "BallTag" o está a más de 2f, restaura su color original
                    GameObject ballObject = GameObject.FindGameObjectWithTag("BallTag");
                    Renderer renderer = ballObject.GetComponent<Renderer>();
                    renderer.material.color = Color.red;
                }
                if (isGrabbing == true)
                {
                    // Si no estamos mirando un objeto con el tag "BallTag" o está a más de 2f, restaura su color original
                    GameObject ballObject = GameObject.FindGameObjectWithTag("BallTag");
                    Renderer renderer = ballObject.GetComponent<Renderer>();
                    renderer.material.color = Color.red;
                }
                // Detecta si el jugador soltó el clic izquierdo
                if (Input.GetMouseButtonUp(0))
                {
                    // Deja de agarrar el objeto
                    isGrabbing = false;
                    grabbedObject = null;
                }

                // Si estamos sosteniendo un objeto, mueve el objeto con la posición del ratón y limita su distancia a 2f del jugador
                if (isGrabbing && grabbedObject != null)
                {
                    Vector3 mousePos = Input.mousePosition;
                    mousePos.z = Vector3.Distance(Camera.main.transform.position, grabbedObject.transform.position);
                    Vector3 worldPos = Camera.main.ScreenToWorldPoint(mousePos);

                    // Limitar la distancia
                    Vector3 playerToObj = worldPos - transform.position;
                    if (playerToObj.magnitude > 2f)
                    {
                        worldPos = transform.position + playerToObj.normalized * 2f;
                    }

                    grabbedObject.velocity = (worldPos - grabbedObject.transform.position) * 10f;
                }
            }
        
    }
}
