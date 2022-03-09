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
using UnityEngine.XR.Interaction.Toolkit;
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
    public GameObject canaanties;
    public GameObject eyes;
    public GameObject cont;
    public GameObject lookAhead;
    public GameObject wishes;
    public GameObject leaving;
    public GameObject comeBack;
    public GameObject goddess;
    public GameObject lookup;
    public GameObject lookdown;
    public GameObject goodSign;
    public GameObject placeBlowpipe;
    public Camera cam;
    public int celciusCounter = 750;
    public bool startBreathing = false;
    public bool birth = false;
    public ParticleSystem ps;
    public GameObject light;
    public bool breathPhase2;
    private InputDevice targetDevice;
    private AudioManager audioManager;
    private EventManager eventManager;
    private bool decreasing = false;
    private bool continueDecreasing = false;
    private bool starMapEvent = false;
    private bool startStarMapEvent = false;
    private bool startOnce = false;
    private bool ibexEvent = false;
    private bool inFurnace = false;
    private float currentFillValue;
    private float r;
    private float g;
    private float b;
    [SerializeField]
    private float speed;
    [SerializeField]
    private float colorIncSpeed;
    [SerializeField]
    private float colorDecSpeed;
    private Vector3 lightScale;
    private CampfireAndBlowPipeCollision campfireAndBlowPipeCollision;
    private bool playOnce1 = false;
    private bool playOnce2 = false;
    private bool playOnce3 = false;
    private bool playOnce4 = false;
    private int celciusAmount = 10;
    private bool debugOff = false;
    [SerializeField]
    private float barTimer = 0f;
    [SerializeField]
    private float celciusTimer = 0f;
    private float celciusDelayAmount = 1f;
    private bool inhale = false;
    private bool exhale = false;
    private bool sfx2 = false;

    private void Awake()
    {
        audioManager = FindObjectOfType<AudioManager>();
        eventManager = FindObjectOfType<EventManager>();
        campfireAndBlowPipeCollision = FindObjectOfType<CampfireAndBlowPipeCollision>();
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
        targetDevice.TryGetFeatureValue(CommonUsages.triggerButton, out bool triggerButtonValue);
        targetDevice.TryGetFeatureValue(CommonUsages.primaryButton, out bool primaryButtonValue);
        targetDevice.TryGetFeatureValue(CommonUsages.secondaryButton, out bool secondaryButtonValue);
        targetDevice.TryGetFeatureValue(CommonUsages.gripButton, out bool gripValue);
        var main = ps.main;
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

            if (campfireAndBlowPipeCollision.pipeInFurnace)
            {
                inFurnace = true;
                placeBlowpipe.SetActive(false);
                bar.SetActive(true);
            }
            else
            {
                inFurnace = false;
                placeBlowpipe.SetActive(true);
                bar.SetActive(false);
            }

            if (inFurnace)
            {
                if (triggerButtonValue)
                {

                    if (!continueDecreasing && !decreasing)
                    {

                        progressBar.color = Color.cyan;
                        barTimer += Time.deltaTime;
                        celciusTimer += Time.deltaTime;
                        if (progressBar.fillAmount <= 0.88f)
                        {
                            currentFillValue = currentFillValue + 1 * speed * Time.deltaTime;
                        }

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

                        //change if want limit here.
                        if (barTimer <= 10)
                        {
                            if (celciusTimer >= celciusDelayAmount)
                            {
                                celciusTimer = 0f;
                                celciusCounter = celciusCounter + celciusAmount;
                                countText.text = celciusCounter + " °F";
                            }
                        }
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

                    exhale = false;
                    progressBar.color = Color.gray;
                    barTimer = 0f;
                    celciusTimer = 0f;
                    stoppedBreathing.SetActive(false);
                    breatheOut.SetActive(false);
                    continueDecreasing = false;
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

                    if (barTimer > 0)
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
                    exhale = false;
                    decreasing = false;
                    progressBar.color = Color.gray;
                    breatheOut.SetActive(false);
                    breatheIn.SetActive(false);
                    stoppedBreathing.SetActive(true);
                    audioManager.Stop("exhale");
                }

                if (progressBar.fillAmount <= 0)
                {
                    if (!exhale)
                    {
                        audioManager.Play("exhale");
                        exhale = true;
                    }
                    if (celciusCounter == 950)
                    {
                        r = 1;
                        b = 1;
                        main.startColor = new Color(1, g, 1);
                    }
                    barTimer = 0f;
                    celciusTimer = 0f;
                    stoppedBreathing.SetActive(false);
                    breatheOut.SetActive(true);
                    breatheIn.SetActive(false);
                    decreasing = false;
                    continueDecreasing = false;
                    inhale = false;
                    sfx2 = false;
                }
                //event changes
                if (celciusCounter == 950)
                {
                    if (!playOnce1)
                    {
                        StartCoroutine(IncreaseLight());
                        playOnce1 = true;
                    }

                    flame1.SetActive(false);
                    flame2.SetActive(true);
                }
                if (celciusCounter == 1050 && !continueDecreasing)
                {
                    if (!playOnce2)
                    {
                        StartCoroutine(IncreaseLight());
                        playOnce2 = true;
                    }
                    flame2.SetActive(false);
                    flame3.SetActive(true);
                    if (!startOnce)
                    {
                        startStarMapEvent = true;
                        startOnce = true;
                    }
                }

                if (celciusCounter == 1150)
                {
                    if (!playOnce3)
                    {
                        StartCoroutine(IncreaseLight());
                        playOnce3 = true;
                    }
                    flame3.SetActive(false);
                    flame4.SetActive(true);
                }

                if (celciusCounter == 1250)
                {
                    if (!playOnce4)
                    {
                        StartCoroutine(IncreaseLight());
                        playOnce4 = true;
                    }
                    flame4.SetActive(false);
                    flame5.SetActive(true);
                }

                if (celciusCounter >= 1250)
                {
                    if (progressBar.fillAmount >= 0.88f && breathPhase2)
                    {
                        audioManager.Stop("Drums");
                        audioManager.Stop("star shining");
                        birth = true;
                        r = 1;
                        b = 1;
                        main.startColor = new Color(1, g, 1);
                        bar.SetActive(false);
                        startBreathing = false;
                        starMap.SetActive(false);
                        breathPhase2 = false;
                        placeBlowpipe.SetActive(false);
                    }
                }

                if (progressBar.fillAmount >= 0.88f)
                {
                    if (!sfx2)
                    {
                        audioManager.Play("SFX2 Tutorial");
                        sfx2 = true;
                    }
                    stoppedBreathing.SetActive(false);
                    breatheOut.SetActive(false);
                    breatheIn.SetActive(true);
                    if (!inhale)
                    {
                        audioManager.Play("inhale");
                        inhale = true;
                    }
                    if (startStarMapEvent)
                    {
                        //Start First Illusion
                        StartCoroutine("StartStarMap");
                        startStarMapEvent = false;
                    }
                }
            }

            progressBar.fillAmount = currentFillValue / 100;
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
                    audioManager.Stop("lookup");
                    StartCoroutine("StarMapNarrative");
                    starMapEvent = false;
                }
            }
        }

        if (ibexEvent)
        {
            Ray ray = cam.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if(hit.transform.name == "Front" || hit.transform.name == "Back" || hit.transform.name == "Left" || hit.transform.name == "Right")
                {
                    audioManager.Stop("look down");
                    StartCoroutine("EndIllusion");
                    ibexEvent = false;
                }
            }
        }


    }
    //coroutine just in case we need to add extra myth stuff
    IEnumerator StartStarMap()
    {
        audioManager.Stop("inhale");
        audioManager.Play("goddess");
        goddess.SetActive(true);
        bar.SetActive(false);
        startBreathing = false;
        yield return new WaitForSeconds(6);
        StartCoroutine("LookUp");
    }

    IEnumerator LookUp()
    {
        starMapEvent = true;
        goddess.SetActive(false);
        lookup.SetActive(true);
        audioManager.Play("lookup");
        yield return new WaitForSeconds(6);
    }

    IEnumerator StarMapNarrative()
    {
        lookup.SetActive(false);
        starMap.SetActive(true);
        ibex.SetActive(true);
        starMapNarrative.SetActive(true);
        audioManager.Play("star shining");
        audioManager.Play("starmap narrative");
        yield return new WaitForSeconds(15);
        starMapNarrative.SetActive(false);
        //insert starmap glow
        StartCoroutine("Canaanites");
    }

    //IEnumerator StartIbex()
    //{
    //    //starMapNarrative.SetActive(false);
    //    //lookdown.SetActive(true);
    //    //ibexEvent = true;
    //    ibexNarrative.SetActive(true);
    //    yield return new WaitForSeconds(6);
    //    ibexNarrative.SetActive(false);
    //    StartCoroutine("Canaanites");
    //}

    IEnumerator Canaanites()
    {
        audioManager.Play("canaanite");
        canaanties.SetActive(true);
        yield return new WaitForSeconds(9);
        canaanties.SetActive(false);
        StartCoroutine("LookDown");
    }

    //can make into regular function
    IEnumerator LookDown()
    {
        audioManager.Play("look down");
        lookdown.SetActive(true);
        ibexEvent = true;
        yield return new WaitForSeconds(1);
    }
    IEnumerator EndIllusion()
    {
        audioManager.Play("wishes");
        audioManager.Play("sheep sound");
        lookdown.SetActive(false);
        wishes.SetActive(true);
        yield return new WaitForSeconds(12);
        wishes.SetActive(false);
        StartCoroutine("Leaving");

    }

    IEnumerator Leaving()
    {
        audioManager.Play("leaving");
        leaving.SetActive(true);
        ibex.SetActive(false);
        audioManager.Stop("walk sheep");
        yield return new WaitForSeconds(4);
        leaving.SetActive(false);
        StartCoroutine("ComeBack");
    }

    IEnumerator ComeBack()
    {
        audioManager.Play("come back");
        comeBack.SetActive(true);
        yield return new WaitForSeconds(4);
        comeBack.SetActive(false);
        StartCoroutine("GoodSign");
    }

    IEnumerator GoodSign()
    {
        audioManager.Play("good sign");
        goodSign.SetActive(true);
        yield return new WaitForSeconds(8);
        goodSign.SetActive(false);
        StartCoroutine("Eyes");
    }

    IEnumerator Eyes()
    {
        audioManager.Play("eyes");
        eyes.SetActive(true);
        yield return new WaitForSeconds(6);
        eyes.SetActive(false);
        StartCoroutine("Cont");
    }

    IEnumerator Cont()
    {
        audioManager.Play("continue");
        cont.SetActive(true);
        yield return new WaitForSeconds(4);
        audioManager.Play("inhale");
        cont.SetActive(false);
        eventManager.breathPhase1 = false;
        breathPhase2 = true;
        bar.SetActive(true);
        startBreathing = true;
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
