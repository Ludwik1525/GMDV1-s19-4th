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

        player=GameObject.FindGameObjectWithTag("Player");

        offset = transform.position - player.transform.position;
    }

    void LateUpdate()
    {
        transform.position = player.transform.position + new Vector3(offset.x, offset.y, -5);
    }
}
