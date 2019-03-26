using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WormMovement : MonoBehaviour {

    [Range(1f, 4f)]
    public float speed;

    [Range(1f, 5f)]
    public float changeSideTime;

    private Vector2 velocity;
    private Rigidbody2D rb;
    private Vector2 moveInput;

    private bool facingRight = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        moveInput = new Vector2(speed, 0);
        StartCoroutine(WormCoroutine(changeSideTime));
    }

    void Update()
    {
        if (!facingRight)
        {
            moveInput = new Vector2(-speed, 0);
        }

        if (facingRight)
        {
            moveInput = new Vector2(speed, 0);
        }
        
        velocity = moveInput.normalized * speed * 50;

        rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);
    }

    void Flip()
    {
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
        facingRight = !facingRight;
    }

    public IEnumerator WormCoroutine(float t)
    {
        while(true)
        {
            yield return new WaitForSeconds(t);
            Flip();
        }
    }
}
