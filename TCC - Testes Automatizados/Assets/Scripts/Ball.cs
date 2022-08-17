using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

    public float speed;
    public bool start;
    public int lifes;
    
    private Transform ballPos;
    private Rigidbody2D rb;
    private Vector3 platformDistBall;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ballPos = GameObject.FindWithTag("BallPosition").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (start == false && !Pause.instance.getIsPaused())
        {
            HorizontalMove();
            
            if(Input.GetKeyDown(KeyCode.Space))
            {
                BallMove();
            }
        }

    }

    public void BallMove()
    {
        rb.velocity = Vector2.up * speed;
        start = true;
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
            Vector2 velocityAdjustment = new Vector2(Random.Range(0f, 0.2f), Random.Range(0f, 0.2f));
            rb.velocity += velocityAdjustment;
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.CompareTag("Hole"))
        {
            if (Lifes.instance.GetLifes() > 1)
            {
                rb.velocity = Vector2.zero;
                transform.position = ballPos.position;
                start = false;
                Lifes.instance.LoseLife();
            }
            else
            {
                Lifes.instance.LoseLife();
                Lifes.instance.gameOver.SetActive(true);
                gameObject.SetActive(false);
            }
            
        }
    }
}
