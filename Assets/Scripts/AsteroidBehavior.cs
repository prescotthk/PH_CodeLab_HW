using UnityEngine;

public class AsteroidBehavior : MonoBehaviour
{
    /*public Transform rightEnd;
    public Transform leftEnd;
    public float meteorSpeed = 2.0f;
    private bool straight = true;
    public bool bouncingAsteroid = false;
    public bool chasingAsteroid = false;
    public GameObject thePlayer;
    private bool chasing = false;

    // Update is called once per frame
    void Update()
    {
       if(chasingAsteroid)
        {
            float distance = Vector3.Distance(thePlayer.transform.position,transform.position);
            if(distance <= 3)
            {
                chasing = true;
                transform.position = Vector3.MoveTowards(transform.position, thePlayer.position, meteorSpeed * Time.deltaTime);
            }
            if(chasing)
            {
                if(distance > 3)
                {
                    chasing = false;
                    float newX = Random.Range(-8f,8f);
                    float newY = Random.Range(-5.5f,2.5f);
                    transform.position = new Vector3(newX,newY,transform.position.z);
                }
            }
        }                                         
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
    }*/
}
