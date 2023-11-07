using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Atract : MonoBehaviour
{
    
    private float fuerzaM = 0.2f;
    private bool shouldApplyForce = true;

    void Update()
    {
        ApplyForceIfNeeded();
        if (Input.GetKeyDown(KeyCode.Q))        
        {
            fuerzaM = 100f;
        }
        if (Input.GetKeyUp(KeyCode.Q))
        {
            fuerzaM = 0.2f;
        }
    }

    private void ApplyForceIfNeeded()
    {
        if (shouldApplyForce)
        {
            GameObject[] balls = GameObject.FindGameObjectsWithTag("BallTag");
            foreach (GameObject ball in balls)
            {
                Rigidbody rb = ball.GetComponent<Rigidbody>();
                if (rb != null)
                {
                    Vector3 vectorCorriente = transform.position - rb.transform.position;
                    float distancia = vectorCorriente.magnitude;
                    if (distancia > 0.0001f)
                    {
                        Vector3 fuerzaCorriente = vectorCorriente.normalized * fuerzaM / distancia;
                        rb.AddForce(fuerzaCorriente);
                    }
                }
            }
        }
    }
}
