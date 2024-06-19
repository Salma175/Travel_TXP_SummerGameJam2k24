using System;
using UnityEngine;
using static Constants;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _loadingScreenGO;

    public static GameManager Instance { get; set; }

    private GameState currentState;
    private AudioManager audioManager;
    public GameState CurrentState
    {
        get => currentState;
        set
        {
            if (currentState != value)
            {
                currentState = value;
                OnGameStateChanged?.Invoke(currentState);
            }
        }
    }

    public event Action<GameState> OnGameStateChanged;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    private void Start()
    {
        CurrentState = (GameState.MainMenu);
        audioManager = GameObject.Find("Audios").GetComponent<AudioManager>();
    }

    public void OnLoadLevel(int level)
    {
        audioManager.clickSound();
        SceneLoader.Instance.LoadScene(Constants.SceneName.Game.ToString());
        _loadingScreenGO.SetActive(true);
        if (level == 1)
        {
            SceneLoader.Instance.LoadAdditiveSceneWithCallback(Constants.SceneName.Env1.ToString(), onComplete);
        }
    }

    private void onComplete()
    {
        _loadingScreenGO.SetActive(false);
        CurrentState = (GameState.Idle);
    }

    public void startGame(){
        CurrentState = (GameState.Playing);
    }
}
