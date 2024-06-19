using System.Collections;
using TMPro;
using UnityEngine;

public class NarrationManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _skipGO;
    [SerializeField]
    private GameObject _startGO;
    [SerializeField]
    private TextMeshProUGUI narrativeText;
    private AudioManager audioManager;

    private string[] storyLines = {
        "Meet Breeze\na Ruby-throated Hummingbird",
        "Ready for her first migration from \nNorth America to Central America....",
        "With an incredible 3,000km to travel \nin just under three weeks, \nRuby's migration poses countless dangers.",
        "A tempestuous sky can prove fatal for the migrants.",
        "Even heavy rain alone could spell disaster for such a delicate species.",
        "A new land means new predators, and hurdles.",
        "A new journey soon awaits Breeze!"
    };
    private int currentLineIndex = 0;

    private float displayDuration = 4f;

    private Coroutine _narrationCoroutine;

    void Start(){
        audioManager = GameObject.Find("Audios").GetComponent<AudioManager>();
    }

    private void OnEnable()
    {
        currentLineIndex = 0;
        _startGO.SetActive(false);
        _skipGO.SetActive(true);

        StopAllCoroutines();
        _narrationCoroutine = StartCoroutine(DisplayNarrative());
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }

    private IEnumerator DisplayNarrative()
    {
        for (; currentLineIndex < storyLines.Length; currentLineIndex++)
        {
            narrativeText.text = storyLines[currentLineIndex];
            yield return new WaitForSeconds(displayDuration);
        }
        _startGO.SetActive(true);
        _skipGO.SetActive(false);
        narrativeText.text = "Ready to Start!!";
    }

    public void ShowNextLine()
    {
        audioManager.clickSound();
        StopCoroutine(_narrationCoroutine);

        if (currentLineIndex < storyLines.Length)
        {
            narrativeText.text = storyLines[currentLineIndex];
            currentLineIndex++;
            _narrationCoroutine = StartCoroutine(DisplayNarrative());
        }
        else
        {
            _startGO.SetActive(true);
            _skipGO.SetActive(false);
            narrativeText.text = "Ready to Start!!";
        }
    }
}
