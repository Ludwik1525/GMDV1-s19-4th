using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

    private GameObject player;
    private Vector3 offset;

    void Start () {

    }

    void Update()
    {
        if(GameObject.FindGameObjectWithTag("Player")){          
        player=GameObject.FindGameObjectWithTag("Player");

        offset = transform.position - player.transform.position;
        }
    }

    void LateUpdate()
    {
       
        // new Vector3(offset.x, offset.y, -5)
        transform.position = player.transform.position + new Vector3(0, 0, -5);
        
    }
}
