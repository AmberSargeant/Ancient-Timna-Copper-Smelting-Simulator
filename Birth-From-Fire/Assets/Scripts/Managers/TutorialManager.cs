using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
public class TutorialManager : MonoBehaviour
{
    private AudioManager audioManager;
    private MessageListenerTutorial messageListener;
    private bool secondStage = false;
    private bool thirdStage = false;
    private bool fourthStage = false;
    private bool fourthStagePart2 = false;
    private bool fifthStage = false;
    private bool fifthStagePart2 = false;
    private bool sixthStage = false;
    private bool lspot1, lspot2, lspot3;
    private bool playOnce1, playOnce2, playOnce3, playOnce4, playOnce5, playOnce6;
    private bool completeCeiling = false;
    private bool completeSculpture = false;
    private bool completePainting = false;
    private bool completeFloor = false;
    private bool floorBuffer = false;
    public Camera cam;
    public XRDirectInteractor rHand;
    public GameObject wakeUp;
    public GameObject timna;
    public GameObject confused;
    public GameObject spirits;
    public GameObject changePerspective;
    public GameObject completeContent;
    public GameObject tasksPrefab;
    public List<GameObject> tasks = new List<GameObject>();
    public GameObject well;
    public GameObject rightHand;
    public GameObject blowPipe;
    public GameObject lightSpot;
    public List<GameObject> lightSpots = new List<GameObject>();
    public GameObject better;
    public GameObject grab;
    public GameObject controllerDemo;
    public GameObject leaflet;
    public GameObject leafletPrefab;
    public GameObject picking;
    //public GameObject flyer;
    public GameObject putDown;
    public GameObject great;
    public GameObject again;
    public GameObject scrollPrefab;
    public GameObject scrollScreenDirty;
    public GameObject scrollScreenClean;
    public GameObject barPrefab;
    public GameObject dust;
    //public GameObject blow;
    public GameObject inhale;
    public GameObject exhale;
    public GameObject thankYou;
    public GameObject smoke;
    public GameObject exhalePrefab;
    public GameObject inhalePrefab;
    private float inhaleTimer = 10;
    private bool startInhaleTimer = false;
    private GameManager GM;

    private void Awake()
    {
        audioManager = FindObjectOfType<AudioManager>();
        GM = FindObjectOfType<GameManager>();
    }
    // Start is called before the first frame update
    void Start()
    {
        //rayPrefab.SetActive(false);
        audioManager.Play("tutorial background");
        messageListener = FindObjectOfType<MessageListenerTutorial>();
        StartCoroutine("WakeUpScene");
        audioManager.Play("wake up");
    }

    // Update is called once per frame
    void Update()
    {
        //print(rHand.selectTarget);
        Ray ray = cam.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));
        RaycastHit hit;
        if (secondStage)
        {
            if (Physics.Raycast(ray, out hit))
            {
                if (!completeFloor)
                {
                    if (hit.transform.name == "Floor_Bottom_01")
                    {
                        if (floorBuffer)
                        {
                            if (!playOnce1)
                            {
                                audioManager.Play("SFX2 Tutorial");
                                audioManager.Play("ceiling");
                                audioManager.Stop("ground");
                                playOnce1 = true;
                            }

                            tasks[0].SetActive(false);
                            tasks[1].SetActive(true);
                            completeFloor = true;
                        }
                    }
                }
                if (!completeCeiling)
                {
                    if (hit.transform.name == "Floor_Top_01")
                    {
                        if (completeFloor)
                        {
                            if (!playOnce2)
                            {
                                audioManager.Play("SFX2 Tutorial");
                                audioManager.Play("sculpture");
                                audioManager.Stop("ceiling");
                                playOnce2 = true;
                            }

                            tasks[1].SetActive(false);
                            tasks[2].SetActive(true);
                            completeCeiling = true;
                        }
                    }
                }
                if (!completeSculpture)
                {
                    if (hit.transform.name == "Task Sculpture")
                    {
                        if (completeCeiling)
                        {
                            if (!playOnce3)
                            {
                                audioManager.Play("SFX2 Tutorial");
                                audioManager.Play("painting");
                                audioManager.Stop("sculpture");
                                playOnce3 = true;
                            }
                            tasks[2].SetActive(false);
                            tasks[3].SetActive(true);
                            completeSculpture = true;
                        }
                    }
                }

                if (!completePainting)
                {
                    if (hit.transform.name == "Task Painting")
                    {
                        if (completeSculpture)
                        {
                            if (!playOnce4)
                            {
                                audioManager.Stop("painting");
                                audioManager.Play("SFX2 Tutorial");
                                playOnce4 = true;
                            }
                            tasks[3].SetActive(false);
                            completePainting = true;
                        }

                    }
                }

                if (completeFloor == true && completeCeiling == true && completePainting == true && completeSculpture == true)
                {
                    secondStage = false;
                    StartCoroutine("EndSecondScene");
                }
            }
        }
        if (thirdStage)
        {
            if (lspot1 && lspot2 && lspot3)
            {
                StartCoroutine("EndThirdScene");
                thirdStage = false;
            }
        }

        if (fourthStage)
        {
            controllerDemo.SetActive(true);
            if (rHand.selectTarget != null)
            {
                if (rHand.selectTarget.tag == "Leaflet")
                {
                    fourthStage = false;
                    StartCoroutine("EndFourthStage");
                }
            }

        }

        //removed references to ray
        if (fourthStagePart2)
        {
            if (rHand.selectTarget == null)
            {
                audioManager.Stop("put down leaflet");
                fourthStagePart2 = false;
                StartCoroutine("RayShootingEvent");
            }
        }

        //removed references to ray
        if (fifthStage)
        {
            //everythingWell.SetActive(true);
            if (rHand.selectTarget != null)
            {
                if (rHand.selectTarget.tag == "Scroll")
                {
                    audioManager.Stop("again");
                    audioManager.Stop("scroll");
                    audioManager.Play("great");
                    fifthStage = false;
                    fifthStagePart2 = true;
                    again.SetActive(false);
                    great.SetActive(true);
                }
            }
        }
        //removed references to blowpipe
        //removed references to ray
        if (fifthStagePart2)
        {
            audioManager.Stop("scroll");
            //everythingWell.SetActive(false);
            if (rHand.selectTarget == null)
            {
                audioManager.Stop("great");
                scrollPrefab.SetActive(false);
                great.SetActive(false);
                fifthStagePart2 = false;
                StartCoroutine("BlowPipeEvent");
            }
        }

        if (sixthStage)
        {
            if (startInhaleTimer)
            {
                inhaleTimer -= Time.deltaTime;
                if (inhaleTimer >= 6)
                {
                    messageListener.startBreathing = true;
                    inhalePrefab.SetActive(false);
                    exhalePrefab.SetActive(true);
                    startInhaleTimer = false;
                }
            }

            if (messageListener.finishedBreathing == true)
            {
                sixthStage = false;
                scrollScreenClean.GetComponent<Image>().CrossFadeAlpha(0, 8, false);
                StartCoroutine("DesertScene");
            }

        }

    }

    public void LightSpot1() {
        if (thirdStage)
        {
            if (!lspot1)
            {
                audioManager.Play("SFX2 Tutorial");
                lightSpots[0].SetActive(false);
                lspot1 = true;
            }
        }
    }

    public void LightSpot2()
    {
        if (thirdStage)
        {
            if (!lspot2)
            {
                audioManager.Play("SFX2 Tutorial");
                lightSpots[1].SetActive(false);
                lspot2 = true;
            }
        }
    }

    public void LightSpot3()
    {
        if (thirdStage)
        {
            if (!lspot3)
            {
                audioManager.Play("SFX2 Tutorial");
                lightSpots[2].SetActive(false);
                lspot3 = true;
            }
        }
    }
    IEnumerator WakeUpScene()
    {
        yield return new WaitForSeconds(7);
        audioManager.Play("discovery hall");
        wakeUp.SetActive(false);
        timna.SetActive(true);
        StartCoroutine("TimnaScene");

    }

    IEnumerator TimnaScene()
    {
        yield return new WaitForSeconds(7);
        audioManager.Play("confused");
        timna.SetActive(false);
        confused.SetActive(true);
        StartCoroutine("Spirits");
    }

    IEnumerator Spirits()
    {
        yield return new WaitForSeconds(2);
        confused.SetActive(false);
        spirits.SetActive(true);
        StartCoroutine("EndFirstScene");
    }
    IEnumerator EndFirstScene()
    {
        yield return new WaitForSeconds(7);
        spirits.SetActive(false);
        changePerspective.SetActive(true);
        audioManager.Play("move your head");
        StartCoroutine("CompleteContentScene");
    }
    IEnumerator CompleteContentScene()
    {
        yield return new WaitForSeconds(7);
        audioManager.Play("complete content");
        changePerspective.SetActive(false);
        completeContent.SetActive(true);
        StartCoroutine("EnableFloorTask");

    }
    IEnumerator EnableFloorTask()
    {
        yield return new WaitForSeconds(5);
        secondStage = true;
        completeContent.SetActive(false);
        tasks[0].SetActive(true);
        audioManager.Play("ground");
        StartCoroutine("FloorBuffer");
    }

    IEnumerator FloorBuffer()
    {
        yield return new WaitForSeconds(3);
        floorBuffer = true;
    }
    IEnumerator EndSecondScene()
    {
        well.SetActive(true);
        audioManager.Play("well");
        yield return new WaitForSeconds(7);
        well.SetActive(false);
        rightHand.SetActive(true);
        audioManager.Play("hand");
        StartCoroutine("LightSpotScene");
    }

    IEnumerator LightSpotScene()
    {
        yield return new WaitForSeconds(7);
        audioManager.Play("use hand");
        rightHand.SetActive(false);
        lightSpot.SetActive(true);
        foreach (GameObject l in lightSpots)
        {
            l.SetActive(true);
        }
        thirdStage = true;

    }

    IEnumerator EndThirdScene()
    {
        audioManager.Play("better");
        lightSpot.SetActive(false);
        better.SetActive(true);
        yield return new WaitForSeconds(7);
        better.SetActive(false);
        audioManager.Play("grab");
        grab.SetActive(true);
        StartCoroutine("LeafletEvent");
    }

    IEnumerator LeafletEvent()
    {
        yield return new WaitForSeconds(7);
        audioManager.Play("leaflet");
        grab.SetActive(false);
        leaflet.SetActive(true);
        StartCoroutine("Picking");
    }
    IEnumerator Picking()
    {
        yield return new WaitForSeconds(3);
        leaflet.SetActive(false);
        picking.SetActive(true);
        leafletPrefab.SetActive(true);
        fourthStage = true;
    }
    IEnumerator EndFourthStage()
    {
        audioManager.Play("tutorial leaflet");
        controllerDemo.SetActive(false);
        picking.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        //flyer.SetActive(true);
        StartCoroutine("EndFourthStagePart2");
    }

    IEnumerator EndFourthStagePart2()
    {
        yield return new WaitForSeconds(7f);
        //flyer.SetActive(false);
        fourthStagePart2 = true;
        audioManager.Play("put down leaflet");
        putDown.SetActive(true);
    }

    //removed ray shooting event can make regular function
    IEnumerator RayShootingEvent()
    {
        audioManager.Play("SFX2 Tutorial");
        leafletPrefab.SetActive(false);
        putDown.SetActive(false);
        StartCoroutine("RayScrollEvent");
        yield return new WaitForSeconds(7f);
    }
    //removed ray scroll event can make into regular function
    IEnumerator RayScrollEvent()
    {
        audioManager.Play("again");
        again.SetActive(true);
        scrollPrefab.SetActive(true);
        fifthStage = true;
        yield return new WaitForSeconds(2f);
        StartCoroutine("GrabScroll");
    }
    IEnumerator GrabScroll()
    {
        if (fifthStage)
        {
            audioManager.Play("scroll");
        }
        yield return new WaitForSeconds(2);
    }
    //removed references to blowpipe
    IEnumerator BlowPipeEvent()
    {
        audioManager.Play("SFX2 Tutorial");
        rightHand.SetActive(false);
        blowPipe.SetActive(true);
        scrollScreenDirty.SetActive(true);
        dust.SetActive(true);
        audioManager.Play("dust");
        yield return new WaitForSeconds(6f);
        StartCoroutine("Blow");

    }

    //can make into regular function
    IEnumerator Blow()
    {
        startInhaleTimer = true;
        sixthStage = true;
        audioManager.Play("inhale");
        barPrefab.SetActive(true);
        inhale.SetActive(true);
        exhale.SetActive(true);
        dust.SetActive(false);
        //blow.SetActive(true);
        yield return new WaitForSeconds(5);
    }
    IEnumerator DesertScene()
    {
        audioManager.Play("soul");
        inhale.SetActive(false);
        exhale.SetActive(false);
        audioManager.Play("SFX2 Tutorial");
        audioManager.Play("tutorial smoke");
        scrollScreenDirty.SetActive(false);
        scrollScreenClean.SetActive(true);
        thankYou.SetActive(true);
        smoke.SetActive(true);
        dust.SetActive(false);
        barPrefab.SetActive(false);
        yield return new WaitForSeconds(10f);
        audioManager.Stop("tutorial background");
        GM.MainGame();
    }
}
