using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TabletController : MonoBehaviour
{

    private Renderer objectRenderer;
    // Start is called before the first frame update
    void Start()
    {
        objectRenderer = GetComponent<Renderer>();
       
        if (objectRenderer == null)
        {
            Debug.LogError("El GameObject no tiene un componente MeshRenderer.");
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Alpha3))
        {
            objectRenderer.enabled = true;
        }
        else
        {
            objectRenderer.enabled = false;
        }

    }
}
