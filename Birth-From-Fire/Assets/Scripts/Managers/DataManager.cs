using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DataManager : MonoBehaviour
{
    public Camera cam;
    private int startTime = 0;
    private int storestartTime = 0;
    private float dataTimer1;
    private float data1TimerDelayAmount = 1;
    private float focusingTime;
    private bool collectFocusingTime = false;
    private MessageListener messageListener;

    void Start()
    {
        messageListener = FindObjectOfType<MessageListener>();
    }



    void Update()
    {
        Ray ray = cam.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));
        RaycastHit hit;

        if (messageListener.startBreathing)
        {
            if (Physics.Raycast(ray, out hit))
            {
                //calculate Data Set 1
                if (hit.transform.name == "FurnaceData")
                {
                    collectFocusingTime = true;
                    dataTimer1 += Time.deltaTime;
                    if (dataTimer1 >= data1TimerDelayAmount)
                    {
                        dataTimer1 = 0f;
                        startTime++;
                    }
                }
                else
                {
                    if (collectFocusingTime)
                    {
                        focusingTime += startTime;
                        startTime = 0;
                        collectFocusingTime = false;
                    }
                }
            }
            //print("FocusingTime: " + focusingTime);
            //print("StartTime: " + startTime);
        }
    }
}
