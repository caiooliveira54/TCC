using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;

public class TestScore
{
    private Ball ball;
    private Player player;
    private Bar[] bars;

    [UnitySetUp]
    public IEnumerator SetUp()
    {
        SceneManager.LoadScene("LevelTest");

        yield return new WaitForSeconds(1);

        bars = GameObject.FindObjectsOfType<Bar>();

        player = GameObject.FindObjectOfType<Player>();
        player.AutoPlay = true;

        ball = GameObject.FindObjectOfType<Ball>();
    }

    [UnityTest]
    public IEnumerator TestScoreWhenDestroyAllBars()
    {
        int num;
        int x = 0;
        foreach (Bar bar in bars)
        {
            x++;
            if (bar.tag == "Destructable")
            {
                if (bar.GetBarPoints() == 10)
                    num = 1;
                if (bar.GetBarPoints() == 30)
                    num = 2;
                else
                    num = 3;
                
                Debug.Log("Block " + x + "X: " + bar.transform.position.x + "Y: " + bar.transform.position.y);
                for (int i = 0; i < num; i++)
                {
                    ball.transform.position = new Vector2(bar.transform.position.x - 0.5f, player.transform.position.y);
                    ball.BallMove();

                    yield return new WaitForSeconds(0.75f);
                } 
            }
            
        }

        Score score = GameObject.FindObjectOfType<Score>();

        Assert.AreEqual(60, score.GetPlayerScore());
    }
}
