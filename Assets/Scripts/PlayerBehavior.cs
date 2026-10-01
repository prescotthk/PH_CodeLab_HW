using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBehavior : MonoBehaviour
{
    InputAction upButton;
    InputAction downButton;
    AudioSource myCDPlayer; 
    InputAction leftButton;
    InputAction rightButton;
    Vector3 startingPosition;
    public float speed = 2; 
    private float startingSpeed = 0;
    public GameObject power;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        upButton = InputSystem.actions.FindAction("Up");
        downButton = InputSystem.actions.FindAction("Down");
        leftButton = InputSystem.actions.FindAction("Left");
        rightButton = InputSystem.actions.FindAction("Right");
        
        myCDPlayer = GetComponent<AudioSource>();

        startingPosition = transform.position;

        startingSpeed = speed;

    }

    // Update is called once per frame
    void Update()
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
            //transform.position = startingPosition;
            ResettingPosition();
        }

        if(other.CompareTag("PowerUp"))
        {
            Debug.Log("I'm Fast!");
            speed += 3;
            power.SetActive(false);
        }
        
    }
    public void ResettingPosition()
    {
        transform.position = startingPosition;
        power.SetActive(true);
        speed = startingSpeed;
    }
}
