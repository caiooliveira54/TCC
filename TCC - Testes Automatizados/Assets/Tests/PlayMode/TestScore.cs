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
        foreach (Bar bar in bars)
        {
            if (bar.tag == "Destructable")
            {
                if (bar.GetBarPoints() == 10)
                    num = 1;
                if (bar.GetBarPoints() == 20)
                    num = 2;
                else
                    num = 3;
                
                for (int i = 0; i < num; i++)
                {
                    ball.transform.position = new Vector2(bar.transform.position.x - 0.5f, player.transform.position.y);
                    ball.BallMove();

                    yield return new WaitForSeconds(0.5f);
                } 
            }
            
        }

        Score score = GameObject.FindObjectOfType<Score>();

        Assert.AreEqual(60, score.GetPlayerScore());
    }
}
