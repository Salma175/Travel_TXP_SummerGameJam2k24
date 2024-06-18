using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePlayManager : MonoBehaviour
{
    public float birdHealth;
    public Image birdHealthBar;
    // Start is called before the first frame update
    void Start()
    {
        birdHealth = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        birdHealth = birdHealth - Time.deltaTime *  .1f;
        birdHealthBar.fillAmount = birdHealth;
    }
}
