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
    public Camera cam;
    public XRDirectInteractor rHand;
    public GameObject rayPrefab;
    public GameObject wakeUp;
    public GameObject timna;
    public GameObject moveBody;
    public GameObject changePerspective;
    public GameObject completeContent;
    public GameObject tasksPrefab;
    public List<GameObject> tasks = new List<GameObject>();
    public GameObject well;
    public GameObject rightHand;
    public GameObject lightSpot;
    public List<GameObject> lightSpots = new List<GameObject>();
    public GameObject better;
    public GameObject grab;
    public GameObject controllerDemo;
    public GameObject leaflet;
    public GameObject leafletPrefab;
    public GameObject flyer;
    public GameObject putDown;
    public GameObject rays;
    public GameObject rayShooting;
    public GameObject rayScroll;
    public GameObject scrollPrefab;
    public GameObject everythingWell;
    public GameObject scrollScreenDirty;
    public GameObject scrollScreenClean;
    public GameObject blowpipe;
    public GameObject blowpipePrefab;
    public GameObject blowpipeUI;
    public GameObject barPrefab;
    public GameObject blowPipeDemo;
    public GameObject dust;
    public GameObject thankYou;
    public GameObject smoke;
    private GameManager GM;

    private void Awake()
    {
        audioManager = FindObjectOfType<AudioManager>();
        GM = FindObjectOfType<GameManager>();
    }
    // Start is called before the first frame update
    void Start()
    {
        rayPrefab.SetActive(false);
        audioManager.Play("tutorial background");
        messageListener = FindObjectOfType<MessageListenerTutorial>();
        StartCoroutine("WakeUpScene");
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
                if (hit.transform.name == "Floor_Bottom_01")
                {
                    if (!playOnce1)
                    {
                        audioManager.Play("SFX2 Tutorial");
                        playOnce1 = true;
                    }
                    tasks[0].SetActive(false);
           
                }
                if (hit.transform.name == "Floor_Top_01")
                {
                    if (!playOnce2)
                    {
                        audioManager.Play("SFX2 Tutorial");
                        playOnce2 = true;
                    }
                    tasks[1].SetActive(false);
                }
                if (hit.transform.name == "Task Sculpture")
                {
                    if (!playOnce3)
                    {
                        audioManager.Play("SFX2 Tutorial");
                        playOnce3 = true;
                    }
                    tasks[2].SetActive(false);
                }
                if (hit.transform.name == "Task Painting")
                {
                    if (!playOnce4)
                    {
                        audioManager.Play("SFX2 Tutorial");
                        playOnce4 = true;
                    }
                    tasks[3].SetActive(false);
                }

                if (tasks[0].activeSelf == false && tasks[1].activeSelf == false && tasks[2].activeSelf == false && tasks[3].activeSelf == false)
                {

                    changePerspective.SetActive(false);
                    completeContent.SetActive(false);
                    well.SetActive(true);
                    secondStage = false;
                    StartCoroutine("EndSecondScene");
                }
            }


            //if (Physics.Raycast(ray, out hit))
            //{
            //    print("I'm looking at " + hit.transform.name);
            //}
            //else
            //    print("I'm looking at nothing!");
        }
        if (thirdStage)
        {
            if (lspot1 && lspot2 && lspot3)
            {
                StartCoroutine("EndThirdScene");
                rightHand.SetActive(false);
                lightSpot.SetActive(false);
                better.SetActive(true);
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
                    controllerDemo.SetActive(false);
                    audioManager.Play("tutorial leaflet");
                    grab.SetActive(false);
                    leaflet.SetActive(false);
                    fourthStage = false;
                    StartCoroutine("EndFourthStage");
                }
            }

        }

        if (fourthStagePart2)
        {
            if(rHand.selectTarget == null)
            {
                audioManager.Play("SFX2 Tutorial");
                leafletPrefab.SetActive(false);
                putDown.SetActive(false);
                rays.SetActive(true);
                fourthStagePart2 = false;
                StartCoroutine("RayShootingEvent");
            }
        }

        if (fifthStage)
        {
            controllerDemo.SetActive(true);
            rayPrefab.SetActive(true);
            if (rHand.selectTarget != null)
            {
                if (rHand.selectTarget.tag == "Scroll")
                {
                    controllerDemo.SetActive(false);
                    rays.SetActive(false);
                    rayShooting.SetActive(false);
                    rayScroll.SetActive(false);
                    everythingWell.SetActive(true);
                    fifthStage = false;
                    fifthStagePart2 = true;
                }
            }
        }
        if (fifthStagePart2)
        {
            if (rHand.selectTarget == null)
            {
                audioManager.Play("SFX2 Tutorial");
                everythingWell.SetActive(false);
                blowpipe.SetActive(true);
                blowpipePrefab.SetActive(true);
                blowpipeUI.SetActive(true);
                fifthStagePart2 = false;
                StartCoroutine("BlowPipeEvent");

            }
        }

        if (sixthStage)
        {
            messageListener.startBreathing = true;

            if(messageListener.finishedBreathing == true)
            {
                blowPipeDemo.SetActive(false);
                audioManager.Play("SFX2 Tutorial");
                audioManager.Play("tutorial smoke");
                blowpipePrefab.SetActive(false);
                blowpipe.SetActive(false);
                dust.SetActive(false);
                barPrefab.SetActive(false);
                sixthStage = false;
                scrollScreenDirty.SetActive(false);
                scrollScreenClean.SetActive(true);
                thankYou.SetActive(true);
                smoke.SetActive(true);
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
        yield return new WaitForSeconds(5);
        timna.SetActive(true);
        StartCoroutine("TimnaScene");

    }

    IEnumerator TimnaScene()
    {
        yield return new WaitForSeconds(5);
        moveBody.SetActive(true);
        StartCoroutine("EndFirstScene");
    }
    IEnumerator EndFirstScene()
    {
        yield return new WaitForSeconds(5);
        wakeUp.SetActive(false);
        timna.SetActive(false);
        moveBody.SetActive(false);
        changePerspective.SetActive(true);
        StartCoroutine("CompleteContentScene");
    }
    IEnumerator CompleteContentScene()
    {
        yield return new WaitForSeconds(5);
        completeContent.SetActive(true);
        tasksPrefab.SetActive(true);
        secondStage = true;
        
    }

    IEnumerator EndSecondScene()
    {
        yield return new WaitForSeconds(5);
        well.SetActive(false);
        rightHand.SetActive(true);
        StartCoroutine("LightSpotScene");
    }

    IEnumerator LightSpotScene()
    {
        yield return new WaitForSeconds(5);
        lightSpot.SetActive(true);
        foreach (GameObject l in lightSpots)
        {
            l.SetActive(true);
        }
        thirdStage = true;

    }

    IEnumerator EndThirdScene()
    {
        yield return new WaitForSeconds(5);
        better.SetActive(false);
        grab.SetActive(true);
        StartCoroutine("LeafletEvent");
    }

    IEnumerator LeafletEvent()
    {
        yield return new WaitForSeconds(5);
        leaflet.SetActive(true);
        leafletPrefab.SetActive(true);
        fourthStage = true;
    }

    IEnumerator EndFourthStage()
    {
        yield return new WaitForSeconds(0.5f);
        flyer.SetActive(true);
        StartCoroutine("EndFourthStagePart2");
    }

    IEnumerator EndFourthStagePart2()
    {
        yield return new WaitForSeconds(5f);
        flyer.SetActive(false);
        fourthStagePart2 = true;
        putDown.SetActive(true);
    }

    IEnumerator RayShootingEvent()
    {
        yield return new WaitForSeconds(5f);
        rayShooting.SetActive(true);
        rayScroll.SetActive(true);
        scrollPrefab.SetActive(true);
        StartCoroutine("RayScrollEvent");
    }

    IEnumerator RayScrollEvent()
    {
        yield return new WaitForSeconds(5f);
        fifthStage = true;
    }

    IEnumerator BlowPipeEvent()
    {
        yield return new WaitForSeconds(5f);
        blowpipeUI.SetActive(false);
        scrollScreenDirty.SetActive(true);
        dust.SetActive(true);
        barPrefab.SetActive(true);
        sixthStage = true;
        blowPipeDemo.SetActive(true);
    }
    IEnumerator DesertScene()
    {
        yield return new WaitForSeconds(10f);
        audioManager.Stop("tutorial background");
        GM.MainGame();
    }
}
