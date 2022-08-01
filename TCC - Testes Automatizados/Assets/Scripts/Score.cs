using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour, Observer
{

    [SerializeField]
    private int score;
    
    Observable[] observables;

    // Start is called before the first frame update
    void Start()
    {
        observables = GameObject.FindObjectsOfType<Bar>();

        foreach (Observable obs in observables)
            obs.RegisterObserver(this);
    }

    public void update(object observable)
    {
        Bar bar = (Bar)observable;

        score += bar.GetBarPoints();
    }

    public void AddPoints(int points)
    {
        score += points;
    }
}
