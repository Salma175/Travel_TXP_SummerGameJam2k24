using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    void Awake()
    {
        Instance = this;
    }
    public void OnLoadLevel(int level)
    {
        SceneLoader.Instance.LoadScene(Constants.SceneName.Game.ToString());
        if (level == 1)
        {
            SceneLoader.Instance.LoadSceneAdditive(Constants.SceneName.Env1.ToString());
        }
    }
}
