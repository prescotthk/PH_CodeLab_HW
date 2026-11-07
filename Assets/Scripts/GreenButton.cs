using System;
using UnityEngine;

public class GreenButton : MonoBehaviour
{
    public GameManager myManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "BlueBall");
        {
            myManager.firstStage();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
