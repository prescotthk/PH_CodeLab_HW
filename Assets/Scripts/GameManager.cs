using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TMP_Text timerText;
    public TMP_Text highscoreText;
    public TMP_Text secondText;
    public TMP_Text thirdText;
    public TMP_Text fourthText;
    public TMP_Text fifthText;
    public TMP_Text lastScoreText;
    public GameObject hsText;
    public bool timerActive = false;
    public float totalTime = 0f;
    public GameObject finishArea;
    public float currentScore = 0f;
    public float highestScore = 0f;
    public float secondScore = 0f;
    public float thirdScore = 0f;
    public float fourthScore = 0f;
    public float fifthScore = 0f;
    public float lastScore = 0f;
    public GameObject startingArea;
    public GameObject gameEnd;
    public bool firstEnd = true;
    public bool firstSecond = true;
    public bool firstThird = true;
    public bool firstFourth = true;
    public bool firstFifth = true;
    public bool touchedEnd = false;
    public GameObject timerTxt;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startingArea.SetActive(true);
        timerActive = false;
        finishArea.SetActive(false);
        gameEnd.SetActive(false);
        hsText.SetActive(false);
        timerTxt.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timerActive)
        {
            totalTime += Time.deltaTime;
            timerText.text = totalTime.ToString("F2");
        }
        if (currentScore == 800)
        {
            finishArea.SetActive(true);
        }
    }

    public void StopTimer()
    {
        hsText.SetActive(true);
        timerActive = false;
        gameEnd.SetActive(true);
        timerTxt.SetActive(false);
        if (touchedEnd)
        {
            lastScore = totalTime;
            
            if (firstEnd)
            {
                highestScore = totalTime;
                firstEnd = false;
            }
            else if (totalTime == 100)
            {

            }

            else if (totalTime <= highestScore)
            {
                fifthScore = fourthScore;
                fourthScore = thirdScore;
                thirdScore = secondScore;
                secondScore = highestScore;
                highestScore = totalTime;
            }
            else if (firstSecond)
            {
                secondScore = totalTime;
                firstSecond = false;
            }
            else if (totalTime <= secondScore)
            {
                fifthScore = fourthScore;
                fourthScore = thirdScore;
                thirdScore = secondScore;
                secondScore = totalTime;
            }
            else if (firstThird)
            {
                thirdScore = totalTime;
                firstThird = false;
            }
            else if (totalTime <= thirdScore)
            {
                fifthScore = fourthScore;
                fourthScore = thirdScore;
                thirdScore = totalTime;
            }
            else if (firstFourth)
            {
                fourthScore = totalTime;
                firstFourth = false;
            }
            else if (totalTime <= fourthScore)
            {
                fifthScore = fourthScore;
                fourthScore = totalTime;
            }
            else if (firstFifth)
            {
                fifthScore = totalTime;
                firstFifth = false;
            }
            else if (totalTime <= fifthScore)
            {
                fifthScore = totalTime;
            }

            touchedEnd = false;
        }
        
        lastScoreText.text = lastScore.ToString("F2");
        lastScore = 0f;
        currentScore = 0f;
        totalTime = 0f;
        highscoreText.text = highestScore.ToString("F2");
        secondText.text = secondScore.ToString("F2");
        thirdText.text = thirdScore.ToString("F2");
        fourthText.text = fourthScore.ToString("F2");
        fifthText.text = fifthScore.ToString("F2");
        hsText.SetActive(true);
    }

    public void GameStart()
    {
        timerActive = true;
        startingArea.SetActive(false);
        gameEnd.SetActive(false);
        hsText.SetActive(false);
        timerTxt.SetActive(true);
    }
}
