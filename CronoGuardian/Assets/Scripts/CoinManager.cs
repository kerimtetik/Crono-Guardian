using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CoinManager : MonoBehaviour
{
    public int coinCount;
    public Text coinText;
    public GameObject door;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        coinText.text = "Zaman Parcacýgý: " + coinCount.ToString();

        if(coinCount == 8)
        {
            Destroy(door);
            WinGame();
        }

    }
    void WinGame()
    {
        SceneManager.LoadScene("WinScene");
    }
}
