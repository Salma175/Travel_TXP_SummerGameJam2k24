using UnityEngine;
using static Constants;

public class ScreenManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _titleScreenGO;
    [SerializeField]
    private GameObject _narrationScreenGO;
    [SerializeField]
    private GameObject _controlsScreenGO;
    [SerializeField]
    private GameObject _mapScreenGO;

    private GameScreen _currentScreen;
    private AudioManager audioManager;
    void Start()
    {
        audioManager = GameObject.Find("Audios").GetComponent<AudioManager>();
        ResetUi();
    }

    private void LateUpdate()
    {
        if(Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (_currentScreen == GameScreen.Title)
            {
                _currentScreen = GameScreen.Narration;
                EnableNarrationScreen();
            }
        }
    }

    private void EnableNarrationScreen()
    {
        audioManager.clickSound();
        _titleScreenGO.SetActive(false);
        _narrationScreenGO.SetActive(true);
    }
    public void EnableControlsScreen()
    {
        audioManager.clickSound();
        _narrationScreenGO.SetActive(false);
        _controlsScreenGO.SetActive(true);
    }
    public void EnableMapScreen()
    {
        audioManager.clickSound();
        _controlsScreenGO.SetActive(false);
        _mapScreenGO.SetActive(true);
    }

    private void ResetUi()
    {
        _currentScreen = GameScreen.Title;

        _titleScreenGO.SetActive(true);
        _narrationScreenGO.SetActive(false);
        _controlsScreenGO.SetActive(false);
        _mapScreenGO.SetActive(false);
    }
}
