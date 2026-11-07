using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform targetSprite;
    private Vector3 cameraOffset = new Vector3(0, 0, -10f);

    // Update is called once per frame
    void Update()
    {
        Vector3 targetDest = targetSprite.position + cameraOffset;
        transform.position = targetDest;
    }
}
