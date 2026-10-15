using UnityEngine;
using UnityEngine.InputSystem;

public class MouseScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());

        transform.position = new Vector3(mousePosition.x, mousePosition.y, transform.position.z);   
    }
}
