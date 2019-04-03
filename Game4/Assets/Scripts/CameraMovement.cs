using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

    private GameObject player;

    void Update()
    {
        if(GameObject.FindGameObjectWithTag("Player")){          
        player=GameObject.FindGameObjectWithTag("Player");
        }
    }

    void LateUpdate()
    {
        transform.position = player.transform.position + new Vector3(0, 0, -5);
        
    }
}
