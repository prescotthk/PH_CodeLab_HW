using System;
using System.Runtime.CompilerServices;
using System.Threading;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;
using System.Collections;

public class FollowMouse : MonoBehaviour
{
    Vector2 positionTracker;
    [SerializeField] public float followSpeed = 50.0f;
    [SerializeField] private float trackingSpeed = 0.25f;
    //private Vector2 refPosition = Vector2.zero;
    private float waitTime = 3.0f;
    public GameObject ballToSpawn;

    void Start()
    {
        //Cursor.visible = false;
        StartCoroutine(SpawnBall(waitTime));
    }
    
    IEnumerator SpawnBall(float w)
    {
        while (false)
        {
            Debug.Log("We are waiting...");
            yield return new WaitForSeconds(w);
            Instantiate(ballToSpawn, transform.position, Quaternion.identity);
            Debug.Log("We are done waiting...");
        }
    }
 
    
    void Following()
    {
        positionTracker = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        //transform.position = positionTracker;
        transform.position = Vector2.Lerp(transform.position, positionTracker, Time.deltaTime * followSpeed);
        //transform.position = Vector2.SmoothDamp(transform.position, positionTracker, ref refPosition, trackingSpeed);
    }
    // Update is called once per frame
    void Update()
    {
        Following();

    }
}
