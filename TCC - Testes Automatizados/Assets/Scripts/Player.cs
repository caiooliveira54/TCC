using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public bool AutoPlay { get; set; } = false;
    Ball ball = null;

    // Start is called before the first frame update
    private void Awake() 
    {
        ball = GameObject.FindObjectOfType<Ball>();
    }

    // Update is called once per frame
    void Update()
    {
        if (AutoPlay)
        {
            transform.position = new Vector2(ball.transform.position.x, transform.position.y);
        }
        else
        {
            if (!Pause.instance.getIsPaused())
            {
                float mousePosWorldUnitX = ((Input.mousePosition.x) / Screen.width * 16) - 8;

                Vector2 platformPos = new Vector2(0, transform.position.y);

                platformPos.x = Mathf.Clamp(mousePosWorldUnitX, -7.4f, 7.4f);

                transform.position = platformPos;
            } 
        }
    }
}
