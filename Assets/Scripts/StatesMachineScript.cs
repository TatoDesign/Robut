using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class StatesMachineScript : MonoBehaviour
{
    private GameObject player;
    private GameObject ball;
    private GameObject robut;
    private MeshRenderer ballMesh;
    public static int StatesMachine = 0;
    int onetime1 = 0;
    int onetime2 = 0;
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
            
            if (onetime1 == 0)
            {
                Invoke("Transporte1",2f);
                onetime1 = 1;
            }
            
        }
        if (StatesMachine == 7)
        {
           
            if (onetime2 == 0)
            {
                Invoke("Transporte2", 2f);
            }
            onetime2 = 1;
        }
    }
    void Transporte1()
    {
     
            player.transform.position = new Vector3(117f, 0.9200001f, -59f);
            robut.transform.position = new Vector3(120f, 0.9200001f, -59f);
            ball.transform.position = new Vector3(117f, 0.9200001f, -60f);
            StatesMachine += 1;
           
        
    }
    void Transporte2()
    {
        player.transform.position = new Vector3(88.05612f, 0.9200001f, 0.917779f);
        robut.transform.position = new Vector3(88.05612f, 0.9200001f, 1f);
        ball.transform.position = new Vector3(88.05612f, 0.9200001f, 2f);
        StatesMachine += 1;
    }
}

