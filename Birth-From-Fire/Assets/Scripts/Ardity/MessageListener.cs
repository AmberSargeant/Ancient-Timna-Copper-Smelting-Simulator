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
using UnityEngine.XR;
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
    public GameObject stoppedBreathing;
    public GameObject bar;
    //public GameObject changingTemp;
    public GameObject furnaceFlame;
    public GameObject greenFlame;
    public int celciusCounter = 750;
    public bool startBreathing = false;
    public bool birth = false;

    private InputDevice targetDevice;

    private int temperature;
    private AudioManager audioManager;
    [SerializeField]
    private int fillCounter = 0;
    private bool firstCount = true;
    private bool secondCount, thirdCount, fourthCount, fifthCount;
    private bool decreasing = false;
    private bool continueDecreasing = false;
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
    private float timeRemaining = 1.3f;
    [SerializeField]
    private float speed;
    private IEnumerator startCelciusTimer;


    private void Awake()
    {
        audioManager = FindObjectOfType<AudioManager>();
    }

    void Start()
    {
        //setting up input
        List<InputDevice> devices = new List<InputDevice>();
        InputDeviceCharacteristics rightControllerCharacteristics = InputDeviceCharacteristics.Right | InputDeviceCharacteristics.Controller;
        InputDevices.GetDevicesWithCharacteristics(rightControllerCharacteristics, devices);

        if (devices.Count > 0)
        {
            targetDevice = devices[0];
        }
    }


    // Update is called once per frame
    void Update()
    {
        targetDevice.TryGetFeatureValue(CommonUsages.primaryButton, out bool primaryButtonValue);

        if (startBreathing)
        {
            if (primaryButtonValue)
            {
                if (!continueDecreasing && !decreasing)
                {
                    progressBar.color = Color.cyan;
                    currentFillValue = currentFillValue + 1 * speed * Time.deltaTime;

                    if (firstCount)
                    {
                        if (celciusCounter <= 950)
                        {
                            celciusCounter = (int)(celciusCounter + 1 * 90 * Time.deltaTime);
                            countText.text = celciusCounter + " °F";
                        }
                    }
                    if (secondCount)
                    {
                        if (celciusCounter <= 1050)
                        {
                            celciusCounter = (int)(celciusCounter + 1 * 88.8 * Time.deltaTime);
                            countText.text = celciusCounter + " °F";
                        }
                    }
                    if (thirdCount)
                    {
                        if (celciusCounter <= 1150)
                        {
                            celciusCounter = (int)(celciusCounter + 1 * 88.8 * Time.deltaTime);
                            countText.text = celciusCounter + " °F";
                        }
                    }

                    if (fourthCount)
                    {
                        if (celciusCounter <= 1250)
                        {
                            celciusCounter = (int)(celciusCounter + 1 * 88.8 * Time.deltaTime);
                            countText.text = celciusCounter + " °F";
                        }
                    }

                    if (fifthCount)
                    {
                        if (celciusCounter <= 1270)
                        {
                            celciusCounter = (int)(celciusCounter + 1 * 86.7 * Time.deltaTime);
                            countText.text = celciusCounter + " °F";
                        }
                    }
                }

            }
            else
            {
                if (progressBar.fillAmount > 0 && !decreasing)
                {
                    continueDecreasing = true;
                }
            }

            if (continueDecreasing)
            {
                if (currentFillValue >= 0)
                {
                    currentFillValue = currentFillValue - 1 * speed * Time.deltaTime;
                }


                if (firstCount)
                {
                    if (celciusCounter >= 751)
                    {
                        celciusCounter = (int)(celciusCounter - 1 * 80 * Time.deltaTime);
                        countText.text = celciusCounter + " °F";
                    }
                }

                if (secondCount)
                {
                    if (celciusCounter >= 951)
                    {
                        celciusCounter = (int)(celciusCounter - 1 * 80 * Time.deltaTime);
                        countText.text = celciusCounter + " °F";
                    }
                }

                if (thirdCount)
                {
                    if (celciusCounter >= 1051)
                    {
                        celciusCounter = (int)(celciusCounter - 1 * 80 * Time.deltaTime);
                        countText.text = celciusCounter + " °F";
                    }
                }

                if (fourthCount)
                {
                    if (celciusCounter >= 1151)
                    {
                        celciusCounter = (int)(celciusCounter - 1 * 80 * Time.deltaTime);
                        countText.text = celciusCounter + " °F";
                    }
                }

                if (fifthCount)
                {
                    if (celciusCounter >= 1251)
                    {
                        celciusCounter = (int)(celciusCounter - 1 * 80 * Time.deltaTime);
                        countText.text = celciusCounter + " °F";
                    }
                }
                decreasing = false;
                progressBar.color = Color.gray;
                breatheOut.SetActive(false);
                breatheIn.SetActive(false);
                stoppedBreathing.SetActive(true);
            }

            if (decreasing)
            {
                if (currentFillValue >= 0)
                {
                    currentFillValue = currentFillValue - 1 * speed * Time.deltaTime;
                }
                continueDecreasing = false;
                progressBar.color = Color.gray;
                breatheOut.SetActive(false);
                breatheIn.SetActive(true);
                stoppedBreathing.SetActive(false);
            }

            if (progressBar.fillAmount <= 0)
            {
                if (fillCounter == 0)
                {
                    celciusCounter = 750;
                    countText.text = celciusCounter + " °F";
                }
                if (fillCounter == 1)
                {
                    celciusCounter = 950;
                    countText.text = celciusCounter + " °F";
                }
                if (fillCounter == 2)
                {
                    celciusCounter = 1050;
                    countText.text = celciusCounter + " °F";
                }
                if (fillCounter == 3)
                {
                    celciusCounter = 1150;
                    countText.text = celciusCounter + " °F";
                }

                if (fillCounter == 4)
                {
                    celciusCounter = 1250;
                    countText.text = celciusCounter + " °F";
                }
                stoppedBreathing.SetActive(false);
                breatheOut.SetActive(true);
                breatheIn.SetActive(false);
                decreasing = false;
                continueDecreasing = false;
            }

            progressBar.fillAmount = currentFillValue / 100;

            if (progressBar.fillAmount >= 0.9 && fillCounter <= 5)
            {
                stoppedBreathing.SetActive(false);
                breatheIn.SetActive(true);
                breatheOut.SetActive(false);
                decreasing = true;
                continueDecreasing = false;
                fillCounter++;
            }

            if (fillCounter == 1)
            {
                if (firstCount)
                {
                    audioManager.Play("Prompt sound effect after each step is completed");
                    celciusCounter = 950;
                    countText.text = celciusCounter + " °F";
                }
                firstCount = false;
                secondCount = true;

            }
            if (fillCounter == 2)
            {
                if (secondCount)
                {
                    audioManager.Play("Prompt sound effect after each step is completed");
                    celciusCounter = 1050;
                    countText.text = celciusCounter + " °F";
                }

                secondCount = false;
                thirdCount = true;

            }
            if (fillCounter == 3)
            {
                if (thirdCount)
                {
                    audioManager.Play("Prompt sound effect after each step is completed");
                    celciusCounter = 1150;
                    countText.text = celciusCounter + " °F";
                }
                thirdCount = false;
                fourthCount = true;
            }
            if (fillCounter == 4)
            {
                if (fourthCount)
                {
                    audioManager.Play("Prompt sound effect after each step is completed");
                    celciusCounter = 1250;
                    countText.text = celciusCounter + " °F";
                }
                fourthCount = false;
                fifthCount = true;
            }
            if (fillCounter == 5)
            {
                if (fifthCount)
                {
                    audioManager.Play("Prompt sound effect after each step is completed");
                    celciusCounter = 1270;
                    countText.text = celciusCounter + " °F";
                    birth = true;
                }
                fifthCount = false;
                bar.SetActive(false);
                startBreathing = false;
            }
        }
    }
}