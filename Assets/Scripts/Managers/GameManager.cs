using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _loadingScreenGO;

    public static GameManager Instance { get; private set; }

    void Awake()
    {
        Instance = this;
    }
    public void OnLoadLevel(int level)
    {
        SceneLoader.Instance.LoadScene(Constants.SceneName.Game.ToString());
        _loadingScreenGO.SetActive(true);
        if (level == 1)
        {
            SceneLoader.Instance.LoadSceneWithCallback(Constants.SceneName.Env2.ToString(), onComplete);
        }
    }

    private void onComplete()
    {
        _loadingScreenGO.SetActive(false);    
    }
}
