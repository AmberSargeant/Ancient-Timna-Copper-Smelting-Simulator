using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class EventManager : MonoBehaviour
{
    private VesselCollision vesselCollision;
    private FurnaceCollision furnaceCollision;
    private BlowPipeCollision blowPipeCollision;
    private bool firstStage = true;
    private bool secondStage, thirdStage, fourthStage, fifthStage, sixthStage, seventhStage = false;
    private bool enough = false;
    private bool inhale = false;
    public XRDirectInteractor rHand;
    public List<GameObject> charcoals = new List<GameObject>();
    public GameObject largeOrePrefab;
    public GameObject smallOrePrefab;
    public GameObject vesselPrefab;
    public GameObject blowpipePrefab;
    public GameObject fireUIPrefab;
    public GameObject firstStagetext;
    public GameObject secondStagetext;
    public GameObject thirdStagetext;
    public GameObject fourthStageText;
    public GameObject enoughText;
    public GameObject fifthStageText;
    public GameObject sixthStageText;
    public GameObject inhaleText;
    void Start()
    {
        vesselCollision = FindObjectOfType<VesselCollision>();
        furnaceCollision = FindObjectOfType<FurnaceCollision>();
        blowPipeCollision = FindObjectOfType<BlowPipeCollision>();
        vesselPrefab.GetComponent<XRGrabInteractable>().interactionLayerMask = LayerMask.GetMask("Nothing");
        blowpipePrefab.GetComponent<XRGrabInteractable>().interactionLayerMask = LayerMask.GetMask("Nothing");
        foreach (GameObject c in charcoals)
        {
            c.GetComponent<XRGrabInteractable>().interactionLayerMask = LayerMask.GetMask("Nothing");
        }
    }
    void Update()
    {
        //need to refactor
        if (firstStage)
        {
            if (rHand.selectTarget != null)
            {
                if (rHand.selectTarget.tag == "Big Ore")
                {
                    firstStagetext.SetActive(false);
                    smallOrePrefab.SetActive(false);
                    //need to refactor
                    firstStage = false;
                    secondStage = true;

                }
                else if (rHand.selectTarget.tag == "Small Ore")
                {
                    firstStagetext.SetActive(false);
                    largeOrePrefab.SetActive(false);
                    //need to refactor
                    firstStage = false;
                    secondStage = true;
                }
            }
        }

        //need to refactor
        if (secondStage)
        {
            //need to refactor
            secondStagetext.SetActive(true);
            vesselCollision.enableCollision = true;

            if (vesselCollision.countOre == 5)
            {
                //need to refactor
                secondStage = false;
                thirdStage = true;
                secondStagetext.SetActive(false);
            }
        }

        //need to refactor
        if (thirdStage)
        {
            vesselPrefab.GetComponent<XRGrabInteractable>().interactionLayerMask = LayerMask.GetMask("Grabbable");
            vesselPrefab.GetComponent<Rigidbody>().isKinematic = false;
            //need to refactor
            thirdStagetext.SetActive(true);

            if (furnaceCollision.inFurnace == true)
            {
                fourthStage = true;
                thirdStagetext.SetActive(false);
            }

        }

        //need to refactor
        if (fourthStage)
        {
            //need to refactor
            fourthStageText.SetActive(true);
            foreach (GameObject c in charcoals)
            {
                c.GetComponent<XRGrabInteractable>().interactionLayerMask = LayerMask.GetMask("Grabbable");
            }

            if (furnaceCollision.countCharcoal == 5)
            {
                fourthStageText.SetActive(false);
                fourthStage = false;
                fifthStage = true;
            }
        }

        if (fifthStage)
        {
            if (!enough)
            {
                StartCoroutine("StartEnough");
                enough = true;
            }
            blowpipePrefab.GetComponent<XRGrabInteractable>().interactionLayerMask = LayerMask.GetMask("Grabbable");
            if (rHand.selectTarget != null)
            {
                if (rHand.selectTarget.tag == "BlowPipe")
                {
                    fifthStageText.SetActive(false);
                    sixthStage = true;
                    fifthStage = false;
                }
            }
        }

        if (sixthStage)
        {
            sixthStageText.SetActive(true);
            if(furnaceCollision.pipeInFurnace == true)
            {
                sixthStageText.SetActive(false);
                sixthStage = false;
                seventhStage = true;
            }
        }

        if (seventhStage)
        {
            if (!inhale)
            {
                StartCoroutine("StartInhale");
                inhale = true;
            }
            seventhStage = false;
        }

    }

    IEnumerator StartEnough()
    {
        enoughText.SetActive(true);
        yield return new WaitForSeconds(5);
        enoughText.SetActive(false);
        fifthStageText.SetActive(true);
    }
    IEnumerator StartInhale()
    {
        inhaleText.SetActive(true);
        yield return new WaitForSeconds(6);
        inhaleText.SetActive(false);
        fireUIPrefab.SetActive(true);
    }
}
