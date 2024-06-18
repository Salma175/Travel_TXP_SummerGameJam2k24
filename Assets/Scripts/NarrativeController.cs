using TMPro;
using UnityEngine;

public class NarrativeController : MonoBehaviour
{
    public TextMeshProUGUI narrativeText;
    private string[] storyLines = {
        "Meet Ruby\nRuby-throated Hummingbird",
        "Ready for her first migration from North America to Central America....",
        "With an incredible 3,000km to travel in just under three weeks, Ruby's migration poses countless dangers.",
        "A tempestuous sky can prove fatal for the migrants.",
        "Even heavy rain alone could spell disaster for such a delicate species.",
        "A new land means new predators, and hurdles.",
        "A new journey soon awaits Ruby!"
    };
    private int currentLineIndex = 0;

    void Start()
    {
        ShowNextLine();
    }

    void LateUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ShowNextLine();
        }
    }

    void ShowNextLine()
    {
        if (currentLineIndex < storyLines.Length)
        {
            narrativeText.text = storyLines[currentLineIndex];
            currentLineIndex++;
        }
        else
        {
            narrativeText.text = "Press Enter to Start";
        }
    }
}
