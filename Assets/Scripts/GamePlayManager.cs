using System;
using UnityEngine;
using UnityEngine.UI;
using static Constants;

public class GamePlayManager : MonoBehaviour
{
    [SerializeField]
    private Image birdHealthBar;
    [SerializeField]
    private GameObject _levelFailGO;
    [SerializeField]
    private GameObject _levelSuccessGO;
    [SerializeField]
    private BirdController _birdController;

    private AudioManager audioManager;

    private float birdHealth;

    void Start()
    {
        ResetUi();
        birdHealth = 1f;
        audioManager = GameObject.Find("Audios").GetComponent<AudioManager>();
    }

  

    private void OnEnable()
    {
        _birdController.OnNectarCollected += HandleStaminaBarOnNectarCollection ;
        _birdController.OnDamage += HandleDamage;
        GameManager.Instance.OnGameStateChanged += HandleGameStateChanged;
    }

    private void OnDisable()
    {
        _birdController.OnNectarCollected -= HandleStaminaBarOnNectarCollection;
        _birdController.OnDamage -= HandleDamage;
        GameManager.Instance.OnGameStateChanged -= HandleGameStateChanged;
    }

    private void HandleDamage()
    {
        birdHealth -= .1f;
    }

    private void HandleStaminaBarOnNectarCollection()
    {
        birdHealth = 1f;
    }
    private void HandleGameStateChanged(GameState state)
    {
        switch (state)
        {
            case GameState.GameOver:
                GameWon();
                break;
            case GameState.Paused:
                GameFail();
                break;
            default:
                break;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.CurrentState == GameState.Playing)
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");

            birdHealth = birdHealth - (Time.deltaTime * .1f * ((Math.Abs(horizontalInput) + 1f) * .5f) * (verticalInput + 1.5f));
            birdHealthBar.fillAmount = birdHealth;
            if (birdHealth <= 0)
            {
                GameManager.Instance.CurrentState = (GameState.Paused);
            }
        }
    }


    public void GameFail()
    {
        _levelFailGO.SetActive(true);
        audioManager.gameOverSound();
    }

    public void GameWon()
    {
        _levelSuccessGO.SetActive(true);
        audioManager.levelCompleteSound();
        // Add Game End Logic
    }

    public void Restart()
    {
        birdHealth = 1f;
        audioManager.clickSound();
        ResetUi();
        _birdController.Restart();
        GameManager.Instance.CurrentState = (GameState.Playing);
    }

    private void ResetUi()
    {
        _levelFailGO.SetActive(false);
        _levelSuccessGO.SetActive(false);
    }
}
