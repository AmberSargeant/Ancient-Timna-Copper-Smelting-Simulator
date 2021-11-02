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
    public GameObject breatheIn;
    public GameObject breatheOut;
    float temperature;
    bool startTimer = false;
    bool fill = false;
    bool decrease = false;
    float currentValue;
    float currentFillValue;
    [SerializeField]
    int fillCounter = 0;
    [SerializeField]
    float speed;
    // Invoked when a line of data is received from the serial device.


    public void OnMessageArrived(string msg)
    {
        string[] msgSplit = msg.Split(' ');
        temperature = float.Parse(msgSplit[0]);
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
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        print(temperature + "Temperature");
        print(currentValue + "Current Value");
        if (fillCounter <= 4)
        {
            if (temperature != 0)
            {
                if (!startTimer)
                {
                    currentValue = temperature;
                    startTimer = true;
                }
            }
            if (temperature > 0 && currentValue > 0)
            {
                if (temperature >= currentValue + 0.01f)
                    if(!fill)
                {
                        breatheIn.SetActive(false);
                        breatheOut.SetActive(true);
                        currentFillValue = currentFillValue + 1 * speed * Time.deltaTime;
                }

                progressBar.fillAmount = currentFillValue / 100;
            }

            if (progressBar.fillAmount == 1)
            {
                decrease = true;
                fillCounter++;
            }

            if (decrease)
            {
                fill = true;
                currentFillValue = currentFillValue - 1 * speed * Time.deltaTime;
                breatheIn.SetActive(true);
                breatheOut.SetActive(false);
                if (progressBar.fillAmount == 0)
                {
                    fill = false;
                    decrease = false;
                }
            }

        }

        if(fillCounter == 1)
        {
            flame1.SetActive(false);
            flame2.SetActive(true);

        }
        if (fillCounter == 2)
        {
            flame2.SetActive(false);
            flame3.SetActive(true);

        }
        if (fillCounter == 3)
        {
            flame3.SetActive(false);
            flame4.SetActive(true);

        }
        if (fillCounter == 4)
        {
            flame4.SetActive(false);
            flame5.SetActive(true);

        }
    }

}