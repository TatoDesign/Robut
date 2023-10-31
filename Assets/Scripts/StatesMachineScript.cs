using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatesMachineScript : MonoBehaviour
{
    private GameObject player;
    private GameObject ball;
    private GameObject robut;
    private MeshRenderer ballMesh;
    public static int StatesMachine = 0;
    
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        ball = GameObject.FindWithTag("BallTag");
        robut = GameObject.FindWithTag("RobutTag");
        ballMesh = ball.GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (StatesMachine == 0)
        {
            ballMesh.enabled = false;
            StatesMachine += 1;
        }
        if (StatesMachine == 3)
        {
            ballMesh.enabled = true;
            StatesMachine += 1;
        }
        if ( StatesMachine == 4)
        {
            Invoke("Transporte1",2f);//es este el que quiero hacer que tarde 
        } 
        if (StatesMachine == 6)
        {
            Invoke("Transporte2", 2f);
        }
    }
    void Transporte1()
    {
        player.transform.position = new Vector3(117f, 6f, -59f);
        robut.transform.position = new Vector3(120f, 6f, -59f);
        ball.transform.position = new Vector3(117f, 8f, -60f);
        StatesMachine += 1;
    }
    void Transporte2()
    {
        player.transform.position = new Vector3(-297, 4f, -182.019f);
        robut.transform.position = new Vector3(-299, 4f, -183.019f);
        ball.transform.position = new Vector3(-300, 4f, -184.019f);
        StatesMachine += 1;
    }
}

