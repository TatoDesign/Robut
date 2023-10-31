using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeDesapiar : MonoBehaviour
{
    void OnMouseDown()
    {
        // Destruye el objeto después de 5 segundos
        Destroy(gameObject, 5f);
    }
}
