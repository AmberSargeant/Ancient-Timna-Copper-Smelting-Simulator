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
    public bool moveIbex = false;
    public bool breathPhase2;
    private InputDevice targetDevice;
    private AudioManager audioManager;
    private EventManager eventManager;
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
    [SerializeField]
    private float timeRemaining = 1.3f;
    [SerializeField]
    private float speed;
    [SerializeField]
    private float colorIncSpeed;
    [SerializeField]
    private float colorDecSpeed;
    private Vector3 lightScale;

    private bool playOnce = false;
    private int celciusAmount = 20;
    [SerializeField]
    private float barTimer = 0f;
    [SerializeField]
    private float celciusTimer = 0f;
    private float barDelayAmount = 5f;
    private float celciusDelayAmount = 1f;

    private void Awake()
    {
        audioManager = FindObjectOfType<AudioManager>();
        eventManager = FindObjectOfType<EventManager>();
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
        //if (primaryButtonValue)
        //{
        //    print("Yeaaaaaah");
        //}
        if (startBreathing)
        {
            if (primaryButtonValue)
            {
                if (!continueDecreasing && !decreasing)
                {
                    progressBar.color = Color.cyan;
                    barTimer += Time.deltaTime;
                    celciusTimer += Time.deltaTime;
                    currentFillValue = currentFillValue + 1 * speed * Time.deltaTime;

                    if (celciusCounter >= 950 && celciusCounter <= 1050)
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
                    }
                    if (barTimer <= barDelayAmount)
                    {
                        if (celciusTimer >= celciusDelayAmount)
                        {
                            celciusTimer = 0f;
                            celciusCounter = celciusCounter + celciusAmount;
                            countText.text = celciusCounter + " °F";
                        }
                    }
                    else
                    {
                        if (!playOnce)
                        {
                            audioManager.Play("Prompt sound effect after each step is completed");
                            playOnce = true;
                        }
                        barTimer = 0f;
                        celciusTimer = 0f;
                        stoppedBreathing.SetActive(false);
                        breatheIn.SetActive(true);
                        breatheOut.SetActive(false);
                        decreasing = true;
                        continueDecreasing = false;
                        StartCoroutine(IncreaseLight());
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
            if (decreasing)
            {
                if (currentFillValue >= 0)
                {
                    currentFillValue = currentFillValue - 1 * speed * Time.deltaTime;
                }
            }
            if (continueDecreasing)
            {
                barTimer -= Time.deltaTime;
                celciusTimer += Time.deltaTime;

                //change to red
                if (celciusCounter >= 950 && celciusCounter <= 1050)
                {
                    if (r <= 1)
                    {

                        main.startColor = new Color(r += 0.1f * colorDecSpeed * Time.deltaTime, g, b);
                    }

                    if (b <= 1)
                    {
                        main.startColor = new Color(r, g, b += 0.1f * colorDecSpeed * Time.deltaTime);
                    }
                }

                if (barTimer > 1)
                {
                    if (celciusTimer >= celciusDelayAmount)
                    {
                        celciusTimer = 0f;
                        celciusCounter = celciusCounter - celciusAmount;
                        countText.text = celciusCounter + " °F";
                    }
                }

                if (currentFillValue >= 0)
                {
                    currentFillValue = currentFillValue - 1 * speed * Time.deltaTime;
                }
                decreasing = false;
                progressBar.color = Color.gray;
                breatheOut.SetActive(false);
                breatheIn.SetActive(false);
                stoppedBreathing.SetActive(true);
            }

            if (progressBar.fillAmount <= 0)
            {
                if (celciusCounter == 950)
                {
                    r = 1;
                    b = 1;
                    main.startColor = new Color(1, g, 1);
                }
                if (startStarMapEvent)
                {
                    //Start First Illusion
                    StartCoroutine("StartStarMap");
                    startStarMapEvent = false;
                }
                playOnce = false;
                barTimer = 0f;
                celciusTimer = 0f;
                stoppedBreathing.SetActive(false);
                breatheOut.SetActive(true);
                breatheIn.SetActive(false);
                decreasing = false;
                continueDecreasing = false;
            }
            //event changes
            if (celciusCounter == 950)
            {
                flame1.SetActive(false);
                flame2.SetActive(true);
            }
            if (celciusCounter == 1050 && !continueDecreasing)
            {
                flame2.SetActive(false);
                flame3.SetActive(true);
                startStarMapEvent = true;
            }

            if (celciusCounter == 1150)
            {
                flame3.SetActive(false);
                flame4.SetActive(true);
            }

            if (celciusCounter == 1250)
            {
                flame4.SetActive(false);
                flame5.SetActive(true);
            }

            //need to fix
            if (celciusCounter >= 1310)
            {
                if (progressBar.fillAmount >= 0.88f)
                {
                    audioManager.Stop("Drums");
                    audioManager.Stop("walk sheep");
                    audioManager.Stop("star shining");
                    birth = true;
                    r = 1;
                    b = 1;
                    main.startColor = new Color(1, g, 1);
                    bar.SetActive(false);
                    startBreathing = false;
                    starMap.SetActive(false);
                    ibex.SetActive(false);
                    breathPhase2 = false;
                }
            }

            progressBar.fillAmount = currentFillValue / 100;
        }
        //flame stuff

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
        audioManager.Play("sheep sound");
        audioManager.Play("star shining");
        yield return new WaitForSeconds(6);
        //insert starmap glow
        StartCoroutine("StartIbex");
    }

    IEnumerator StartIbex()
    {
        moveIbex = true;
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
        eventManager.breathPhase1 = false;
        breathPhase2 = true;
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
