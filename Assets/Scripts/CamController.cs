using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamController : MonoBehaviour
{
    private Camera cam;
    private GameObject objetoActual;

    void Start()
    {
        cam = Camera.main;
    }

    void Update()
    {
        // Lanza un rayo desde la posición de la cámara hacia la dirección del mouse
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        // Verifica si el rayo golpea un objeto
        if (Physics.Raycast(ray, out hit))
        {
            GameObject nuevoObjeto = hit.transform.gameObject;

            // Si el objeto mirado ha cambiado, muestra el nombre en la consola
            if (nuevoObjeto != objetoActual)
            {
                if (objetoActual != null)
                {
                    Debug.Log("Dejaste de mirar a: " + objetoActual.name);
                }
                objetoActual = nuevoObjeto;
                Debug.Log("Estás mirando a: " + objetoActual.name);
            }
        }
        else
        {
            // Si no golpea ningún objeto, muestra un mensaje de que no estás mirando ningún objeto
            if (objetoActual != null)
            {
                Debug.Log("Dejaste de mirar a: " + objetoActual.name);
                objetoActual = null;
            }
        }
    }
}


