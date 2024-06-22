using UnityEngine;
using System.Collections;
using static Constants;

public class BirdAnimationController : MonoBehaviour
{
    [SerializeField]
    private Animator animator;
    private AudioManager audioManager;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(WaitAndStartGame(2f));
        audioManager = GameObject.Find("Audios").GetComponent<AudioManager>();
    }

    public IEnumerator WaitAndStartGame(float timeInSeconds){
        yield return new WaitForSeconds(timeInSeconds);
        animator.SetTrigger(AnimParam.Fly.ToString());
        yield return new WaitForSeconds(.5f);
        GameManager.Instance.startGame();
    }

    // Update is called once per frame
    void Update()
    {
        
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        animator.SetFloat("Vertical_Blend", verticalInput);
        animator.SetFloat("Horizontal_Blend", horizontalInput);
    }

    public void WingFlap(){
        if (GameManager.Instance.CurrentState == GameState.Playing){
            audioManager.wingsFlapSound();
        }
    }
}
