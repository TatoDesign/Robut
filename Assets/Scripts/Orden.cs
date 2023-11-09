using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orden : MonoBehaviour
{
    public Animator animator;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(RobutController.buscando == true)
        {
            animator.SetBool("OrdenSalta", true);
        }
        else
        {
            animator.SetBool("OrdenSalta", false);
        }
    }
}
