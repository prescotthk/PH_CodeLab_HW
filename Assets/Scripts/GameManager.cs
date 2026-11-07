using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    public GameObject startingPlatform;

    public GameObject player;
    public GameObject goomba;
    public GameObject firstBall;

    public GameObject firstHinge;

    public Transform spawnPoint;

    public GameObject endScreen;

    public bool canMove = true;

    public bool gameActive = true;

    public float playerHP = 3f;

    public float graceTimer = 0f;

    public bool canTakeDamage = true;

    public bool immuneTimer = false;

    public bool byeGoomba = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Update()
    {
        if(gameActive == false)
        {
            if (Keyboard.current.spaceKey.wasPressedThisFrame)
            {
                gameStart();
            }
        }

        if (immuneTimer)
        {
            graceTimer += Time.deltaTime;
            if (graceTimer >= 3f)
            {
                canTakeDamage = true;
                immuneTimer = false;
                graceTimer = 0f;
            }
        }
    }

    public void takenDamage()
    {
        if (canTakeDamage)
        {
            playerHP -= 1f;
            Debug.Log("playerHP: " + playerHP);
            if (playerHP <= 0f)
            {
                toSpawn();
            }
            else
            {
                canTakeDamage = false;
                immuneTimer = true;
            }
        }
    }
    
    public void firstStage()
    {
        startingPlatform.SetActive(false);
        Debug.Log("Triggered");
    }

    public void teleportPlayer()
    {
        player.transform.position = new Vector3(-7.43f, 3.28f, 0f);
    }

    public void triggerHitbox()
    {
        firstBall.GetComponent<Rigidbody2D>().isKinematic = false;
        firstHinge.GetComponent<Rigidbody2D>().isKinematic = false;
    }

    public void toSpawn()
    {
        player.transform.position = spawnPoint.position;
        playerHP = 3f;
        goomba.SetActive(true);
        byeGoomba = false;
    }

    public void gameEnd()
    {
        endScreen.SetActive(true);
        gameActive = false;
        canMove = false;
    }

    public void gameStart()
    {
        endScreen.SetActive(false);
        toSpawn();
        gameActive = true;
        canMove = true;
        goomba.SetActive(true);
    }

    public void goombaDestroyed()
    {
        goomba.SetActive(false);
        byeGoomba = true;
    }
}
