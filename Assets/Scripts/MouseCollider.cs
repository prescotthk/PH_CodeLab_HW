using System;
using NUnit.Framework.Constraints;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class MouseCollider: MonoBehaviour
{
    private bool isSprite = false;
    private bool isWrongDrink = false;
    private bool isCider = false;
    private GameObject currentObject;
    private InputAction leftClick;
    public TMP_Text scoreText;
    private int score;
    public AudioSource spriteFound;
    public AudioSource wrongDrink;
    private bool timeForCider = true;
    public GameObject cider;
    public GameObject fanta;
    private int progressScore = 0;
    public GameObject gameOver;

    void Start()
    {
        leftClick = InputSystem.actions.FindAction("LeftClick");
        scoreText.text = ("Current Score: " + score.ToString());
        Cursor.visible = false;
    }
    
    // Update is called once per frame
    void Update()
    {
        if (leftClick.WasPressedThisDynamicUpdate() && isSprite)
        {
            Debug.Log("Pressed");
            Destroy(currentObject.gameObject);
            score++;
            progressScore++;
            scoreText.text = ("Current Score: " + score.ToString());
            spriteFound.Play();
        }
        if (leftClick.WasPressedThisDynamicUpdate() && isWrongDrink)
        {
            Debug.Log("Pressed");
            Destroy(currentObject.gameObject);
            score--;
            scoreText.text = ("Current Score: " + score.ToString());
            wrongDrink.Play();
        }
        if (leftClick.WasPressedThisDynamicUpdate() && isCider)
        {
            Debug.Log("Pressed Cider");
            if (timeForCider)
            {
                Debug.Log("Pressed");
                cider.SetActive(false);
                fanta.SetActive(true);
                timeForCider = false;
                score--;
                scoreText.text = ("Current Score: " + score.ToString());
                wrongDrink.Play();   
            }
            else
            {
                Debug.Log("Pressed");
                cider.SetActive(true);
                fanta.SetActive(false);
                timeForCider = true;
                score--;
                scoreText.text = ("Current Score: " + score.ToString());
                wrongDrink.Play();
            }
        }

        if (progressScore == 10)
        {
            gameOver.SetActive(true);
            cider.SetActive(false);
            fanta.SetActive(false);
            scoreText.text = ("");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Sprite"))
        {
            Debug.Log(other.name);
            isSprite = true;
            currentObject = other.gameObject;
        }
        if (other.CompareTag("7Up"))
        {
            Debug.Log(other.name);
            isWrongDrink = true;
            currentObject = other.gameObject;
        }
        if (other.CompareTag("Cider"))
        {
            Debug.Log(other.name);
            isCider = true;
            currentObject = other.gameObject;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Sprite"))
        {
            isSprite = false;
            currentObject = null;
        }
        if (other.CompareTag("7Up"))
        {
            Debug.Log(other.name);
            isWrongDrink = false;
            currentObject = null;
        }
        if (other.CompareTag("Cider"))
        {
            Debug.Log(other.name);
            isCider = false;
            currentObject = null;
        }
    }
}
