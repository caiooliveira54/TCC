using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bar : MonoBehaviour
{
    [SerializeField]
    private int lifePoints;
    [SerializeField]
    private int barScore;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.CompareTag("Ball"))
        {
            lifePoints--;

            if (lifePoints <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
    
    public int GetLifePoints()
    {
        return lifePoints;
    }

    public int GetBarScore()
    {
        return barScore;
    }
}
