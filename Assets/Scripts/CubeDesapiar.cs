using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CubeDesapiar : MonoBehaviour
{
    // Este m�todo se llama cuando el objeto con este script colisiona con otro
    private void OnCollisionEnter(Collision collision)
    {
        // Comprobamos si el objeto que colisiona tiene el tag "Player"
        if (collision.gameObject.CompareTag("Player"))
        {
            // Si es as�, hacemos lo que queremos, como destruir el objeto o cambiar el estado de la m�quina
            Destroy(gameObject, 5f);
            StatesMachineScript.StatesMachine += 1;
        }
    }
}
