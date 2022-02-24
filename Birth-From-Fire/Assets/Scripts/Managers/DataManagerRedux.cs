using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public class DataManagerRedux : MonoBehaviour
{
    public Camera cam;
    private int startTime = 0;
    private int storestartTime = 0;
    private float dataTimer1 = 0;
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
    // Start is called before the first frame update
    void Start()
    {
        messageListener = FindObjectOfType<MessageListener>();
        eventManager = FindObjectOfType<EventManager>();
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = cam.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));
        RaycastHit hit;

        if (messageListener.startBreathing)
        {
            //first data
            if (Physics.Raycast(ray, out hit))
            {
                dataTimer1 += Time.deltaTime;
                if (dataTimer1 >= data1TimerDelayAmount)
                {
                    print("reached");
                    string path = Application.dataPath + "/TestLogFocusingTime.txt";
                    if (!File.Exists(path))
                    {
                        File.WriteAllText(path, "Test Log \n \n");
                    }

                    string content = "TimeStamp " + System.DateTime.Now
                    + " Looking At: " + hit.transform.name + "\n";

                    File.AppendAllText(path, content);

                    dataTimer1 = 0;

                }
            }
        }
    }
}
