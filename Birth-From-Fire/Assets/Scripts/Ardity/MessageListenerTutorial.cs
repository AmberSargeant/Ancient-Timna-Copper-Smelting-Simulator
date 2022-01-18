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
    public GameObject stoppedBreathing;
    public bool finishedBreathing = false;
    public bool startBreathing = false;

    private InputDevice targetDevice;

    private bool decreasing = false;
    private float currentFillValue;

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
            if (primaryButtonValue)
            {
                if (!decreasing)
                {
                    progressBar.color = Color.cyan;
                    currentFillValue = currentFillValue + 1 * speed * Time.deltaTime;
                }

            }
            else
            {
                if (progressBar.fillAmount > 0)
                {
                    decreasing = true;
                }
            }

            if (decreasing)
            {
                if (currentFillValue >= 0)
                {
                    currentFillValue = currentFillValue - 1 * speed * Time.deltaTime;
                }
                progressBar.color = Color.gray;
                stoppedBreathing.SetActive(true);
                breatheOut.SetActive(false);
            }

            if (progressBar.fillAmount <= 0)
            {
                stoppedBreathing.SetActive(false);
                breatheOut.SetActive(true);
                decreasing = false;
            }
        }

        progressBar.fillAmount = currentFillValue / 100;

        if(progressBar.fillAmount >= 0.9)
        {
            startBreathing = false;
            finishedBreathing = true;
        }
    }
}