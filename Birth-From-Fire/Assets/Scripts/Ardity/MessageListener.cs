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
    public GameObject furnaceFlame;
    public GameObject greenFlame;
    public int celciusCounter = 750;
    public bool startBreathing = false;
    public bool birth = false;
    private int temperature;
    private AudioManager audioManager;
    [SerializeField]
    private int fillCounter = 0;
    private bool firstCount = true;
    private bool secondCount, thirdCount, fourthCount, fifthCount;
    private bool decreasing = false;
    private bool setOnce = false;
    private bool setFlameSize = false;
    private bool timerIsRunning = false;
    private bool startTimer = false;
    private bool atStart = false;
    private bool increasing = false;
    private bool isCelciusTimerStarted = false;
    private bool isDCelciusTimerStarted = false;
    private int previousTemperature;
    private int StartingTemperature;
    private float currentFillValue;
    private Vector3 flameScale;
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
        flameScale = new Vector3(0.010f, 0.010f, 0.010f);
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

    IEnumerator FlameIncrease()
    {
        if (firstCount)
        {
            while (furnaceFlame.transform.localScale.x <= 0.3 && furnaceFlame.transform.localScale.y <= 0.3 && furnaceFlame.transform.localScale.z <= 0.3)
            {
                yield return new WaitForSeconds(0.3f);
                furnaceFlame.transform.localScale+=flameScale;
                if (decreasing)
                {
                    yield break;
                }
            }
        }

        if (secondCount)
        {
            while (furnaceFlame.transform.localScale.x <= 0.4 && furnaceFlame.transform.localScale.y <= 0.4 && furnaceFlame.transform.localScale.z <= 0.4)
            {
                yield return new WaitForSeconds(0.3f);
                furnaceFlame.transform.localScale += flameScale;
                if (decreasing)
                {
                    yield break;
                }
            }
        }

        if (thirdCount)
        {
            while (greenFlame.transform.localScale.x <= 0.5 && greenFlame.transform.localScale.y <= 0.5 && greenFlame.transform.localScale.z <= 0.5)
            {
                yield return new WaitForSeconds(0.3f);
                greenFlame.transform.localScale += flameScale;
                if (decreasing)
                {
                    yield break;
                }
            }
        }

        if (fourthCount)
        {
            while (greenFlame.transform.localScale.x <= 0.6 && greenFlame.transform.localScale.y <= 0.6 && greenFlame.transform.localScale.z <= 0.6)
            {
                yield return new WaitForSeconds(0.3f);
                greenFlame.transform.localScale += flameScale;
                if (decreasing)
                {
                    yield break;
                }
            }
        }

        if (fifthCount)
        {
            while (greenFlame.transform.localScale.x <= 0.7 && greenFlame.transform.localScale.y <= 0.7 && greenFlame.transform.localScale.z <= 0.7)
            {
                yield return new WaitForSeconds(0.3f);
                greenFlame.transform.localScale += flameScale;
                if (decreasing)
                {
                    yield break;
                }
            }
        }
    }

    void FlameDecrease()
    {
        if (firstCount)
        {
            if (furnaceFlame.transform.localScale.x >= 0.2 && furnaceFlame.transform.localScale.y >= 0.2 && furnaceFlame.transform.localScale.z >= 0.2)
            {
                furnaceFlame.transform.localScale -= flameScale * Time.deltaTime;
            }
        }

        if (secondCount)
        {
            if (furnaceFlame.transform.localScale.x >= 0.3 && furnaceFlame.transform.localScale.y >= 0.3 && furnaceFlame.transform.localScale.z >= 0.3)
            {
                furnaceFlame.transform.localScale -= flameScale * Time.deltaTime;
            }
        }

        if (thirdCount)
        {
            if (greenFlame.transform.localScale.x >= 0.4 && greenFlame.transform.localScale.y >= 0.4 && greenFlame.transform.localScale.z >= 0.4)
            {
                greenFlame.transform.localScale -= flameScale * Time.deltaTime;
            }
        }

        if (fourthCount)
        {
            if (greenFlame.transform.localScale.x >= 0.5 && greenFlame.transform.localScale.y >= 0.5 && greenFlame.transform.localScale.z >= 0.5)
            {
                greenFlame.transform.localScale -= flameScale * Time.deltaTime;
            }
        }
        if (fifthCount)
        {
            if (greenFlame.transform.localScale.x >= 0.6 && greenFlame.transform.localScale.y >= 0.6 && greenFlame.transform.localScale.z >= 0.6)
            {
                greenFlame.transform.localScale -= flameScale * Time.deltaTime;
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
            if (celciusCounter >= 1051)
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
            if (celciusCounter >= 1151)
            {
                celciusCounter = (int)(celciusCounter - 1 * Time.deltaTime);
                countText.text = celciusCounter + "°F";
                if (celciusCounter == 1250)
                {
                    isDCelciusTimerStarted = false;
                }
            }
        }
        if (fifthCount)
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
        //print("Starting Temperature " + StartingTemperature + " Prev Temperature " + previousTemperature + " Temperature " + temperature);
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
                        decreasing = false;
                        if (temperature > StartingTemperature + 1)
                        {
                            increasing = true;
                            startTimer = false;
                            atStart = false;
                            if (!atStart)
                            {
                                if (!isCelciusTimerStarted)
                                {
                                    StartCoroutine(StartCelciusTimer());
                                    StartCoroutine(FlameIncrease());
                                    isCelciusTimerStarted = true;
                                }
                            }
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
                            StopCoroutine(FlameIncrease());
                            isCelciusTimerStarted = false;
                        }
                        if (firstCount)
                        {
                            FlameDecrease();
                            StartDCelciusTimer();
                        }
                        if (secondCount)
                        {
                            FlameDecrease();
                            StartDCelciusTimer();
                        }
                        if (thirdCount)
                        {
                            FlameDecrease();
                            StartDCelciusTimer();
                        }
                        if (fourthCount)
                        {
                            FlameDecrease();
                            StartDCelciusTimer();
                        }
                        if (fifthCount)
                        {
                            FlameDecrease();
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
                breatheIn.SetActive(true);
                breatheOut.SetActive(false);
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
                furnaceFlame.SetActive(false);
                greenFlame.SetActive(true);
                if (!setFlameSize)
                {
                    greenFlame.transform.localScale = furnaceFlame.transform.localScale;
                    setFlameSize = true;
                }
                secondCount = false;
                thirdCount = true;
                changingTemp.SetActive(false);
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
                    StartCoroutine(OriginalFlame());
                    audioManager.Play("Prompt sound effect after each step is completed");
                    celciusCounter = 1269;
                    birth = true;
                }
                fifthCount = false;
                bar.SetActive(false);
                startBreathing = false;
                CancelInvoke();
            }

        }
    }

    IEnumerator OriginalFlame()
    {
        greenFlame.SetActive(false);
        furnaceFlame.SetActive(true);
        while (furnaceFlame.transform.localScale.x > 0.2 && furnaceFlame.transform.localScale.y >= 0.2 && furnaceFlame.transform.localScale.z >= 0.2)
        {
            yield return new WaitForSeconds(0.3f);
            furnaceFlame.transform.localScale -= flameScale * Time.deltaTime;
            if (furnaceFlame.transform.localScale.x <= 0.2 && furnaceFlame.transform.localScale.y >= 0.2 && furnaceFlame.transform.localScale.z >= 0.2)
            {
                furnaceFlame.SetActive(false);
                yield break;
            }
        }
    }

}