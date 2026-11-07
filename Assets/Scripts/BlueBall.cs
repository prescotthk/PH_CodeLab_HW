using System;
using UnityEngine;

public class BlueBall : MonoBehaviour
{
    public GameManager myManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("GreenButton"));
        {
            myManager.firstStage();
        } 
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
