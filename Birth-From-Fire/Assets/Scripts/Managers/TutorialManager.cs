using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
public class TutorialManager : MonoBehaviour
{
    private MessageListenerTutorial messageListener;
    private bool secondStage = false;
    private bool thirdStage = false;
    private bool fourthStage = false;
    private bool fourthStagePart2 = false;
    private bool fifthStage = false;
    private bool fifthStagePart2 = false;
    private bool sixthStage = false;
    private bool lspot1, lspot2, lspot3;
    public Camera cam;
    public XRDirectInteractor rHand;
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
    public GameObject dust;
    public GameObject thankYou;
    public GameObject smoke;
    private GameManager GM;

    private void Awake()
    {
        GM = FindObjectOfType<GameManager>();
    }
    // Start is called before the first frame update
    void Start()
    {
        messageListener = FindObjectOfType<MessageListenerTutorial>();
        StartCoroutine("WakeUpScene");
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = cam.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));
        RaycastHit hit;
        if (secondStage)
        {
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.name == "Floor_Bottom_01")
                {
                    tasks[0].SetActive(false);
                    print("hit floor");
                }
                if (hit.transform.name == "Floor_Top_01")
                {
                    print("hit top");
                    tasks[1].SetActive(false);
                }
                if (hit.transform.name == "Task Sculpture")
                {
                    print("hit sculpture");
                    tasks[2].SetActive(false);
                }
                if (hit.transform.name == "Task Painting")
                {
                    print("hit painting");
                    tasks[3].SetActive(false);
                }

                if (tasks[0].activeSelf == false && tasks[1].activeSelf == false && tasks[2].activeSelf == false && tasks[3].activeSelf == false)
                {
                    print("reached");
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
            if (rHand.selectTarget != null)
            {
                if (rHand.selectTarget.tag == "Leaflet")
                {
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
                leafletPrefab.SetActive(false);
                putDown.SetActive(false);
                rays.SetActive(true);
                fourthStagePart2 = false;
                StartCoroutine("RayShootingEvent");
            }
        }

        if (fifthStage)
        {
            if (rHand.selectTarget != null)
            {
                if (rHand.selectTarget.tag == "Leaflet" || rHand.selectTarget.tag == "Scroll")
                {
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
                blowpipePrefab.SetActive(false);
                blowpipe.SetActive(false);
                dust.SetActive(false);
                barPrefab.SetActive(false);
                sixthStage = false;
                scrollScreenDirty.SetActive(false);
                scrollScreenClean.SetActive(true);
                thankYou.SetActive(true);
                smoke.SetActive(true);
                StartCoroutine("DesertScene");
            }

        }

    }
    public void HandleOnStateChange()
    {
        Debug.Log("OnStateChange!");
    }
    public void LightSpot1() {
        if (thirdStage)
        {
            lightSpots[0].SetActive(false);
            lspot1 = true;
        }
    }

    public void LightSpot2()
    {
        if (thirdStage)
        {
            lightSpots[1].SetActive(false);
            lspot2 = true;
        }
    }

    public void LightSpot3()
    {
        if (thirdStage)
        {
            lightSpots[2].SetActive(false);
            lspot3 = true;
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
        yield return new WaitForSeconds(2);
        moveBody.SetActive(true);
        StartCoroutine("EndFirstScene");
    }
    IEnumerator EndFirstScene()
    {
        yield return new WaitForSeconds(2);
        wakeUp.SetActive(false);
        timna.SetActive(false);
        moveBody.SetActive(false);
        changePerspective.SetActive(true);
        StartCoroutine("CompleteContentScene");
    }
    IEnumerator CompleteContentScene()
    {
        yield return new WaitForSeconds(2);
        completeContent.SetActive(true);
        tasksPrefab.SetActive(true);
        secondStage = true;
        
    }

    IEnumerator EndSecondScene()
    {
        yield return new WaitForSeconds(2);
        well.SetActive(false);
        rightHand.SetActive(true);
        StartCoroutine("LightSpotScene");
    }

    IEnumerator LightSpotScene()
    {
        yield return new WaitForSeconds(2);
        lightSpot.SetActive(true);
        foreach (GameObject l in lightSpots)
        {
            l.SetActive(true);
        }
        thirdStage = true;

    }

    IEnumerator EndThirdScene()
    {
        yield return new WaitForSeconds(2);
        better.SetActive(false);
        grab.SetActive(true);
        StartCoroutine("LeafletEvent");
    }

    IEnumerator LeafletEvent()
    {
        yield return new WaitForSeconds(2);
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
        yield return new WaitForSeconds(2f);
        flyer.SetActive(false);
        fourthStagePart2 = true;
        putDown.SetActive(true);
    }

    IEnumerator RayShootingEvent()
    {
        yield return new WaitForSeconds(2f);
        rayShooting.SetActive(true);
        StartCoroutine("RayScrollEvent");
    }

    IEnumerator RayScrollEvent()
    {
        yield return new WaitForSeconds(2f);
        rayScroll.SetActive(true);
        scrollPrefab.SetActive(true);
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
    }

    IEnumerator DesertScene()
    {
        yield return new WaitForSeconds(10f);
        GM.MainGame();
    }
}
