using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

    public float speed;
    public bool start;

    private Rigidbody2D rb;
    private Vector3 platformDistBall;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (start == false)
        {
            HorizontalMove();
            
            if(Input.GetKeyDown(KeyCode.Space))
            {
                start = true;
                BallMove();
            }
        }

    }

    private void BallMove()
    {
        rb.velocity = Vector2.up * speed;
    }

    private void HorizontalMove()
    {
        float mousePosWorldUnitX = ((Input.mousePosition.x) / Screen.width * 16) - 8;

        Vector2 platformPos = new Vector2(0, transform.position.y);

        platformPos.x = Mathf.Clamp(mousePosWorldUnitX, -7.4f, 7.4f);

        transform.position = platformPos; 

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
