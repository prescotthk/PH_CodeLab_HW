using UnityEngine;
using UnityEngine.EventSystems;

public class MouseInteractions : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    private bool canClick = false;
    public GameObject ballToSpawn;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void OnPointerEnter(PointerEventData p)
    {
        //Debug.Log("Entered: " + gameObject.name + ". Yay! We did it");
        Debug.Log($"Entered {gameObject.name}. Yay! We did it");
        canClick = true;
    }

    public void OnPointerExit(PointerEventData p)
    {
        Instantiate(ballToSpawn,transform.position,Quaternion.identity);
        canClick = false;
    }

    public void OnPointerClick(PointerEventData p)
    {
        
    }
}
