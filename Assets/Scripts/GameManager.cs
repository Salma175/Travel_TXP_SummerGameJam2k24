using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    void Awake()
    {
        Instance = this;
    }

    public void OnLaunchGame()
    {
        SceneLoader.Instance.LoadScene(Constants.SceneName.Game.ToString());
        SceneLoader.Instance.LoadSceneAdditive(Constants.SceneName.Env1.ToString());
    }
}
