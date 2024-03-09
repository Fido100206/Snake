using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float TimeLeft = 10;

    public Text TimerText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (TimeLeft > 0)
        {
        TimeLeft += Time.deltaTime;

       
        }

        else
        {
            Debug.Log ("Gane Over");
            TimeLeft= 0;
        }
        updateTimer(TimeLeft);
    }

    void updateTimer (float currentTime)
    {
        currentTime += 1;

        float minutes = Mathf.FloorToInt (currentTime / 60);
        float seconds = Mathf.FloorToInt (currentTime % 60);

        TimerText.text = string.Format("{0:00} : {1:00}", minutes, seconds);
    }
}
