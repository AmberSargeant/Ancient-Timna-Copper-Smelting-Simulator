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
    float temperature;
    bool startTimer = false;
    bool startWaitOnce ,startWaitTwo,startWaitThree,startWaitFour= false;
    bool fill = false;
    float currentValue;
    float currentFillValue;
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
        Debug.Log(temperature + "Temperature");
        Debug.Log(currentValue + "Current Value");
        Debug.Log(startTimer + "StartTimer");
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
                if (temperature >= currentValue + 5)
                    if(!fill)
                {
                    currentFillValue += speed * Time.deltaTime;
                }

                progressBar.fillAmount = currentFillValue / 100;
            }

            if (progressBar.fillAmount == 1)
            {
                fillCounter++;
                currentFillValue = 0;
                progressBar.fillAmount = 0;
            }
        }

        if(fillCounter == 1)
        {
            flame1.SetActive(false);
            flame2.SetActive(true);
            if (!startWaitOnce)
            {
                fill = true;
                startWaitOnce = true;
                StartCoroutine("Wait");
            }
        }
        if (fillCounter == 2)
        {
            flame2.SetActive(false);
            flame3.SetActive(true);
            if (!startWaitTwo)
            {
                fill = true;
                startWaitTwo = true;
                StartCoroutine("Wait");
            }
        }
        if (fillCounter == 3)
        {
            flame3.SetActive(false);
            flame4.SetActive(true);
            if (!startWaitThree)
            {
                fill = true;
                startWaitThree = true;
                StartCoroutine("Wait");
            }
        }
        if (fillCounter == 4)
        {
            flame4.SetActive(false);
            flame5.SetActive(true);
            if (!startWaitFour)
            {
                fill = true;
                startWaitFour = true;
                StartCoroutine("Wait");
            }
        }
    }
    private  IEnumerator Wait()
    {
        yield return new WaitForSeconds(3f);
        fill = false;
        
    }
}