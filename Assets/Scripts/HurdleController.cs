using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurdleController : MonoBehaviour
{
    // public float forwardSpeed; // Constant forward speed
    public float glideSpeed; // Speed at which bird glides in a direction
    private BirdController _birdController;

    
    // Start is called before the first frame update
    void Start()
    {
        _birdController = GameObject.Find("WhiteBird").GetComponent<BirdController>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _birdController.gameObject.transform.position, Time.deltaTime * glideSpeed);
        // Debug.Log($"{transform.position} -------- {_birdController.gameObject.transform.position}");
    }
}
