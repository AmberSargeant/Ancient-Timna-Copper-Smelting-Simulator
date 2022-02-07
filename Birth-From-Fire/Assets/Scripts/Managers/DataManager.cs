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
    private float totalDistractions = 0;
    private float freqOfDistractions = 0;
    private float breathPhase1Timer = 0;
    private float breathPhase2Timer = 0;
    private float breathPhase1Delay = 1;
    private float breathPhase2Delay = 1;
    private float totalBreathPhase1 = 0;
    private float totalBreathPhase2 = 0;
    private float totalBreathPhaseAll = 0;
    private Vector3 lastCamPosition;
    private Vector3 orgCamPosition;
    private bool collectFocusingTime = false;
    private bool collectData = false;
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

        if (messageListener.startBreathing)
        {
            //first data
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


            //second data

            if (eventManager.breathPhase1)
            {
                breathPhase1Timer += Time.deltaTime;
                if (breathPhase1Timer >= breathPhase1Delay)
                {
                    breathPhase1Timer = 0f;
                    totalBreathPhase1++;
                }
            }
            else if (messageListener.breathPhase2)
            {
                breathPhase2Timer += Time.deltaTime;
                if (breathPhase2Timer >= breathPhase2Delay)
                {
                    breathPhase2Timer = 0f;
                    totalBreathPhase2++;
                }
            }
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
                        if (eventManager.breathPhase1)
                        {
                            totalDistractions++;
                        }
                        else if (messageListener.breathPhase2)
                        {
                            totalDistractions++;
                        }

                        else if (lastCamPosition.y - orgCamPosition.y >= 0.03 || lastCamPosition.y - orgCamPosition.y <= -0.03)
                        {
                            if (eventManager.breathPhase1)
                            {
                                totalDistractions++;
                            }
                            else if (messageListener.breathPhase2)
                            {
                                totalDistractions++;
                            }
                        }
                        dataTimer2 = 0f;
                        lastCamPosition = orgCamPosition;
                    }
                }
            }
        }
        //export to file
        else if (messageListener.birth)
        {
            if (!collectData)
            {
                totalBreathPhaseAll = totalBreathPhase1 + totalBreathPhase2;
                freqOfDistractions = totalBreathPhaseAll / totalDistractions;
                string path = Application.dataPath + "/TestLog.txt";
                if (!File.Exists(path))
                {
                    File.WriteAllText(path, "Test Log \n \n");
                }

                string content = "Focusing Time: " + focusingTime + "\n"
                + "Frequency of Distractions: " + freqOfDistractions + "\n"
                + "Total Time for 1st Breath Phase: " + totalBreathPhase1 + "\n"
                + "Total Time for 2st Breath Phase: " + totalBreathPhase2 + "\n"
                + "Total Amount of Distractions: " + totalDistractions + "\n";

                File.AppendAllText(path, content);
                collectData = true;
            }
        }
    }
}

