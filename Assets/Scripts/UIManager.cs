using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Text scoreText, healthText, gameOverText;
    [SerializeField]
    private Player _player;
    Animator textAnim;
    // handle to text

    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.Find("Player").GetComponent<Player>();

        textAnim = GameObject.Find("GameOver_Text").GetComponent<Animator>();

        scoreText.text = "Score: " + 0;

        healthText.text = "Health: " + 3;

        gameOverText.enabled = false;
        textAnim.enabled = false;
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
            textAnim.enabled = true;

            //StartCoroutine(GameOverFlicker());
        }
    }

    // alt method to flicker game over text
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
