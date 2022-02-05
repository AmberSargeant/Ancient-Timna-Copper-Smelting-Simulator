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
    private float dataTimer2;
    private float data2TimerDelayAmount = 1;
    private float totalDistractions;
    private float freqOfDistractions;
    private float breathPhase1Count;
    private float breathPhase2Count;
    private float totalBreathPhase;
    private Vector3 lastCamPosition;
    private Vector3 orgCamPosition;
    private bool collectFocusingTime = false;
    private bool setPosOnce = false;
    private MessageListener messageListener;
    private EventManager eventManager;

    void Start()
    {
        messageListener = FindObjectOfType<MessageListener>();
        eventManager = FindObjectOfType<EventManager>();

    }



    void Update()
    {
        Ray ray = cam.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));
        RaycastHit hit;
        //first data(working)
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

        //print("orgcampositionx " + orgCamPosition.x);
        //print("lastcampositionx " + lastCamPosition.x);

        //second data
        if (!setPosOnce)
        {
            if (cam.transform.localPosition.x > 0 && cam.transform.localPosition.y > 0)
            {
                lastCamPosition = cam.transform.localPosition;
                setPosOnce = true;
            }
        }
        if (setPosOnce)
        {
            orgCamPosition = cam.transform.localPosition;

            dataTimer2 += Time.deltaTime;
            if (dataTimer2 >= data2TimerDelayAmount)
            {
                if (lastCamPosition.x - orgCamPosition.x >= 0.05 || lastCamPosition.x - orgCamPosition.x <= -0.05)
                {
                    print("Distraction!");
                }

                else if (lastCamPosition.y - orgCamPosition.y >= 0.03 || lastCamPosition.y - orgCamPosition.y <= -0.03)
                {
                    print("Distraction!");
                }
                dataTimer2 = 0f;
                lastCamPosition = orgCamPosition;
            }
        }
    }
}

