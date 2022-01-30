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
    public GameObject furnaceFlame;
    public GameObject greenFlame;
    public GameObject starMap;
    public GameObject starMapNarrative;
    public GameObject ibex;
    public GameObject ibexNarrative;
    public GameObject lookup;
    public GameObject lookdown;
    public Camera cam;
    public int celciusCounter = 750;
    public bool startBreathing = false;
    public bool birth = false;
    public ParticleSystem ps;
    public GameObject light;
    private InputDevice targetDevice;
    private AudioManager audioManager;
    [SerializeField]
    private int fillCounter = 0;
    private bool firstCount = true;
    private bool secondCount, thirdCount, fourthCount, fifthCount;
    private bool decreasing = false;
    private bool continueDecreasing = false;
    private bool drums = false;
    private bool starMapEvent = false;
    private bool startStarMapEvent = false;
    private float currentFillValue;
    private float r;
    private float g;
    private float b;
    private float currentR;
    private float currentG;
    [SerializeField]
    private float timeRemaining = 1.3f;
    [SerializeField]
    private float speed;
    [SerializeField]
    private float colorIncSpeed;
    [SerializeField]
    private float colorDecSpeed;
    private Vector3 lightScale;



    private void Awake()
    {
        audioManager = FindObjectOfType<AudioManager>();
    }

    void Start()
    {
        //furnace light
        lightScale = new Vector3(0.10f, 0.10f, 0.10f);
        //setting up color variables
        r = ps.main.startColor.color.r;
        g = ps.main.startColor.color.g;
        b = ps.main.startColor.color.b;
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
        var main = ps.main;
        if (primaryButtonValue)
        {
            print("Yeaaaaaah");
        }
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
                        //change to green
                        if (r >= 0)
                        {

                            main.startColor = new Color(r -= 0.1f * colorIncSpeed * Time.deltaTime, g, b);
                        }

                        if (b >= 0.2)
                        {
                            main.startColor = new Color(r, g, b -= 0.1f * colorIncSpeed * Time.deltaTime);
                        }

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
                //change to red
                if (r <= 1)
                {

                    main.startColor = new Color(r += 0.1f * colorDecSpeed * Time.deltaTime, g, b);
                }

                if (b <= 1)
                {
                    main.startColor = new Color(r, g, b += 0.1f * colorDecSpeed * Time.deltaTime);
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
                    r = 1;
                    b = 1;
                    main.startColor = new Color(1, g, 1);
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
                StartCoroutine(IncreaseLight());
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
                    startStarMapEvent = true;
                }

                if (startStarMapEvent)
                {
                    if(progressBar.fillAmount <=0)
                    {
                        //Start First Illusion
                        StartCoroutine("StartStarMap");

                        startStarMapEvent = false;
                    }
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
                    audioManager.Stop("Drums");
                    audioManager.Play("Prompt sound effect after each step is completed");
                    celciusCounter = 1270;
                    countText.text = celciusCounter + " °F";
                    birth = true;
                    r = 1;
                    b = 1;
                    main.startColor = new Color(1, g, 1);
                }
                fifthCount = false;
                bar.SetActive(false);
                startBreathing = false;
                starMap.SetActive(false);
                ibex.SetActive(false);
            }
        }

        //illusion events

        if (starMapEvent)
        {
            Ray ray = cam.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.name == "Sky")
                {
                    StartCoroutine("StarMapNarrative");
                    starMapEvent = false;
                }
            }
        }
    }
    //coroutine just in case we need to add extra myth stuff
    IEnumerator StartStarMap()
    {
        lookup.SetActive(true);
        starMapEvent = true;
        bar.SetActive(false);
        startBreathing = false;
        yield return new WaitForSeconds(6);

    }

    IEnumerator StarMapNarrative()
    {
        lookup.SetActive(false);
        starMap.SetActive(true);
        ibex.SetActive(true);
        starMapNarrative.SetActive(true);
        yield return new WaitForSeconds(6);
        //insert starmap glow
        StartCoroutine("StartIbex");
    }

    IEnumerator StartIbex()
    {
        starMapNarrative.SetActive(false);
        lookdown.SetActive(true);
        yield return new WaitForSeconds(3);
        lookdown.SetActive(false);
        ibexNarrative.SetActive(true);
        StartCoroutine("EndIllusion");
    }

    IEnumerator EndIllusion()
    {
        yield return new WaitForSeconds(6);
        ibexNarrative.SetActive(false);
        bar.SetActive(true);
        startBreathing = true;
        drums = false;

    }

    IEnumerator IncreaseLight()
    {
        while (light.transform.localScale.x <= 7 && light.transform.localScale.y <= 7 && light.transform.localScale.z <= 7)
        {
            yield return new WaitForSeconds(0.03f);
            light.transform.localScale += lightScale;
            if (light.transform.localScale.x >= 7 && light.transform.localScale.y >= 7 && light.transform.localScale.z >= 7)
            {
                StartCoroutine(DecreaseLight());
                yield break;
            }
        }
    }

    IEnumerator DecreaseLight()
    {
        while (light.transform.localScale.x > 1 && light.transform.localScale.y > 1 && light.transform.localScale.z > 1)
        {
            yield return new WaitForSeconds(0.03f);
            light.transform.localScale -= lightScale;
            if (light.transform.localScale.x <= 1f && light.transform.localScale.y <= 1 && light.transform.localScale.z <= 1f)
            {
                yield break;
            }
        }
    }
}
