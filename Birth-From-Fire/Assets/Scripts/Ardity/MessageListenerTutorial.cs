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
using TMPro;

//Need to refactor this entire script lol
public class MessageListenerTutorial : MonoBehaviour
{
    public Image progressBar;
    public GameObject breatheOut;
    public GameObject breatheIn;
    public GameObject stoppedBreathing;
    public bool finishedBreathing = false;
    public bool startBreathing = false;
    private InputDevice targetDevice;
    [SerializeField]
    private bool continueDecreasing = false;
    [SerializeField]
    private bool decreasing = false;
    private bool countOnce = false;
    private float currentFillValue;
    private int count = 0;
    private bool debugOff = false;
    private AudioManager audioManager;
    private bool sfx = false;
    private bool inhale = false;
    private bool exhale = false;

    [SerializeField]
    private float speed;



    void Start()
    {

        //setting up input
        List<InputDevice> devices = new List<InputDevice>();
        InputDeviceCharacteristics rightControllerCharacteristics = InputDeviceCharacteristics.Right | InputDeviceCharacteristics.Controller;
        InputDevices.GetDevicesWithCharacteristics(rightControllerCharacteristics, devices);
        audioManager = FindObjectOfType<AudioManager>();
        if (devices.Count > 0)
        {
            targetDevice = devices[0];
        }
    }


    // Update is called once per frame
    void Update()
    {
        targetDevice.TryGetFeatureValue(CommonUsages.triggerButton, out bool triggerButtonValue);
        targetDevice.TryGetFeatureValue(CommonUsages.primaryButton, out bool primaryButtonValue);
        targetDevice.TryGetFeatureValue(CommonUsages.secondaryButton, out bool secondaryButtonValue);
        targetDevice.TryGetFeatureValue(CommonUsages.gripButton, out bool gripValue);

        //debug
        if (secondaryButtonValue && primaryButtonValue && !debugOff && gripValue)
        {
            decreasing = false;
            continueDecreasing = false;
            startBreathing = true;
            debugOff = true;
            progressBar.fillAmount = 0;
            print("reached");
        }


        if (startBreathing)
        {
            if (triggerButtonValue && !continueDecreasing && !decreasing)
            {
                progressBar.color = Color.cyan;
                if (progressBar.fillAmount <= 0.88f)
                {
                    currentFillValue = currentFillValue + 1 * speed * Time.deltaTime;
                }

            }
            else
            {
                if (progressBar.fillAmount >= 0.88f && !continueDecreasing)
                {
                    decreasing = true;
                }
                else if (progressBar.fillAmount > 0 && progressBar.fillAmount < 0.88 && !decreasing)
                {
                    continueDecreasing = true;
                }
            }

            if (decreasing)
            {
                if (currentFillValue >= 0)
                {
                    currentFillValue = currentFillValue - 1 * speed * Time.deltaTime;
                }
                progressBar.color = Color.gray;
                stoppedBreathing.SetActive(false);
                breatheOut.SetActive(false);
                continueDecreasing = false;
                exhale = false;
            }

            if (continueDecreasing)
            {
                if (currentFillValue >= 0)
                {
                    currentFillValue = currentFillValue - 1 * speed * Time.deltaTime;
                }
                exhale = false;
                decreasing = false;
                progressBar.color = Color.gray;
                stoppedBreathing.SetActive(true);
                breatheOut.SetActive(false);
                breatheIn.SetActive(false);
                audioManager.Stop("exhale");
            }

            if (progressBar.fillAmount <= 0)
            {
                if (!exhale)
                {
                    audioManager.Play("exhale");
                    exhale = true;
                }
                inhale = false;
                sfx = false;
                countOnce = false;
                stoppedBreathing.SetActive(false);
                decreasing = false;
                continueDecreasing = false;
                breatheIn.SetActive(false);
                breatheOut.SetActive(true);
                continueDecreasing = false;
            }

            progressBar.fillAmount = currentFillValue / 100;

            if (progressBar.fillAmount >= 0.88)
            {
                if (!inhale)
                {
                    audioManager.Play("inhale");
                    inhale = true;
                }
                breatheIn.SetActive(true);
                breatheOut.SetActive(false);
                if (!sfx)
                {
                    audioManager.Play("SFX2 Tutorial");
                    sfx = true;
                }
                if (!countOnce)
                {
                    count++;
                    countOnce = true;
                }
            }

            if (count >= 2)
            {
                startBreathing = false;
                finishedBreathing = true;

            }
        }
    }
}