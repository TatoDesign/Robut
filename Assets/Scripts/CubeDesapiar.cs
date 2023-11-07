using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeDesapiar : MonoBehaviour
{

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit) && hit.collider.gameObject == gameObject)
            {
                Teleport();
            }
        }
    }

    void Teleport()
    {
        StatesMachineScript.StatesMachine += 1;
    }

}


