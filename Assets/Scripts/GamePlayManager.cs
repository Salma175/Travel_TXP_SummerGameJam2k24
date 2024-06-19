using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GamePlayManager : MonoBehaviour
{
    public bool gameRunning;
    public float birdHealth;
    public Image birdHealthBar;
    // Start is called before the first frame update
    public GameObject retryButton;

    void Start()
    {
        Time.timeScale = 1f;
        birdHealth = 1f;
        gameRunning = true;
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        birdHealth = birdHealth - (Time.deltaTime *  .1f * ((Math.Abs(horizontalInput) + 1f) * .5f) * (verticalInput + 1.5f));
        birdHealthBar.fillAmount = birdHealth;
        if (birdHealth <= 0){
            GameOver();
        }
    }


    public void GameOver(){
        Time.timeScale = 0;
        retryButton.SetActive(true);
    }

    public void GameWon(){
        gameRunning = false;
        // Add Game End Logic
    }

    public void Restart(){
        SceneManager.LoadScene(Constants.SceneName.Env1.ToString());
    }
}
