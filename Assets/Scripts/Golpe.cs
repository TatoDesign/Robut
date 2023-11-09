using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Golpe : MonoBehaviour
{

    public Vector3 teletransportPosition = new Vector3(-5.174458f, 1.03f, -1.802533f);

    private void OnCollisionEnter(Collision collision)
    {
        // Comprueba si el objeto con el que colisionamos tiene un collider
        if (collision.collider != null)
        {
            // Teletransporta este objeto a la posición especificada
            transform.position = teletransportPosition;
        }
    }
}


