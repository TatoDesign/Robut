using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class ComunicatorController : MonoBehaviour
{
    bool isPressed;
    public GameObject uiObject;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
   
            isPressed = true;
        }
        if (Input.GetKeyUp(KeyCode.Alpha3))
        {
          
            isPressed = false;
        }
        if (isPressed)
        {
            // Mostrar todos los elementos de la interfaz de usuario en la capa
            gameObject.layer = LayerMask.NameToLayer("UI");
            uiObject.SetActive(true);
        }
        else
        {
            gameObject.layer = LayerMask.NameToLayer("UI");
            uiObject.SetActive(false);
        }
    }

}
