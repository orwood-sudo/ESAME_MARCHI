using TMPro;
using UnityEngine;

public class GameOverManager : MonoBehaviour
{
    public GameObject gameOver;
    public GameObject winText;
    public GameObject looseText;

    public int maxCannon = 0;


    private void Awake()
    {
        gameOver.SetActive(false);
        winText.SetActive(false);
        looseText.SetActive(false);
    }

    public void Update()
    {
        if (maxCannon == 4)
        {
            GameOver(true);
        }
    }

    public void GameOver(bool win)
    {
        if (win)
        {
            Time.timeScale = 0;
            winText.SetActive(true);

        }
        else
        {
            looseText.SetActive(true);
        }
            gameOver.SetActive(true);
    }

}
