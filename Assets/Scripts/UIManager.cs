using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Text scoreText, healthText, gameOverText, startOverText;
    Animator gameOverTextAnim;

    private GameManager _gameManager;
    // handle to text

    // Start is called before the first frame update
    void Start()
    {     
        gameOverTextAnim = GameObject.Find("GameOver_Text").GetComponent<Animator>();
        scoreText.text = "Score: " + 0;
        healthText.text = "Health: " + 3;
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        if (_gameManager == null)
        {
            Debug.LogError("GameManager is NULL");
        }

        gameOverText.enabled = false;
        startOverText.enabled = false;
        gameOverTextAnim.enabled = false;
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
            _gameManager.GameOver();
            gameOverText.enabled = true;
            startOverText.enabled = true;
            gameOverTextAnim.enabled = true;

            //StartCoroutine(GameOverFlicker());
        }
    }

    // alt method to flicker game over text
    // currently the flicker is an Animation that loops betweens on and off
    /*
    IEnumerator GameOverFlicker()
    {
        while (true)
        {
            gameOverText.enabled = true;
            yield return new WaitForSeconds(0.5f);
            gameOverText.enabled = false;
            yield return new WaitForSeconds(0.5f);
        }    
    }
    */
}
