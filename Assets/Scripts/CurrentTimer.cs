using UnityEngine;
using TMPro;

public class CurrentTimer : MonoBehaviour
{
    public TMP_Text timerText;
    public float totalTime = 0f;
    public GameManager myManager;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        myManager.timerActive = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (myManager.timerActive)
        {
            totalTime += Time.deltaTime;
            timerText.text = totalTime.ToString("F2");
        }
    }
}
