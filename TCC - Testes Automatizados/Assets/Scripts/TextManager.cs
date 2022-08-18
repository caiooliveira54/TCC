using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextManager : MonoBehaviour
{
    public Text playerName;

    private AddScore addScore;
    private bool isSubmited = false;
    private int playerScore;

    private void Start() {
        addScore = new AddScore();
    }

    public void getTextValor()
    {
        if (!isSubmited)
        {
            playerScore = Score.instance.GetPlayerScore();
            Debug.Log("valor: " + playerName.text + "score: " + playerScore);
            addScore.addHighScoreEntry(playerName.text, playerScore);
            // playerName.text 
            isSubmited = true;
        }
    }
}
