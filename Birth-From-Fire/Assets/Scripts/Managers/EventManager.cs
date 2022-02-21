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
    private CampfireAndBlowPipeCollision campfireAndBlowPipeCollision;
    public LightSpotMovement lightSpotMovement;
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
    private bool eleventhStage = false;
    private bool twelvethStage = false;
    private bool thirteenthStage = false;
    private bool fourteenthStage = false;
    private bool playOnce1;
    private bool enough = false;
    private bool inhale = false;
    private bool oreGlow, charcoalGlow, vesselGlow;
    private bool startSnakeEvent = false;
    public VesselCollision finalVesselCollision;
    public Vector3 vesselTransform;
    public int countOre = 0;
    private float dirtTimer = 0;
    private int dirtDelay = 5;
    public bool checkVesselPosition = false;
    public bool enableVesselCollision = false;
    public bool enableFloorCollision = false;
    public bool breathPhase1 = false;
    public XRDirectInteractor rHand;
    public XRDirectInteractor tong;
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
    public GameObject vesselLiquid;
    public GameObject vesselSlag;
    public GameObject vesselLight;
    public GameObject blowpipePrefab;
    public GameObject fireUIPrefab;
    public GameObject redFlamePrefab;
    public GameObject lavaDownLPrefab;
    public GameObject lavaDownRPrefab;
    public GameObject dirtLavaPrefab;
    public GameObject snakePrefab;
    public GameObject finishedCopperPrefab;
    public GameObject finalLightSpotPrefab;
    public GameObject mirrorPrefab;
    public GameObject titleText;
    public GameObject negevDesertText;
    public GameObject archeologistsText;
    public GameObject blessingText;
    public GameObject hathorText;
    public GameObject patronessText;
    public GameObject strengthText;
    public GameObject secretText;
    public GameObject promiseText;
    public GameObject saltText;
    public GameObject ruahText;
    public GameObject technologyText;
    public GameObject egyptiansText;
    public GameObject traditionalText;
    public GameObject shamansText;
    public GameObject magiciansText;
    public GameObject metalsmithText;
    public GameObject chooseOreText;
    public GameObject placeOreText;
    public GameObject furnaceText;
    public GameObject charcoalText;
    public GameObject enoughText;
    public GameObject insertBlowPipeText;
    public GameObject drumText;
    public GameObject flameText;
    public GameObject magicalText;
    public GameObject bellyText;
    public GameObject spaceText;
    public GameObject countsText;
    public GameObject lengthText;
    public GameObject fallText;
    public GameObject birthdayText;
    public GameObject guideText;
    public GameObject readyText;
    public GameObject insertFurnaceText;
    public GameObject rawText;
    public GameObject newbornText;
    public GameObject removeVesselText;
    public GameObject dirtPileText;
    public GameObject orgPositionText;
    public GameObject birthText;
    public GameObject seeText;
    public GameObject divineText;
    public GameObject lifeForceText;
    public GameObject cooledText;
    //public GameObject snakeText;
    public GameObject getCopperText;
    public GameObject placeCopperText;
    public GameObject copperMirrorText;
    public GameObject hathorBlessedText;
    public GameObject thankYouText;
    public GameObject memoryText;
    public GameObject ancestorsText;
    public GameObject enjoyText;
    public GameObject celebrationText;
    public Material dawn;
    public Animator childAnimator;
    public Animator oldManAnimator;

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
        campfireAndBlowPipeCollision = FindObjectOfType<CampfireAndBlowPipeCollision>();
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
            glows[3].SetActive(true);
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
                vesselSlagPrefab.GetComponent<Rigidbody>().isKinematic = true;
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
                redFlamePrefab.SetActive(true);
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

        //added place blowpipe in furnace
        if (sixthStage)
        {
            if (campfireAndBlowPipeCollision.pipeInFurnace)
            {
                insertBlowPipeText.SetActive(false);
                sixthStage = false;
                seventhStage = true;
            }
        }

        if (seventhStage)
        {
            if (!inhale)
            {
                StartCoroutine("Drums");
                inhale = true;
            }
            seventhStage = false;
        }

        if (messageListener.birth)
        {
            StartCoroutine(Birth());
            messageListener.birth = false;
        }

        if (eigthStage)
        {
            tongPrefab.SetActive(true);
            blowPipeHoldPrefab.SetActive(false);
            handPrefab.SetActive(false);


            vesselSlagPrefab.GetComponent<XRGrabInteractable>().interactionLayerMask = LayerMask.GetMask("Grabbable");

            //might be a floating bug if the player puts back vessel in the furnace
            if (tong.selectTarget != null)
            {
                if (tong.selectTarget.tag == "Vessel")
                {
                    campfireCollision.inFurnace = false;
                    ninthStage = true;
                    eigthStage = false;
                }
            }
        }

        if (ninthStage)
        {
            if (tong.selectTarget != null)
            {
                if (tong.selectTarget.tag == "Vessel")
                {
                    campfireCollision.inFurnace = false;
                }
            }

            //dirt glow
            glows[5].SetActive(true);
            removeVesselText.SetActive(false);
            dirtPileText.SetActive(true);

            //pouring slag
            if (tong.selectTarget != null)
            {
                //pouring slag
                if (tong.selectTarget.transform.localRotation.z >= 0.50)
                {

                    lavaDownLPrefab.SetActive(true);
                    dirtTimer += Time.deltaTime;
                }
                else if (tong.selectTarget.transform.localRotation.z <= -0.50)
                {
                    lavaDownRPrefab.SetActive(true);
                    dirtTimer += Time.deltaTime;
                }
                else
                {
                    lavaDownLPrefab.SetActive(false);
                    lavaDownRPrefab.SetActive(false);
                }
            }

            if (dirtTimer >= 5)
            {
                dirtLavaPrefab.SetActive(true);
                lavaDownLPrefab.SetActive(false);
                lavaDownRPrefab.SetActive(false);
                vesselLight.SetActive(false);
                vesselLiquid.SetActive(false);
                vesselSlag.SetActive(false);
                ninthStage = false;
                tenthStage = true;
            }
        }

        if (tenthStage)
        {

            if (tong.selectTarget != null)
            {
                if (tong.selectTarget.tag == "Vessel")
                {
                    campfireCollision.inFurnace = false;
                }
            }

            glows[5].SetActive(false);
            dirtPileText.SetActive(false);
            orgPositionText.SetActive(true);


            checkVesselPosition = true;
            //org vessel pos glow
            glows[4].SetActive(true);
            if (!finalVesselCollision.vesselGrabbable)
            {
                orgPositionText.SetActive(false);
                vesselSlagPrefab.GetComponent<XRGrabInteractable>().interactionLayerMask = LayerMask.GetMask("Nothing");
                //vessel glow
                glows[1].SetActive(false);
                //org vessel position glow
                glows[4].SetActive(false);
                tenthStage = false;
                eleventhStage = true;
            }
        }

        if (eleventhStage)
        {
            if (!startSnakeEvent)
            {
                StartCoroutine("SnakeEvent");
                startSnakeEvent = true;
            }
            eleventhStage = false;
        }

        if (twelvethStage)
        {
            if(tong.selectTarget != null)
            {
                if(tong.selectTarget.tag == "Copper")
                {
                    getCopperText.SetActive(false);
                    twelvethStage = false;
                    thirteenthStage = true;
                }
            }
        }

        if (thirteenthStage)
        {
            placeCopperText.SetActive(true);
            //slag vessel glow
            glows[1].SetActive(true);
            if (finalVesselCollision.celebration)
            {
                finishedCopperPrefab.GetComponent<XRGrabInteractable>().interactionLayerMask = LayerMask.GetMask("Nothing");
                //finished copper glow
                glows[6].SetActive(false);

                //slag vessel glow
                glows[1].SetActive(false);
                placeCopperText.SetActive(false);
                thirteenthStage = false;
                StartCoroutine("CopperMirror");
                //fourteenthStage = true;
            }

        }

        if (fourteenthStage)
        {
            snakePrefab.SetActive(false);
            finalLightSpotPrefab.SetActive(true);
            if (lightSpotMovement.mirror)
            {
                StartCoroutine("Blessed");
                fourteenthStage = false;
            }

        }

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
        StartCoroutine("Secret");
    }

    IEnumerator Secret()
    {
        secretText.SetActive(true);
        yield return new WaitForSeconds(5);
        secretText.SetActive(false);
        StartCoroutine("Promise");
    }

    IEnumerator Promise()
    {
        promiseText.SetActive(true);
        yield return new WaitForSeconds(5);
        promiseText.SetActive(false);
        StartCoroutine("Salt");
    }

    IEnumerator Salt()
    {
        saltText.SetActive(true);
        yield return new WaitForSeconds(5);
        saltText.SetActive(false);
        StartCoroutine("Ruah");
    }

    IEnumerator Ruah()
    {
        ruahText.SetActive(true);
        yield return new WaitForSeconds(5);
        ruahText.SetActive(false);
        StartCoroutine("Technology");
    }

    IEnumerator Technology()
    {
        technologyText.SetActive(true);
        yield return new WaitForSeconds(5);
        technologyText.SetActive(false);
        StartCoroutine("Egyptians");
    }

    IEnumerator Egyptians()
    {
        egyptiansText.SetActive(true);
        yield return new WaitForSeconds(5);
        egyptiansText.SetActive(false);
        StartCoroutine("Traditional");
    }

    IEnumerator Traditional()
    {
        traditionalText.SetActive(true);
        yield return new WaitForSeconds(5);
        traditionalText.SetActive(false);
        StartCoroutine("Shamans");
    }

    IEnumerator Shamans()
    {
        shamansText.SetActive(true);
        yield return new WaitForSeconds(5);
        shamansText.SetActive(false);
        StartCoroutine("Magicians");
    }

    IEnumerator Magicians()
    {
        magiciansText.SetActive(true);
        yield return new WaitForSeconds(5);
        magiciansText.SetActive(false);
        //start choose ore pile scene
        chooseOreText.SetActive(true);
        firstStage = true;
    }
    //added place blowpipe functionality
    IEnumerator StartEnough()
    {
        enoughText.SetActive(true);
        yield return new WaitForSeconds(5);
        enoughText.SetActive(false);
        insertBlowPipeText.SetActive(true);
        blowPipeHoldPrefab.SetActive(true);
        blowpipePrefab.SetActive(false);
        sixthStage = true;
    }
    IEnumerator Drums()
    {
        audioManager.Play("Drums");
        drumText.SetActive(true);
        yield return new WaitForSeconds(5);
        drumText.SetActive(false);
        StartCoroutine("Flame");
    }

    IEnumerator Flame()
    {
        flameText.SetActive(true);
        yield return new WaitForSeconds(5);
        flameText.SetActive(false);
        StartCoroutine("Magical");
    }
    IEnumerator Magical()
    {
        magicalText.SetActive(true);
        yield return new WaitForSeconds(5);
        magicalText.SetActive(false);
        StartCoroutine("Belly");
    }

    IEnumerator Belly()
    {
        bellyText.SetActive(true);
        yield return new WaitForSeconds(5);
        bellyText.SetActive(false);
        StartCoroutine("Space");
    }

    IEnumerator Space()
    {
        spaceText.SetActive(true);
        yield return new WaitForSeconds(5);
        spaceText.SetActive(false);
        StartCoroutine("Counts");
    }

    IEnumerator Counts()
    {
        countsText.SetActive(true);
        yield return new WaitForSeconds(5);
        countsText.SetActive(false);
        StartCoroutine("Length");
    }

    IEnumerator Length()
    {
        lengthText.SetActive(true);
        yield return new WaitForSeconds(5);
        lengthText.SetActive(false);
        StartCoroutine("Fall");
    }

    IEnumerator Fall()
    {
        fallText.SetActive(true);
        yield return new WaitForSeconds(5);
        fallText.SetActive(false);
        StartCoroutine("Birthday");
    }

    IEnumerator Birthday()
    {
        birthdayText.SetActive(true);
        yield return new WaitForSeconds(5);
        birthdayText.SetActive(false);
        StartCoroutine("Guide");
    }

    IEnumerator Guide()
    {
        guideText.SetActive(true);
        yield return new WaitForSeconds(5);
        guideText.SetActive(false);
        StartCoroutine("Ready");
    }

    IEnumerator Ready()
    {
        readyText.SetActive(true);
        yield return new WaitForSeconds(5);
        readyText.SetActive(false);
        StartCoroutine("InsertFurnace");
    }

    IEnumerator InsertFurnace()
    {
        insertFurnaceText.SetActive(true);
        yield return new WaitForSeconds(5);
        insertFurnaceText.SetActive(false);
        StartCoroutine("Raw");
    }

    IEnumerator Raw()
    {
        rawText.SetActive(true);
        yield return new WaitForSeconds(5);
        rawText.SetActive(false);
        StartCoroutine("StartInhale");
    }

    IEnumerator StartInhale()
    {
        breathPhase1 = true;
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
        birthText.SetActive(true);
        yield return new WaitForSeconds(6);
        birthText.SetActive(false);
        StartCoroutine("Newborn");
    }

    IEnumerator Newborn()
    {
        newbornText.SetActive(true);
        yield return new WaitForSeconds(6);
        newbornText.SetActive(false);
        eigthStage = true;
        removeVesselText.SetActive(true);
        glows[1].SetActive(true);
    }

    IEnumerator SnakeEvent()
    {
        snakePrefab.SetActive(true);
        seeText.SetActive(true);
        yield return new WaitForSeconds(6);
        seeText.SetActive(false);
        StartCoroutine("Divine");
    }

    IEnumerator Divine()
    {
        divineText.SetActive(true);
        yield return new WaitForSeconds(6);
        divineText.SetActive(false);
        StartCoroutine("LifeForce");
    }
    IEnumerator LifeForce()
    {
        lifeForceText.SetActive(true);
        yield return new WaitForSeconds(6);
        lifeForceText.SetActive(false);
        StartCoroutine("Cooled");
    }

    IEnumerator Cooled()
    {
        cooledText.SetActive(true);
        yield return new WaitForSeconds(6);
        cooledText.SetActive(false);
        finishedCopperPrefab.SetActive(true);
        dirtLavaPrefab.SetActive(false); ;
        getCopperText.SetActive(true);
        twelvethStage = true;
    }

    IEnumerator CopperMirror()
    {
        copperMirrorText.SetActive(true);
        yield return new WaitForSeconds(6);
        copperMirrorText.SetActive(false);
        fourteenthStage = true;
    }

    IEnumerator Blessed()
    {
        hathorBlessedText.SetActive(true);
        finishedCopperPrefab.SetActive(false);
        finalLightSpotPrefab.SetActive(false);
        mirrorPrefab.SetActive(true);
        yield return new WaitForSeconds(6);
        hathorBlessedText.SetActive(false);
        StartCoroutine("ThankYou");
    }

    IEnumerator ThankYou()
    {
        thankYouText.SetActive(true);
        yield return new WaitForSeconds(6);
        thankYouText.SetActive(false);
        StartCoroutine("Memory");
    }

    IEnumerator Memory()
    {
        memoryText.SetActive(true);
        yield return new WaitForSeconds(6);
        memoryText.SetActive(false);
        StartCoroutine("Ancestors");
    }

    IEnumerator Ancestors()
    {
        ancestorsText.SetActive(true);
        yield return new WaitForSeconds(6);
        ancestorsText.SetActive(false);
        StartCoroutine("Enjoy");
    }

    IEnumerator Enjoy()
    {
        enjoyText.SetActive(true);
        yield return new WaitForSeconds(6);
        enjoyText.SetActive(false);
        StartCoroutine("Celebration");
    }
    
    //can turn into normal function
    IEnumerator Celebration()
    {
        enjoyText.SetActive(true);
        celebrationText.SetActive(true);
        audioManager.Play("celebration");
        RenderSettings.skybox = dawn;
        childAnimator.SetBool("Celebration", true);
        oldManAnimator.SetBool("Celebration", true);
        tongPrefab.SetActive(false);
        handPrefab.SetActive(true);
        yield return new WaitForSeconds(1);

    }

}