using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lifes : MonoBehaviour
{
    public static Lifes instance;

    public Text lifeText;
    public GameObject gameOver;

    [SerializeField]
    private int lifes;

    private void Awake() {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        lifeText.text = "LIFES: " + lifes.ToString();
    }

    public void LoseLife()
    {
        lifes--;
        lifeText.text = "LIFES: " + lifes.ToString();
    }

    public int GetLifes()
    {
        return lifes;
    }
}
