using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       float mousePosWorldUnitX = ((Input.mousePosition.x) / Screen.width * 16) - 8;

        Vector2 platformPos = new Vector2(0, transform.position.y);

        platformPos.x = Mathf.Clamp(mousePosWorldUnitX, -7.4f, 7.4f);

        transform.position = platformPos; 
    }
}
