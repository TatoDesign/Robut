using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeDesapiar : MonoBehaviour
{
    void OnMouseDown()
    {
        // Destruye el objeto despu�s de 5 segundos
        Destroy(gameObject, 5f);
    }
}
