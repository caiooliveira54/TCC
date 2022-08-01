using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bar : MonoBehaviour, Observable
{
    [SerializeField]
    private int lifePoints;
    [SerializeField]
    private int barPoints;
    [SerializeField]
    private Score score;

    List<Observer> observers;

    // Start is called before the first frame update
    void Awake()
    {
        observers = new List<Observer>();

        score = GameObject.FindObjectOfType<Score>().GetComponent<Score>();
    }

    private void OnDisable() {
        score.AddPoints(barPoints);
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.CompareTag("Ball"))
        {
            lifePoints--;

            if (lifePoints <= 0)
            {
                gameObject.SetActive(false);
            }
        }
    }

    public void RegisterObserver(Observer obs)
    {
        observers.Add(obs);
    }

    public void Notify(object observable)
    {
        foreach(var observer in observers)
        {
            observer.update(this);
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
