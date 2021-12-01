using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class EventManager : MonoBehaviour
{
    private AudioManager audioManager;
    private CampfireCollision campfireCollision;
    private FloorCollision floorCollision;
    private MessageListener messageListener;
    private bool firstStage = true;
    private bool secondStage, thirdStage, fourthStage, fifthStage, sixthStage, seventhStage, eigthStage ,ninthStage,tenthStage= false;
    private bool playOnce1;
    private bool enough = false;
    private bool inhale = false;
    public VesselCollision finalVesselCollision;
    public Vector3 vesselTransform;
    public int countOre = 0;
    public bool checkVesselPosition = false;
    public bool enableVesselCollision = false;
    public bool enableFloorCollision = false;
    public XRDirectInteractor rHand;
    public List<GameObject> charcoals = new List<GameObject>();
    public List<GameObject> vCharcoals = new List<GameObject>();
    public List<GameObject> vessels = new List<GameObject>();
    public List<GameObject> glows = new List<GameObject>();
    public GameObject tongPrefab;
    public GameObject handPrefab;
    public GameObject charcoalPiece;
    public GameObject rHandPrefab;
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
    //public GameObject ninthStageText;
    public GameObject tenthStageText;
    void Start()
    {
        audioManager.Play("Dessert ambience");
        vesselTransform = vesselPrefab.transform.position;
        audioManager = FindObjectOfType<AudioManager>();
        messageListener = FindObjectOfType<MessageListener>();
        campfireCollision = FindObjectOfType<CampfireCollision>();
        floorCollision = FindObjectOfType<FloorCollision>();
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
            //ore glow
            glows[0].SetActive(true);
            if (rHand.selectTarget != null)
            {
                if (rHand.selectTarget.tag == "Small Ore")
                {
                    firstStagetext.SetActive(false);
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
            //First vessel Glow
            glows[6].SetActive(true);
            if (countOre == 1)
            {
                if (!playOnce1)
                {
                    audioManager.Play("Ore falling on the vessel");
                    playOnce1 = true;
                }
                vessels[0].SetActive(false);
                vessels[1].SetActive(true);

                //need to refactor
                secondStage = false;
                thirdStage = true;
                secondStagetext.SetActive(false);
            }
        }

        //need to refactor
        if (thirdStage)
        {
            //vessel glow
            glows[1].SetActive(true);
            //need to refactor
            thirdStagetext.SetActive(true);

            if (campfireCollision.inFurnace == true)
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
            //vessel glow
            glows[1].SetActive(false);
            //charcoal glow
            glows[2].SetActive(true);
            //need to refactor
            fourthStageText.SetActive(true);
            foreach (GameObject c in charcoals)
            {
                c.GetComponent<XRGrabInteractable>().interactionLayerMask = LayerMask.GetMask("Grabbable");
            }

            if (campfireCollision.countCharcoal == 1)
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
            if(campfireCollision.pipeInFurnace == true)
            {
                //blowpipe glow
                glows[5].SetActive(false);
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
            blowpipePrefab.SetActive(false);
            checkVesselPosition = true;
            tongPrefab.SetActive(true);
            handPrefab.SetActive(false);
            //org vessel pos glow
            glows[7].SetActive(true);
            fullVesselPrefab.GetComponent<XRGrabInteractable>().interactionLayerMask = LayerMask.GetMask("Grabbable");
            if (!finalVesselCollision.vesselGrabbable)
            {
                charcoalPiece.SetActive(false);
                fullVesselPrefab.GetComponent<XRGrabInteractable>().interactionLayerMask = LayerMask.GetMask("Nothing");
                //vessel pos glow
                glows[3].SetActive(false);
                //vessel glow
                glows[1].SetActive(false);
                //org vessel position glow
                glows[7].SetActive(false);
                foreach (GameObject c in vCharcoals)
                {
                    c.SetActive(true);
                    c.GetComponent<MeshCollider>().enabled = true;
                    c.GetComponent<XRGrabInteractable>().interactionLayerMask = LayerMask.GetMask("Grabbable");
                }
                //v charcoal glow
                glows[4].SetActive(true);
                eigthStage = false;
                ninthStage = true;
            }
        }

        if (ninthStage)
        {
            enableFloorCollision = true;
            if (floorCollision.charcoalOnFloor)
            {
                //v charcoal glow
                glows[4].SetActive(false);
                seventhStageText.SetActive(false);
                ninthStage = false;
                tenthStage = true;
            }
        }

        if (tenthStage)
        {
             tenthStageText.SetActive(true);
             tenthStage = false;
        }
    }

    IEnumerator StartEnough()
    {
        enoughText.SetActive(true);
        yield return new WaitForSeconds(5);
        blowpipePrefab.GetComponent<XRGrabInteractable>().interactionLayerMask = LayerMask.GetMask("Grabbable");
        enoughText.SetActive(false);
        fifthStageText.SetActive(true);
        //blowpipe glow
        glows[5].SetActive(true);
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
        //vessel pos glow
        glows[3].SetActive(true);
        //vessel glow
        glows[1].SetActive(true);
    }
}
