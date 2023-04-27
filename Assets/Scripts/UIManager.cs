using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Text scoreText;
    // handle to text

    // Start is called before the first frame update
    void Start()
    {
        // assign text component to handle
        scoreText.text = "Score: " + 0; 
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void UpdateScore(int playerScore)
    {
        scoreText.text = "Score:" + playerScore;
    }
}
