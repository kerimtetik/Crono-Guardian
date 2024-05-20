using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BlackPlayButtonScript : MonoBehaviour
{
    public Button playButton;

    void Start()
    {
        if (playButton != null)
        {
            playButton.onClick.AddListener(StartGame);
        }
        else
        {
            Debug.LogError("PlayButton is not assigned in the inspector.");
        }
    }

    void StartGame()
    {
        Debug.Log("Play button clicked. Loading GameScene...");
        SceneManager.LoadScene("StoryScene");
    }
}