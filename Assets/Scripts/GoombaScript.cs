using UnityEngine;

public class GoombaScript : MonoBehaviour
{
    public Transform goombaStart;
    public Transform goombaEnd;

    private bool forward = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x == goombaStart.position.x)
        {
            forward = false;
        }
        else if (transform.position.x == goombaEnd.position.x)
        {
            forward = true;
        }
        if (forward)
        {
            transform.position = Vector3.MoveTowards(transform.position, goombaStart.position, Time.deltaTime);
        }
        else if (forward == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, goombaEnd.position, Time.deltaTime);
        }
    }
}
