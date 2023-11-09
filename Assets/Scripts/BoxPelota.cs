using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxPelota : MonoBehaviour
{
    // Declara las variables estáticas públicas
    public static bool PelotaBOX = false;
    public static bool CommunicatorBOX = false;
    public static bool ResorteraBOX = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    // Método que se ejecuta cuando hay una colisión
    void OnCollisionEnter(Collision collision)
    {
        // Comprueba si el otro objeto tiene el tag "Player"
        if (collision.gameObject.CompareTag("Player"))
        {
            // Cambia el valor de las variables
            PelotaBOX = true;
            CommunicatorBOX = false;
            ResorteraBOX = false;
        }
    }
}
