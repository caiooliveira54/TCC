using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

    public float speed;

    private Rigidbody2D rb;
    private Vector3 platformDistBall;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.up * speed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private float HitFactor(Vector2 ball, Vector2 player, float playerWidth)
    {
        return (ball.x - player.x) / playerWidth;
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.CompareTag("Player"))
        {
            float x = HitFactor(
            transform.position, 
            col.transform.position, 
            col.collider.bounds.size.x);

            Vector2 dir = new Vector2(x, 1).normalized;
            rb.velocity = dir * speed;
        }
    }
}
