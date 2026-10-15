using UnityEngine;

public class MoveBetweens : MonoBehaviour
{
    public Transform itemStart;
    public Transform itemEnd;

    private bool toStart = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (toStart)
        {
            transform.position = Vector3.MoveTowards(transform.position, itemEnd.position, 3 * Time.deltaTime);
            if (transform.position == itemEnd.position)
            {
                toStart = false;
            }
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, itemStart.position, 3 * Time.deltaTime);
            if (transform.position == itemStart.position)
            {
                toStart = true;
            }
        }
    }
}
