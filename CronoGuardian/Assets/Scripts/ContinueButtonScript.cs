using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ContinueButtonScript : MonoBehaviour
{
    public Button playButton;

    void Start()
    {
        if (playButton != null)
        {
            playButton.onClick.AddListener(SkipStory);
        }
        else
        {
            Debug.LogError("SkipButton is not assigned in the inspector.");
        }
    }

    void SkipStory()
    {
        Debug.Log("Skip button clicked. Loading GameScene...");
        SceneManager.LoadScene("SampleScene");
    }
}
