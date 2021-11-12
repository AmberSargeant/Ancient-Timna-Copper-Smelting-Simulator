using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class EventManager : MonoBehaviour
{
    private AudioManager audioManager;
    private FurnaceCollision furnaceCollision;
    private BlowPipeCollision blowPipeCollision;
    private MessageListener messageListener;
    private bool firstStage = true;
    private bool secondStage, thirdStage, fourthStage, fifthStage, sixthStage, seventhStage, eigthStage ,ninthStage,tenthStage= false;
    private bool playOnce1, playOnce2, playOnce3, playOnce4, playOnce5;
    private bool enough = false;
    private bool inhale = false;
    public VesselCollision finalVesselCollision;
    public Vector3 vesselTransform;
    public int countOre = 0;
    public bool checkVesselPosition = false;
    public bool enableVesselCollision = false;
    public XRDirectInteractor rHand;
    public Transform tongPrefab;
    public List<GameObject> charcoals = new List<GameObject>();
    public List<GameObject> vCharcoals = new List<GameObject>();
    public List<GameObject> vessels = new List<GameObject>();
    public GameObject newCollider;
    public GameObject charcoalPiece;
    public GameObject rHandPrefab;
    public GameObject largeOrePrefab;
    public GameObject smallOrePrefab;
    public GameObject vesselPrefab;
    public GameObject fullVesselPrefab;
    public GameObject blowpipePrefab;
    public GameObject fireUIPrefab;
    public GameObject firstStagetext;
    public GameObject secondStagetext;
    public GameObject thirdStagetext;
    public GameObject fourthStageText;
    public GameObject enoughText;
    public GameObject fifthStageText;
    public GameObject sixthStageText;
    public GameObject seventhStageText;
    public GameObject eigthStageText;
    public GameObject ninthStageText;
    public GameObject tenthStageText;
    void Start()
    {
        vesselTransform = vesselPrefab.transform.position;
        audioManager = FindObjectOfType<AudioManager>();
        messageListener = FindObjectOfType<MessageListener>();
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
            enableVesselCollision = true;

            if(countOre == 1)
            {
                if (!playOnce1)
                {
                    audioManager.Play("Ore falling on the vessel");
                    playOnce1 = true;
                }
                vessels[0].SetActive(false);
                vessels[1].SetActive(true);
            }
            if (countOre == 2) 
            {
                if (!playOnce2)
                {
                    audioManager.Play("Ore falling on the vessel");
                    playOnce2 = true;
                }
                vessels[0].SetActive(false);
                vessels[1].SetActive(false);
                vessels[2].SetActive(true);
            }
            if(countOre == 3) 
            {
                if (!playOnce3)
                {
                    audioManager.Play("Ore falling on the vessel");
                    playOnce3 = true;
                }
                vessels[0].SetActive(false);
                vessels[1].SetActive(false);
                vessels[2].SetActive(false);
                vessels[3].SetActive(true);
            }
            if(countOre == 4)
            {
                if (!playOnce4)
                {
                    audioManager.Play("Ore falling on the vessel");
                    playOnce4 = true;
                }
                vessels[0].SetActive(false);
                vessels[1].SetActive(false);
                vessels[2].SetActive(false);
                vessels[3].SetActive(false);
                vessels[4].SetActive(true);
            }
            if (countOre == 5)
            {
                if (!playOnce5)
                {
                    audioManager.Play("Ore falling on the vessel");
                    playOnce5 = true;
                }
                vessels[0].SetActive(false);
                vessels[1].SetActive(false);
                vessels[2].SetActive(false);
                vessels[3].SetActive(false);
                vessels[4].SetActive(false);
                vessels[5].SetActive(true);

                //need to refactor
                secondStage = false;
                thirdStage = true;
                secondStagetext.SetActive(false);
            }
        }

        //need to refactor
        if (thirdStage)
        {
            //need to refactor
            thirdStagetext.SetActive(true);

            if (furnaceCollision.inFurnace == true)
            {
                charcoalPiece.SetActive(true);
                fourthStage = true;
                thirdStagetext.SetActive(false);
                thirdStage = false;
                fullVesselPrefab.GetComponent<XRGrabInteractable>().interactionLayerMask = LayerMask.GetMask("Nothing");
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
                blowpipePrefab.GetComponent<XRGrabInteractable>().interactionLayerMask = LayerMask.GetMask("Nothing");
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

        if (messageListener.birth)
        {
            StartCoroutine(Birth());
            eigthStage = true;
            messageListener.birth = false;
        }

        if (eigthStage)
        {
            checkVesselPosition = true;
            rHand.GetComponent<XRController>().modelPrefab = tongPrefab;
            fullVesselPrefab.GetComponent<XRGrabInteractable>().interactionLayerMask = LayerMask.GetMask("Grabbable");
            if (!finalVesselCollision.vesselGrabbable)
            {
                fullVesselPrefab.GetComponent<XRGrabInteractable>().interactionLayerMask = LayerMask.GetMask("Nothing");
                foreach (GameObject c in vCharcoals)
                {
                    c.SetActive(true);
                    c.GetComponent<MeshCollider>().enabled = true;
                    c.GetComponent<XRGrabInteractable>().interactionLayerMask = LayerMask.GetMask("Grabbable");
                }
                eigthStage = false;
                ninthStage = true;
            }
        }

        if (ninthStage)
        {
            if (furnaceCollision.countCharcoal == 10)
            {
                fullVesselPrefab.GetComponent<XRGrabInteractable>().interactionLayerMask = LayerMask.GetMask("Grabbable");
                checkVesselPosition = false;
                charcoalPiece.SetActive(false);
                seventhStageText.SetActive(false);
                ninthStageText.SetActive(true);
                ninthStage = false;
                tenthStage = true;
            }
        }

        if (tenthStage)
        {
            newCollider.SetActive(true);
            if (finalVesselCollision.celebration)
            {
                ninthStageText.SetActive(false);
                tenthStageText.SetActive(true);
                tenthStage = false;
            }
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
        messageListener.breatheIn.SetActive(true);
        messageListener.breatheOut.SetActive(false);
        fireUIPrefab.SetActive(true);
        messageListener.celciusCounter = 750;
        yield return new WaitForSeconds(6);
        messageListener.breatheIn.SetActive(false);
        messageListener.breatheOut.SetActive(true);
        messageListener.startBreathing = true;
    }

    IEnumerator Birth()
    {
        eigthStageText.SetActive(true);
        yield return new WaitForSeconds(6);
        eigthStageText.SetActive(false);
        seventhStageText.SetActive(true);
    }
}
