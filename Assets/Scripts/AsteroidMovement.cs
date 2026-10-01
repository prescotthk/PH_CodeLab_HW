using UnityEngine;

public class AsteroidMovement : MonoBehaviour
{
    public Transform rightEnd;
    public Transform leftEnd;
    private float meteorSpeed = 2;
    private bool straight = true;
    public bool bouncingAsteroid = false;
    public bool chasingAsteroid = false;
    public Transform thePlayer;
    private bool chasing = false;
    public float detectionRange = 3.5f;

void Start()
    {
        meteorSpeed = Random.Range(2,4);
    }

    // Update is called once per frame
    void Update()
    {
       if(chasingAsteroid)
        {
            float distance = Vector3.Distance(thePlayer.transform.position,transform.position);
            if(distance <= detectionRange)
            {
                chasing = true;
                transform.position = Vector3.MoveTowards(transform.position, thePlayer.position, meteorSpeed * Time.deltaTime);
            }
            if(chasing)
            {
                if(distance > detectionRange)
                {
                    chasing = false;
                    float newX = Random.Range(-8f,8f);
                    float newY = Random.Range(-3f,2.5f);
                    transform.position = new Vector3(newX,newY,transform.position.z);
                }
            }
        }                                         
            if(chasingAsteroid)
                {
                    
                }
            else{
                if(straight)
                {
                    transform.position = Vector3.MoveTowards(transform.position, rightEnd.position, meteorSpeed * Time.deltaTime);
                    if(transform.position == rightEnd.position)
                        {
                            straight = false;
                        }
                }
                else
                {
                    if(bouncingAsteroid)
                    {
                        transform.position = Vector3.MoveTowards(transform.position, leftEnd.position, meteorSpeed * Time.deltaTime);
                        if(transform.position == leftEnd.position)
                            {
                            straight = true;
                            } 
                    }
                    else
                    {
                        transform.position = leftEnd.position;
                        straight = true;
                    }
                }
            }
    }
}
