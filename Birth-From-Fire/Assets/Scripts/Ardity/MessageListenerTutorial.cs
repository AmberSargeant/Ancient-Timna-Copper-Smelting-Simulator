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
public class MessageListenerTutorial : MonoBehaviour
{
    public Image progressBar;
    public GameObject breatheOut;
    public GameObject stoppedBreathing;
    public bool finishedBreathing = false;
    public bool startBreathing = false;
    private int temperature;
    private AudioManager audioManager;
    private bool decreasing = false;
    private bool continueDecreasing = false;
    private bool setOnce = false;
    private bool timerIsRunning = false;
    private bool startTimer = false;
    private bool atStart = false;
    private bool increasing = false;
    private int previousTemperature;
    private int StartingTemperature;
    private float currentFillValue;
    [SerializeField]
    private float timeRemaining = 1.3f;
    [SerializeField]
    private float speed;


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
        audioManager = FindObjectOfType<AudioManager>();
        StartingTemperature = temperature;
        InvokeRepeating("SetVariable", 0, 0.1f);
    }

    void SetVariable()
    {
        previousTemperature = temperature;
    }

    void StartTimer()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
            }
            else
            {
                timeRemaining = 0;
                timerIsRunning = false;
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        StartTimer();
        print("Starting Temperature " + StartingTemperature + " Prev Temperature " + previousTemperature + " Temperature " + temperature);
        print(startBreathing);
        if (startBreathing)
        {
            if (temperature != 0)
            {
                if (!setOnce)
                {
                    StartingTemperature = temperature;
                    setOnce = true;
                }
            }
            if (temperature != 0 && StartingTemperature != 0)
            {
                if (!decreasing)
                {
                    decreasing = false;
                    if (temperature > StartingTemperature + 1)
                    {
                        increasing = true;
                        startTimer = false;
                        atStart = false;
                        if (increasing)
                        {
                            progressBar.color = Color.cyan;
                            currentFillValue = currentFillValue + 1 * speed * Time.deltaTime;
                            if (temperature == previousTemperature)
                            {
                                currentFillValue = currentFillValue + 1 * speed * Time.deltaTime;

                            }
                        }
                    }
                    if (temperature > previousTemperature)
                    {
                        timeRemaining = 1.3f;
                    }
                }
                if (temperature < previousTemperature)
                {
                    increasing = false;
                    if (!atStart)
                    {
                        startTimer = true;
                    }
                    if (startTimer)
                    {
                        timerIsRunning = true;
                        startTimer = false;
                    }
                    if (timeRemaining == 0 && !increasing)
                    {
                        decreasing = true;
                        if (!continueDecreasing)
                        {
                            stoppedBreathing.SetActive(true);
                            breatheOut.SetActive(false);
                        }
                    }
                }
                if (decreasing)
                {
                    progressBar.color = Color.gray;
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
                    if (progressBar.fillAmount <= 0)
                    {
                        //added
                        stoppedBreathing.SetActive(false);
                        //-----;
                        breatheOut.SetActive(true);
                        setOnce = false;
                        startTimer = false;
                        decreasing = false;
                        atStart = true;
                        timeRemaining = 1.3f;
                        continueDecreasing = false;
                    }
                }
            }
        }

        progressBar.fillAmount = currentFillValue / 100;

        if (progressBar.fillAmount <= 0)
        {
            atStart = true;
        }

        if (progressBar.fillAmount >= 0.9)
        {
            startBreathing = false;
            finishedBreathing = true;
        }
    }
}