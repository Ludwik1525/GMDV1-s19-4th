using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class  EnemyMovement : MonoBehaviour {
    
    private float speed;

    private Vector2 velocity;
    private Rigidbody2D rb;
    private Vector2 moveInput;

    private bool facingRight = true;

    private GameManager manager;

    void Start()
    {
        manager = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<GameManager>();

        switch (this.gameObject.tag)
        {
            case "Worm": speed = manager.wormsSpeed;
                break;
            case "Golem": speed = manager.golemSpeed;
                break;
            case "Blackman": speed = manager.blackmanSpeed;
                break;
            case "Skeleton": speed = manager.skeletonSpeed;
                break;
            case "Flame": speed = manager.flameSpeed;
                break;
            case "Spider": speed = manager.spiderSpeed;
                break;
        }

        rb = GetComponent<Rigidbody2D>();
        moveInput = new Vector2(speed, 0);
        StartCoroutine(WormCoroutine());
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

    private void OnCollisionEnter2D(Collision2D other)
    {
        Flip();
    }

    public IEnumerator WormCoroutine()
    {
        int i = 0;
        while(true)
        {
            i = Random.Range(2, 6);
            yield return new WaitForSeconds(i);
            Flip();
        }
    }
}
