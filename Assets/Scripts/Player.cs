using System;
using NUnit.Framework.Constraints;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    private InputAction moveInput;

    private Vector2 inputForce;

    public float speed;
    
    //public float force;

    public Rigidbody2D myBody;
    public GameObject goomba;
    public float jumpPower;

    public Transform groundChecker;
    public float checkSize;
    public LayerMask groundLayer;
    public LayerMask hazardLayer;
    public LayerMask goombaLayer;
    private bool onGround = false;
    private bool onHazard = false;
    private bool canJump = false;
    public GameManager myManager;
    private bool goombaDestroyed = false;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moveInput = InputSystem.actions.FindAction("Move");
    }

    // Update is called once per frame
    void Update()
    {
        if(myManager.canMove)
        {
            inputForce = moveInput.ReadValue<Vector2>();
        }
        else
        {
            
        }
    }

    private void FixedUpdate()
    {
        if (onHazard = Physics2D.OverlapCircle(groundChecker.position, checkSize, goombaLayer))
        {
            myManager.goombaDestroyed();
        }
        //myBody.AddForce(inputForce * force);
        myBody.linearVelocityX = inputForce.x * speed;
        if (inputForce.y > 0 && canJump)
        {
            myBody.linearVelocityY = inputForce.y * jumpPower;
            onGround = false;
            onHazard = false;
            canJump = false;
        }
        else if (inputForce.y > 0 && canJump)
        {
            myBody.linearVelocityY = inputForce.y * jumpPower;
            onGround = false;
            onHazard = false;
            canJump = false;
        }
        else
        {
            onGround = Physics2D.OverlapCircle(groundChecker.position, checkSize, groundLayer);
            onHazard = Physics2D.OverlapCircle(groundChecker.position, checkSize, hazardLayer);
            if (onHazard || onGround)
            {
                canJump = true;
            }
        }

        if (onHazard)
        {
            myManager.takenDamage();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Goomba"))
        {
            if (myManager.byeGoomba == false)
            {
                myManager.takenDamage();
            }
            else
            {
                goombaDestroyed = false;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        GameObject otherObject = other.gameObject;
        if (other.CompareTag("Trophy"))
        {
            Destroy(otherObject);
            Debug.Log("You Won");
        }
        else if (other.CompareTag("Teleporter"))
        {
            Debug.Log("Teleported");
            myManager.teleportPlayer();
        }
        else if (other.CompareTag("ToK"))
        {
            myManager.triggerHitbox();
        }
        else if (other.CompareTag("DeathBox"))
        {
            myManager.toSpawn();
        }
        else if (other.CompareTag("GreenButton"))
        {
            myManager.gameEnd();
        }
        
    }
}
