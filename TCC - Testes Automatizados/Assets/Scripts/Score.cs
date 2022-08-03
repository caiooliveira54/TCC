using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public static Score instance;

    public Text scoreText;

    [SerializeField]
    private int score;

    private void Awake() {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "SCORE: " + score.ToString();
    }

    public void AddPoints(int points)
    {
        score += points;
        scoreText.text = "SCORE: " + score.ToString();
    }

    public int GetPlayerScore()
    {
        return score;
    }
}
