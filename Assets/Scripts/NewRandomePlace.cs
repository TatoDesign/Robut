using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewRandomePlace : MonoBehaviour
{
    public Comer comer;

    public float minX = -20f; // Valor mínimo en el eje X
    public float maxX = 20f;  // Valor máximo en el eje X
    public float minZ = -20f; // Valor mínimo en el eje Z
    public float maxZ = 20f;  // Valor máximo en el eje Z
    public float constantY = 11f; // Valor constante en el eje Y
    public Vector3 teletransportPosition = new Vector3(-5.174458f, 1.03f, -1.802533f);
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider != null)
        {
            Moverse();  
        }
        /*
        // Comprueba si el objeto con el que colisionamos tiene un collider
        if (collision.collider != null)
        {
            // Teletransporta este objeto a la posición especificada
            transform.position = teletransportPosition;
        }
        */
    }
    // Referencia al objeto con el tag "Player"
    private GameObject player;

    void Start()
    {
        //comer = GetComponent<Comer>();
        // Buscar el objeto con el tag "Player" al inicio
        player = GameObject.FindGameObjectWithTag("Player");

        if (player == null)
        {
            Debug.LogError("No se ha encontrado un objeto con el tag 'Player'. Asegúrate de asignar el tag correctamente.");
        }
    }

    void Update()
    {
        // Verificar si se ha encontrado el objeto "Player" y si se presiona la tecla "G"
        if (player != null && Input.GetKeyDown(KeyCode.Alpha1))
        {
            Moverse();
        }
        if(player != null && Input.GetKeyDown(KeyCode.Alpha2))
        {
            transform.position = teletransportPosition;
        }
    }

    private void Moverse()
    {
        // Generar una posición aleatoria dentro del rango especificado
        float randomX = Random.Range(minX, maxX);
        float randomZ = Random.Range(minZ, maxZ);

        // Obtener la posición actual del objeto "Player"
        Vector3 playerPosition = player.transform.position;

        // Teletransportar este objeto a la posición aleatoria relativa al "Player" con Y constante
        transform.position = new Vector3(playerPosition.x + randomX, constantY, playerPosition.z + randomZ);
        comer.Saltar();
    }


   
}


