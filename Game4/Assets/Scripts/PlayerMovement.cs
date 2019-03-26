using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    
    private float speed;
    private Vector2 velocity;
    private Rigidbody2D rb;

    private GameManager manager;

    void Start()
    {
        manager = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<GameManager>();
        speed = manager.playerSpeed;
        rb = GetComponent<Rigidbody2D>();
    }
    
    void Update()
    {
        Vector2 moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        velocity = moveInput.normalized * speed * 50;

        rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);
    }
    
}
