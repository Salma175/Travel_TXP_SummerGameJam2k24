using UnityEngine;
using static Constants;

public class BirdAnimationController : MonoBehaviour
{
    [SerializeField]
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator.SetTrigger(AnimParam.Fly.ToString());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
