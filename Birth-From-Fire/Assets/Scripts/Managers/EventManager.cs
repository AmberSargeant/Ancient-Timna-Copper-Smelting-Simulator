using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;

public class EventManager : MonoBehaviour
{
    private AudioManager audioManager;
    private CampfireCollision campfireCollision;
    private FloorCollision floorCollision;
    private MessageListener messageListener;
    private bool firstStage = false;
    private bool secondStage = false;
    private bool thirdStage = false;
    private bool fourthStage = false;
    private bool fifthStage = false;
    private bool sixthStage = false;
    private bool seventhStage = false;
    private bool eigthStage = false;
    private bool ninthStage = false;
    private bool tenthStage = false;
    private bool playOnce1;
    private bool enough = false;
    private bool inhale = false;
    private bool oreGlow, charcoalGlow, vesselGlow;
    public VesselCollision finalVesselCollision;
    public Vector3 vesselTransform;
    public int countOre = 0;
    public bool checkVesselPosition = false;
    public bool enableVesselCollision = false;
    public bool enableFloorCollision = false;
    public bool breathPhase1 = false;
    public XRDirectInteractor rHand;
    public XRDirectInteractor tong;
    public List<Image> whiteScreens;
    public List<GameObject> charcoals = new List<GameObject>();
    public List<GameObject> vessels = new List<GameObject>();
    public List<GameObject> glows = new List<GameObject>();
    public GameObject tongPrefab;
    public GameObject handPrefab;
    public GameObject blowPipeHoldPrefab;
    public GameObject rHandPrefab;
    public GameObject smallOrePrefab;
    public GameObject vesselPrefab;
    public GameObject fullVesselPrefab;
    public GameObject vesselSlagPrefab;
    public GameObject blowpipePrefab;
    public GameObject fireUIPrefab;
    public GameObject titleText;
    public GameObject negevDesertText;
    public GameObject archeologistsText;
    public GameObject blessingText;
    public GameObject hathorText;
    public GameObject patronessText;
    public GameObject strengthText;
    public GameObject chooseOreText;
    public GameObject placeOreText;
    public GameObject furnaceText;
    public GameObject charcoalText;
    public GameObject enoughText;
    public GameObject drumText;
    public GameObject blowPipeText;
    public GameObject insertBlowPipeText;
    public GameObject removeVesselText;
    public GameObject birthText;
    public GameObject celebrationText;

    private void Awake()
    {
        audioManager = FindObjectOfType<AudioManager>();
    }
    void Start()
    {
        StartCoroutine("Intro");
        audioManager.Play("Dessert ambience");
        vesselTransform = vesselPrefab.transform.position;
        messageListener = FindObjectOfType<MessageListener>();
        campfireCollision = FindObjectOfType<CampfireCollision>();
        floorCollision = FindObjectOfType<FloorCollision>();
        smallOrePrefab.GetComponent<XRGrabInteractable>().interactionLayerMask = LayerMask.GetMask("Nothing");
        vesselPrefab.GetComponent<XRGrabInteractable>().interactionLayerMask = LayerMask.GetMask("Nothing");
        blowpipePrefab.GetComponent<XRGrabInteractable>().interactionLayerMask = LayerMask.GetMask("Nothing");
        foreach (GameObject c in charcoals)
        {
            c.GetComponent<XRGrabInteractable>().interactionLayerMask = LayerMask.GetMask("Nothing");
        }
    }
    void Update()
    {
        //crossfade alpha
        foreach (Image w in whiteScreens)
        {
            w.CrossFadeAlpha(0, 3, false);
        }
        //need to refactor
        if (firstStage)
        {
            smallOrePrefab.GetComponent<XRGrabInteractable>().interactionLayerMask = LayerMask.GetMask("Grabbable");
            //ore glow
            if (!oreGlow)
            {
                glows[0].SetActive(true);
                oreGlow = true;
            }
                if (rHand.selectTarget != null)
            {
                if (rHand.selectTarget.tag == "Small Ore")
                {
                    chooseOreText.SetActive(false);
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
            placeOreText.SetActive(true);
            enableVesselCollision = true;
            //First vessel Glow
            glows[4].SetActive(true);
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
                placeOreText.SetActive(false);
            }
        }

        //need to refactor
        if (thirdStage)
        {
            //vessel glow
            if (!vesselGlow)
            {
                glows[1].SetActive(true);
                vesselGlow = true;
            }
            //need to refactor
            furnaceText.SetActive(true);

            if (campfireCollision.inFurnace == true)
            {
                //change to slag vessel here
       
                fourthStage = true;
                furnaceText.SetActive(false);
                thirdStage = false;
                fullVesselPrefab.SetActive(false);
                vesselSlagPrefab.SetActive(true);
                vesselSlagPrefab.transform.localPosition = new Vector3(1.7566f, -0.8999999f, -4.055f);
            }

        }

        //need to refactor
        if (fourthStage)
        {
            //vessel glow
            glows[1].SetActive(false);
            //charcoal glow
            if (!charcoalGlow)
            {
                glows[2].SetActive(true);
                charcoalGlow = true;
            }
            //need to refactor
            charcoalText.SetActive(true);
            foreach (GameObject c in charcoals)
            {
                c.GetComponent<XRGrabInteractable>().interactionLayerMask = LayerMask.GetMask("Grabbable");
            }

            if (campfireCollision.countCharcoal == 1)
            {
                charcoalText.SetActive(false);
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
        }

        //removed placing into the furnace, might need to put
        //direction text here.
        if (sixthStage)
        {
            sixthStage = false;
            seventhStage = true;
        }

        if (seventhStage)
        {
            if (!inhale)
            {
                blowPipeHoldPrefab.SetActive(true);
                blowpipePrefab.SetActive(false);
                StartCoroutine("StartInhale");
                inhale = true;
                breathPhase1 = true;
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
            tongPrefab.SetActive(true);
            blowPipeHoldPrefab.SetActive(false);
            handPrefab.SetActive(false);

            //**if vessel is palced back to original position*****
            ////org vessel pos glow
            //glows[5].SetActive(true);

            

            //vesselSlagPrefab.GetComponent<XRGrabInteractable>().interactionLayerMask = LayerMask.GetMask("Grabbable");
            //if (!finalVesselCollision.vesselGrabbable)
            //{
            //    vesselSlagPrefab.GetComponent<XRGrabInteractable>().interactionLayerMask = LayerMask.GetMask("Nothing");
            //    //vessel pos glow
            //    glows[3].SetActive(false);
            //    //vessel glow
            //    glows[1].SetActive(false);
            //    //org vessel position glow
            //    glows[5].SetActive(false);
            //    eigthStage = false;
            //    ninthStage = true;
            //}
        }

        //if (ninthStage)
        //{
        //    removeVesselText.SetActive(false);
        //    ninthStage = false;
        //    tenthStage = true;
        //}

        //celebration stage;
        //if (tenthStage)
        //{
        //    celebrationText.SetActive(true);
        //    tenthStage = false;
        //}
    }
    IEnumerator Intro()
    {
        yield return new WaitForSeconds(8);
        titleText.SetActive(false);
        StartCoroutine("NegevDesert");
    }

    IEnumerator NegevDesert()
    {
        negevDesertText.SetActive(true);
        yield return new WaitForSeconds(5);
        negevDesertText.SetActive(false);
        StartCoroutine("Archeologists");
    }

    IEnumerator Archeologists()
    {
        archeologistsText.SetActive(true);
        yield return new WaitForSeconds(5);
        archeologistsText.SetActive(false);
        StartCoroutine("Blessing");
    }
    IEnumerator Blessing()
    {
        blessingText.SetActive(true);
        yield return new WaitForSeconds(5);
        blessingText.SetActive(false);
        StartCoroutine("Hathor");
    }
    IEnumerator Hathor()
    {
        hathorText.SetActive(true);
        yield return new WaitForSeconds(5);
        hathorText.SetActive(false);
        StartCoroutine("Patroness");
    }
    IEnumerator Patroness()
    {
        patronessText.SetActive(true);
        yield return new WaitForSeconds(5);
        patronessText.SetActive(false);
        StartCoroutine("Strength");
    }

    IEnumerator Strength()
    {
        strengthText.SetActive(true);
        yield return new WaitForSeconds(5);
        strengthText.SetActive(false);
        chooseOreText.SetActive(true);
        firstStage = true;
    }

    //removed blowpipe grabability and directly added it to hand
    IEnumerator StartEnough()
    {
        enoughText.SetActive(true);
        yield return new WaitForSeconds(5);
        enoughText.SetActive(false);
        sixthStage = true;
    }
    IEnumerator StartInhale()
    {
        audioManager.Play("Drums");
        drumText.SetActive(true);
        messageListener.breatheIn.SetActive(true);
        messageListener.breatheOut.SetActive(false);
        fireUIPrefab.SetActive(true);
        messageListener.celciusCounter = 750;
        yield return new WaitForSeconds(8);
        drumText.SetActive(false);
        messageListener.breatheIn.SetActive(false);
        messageListener.breatheOut.SetActive(true);
        messageListener.startBreathing = true;
    }

    IEnumerator Birth()
    {
        birthText.SetActive(true);
        yield return new WaitForSeconds(6);
        birthText.SetActive(false);
        removeVesselText.SetActive(true);
        //vessel pos glow
        glows[3].SetActive(true);
        //vessel glow
        glows[1].SetActive(true);
    }
}