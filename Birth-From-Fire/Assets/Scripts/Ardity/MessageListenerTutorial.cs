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
    public GameObject breathOutTut;
    public GameObject stoppedBreathing;
    public bool finishedBreathing = false;
    public bool startBreathing = false;
    private InputDevice targetDevice;
    private bool continueDecreasing = false;
    private bool decreasing = false;
    private bool countOnce = false;
    private float currentFillValue;
    private int count = 0;

    [SerializeField]
    private float speed;



    void Start()
    {

        //setting up input
        List<InputDevice> devices = new List<InputDevice>();
        InputDeviceCharacteristics rightControllerCharacteristics = InputDeviceCharacteristics.Right | InputDeviceCharacteristics.Controller;
        InputDevices.GetDevicesWithCharacteristics(rightControllerCharacteristics, devices);

        if(devices.Count > 0)
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
            if (primaryButtonValue && !continueDecreasing && !decreasing)
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
                breatheIn.SetActive(true);
                breathOutTut.SetActive(false);
                breatheOut.SetActive(false);
                continueDecreasing = false;
            }

            if (continueDecreasing)
            {
                if (currentFillValue >= 0)
                {
                    currentFillValue = currentFillValue - 1 * speed * Time.deltaTime;
                }
                decreasing = false;
                progressBar.color = Color.gray;
                stoppedBreathing.SetActive(true);
                breatheOut.SetActive(false);
                breathOutTut.SetActive(false);
                breatheIn.SetActive(false);
            }

            if (progressBar.fillAmount <= 0)
            {
                countOnce = false;
                stoppedBreathing.SetActive(false);
                decreasing = false;
                continueDecreasing = false;
                if (count == 0)
                {
                    breathOutTut.SetActive(true);
                    breatheOut.SetActive(false);
                    breatheIn.SetActive(false);
                }
                else if (count > 0)
                {
                    breatheIn.SetActive(false);
                    breatheOut.SetActive(true);
                    breathOutTut.SetActive(false);
                }
                continueDecreasing = false;
            }


            progressBar.fillAmount = currentFillValue / 100;

            if (progressBar.fillAmount >= 0.88)
            {
                if (!countOnce)
                {
                    count++;
                    countOnce = true;
                }
            }

            if (count >= 2)
            {
                if (progressBar.fillAmount <= 0)
                {
                    startBreathing = false;
                    finishedBreathing = true;
                }
            }
        }
    }
}