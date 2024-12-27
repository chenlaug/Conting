using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI timeText;
    public GameObject gameOverPanel;
    public GameObject DuringPanel;
    public GameObject PausePanel;
    public GameObject BeforePanel;
    [SerializeField] public int isGameActive;


    [SerializeField] private int score = 0;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(UpdateTimer(60));
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameActive == 0) // before game
        {
            DuringPanel.SetActive(false);
            PausePanel.SetActive(false);
            BeforePanel.SetActive(true);
            gameOverPanel.SetActive(false);
        }
        else if (isGameActive == 1) // during game
        {
            DuringPanel.SetActive(true);
            PausePanel.SetActive(false);
            BeforePanel.SetActive(false);
            gameOverPanel.SetActive(false);
        }

        else if (isGameActive == 3) // game over
        {
            DuringPanel.SetActive(false);
            PausePanel.SetActive(false);
            BeforePanel.SetActive(false);
            gameOverPanel.SetActive(true);
        }
    }
    public void UpdateScore(int Add)
    {
        score += Add;
        scoreText.text = $"Score : {score}";
    }

    IEnumerator UpdateTimer(int timeLeft)
    {
        while (timeLeft > 0)
        {
            timeText.text = $"Time : {timeLeft}";
            yield return new WaitForSeconds(1);
            timeLeft--;
        }
        GameOver();
    }

    public void GameOver()
    {
        isGameActive = 3;
    }

}


