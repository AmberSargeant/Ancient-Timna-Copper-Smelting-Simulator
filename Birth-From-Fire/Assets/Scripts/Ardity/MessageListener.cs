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
    public GameObject bar;
    public GameObject changingTemp;
    public int celciusCounter = 750;
    public bool startBreathing = false;
    private int temperature;
    private AudioManager audioManager;
    [SerializeField]
    private int fillCounter = 0;
    private bool firstCount = true;
    private bool secondCount, thirdCount, fourthCount, fifthCount;
    private bool decreasing = false;
    private bool setOnce = false;
    private bool timerIsRunning = false;
    private bool startTimer = false;
    private bool atStart = false;
    private bool increasing = false;
    private bool isCelciusTimerStarted = false;
    private bool isDCelciusTimerStarted = false;
    private int previousTemperature;
    private int StartingTemperature;
    private float currentFillValue;
    [SerializeField]
    private float timeRemaining = 1.0f;
    [SerializeField]
    private float speed;
    private IEnumerator startCelciusTimer;


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
        startCelciusTimer = StartCelciusTimer();
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

    IEnumerator StartCelciusTimer()
    {
        if (firstCount)
        {
            while (celciusCounter <= 949)
            {
                yield return new WaitForSeconds(0.022f);
                celciusCounter++;
                countText.text = celciusCounter + "°F";
                if (decreasing)
                {
                    yield break;
                }
            }
        }

        if (secondCount)
        {
            while (celciusCounter <= 1049)
            {
                yield return new WaitForSeconds(0.037f);
                celciusCounter++;
                countText.text = celciusCounter + "°F";
                if (decreasing)
                {
                    yield break;
                }
            }
        }

        if (thirdCount)
        {
            while (celciusCounter <= 1149)
            {
                yield return new WaitForSeconds(0.037f);
                celciusCounter++;
                countText.text = celciusCounter + "°F";
                if (decreasing)
                {
                    yield break;
                }
            }
        }

        if (fourthCount)
        {
            while (celciusCounter <= 1249)
            {
                yield return new WaitForSeconds(0.037f);
                celciusCounter++;
                countText.text = celciusCounter + "°F";
                if (decreasing)
                {
                    yield break;
                }
            }
        }

        if (fifthCount)
        {
            while (celciusCounter <= 1269)
            {
                yield return new WaitForSeconds(0.25f);
                celciusCounter++;
                countText.text = celciusCounter + "°F";
                if (decreasing)
                {
                    yield break;
                }
            }
        }
    }
    void StartDCelciusTimer()
    {
        if (firstCount)
        {
            if (celciusCounter >= 751)
            {
                celciusCounter = (int)(celciusCounter - 1 * Time.deltaTime);
                countText.text = celciusCounter + "°F";
                if (celciusCounter == 750)
                {
                    isDCelciusTimerStarted = false;
                }
            }
        }

        if (secondCount)
        {
            if (celciusCounter >= 951)
            {
                celciusCounter = (int)(celciusCounter - 1 * Time.deltaTime);
                countText.text = celciusCounter + "°F";
                if (celciusCounter == 950)
                {
                    isDCelciusTimerStarted = false;
                }
            }
        }

        if (thirdCount)
        {
            if (celciusCounter >= 1151)
            {
                celciusCounter = (int)(celciusCounter - 1 * Time.deltaTime);
                countText.text = celciusCounter + "°F";
                if (celciusCounter == 1150)
                {
                    isDCelciusTimerStarted = false;
                }
            }
        }

        if (fourthCount)
        {
            if (celciusCounter >= 1251)
            {
                celciusCounter = (int)(celciusCounter - 1 * Time.deltaTime);
                countText.text = celciusCounter + "°F";
                if (celciusCounter == 1250)
                {
                    isDCelciusTimerStarted = false;
                }
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        StartTimer();
        print("Starting Temperature " + StartingTemperature + " Prev Temperature " + previousTemperature + " Temperature " + temperature);
        if (startBreathing)
        {
            if (fillCounter <= 4)
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
                        if (!atStart)
                        {
                            if (!isCelciusTimerStarted)
                            {
                                StartCoroutine(StartCelciusTimer());
                                isCelciusTimerStarted = true;
                            }
                        }

                        decreasing = false;
                        if (temperature > StartingTemperature + 1)
                        {
                            increasing = true;
                            startTimer = false;
                            atStart = false;
                            if (increasing)
                            {
                                currentFillValue = currentFillValue + 1 * speed * Time.deltaTime;
                            }
                        }
                        if (temperature > previousTemperature)
                        {
                            timeRemaining = 1.0f;
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
                        }
                    }
                    if (decreasing)
                    {
                        if (isCelciusTimerStarted)
                        {
                            StopCoroutine(startCelciusTimer);
                            isCelciusTimerStarted = false;
                        }
                        if (firstCount)
                        {
                            StartDCelciusTimer();
                        }
                        if (secondCount)
                        {
                            StartDCelciusTimer();
                        }
                        if (thirdCount)
                        {
                            StartDCelciusTimer();
                        }
                        if (fourthCount)
                        {
                            StartDCelciusTimer();
                        }
                        if (fifthCount)
                        {
                            StartDCelciusTimer();
                        }
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
                            breatheIn.SetActive(false);
                            breatheOut.SetActive(true);
                            setOnce = false;
                            startTimer = false;
                            decreasing = false;
                            atStart = true;
                            timeRemaining = 1.5f;
                        }
                    }
                }

            }

            progressBar.fillAmount = currentFillValue / 100;

            if (progressBar.fillAmount <= 0)
            {
                atStart = true;
            }

            if (progressBar.fillAmount >= 0.9 && fillCounter <= 5)
            {
                breatheIn.SetActive(false);
                breatheOut.SetActive(true);
                decreasing = true;
                fillCounter++;
            }

            if (fillCounter == 1)
            {
                if (firstCount)
                {
                    audioManager.Play("Prompt sound effect after each step is completed");
                    celciusCounter = 949;
                }
                firstCount = false;
                secondCount = true;
                changingTemp.SetActive(true);
                flame1.SetActive(false);
                flame2.SetActive(true);

            }
            if (fillCounter == 2)
            {
                if (secondCount)
                {
                    audioManager.Play("Prompt sound effect after each step is completed");
                    celciusCounter = 1049;
                }
                secondCount = false;
                thirdCount = true;
                flame2.SetActive(false);
                flame3.SetActive(true);

            }
            if (fillCounter == 3)
            {
                if (thirdCount)
                {
                    audioManager.Play("Prompt sound effect after each step is completed");
                    celciusCounter = 1149;
                }
                thirdCount = false;
                fourthCount = true;
                flame3.SetActive(false);
                flame4.SetActive(true);
            }
            if (fillCounter == 4)
            {
                if (fourthCount)
                {
                    audioManager.Play("Prompt sound effect after each step is completed");
                    celciusCounter = 1249;
                }
                fourthCount = false;
                fifthCount = true;
                flame4.SetActive(false);
                flame5.SetActive(true);
            }
            if (fillCounter == 5)
            {
                if (fifthCount)
                {
                    audioManager.Play("Prompt sound effect after each step is completed");
                    celciusCounter = 1269;
                }
                fifthCount = false;
                bar.SetActive(false);
                startBreathing = false;
                CancelInvoke();
            }

        }
    }
}