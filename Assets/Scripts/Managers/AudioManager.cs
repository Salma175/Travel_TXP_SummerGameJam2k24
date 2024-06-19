using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField]
    private AudioSource _audioSource;
    [SerializeField]
    private AudioClip _bgm;

    public AudioClip gameOver;
    public AudioClip levelComplete;
    public AudioClip buttonClick;
    public AudioClip wingsFlap;

    public void clickSound(){
        _audioSource.PlayOneShot(buttonClick, 1F);
    }
    public void levelCompleteSound(){
        _audioSource.PlayOneShot(levelComplete, 1F);
    }
    public void gameOverSound(){
        _audioSource.PlayOneShot(gameOver, 1F);
    }
    public void wingsFlapSound(){
        _audioSource.PlayOneShot(wingsFlap, 1F);
    }
}
