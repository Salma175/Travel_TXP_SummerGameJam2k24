using UnityEngine;
using static Constants;

public class ScreenManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _titleScreenGO;
    [SerializeField]
    private GameObject _narrationScreenGO;
    [SerializeField]
    private GameObject _mapScreenGO;

    private GameScreen _currentScreen;
    void Start()
    {
        ResetUi();
    }

    private void LateUpdate()
    {
        if(Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (_currentScreen != GameScreen.Map)
            {
                ChangeScreen();
            }
        }
    }

    private void ChangeScreen()
    {
        switch(_currentScreen)
        {
            case GameScreen.Title:
                _currentScreen = GameScreen.Narration;
                EnableNarrationScreen();
                break;
            case GameScreen.Narration:
                _currentScreen = GameScreen.Map;
                EnableMapScreen();
                break;
            case GameScreen.Map:
                break;
        }
    }

    private void EnableNarrationScreen()
    {
        _titleScreenGO.SetActive(false);
        _narrationScreenGO.SetActive(true);
    }

    private void EnableMapScreen()
    {
        _narrationScreenGO.SetActive(false);
        _mapScreenGO.SetActive(true);
    }

    private void ResetUi()
    {
        _currentScreen = GameScreen.Title;

        _titleScreenGO.SetActive(true);
        _narrationScreenGO.SetActive(false);
        _mapScreenGO.SetActive(false);
    }
}
