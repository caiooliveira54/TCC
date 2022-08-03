using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bar : MonoBehaviour
{
    [SerializeField]
    private int lifePoints;
    [SerializeField]
    private int barPoints;

    // Start is called before the first frame update
    void Awake()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.CompareTag("Ball"))
        {
            lifePoints--;

            if (lifePoints <= 0)
            {
                gameObject.SetActive(false);
                //Destroy(gameObject);
                Score.instance.AddPoints(barPoints);
            }
        }
    }

    public int GetLifePoints()
    {
        return lifePoints;
    }

    public int GetBarPoints()
    {
        return barPoints;
    }
}
