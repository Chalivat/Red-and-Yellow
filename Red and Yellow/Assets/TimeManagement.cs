using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManagement : MonoBehaviour
{
    private float frameCount;
    private int maxFrame;
    private bool isTimeStopped;
    private bool isTimeFrozen;
    void Start()
    {
        
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            FreezeTime(30);
        }
        if (isTimeFrozen)
        {
            frameCount++;
            if (frameCount >= maxFrame)
            {
                frameCount = 0;
                TimeGo();
                isTimeFrozen = false;
            }
        }
    }

    public void FreezeTime(int length)
    {
        maxFrame = length;
        isTimeFrozen = true;
        Time.timeScale = 0.02f;
        Time.fixedDeltaTime = 0.02f * Time.timeScale;
    }

    public void TimeStop()
    {
        
    }
    public void TimeGo()
    {
        Time.timeScale = 1;
        Time.fixedDeltaTime = 0.02f;
    }
}
