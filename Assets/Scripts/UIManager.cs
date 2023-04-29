using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Text scoreText, healthText, gameOverText;
    [SerializeField]
    private Player _player;
    // handle to text

    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.Find("Player").GetComponent<Player>();

        // assign text component to handle
        scoreText.text = "Score: " + 0;

        healthText.text = "Health: " + 3;

        gameOverText.enabled = false;

        //healthDisplay = GameObject.Find("Full_Health").GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void UpdateScore(int playerScore)
    {
        scoreText.text = "Score:" + playerScore;
    }

    public void UpdateHealth(int playerHealth)
    {
        healthText.text = "Health: " + playerHealth;

        if (playerHealth < 1)
        {
            gameOverText.enabled = true;
        }
    }
}
