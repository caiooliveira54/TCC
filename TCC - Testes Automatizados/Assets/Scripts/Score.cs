using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public static Score instance;

    public Text scoreText;
    public GameObject victory;

    [SerializeField]
    private int score;
    private GameObject[] bars;
    private int barCounter = 0; 
    [SerializeField]
    private bool isTesting = false;

    private void Awake() {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        bars = GameObject.FindGameObjectsWithTag("Destructable");
        scoreText.text = "SCORE: " + score.ToString();
    }

    void Update() {
        if (barCounter == bars.Length)
        {
            // Debug.Log("Zerou");
            if (!isTesting)
            {
                victory.SetActive(true);
                Time.timeScale = 0;
            }
        }
    }

    public void AddPoints(int points)
    {
        score += points;
        scoreText.text = "SCORE: " + score.ToString();
        barCounter++;
    }

    public int GetPlayerScore()
    {
        return score;
    }


}