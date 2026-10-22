using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBehavior : MonoBehaviour
{
    InputAction upButton;
    InputAction downButton;
    AudioSource myCDPlayer; 
    InputAction leftButton;
    InputAction rightButton;
    InputAction spaceButton;
    Vector3 startingPosition;
    public float speed = 5; 
    private float startingSpeed = 0f;
    private float currentScore = 0f;
    private float highestScore = 0f;
    public GameObject power;
    public GameObject pointOne;

    public GameObject pointTwo;
    public GameObject pointThree;

    public GameObject pointFour;

    public GameObject pointFive;

    public GameObject pointSix;

    public GameObject pointSeven;
    public GameObject pointEight;
    public GameManager myManager;
    public bool spacePressed = false;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        upButton = InputSystem.actions.FindAction("Up");
        downButton = InputSystem.actions.FindAction("Down");
        leftButton = InputSystem.actions.FindAction("Left");
        rightButton = InputSystem.actions.FindAction("Right");
        spaceButton =  InputSystem.actions.FindAction("Space");
        
        myCDPlayer = GetComponent<AudioSource>();

        startingPosition = transform.position;

        startingSpeed = speed;

    }

    // Update is called once per frame
    void Update()
    {
        if (spaceButton.IsPressed())
        {
            if (spacePressed)
            {
                
            }
            else
            {
                myManager.GameStart();
                spacePressed = true;
            }
        }
            
        if (myManager.timerActive)
        {
            Vector3 playerPosition = transform.position;
            if (upButton.IsPressed())
            {
                playerPosition.y += speed * Time.deltaTime;
                Debug.Log("go up");
            }

            if(downButton.IsPressed())
            {
                playerPosition.y -= speed * Time.deltaTime;
                Debug.Log("go down");
            }

            if (leftButton.IsPressed())
            {
                playerPosition.x -= speed * Time.deltaTime;
                Debug.Log("go left");
            }
        
            if(rightButton.IsPressed())
            {
                playerPosition.x += speed * Time.deltaTime;
                Debug.Log("go right");                
            }

            playerPosition.x = Mathf.Clamp(playerPosition.x,-9f,9f);

            playerPosition.y = Mathf.Clamp(playerPosition.y,-6.5f,3.5f);

            transform.position = playerPosition;
        }
    }

    void OnTriggerEnter(Collider other)
    {
         if(other.CompareTag("AsteroidContact"))
        {
            myCDPlayer.Play();
            Debug.Log("Ouch!");
            //transform.position = startingPosition;
            ResettingPosition();
        }

        if(other.CompareTag("FC4"))
        {
            myCDPlayer.Play();
            Debug.Log("Ouch!");
            //transform.position = startingPosition;
            ResettingPosition();
        }

        if(other.CompareTag("Finish"))
        {
            Debug.Log("I Won!");
            myManager.touchedEnd = true;
            //transform.position = startingPosition;
            ResettingPosition();
        }

        if(other.CompareTag("PowerUp"))
        {
            Debug.Log("I'm Fast!");
            speed += 3;
            GameObject powerUp = other.gameObject;
            powerUp.SetActive(false);
        }
        
        if(other.CompareTag("Points"))
        {
            Debug.Log("Points Gained");
            myManager.currentScore += 100;
            GameObject point = other.gameObject;
            point.SetActive(false);
        }
        
    }
    public void ResettingPosition()
    {
        transform.position = startingPosition;
        power.SetActive(true);
        pointOne.SetActive(true);
        pointTwo.SetActive(true);
        pointThree.SetActive(true);
        pointFour.SetActive(true);
        pointFive.SetActive(true);
        pointSix.SetActive(true);
        pointSeven.SetActive(true);
        pointEight.SetActive(true);
        myManager.currentScore = 0f;
        speed = startingSpeed;
        spacePressed = false;
        myManager.finishArea.SetActive(false);
        myManager.StopTimer();
        
    }
}
