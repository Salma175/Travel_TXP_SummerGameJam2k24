using TMPro;
using UnityEngine;

public class NarrativeController : MonoBehaviour
{
    public TextMeshProUGUI narrativeText;
    private string[] storyLines = {
        "Meet Ruby, the Ruby-throated Hummingbird...",
        "Ready for her first migration from North America to Central America....",
        "Facing many challenges and foes..."
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
            narrativeText.text = "The End.";
        }
    }
}
