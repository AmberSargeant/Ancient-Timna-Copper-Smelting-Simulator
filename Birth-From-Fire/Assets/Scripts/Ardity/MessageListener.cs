/**
 * Ardity (Serial Communication for Arduino + Unity)
 * Author: Daniel Wilches <dwilches@gmail.com>
 *
 * This work is released under the Creative Commons Attributions license.
 * https://creativecommons.org/licenses/by/2.0/
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
/**
 * When creating your message listeners you need to implement these two methods:
 *  - OnMessageArrived
 *  - OnConnectionEvent
 */

//Need to refactor this entire script lol
public class MessageListener : MonoBehaviour
{
    public GameObject flame1, flame2, flame3, flame4, flame5;
    public Image progressBar;
    public TMP_Text countText;
    public GameObject breatheIn;
    public GameObject breatheOut;
    public GameObject progress;
    private int temperature;
    private bool decreasing = false;
    private bool setOnce = false;
    private int previousTemperature;
    private int StartingTemperature;
    private float currentFillValue;
    [SerializeField]
    float speed;


    // Invoked when a line of data is received from the serial device.


    public void OnMessageArrived(string msg)
    {
        string[] msgSplit = msg.Split(' ');
        temperature = int.Parse(msgSplit[0]);
    }

    // Invoked when a connect/disconnect event occurs. The parameter 'success'
    // will be 'true' upon connection, and 'false' upon disconnection or
    // failure to connect.
    void OnConnectionEvent(bool success)
    {
        if (success)
            Debug.Log("Connection established");
        else
            Debug.Log("Connection attempt failed or disconnection detected");
    }



    void Start()
    {
        StartingTemperature = temperature;
        InvokeRepeating("SetVariable", 0, 0.1f);
    }
  
    void SetVariable()
    {
        previousTemperature = temperature;
    }

    // Update is called once per frame
    void Update()
    {
        if (temperature != 0)
        {
            if (!setOnce)
            {
                StartingTemperature = temperature;
                setOnce = true;
            }
        }
        //print(StartingTemperature + " Starting Temperature " + temperature + " Temperature" + previousTemperature + " PreviousTemperature");
        //print(decreasing + " Decreasing");
        //print(currentFillValue + " Current Fill Value");
        if (temperature != 0 && StartingTemperature != 0)
        {
            if (!decreasing)
            {
                decreasing = false;
                if (temperature > StartingTemperature + 1)
                {
                    currentFillValue = currentFillValue + 1 * speed * Time.deltaTime;
                }
            }
            if (temperature < previousTemperature)
            {
                decreasing = true;
            }
            if (decreasing)
            {
                if (currentFillValue >= 0)
                {
                    currentFillValue = currentFillValue - 1 * speed * Time.deltaTime;
                }
                if (temperature == previousTemperature)
                {
                    if (currentFillValue >= 0)
                    {
                        currentFillValue = currentFillValue - 1 * speed * Time.deltaTime;
                    }
                }
                if (progressBar.fillAmount == 0)
                {
                    setOnce = false;
                    decreasing = false;
                }
            }
        }
        
           progressBar.fillAmount = currentFillValue / 100;
        //    if (fillCounter <= 4)
        //    {
        //        if (temperature != 0)
        //        {
        //            if (!startTimer)
        //            {
        //                //currentValue = temperature;
        //                //startTimer = true;
        //            }
        //        }
        //        if (temperature > 0 && currentValue > 0)
        //        {
        //            if (temperature > currentValue)
        //                if (!fill)
        //                {
        //                    breatheIn.SetActive(false);
        //                    breatheOut.SetActive(true);
        //                    if (firstCount)
        //                    {
        //                        if (counter <= 949)
        //                        {
        //                            counterSpeed = 90f;
        //                            counter = (int)(counter + 1 * counterSpeed * Time.deltaTime);
        //                            countText.text = counter + "°F";
        //                        }
        //                    }
        //                    if (secondCount)
        //                    {
        //                        if (counter <= 1049)
        //                        {
        //                            counterSpeed = 88.5f;
        //                            counter = (int)(counter + 1 * counterSpeed * Time.deltaTime);
        //                            countText.text = counter + "°F";
        //                        }
        //                    }

        //                    if (thirdCount)
        //                    {
        //                        if (counter <= 1149)
        //                        {
        //                            counterSpeed = 88.5f;
        //                            counter = (int)(counter + 1 * counterSpeed * Time.deltaTime);
        //                            countText.text = counter + "°F";
        //                        }
        //                    }

        //                    if (fourthCount)
        //                    {
        //                        if (counter <= 1249)
        //                        {
        //                            counterSpeed = 88.5f;
        //                            counter = (int)(counter + 1 * counterSpeed * Time.deltaTime);
        //                            countText.text = counter + "°F";
        //                        }
        //                    }
        //                    currentFillValue = currentFillValue + 1 * speed * Time.deltaTime;

        //                }

        //            progressBar.fillAmount = currentFillValue / 100;
        //        }

        //        if (progressBar.fillAmount == 1)
        //        {
        //            //startTimer = false;
        //            decrease = true;
        //            fillCounter++;
        //        }

        //        if (decrease)
        //        {
        //            fill = true;
        //            currentFillValue = currentFillValue - 1 * speed * Time.deltaTime;
        //            breatheIn.SetActive(true);
        //            breatheOut.SetActive(false);
        //            if (progressBar.fillAmount == 0)
        //            {
        //                fill = false;
        //                decrease = false;
        //            }
        //        }

        //    }

        //    if (fillCounter == 1)
        //    {
        //        firstCount = false;
        //        secondCount = true;
        //        flame1.SetActive(false);
        //        flame2.SetActive(true);

        //    }
        //    if (fillCounter == 2)
        //    {
        //        secondCount = false;
        //        thirdCount = true;
        //        flame2.SetActive(false);
        //        flame3.SetActive(true);

        //    }
        //    if (fillCounter == 3)
        //    {
        //        thirdCount = false;
        //        fourthCount = true;
        //        flame3.SetActive(false);
        //        flame4.SetActive(true);

        //    }
        //    if (fillCounter == 4)
        //    {
        //        fourthCount = false;
        //        fifthCount = true;
        //        flame4.SetActive(false);
        //        flame5.SetActive(true);

        //    }
        //}
    }
}