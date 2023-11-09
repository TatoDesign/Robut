using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallDesapair : MonoBehaviour
{
    private List<GameObject> ballObjects = new List<GameObject>();

    void Start()
    {
        // Almacenar los objetos con la etiqueta "BallTag" en una lista
        GameObject[] balls = GameObject.FindGameObjectsWithTag("BallTag");
        foreach (GameObject ball in balls)
        {
            ballObjects.Add(ball);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            // Desactivar los objetos en la lista
            foreach (GameObject ballObject in ballObjects)
            {
                ballObject.SetActive(false);
            }
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            // Reactivar los objetos en la lista
            foreach (GameObject ballObject in ballObjects)
            {
                ballObject.SetActive(true);
            }
        }
    }
}
