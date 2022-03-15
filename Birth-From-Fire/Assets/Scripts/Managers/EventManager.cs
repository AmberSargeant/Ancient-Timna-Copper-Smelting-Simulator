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
    private bool placeOreVoice = false;
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
    public GameObject fireUIPrefab;
    public GameObject redFlamePrefab;
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
    public GameObject developedText;
    public GameObject designerText;
    public GameObject threeDText;
    public GameObject twoDText;
    public GameObject programmerText;
    public GameObject audioText;
    public GameObject narrativeText;
    public GameObject QAText;
    public GameObject producerText;
    public GameObject stakeText;
    public GameObject instructorText;
    public GameObject musicText;
    public GameObject endingText;
    public GameObject besPrefab;
    public Material dawn;
    public Animator childAnimator;
    public Animator oldManAnimator;
    public Animator manAnimator;

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
                    StartCoroutine("PlaceOreVoice");
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
                audioManager.Stop("place ore");
                audioManager.Stop("crucible");
                audioManager.Play("furnace");
            }
        }

        //need to refactor
        if (thirdStage)
        {
            audioManager.Stop("crucible");
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
                audioManager.Stop("furnace");
                StartCoroutine("CharcoalVoice");
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
                audioManager.Stop("charcoal");
                audioManager.Stop("nourishment");
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
                audioManager.Stop("nourishment");
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
                audioManager.Stop("insert blowpipe");
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
                    audioManager.Stop("remove vessel");
                    campfireCollision.inFurnace = false;
                    ninthStage = true;
                    eigthStage = false;
                    StartCoroutine("DirtPileVoice");
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

                    
                    dirtTimer += Time.deltaTime;
                }
                else if (tong.selectTarget.transform.localRotation.z <= -0.50)
                {
                    dirtTimer += Time.deltaTime;
                }
            }

            if (dirtTimer >= 0.5)
            {
                dirtLavaPrefab.SetActive(true);
                vesselLight.SetActive(false);
                vesselLiquid.SetActive(false);
                vesselSlag.SetActive(false);
                ninthStage = false;
                tenthStage = true;
                audioManager.Stop("separate");
                audioManager.Stop("liquified");
                audioManager.Stop("dirt pile");
                audioManager.Play("original position");
            }
        }

        if (tenthStage)
        {
            audioManager.Stop("separate");
            audioManager.Stop("liquified");
            audioManager.Stop("dirt pile");
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
                audioManager.Stop("get copper");
                audioManager.Stop("born");
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
            audioManager.Stop("born");
            audioManager.Stop("copper snake");
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
        audioManager.Play("negev");
        negevDesertText.SetActive(true);
        yield return new WaitForSeconds(6);
        negevDesertText.SetActive(false);
        StartCoroutine("Blessing");
    }

    //IEnumerator Archeologists()
    //{
    //    archeologistsText.SetActive(true);
    //    yield return new WaitForSeconds(5);
    //    archeologistsText.SetActive(false);
    //    StartCoroutine("Blessing");
    //}
    IEnumerator Blessing()
    {
        audioManager.Play("blessing");
        blessingText.SetActive(true);
        yield return new WaitForSeconds(7);
        blessingText.SetActive(false);
        StartCoroutine("Hathor");
    }
    IEnumerator Hathor()
    {
        audioManager.Play("hathor");
        hathorText.SetActive(true);
        yield return new WaitForSeconds(4);
        hathorText.SetActive(false);
        StartCoroutine("Patroness");
    }
    IEnumerator Patroness()
    {
        patronessText.SetActive(true);
        yield return new WaitForSeconds(6);
        patronessText.SetActive(false);
        StartCoroutine("Strength");
    }

    IEnumerator Strength()
    {
        strengthText.SetActive(true);
        yield return new WaitForSeconds(8);
        strengthText.SetActive(false);
        StartCoroutine("Secret");
    }

    IEnumerator Secret()
    {
        audioManager.Play("secret");
        secretText.SetActive(true);
        yield return new WaitForSeconds(5);
        secretText.SetActive(false);
        StartCoroutine("Promise");
    }

    IEnumerator Promise()
    {
        promiseText.SetActive(true);
        yield return new WaitForSeconds(7);
        promiseText.SetActive(false);
        StartCoroutine("Salt");
    }

    IEnumerator Salt()
    {
        audioManager.Play("salt");
        saltText.SetActive(true);
        yield return new WaitForSeconds(9);
        saltText.SetActive(false);
        StartCoroutine("Ruah");
    }

    IEnumerator Ruah()
    {
        audioManager.Play("ruah");
        ruahText.SetActive(true);
        yield return new WaitForSeconds(9);
        ruahText.SetActive(false);
        StartCoroutine("Technology");
    }

    IEnumerator Technology()
    {
        audioManager.Play("technology");
        technologyText.SetActive(true);
        yield return new WaitForSeconds(5);
        technologyText.SetActive(false);
        StartCoroutine("Egyptians");
    }

    IEnumerator Egyptians()
    {
        audioManager.Play("egyptians");
        egyptiansText.SetActive(true);
        yield return new WaitForSeconds(10);
        egyptiansText.SetActive(false);
        StartCoroutine("Traditional");
    }

    IEnumerator Traditional()
    {
        audioManager.Play("traditional");
        traditionalText.SetActive(true);
        yield return new WaitForSeconds(6);
        traditionalText.SetActive(false);
        StartCoroutine("Shamans");
    }

    IEnumerator Shamans()
    {
        audioManager.Play("shamans");
        shamansText.SetActive(true);
        yield return new WaitForSeconds(5);
        shamansText.SetActive(false);
        StartCoroutine("Magicians");
    }

    IEnumerator Magicians()
    {
        magiciansText.SetActive(true);
        yield return new WaitForSeconds(6);
        magiciansText.SetActive(false);
        StartCoroutine("MetalSmith");
    }

    IEnumerator MetalSmith()
    {
        audioManager.Play("metalsmith");
        metalsmithText.SetActive(true);
        yield return new WaitForSeconds(6);
        metalsmithText.SetActive(false);
        //start choose ore pile scene
        audioManager.Play("choose ore");
        chooseOreText.SetActive(true);
        firstStage = true;
    }
    //added place blowpipe functionality
    IEnumerator StartEnough()
    {
        audioManager.Play("enough");
        enoughText.SetActive(true);
        yield return new WaitForSeconds(5);
        enoughText.SetActive(false);
        insertBlowPipeText.SetActive(true);
        blowPipeHoldPrefab.SetActive(true);
        audioManager.Play("insert blowpipe");
        sixthStage = true;
    }
    IEnumerator Drums()
    {
        audioManager.Play("Drums");
        audioManager.Play("drum");
        drumText.SetActive(true);
        yield return new WaitForSeconds(6);
        drumText.SetActive(false);
        StartCoroutine("Flame");
    }

    IEnumerator Flame()
    {
        flameText.SetActive(true);
        audioManager.Play("flame");
        yield return new WaitForSeconds(4);
        flameText.SetActive(false);
        StartCoroutine("Magical");
    }
    IEnumerator Magical()
    {
        audioManager.Play("magical");
        magicalText.SetActive(true);
        yield return new WaitForSeconds(9);
        magicalText.SetActive(false);
        StartCoroutine("Belly");
    }

    IEnumerator Belly()
    {
        audioManager.Play("belly");
        bellyText.SetActive(true);
        yield return new WaitForSeconds(7);
        bellyText.SetActive(false);
        StartCoroutine("Space");
    }

    IEnumerator Space()
    {
        audioManager.Play("space");
        spaceText.SetActive(true);
        yield return new WaitForSeconds(6);
        spaceText.SetActive(false);
        StartCoroutine("Counts");
    }

    IEnumerator Counts()
    {
        audioManager.Play("counts");
        countsText.SetActive(true);
        yield return new WaitForSeconds(13);
        countsText.SetActive(false);
        StartCoroutine("Length");
    }

    IEnumerator Length()
    {
        audioManager.Play("length");
        lengthText.SetActive(true);
        yield return new WaitForSeconds(5);
        lengthText.SetActive(false);
        StartCoroutine("Fall");
    }

    IEnumerator Fall()
    {
        audioManager.Play("fall");
        fallText.SetActive(true);
        yield return new WaitForSeconds(6);
        fallText.SetActive(false);
        StartCoroutine("Birthday");
    }

    IEnumerator Birthday()
    {
        audioManager.Play("birthday");
        birthdayText.SetActive(true);
        yield return new WaitForSeconds(5);
        birthdayText.SetActive(false);
        StartCoroutine("Guide");
    }

    IEnumerator Guide()
    {
        audioManager.Play("guide");
        guideText.SetActive(true);
        yield return new WaitForSeconds(5);
        guideText.SetActive(false);
        StartCoroutine("Ready");
    }

    IEnumerator Ready()
    {
        audioManager.Play("ready");
        readyText.SetActive(true);
        yield return new WaitForSeconds(4);
        readyText.SetActive(false);
        StartCoroutine("InsertFurnace");
    }

    IEnumerator InsertFurnace()
    {
        audioManager.Play("insert into furnace");
        insertFurnaceText.SetActive(true);
        yield return new WaitForSeconds(5);
        insertFurnaceText.SetActive(false);
        StartCoroutine("Raw");
    }

    IEnumerator Raw()
    {
        audioManager.Play("raw");
        rawText.SetActive(true);
        yield return new WaitForSeconds(8);
        rawText.SetActive(false);
        StartCoroutine("StartInhale");
    }

    IEnumerator StartInhale()
    {
        audioManager.Play("inhale");
        breathPhase1 = true;
        messageListener.breatheIn.SetActive(true);
        messageListener.breatheOut.SetActive(false);
        fireUIPrefab.SetActive(true);
        messageListener.celciusCounter = 750;
        yield return new WaitForSeconds(6);
        messageListener.breatheIn.SetActive(false);
        messageListener.breatheOut.SetActive(true);
        messageListener.startBreathing = true;
        audioManager.Play("exhale");
    }
    IEnumerator Birth()
    {
        audioManager.Stop("inhale");
        audioManager.Play("see");
        birthText.SetActive(true);
        yield return new WaitForSeconds(4);
        StartCoroutine("Saw");
    }

    IEnumerator Saw()
    {
        audioManager.Play("saw");
        yield return new WaitForSeconds(3);
        birthText.SetActive(false);
        StartCoroutine("Newborn");
    }
    IEnumerator Newborn()
    {
        audioManager.Play("baby");
        audioManager.Play("newborn");
        newbornText.SetActive(true);
        yield return new WaitForSeconds(5);
        audioManager.Play("remove vessel");
        newbornText.SetActive(false);
        eigthStage = true;
        removeVesselText.SetActive(true);
        glows[1].SetActive(true);
    }

    IEnumerator SnakeEvent()
    {
        audioManager.Stop("remove vessel");
        audioManager.Play("see2");
        audioManager.Play("copper snake");
        snakePrefab.SetActive(true);
        seeText.SetActive(true);
        yield return new WaitForSeconds(4);
        seeText.SetActive(false);
        StartCoroutine("Divine");
    }

    IEnumerator Divine()
    {
        audioManager.Play("divine");
        divineText.SetActive(true);
        yield return new WaitForSeconds(6);
        divineText.SetActive(false);
        StartCoroutine("LifeForce");
    }
    IEnumerator LifeForce()
    {
        audioManager.Play("life force");
        lifeForceText.SetActive(true);
        yield return new WaitForSeconds(5);
        lifeForceText.SetActive(false);
        StartCoroutine("Cooled");
    }

    IEnumerator Cooled()
    {
        audioManager.Play("cooled");
        cooledText.SetActive(true);
        yield return new WaitForSeconds(4);
        StartCoroutine("GetCopperVoice");
        cooledText.SetActive(false);
        finishedCopperPrefab.SetActive(true);
        dirtLavaPrefab.SetActive(false); ;
        getCopperText.SetActive(true);
        twelvethStage = true;
    }

    IEnumerator CopperMirror()
    {
        audioManager.Play("copper mirror");
        copperMirrorText.SetActive(true);
        yield return new WaitForSeconds(10);
        copperMirrorText.SetActive(false);
        fourteenthStage = true;
    }

    IEnumerator Blessed()
    {
        audioManager.Play("blessed");
        hathorBlessedText.SetActive(true);
        finishedCopperPrefab.SetActive(false);
        finalLightSpotPrefab.SetActive(false);
        mirrorPrefab.SetActive(true);
        tongPrefab.SetActive(false);
        handPrefab.SetActive(true);
        yield return new WaitForSeconds(4);
        hathorBlessedText.SetActive(false);
        StartCoroutine("ThankYou");
    }

    IEnumerator ThankYou()
    {
        RenderSettings.skybox = dawn;
        DynamicGI.UpdateEnvironment();
        besPrefab.SetActive(true);
        childAnimator.SetBool("Celebration", true);
        oldManAnimator.SetBool("Celebration", true);
        manAnimator.SetBool("Celebration", true);
        audioManager.Play("celebration");
        audioManager.Play("thank you");
        thankYouText.SetActive(true);
        yield return new WaitForSeconds(4);
        thankYouText.SetActive(false);
        StartCoroutine("Memory");
    }

    IEnumerator Memory()
    {
        audioManager.Play("memory");
        memoryText.SetActive(true);
        yield return new WaitForSeconds(6);
        memoryText.SetActive(false);
        StartCoroutine("Ancestors");
    }

    IEnumerator Ancestors()
    {
        audioManager.Play("ancestors");
        ancestorsText.SetActive(true);
        yield return new WaitForSeconds(8);
        ancestorsText.SetActive(false);
        StartCoroutine("Enjoy");
    }

    IEnumerator Enjoy()
    {
        audioManager.Play("enjoy");
        enjoyText.SetActive(true);
        yield return new WaitForSeconds(6);
        enjoyText.SetActive(false);
        StartCoroutine("Celebration");
    }
    
    //can turn into normal function
    IEnumerator Celebration()
    {
        celebrationText.SetActive(true);
        yield return new WaitForSeconds(5);
        StartCoroutine("Developed");
    }

    IEnumerator Developed()
    {
        celebrationText.SetActive(false);
        developedText.SetActive(true);
        yield return new WaitForSeconds(5);
        StartCoroutine("Designer");
    }

    IEnumerator Designer()
    {
        developedText.SetActive(false);
        designerText.SetActive(true);
        yield return new WaitForSeconds(5);
        StartCoroutine("ThreeD");
    }

    IEnumerator ThreeD()
    {
        designerText.SetActive(false);
        threeDText.SetActive(true);
        yield return new WaitForSeconds(5);
        StartCoroutine("TwoD");
    }

    IEnumerator TwoD()
    {
        threeDText.SetActive(false);
        twoDText.SetActive(true);
        yield return new WaitForSeconds(5);
        StartCoroutine("Programmer");
    }

    IEnumerator Programmer()
    {
        twoDText.SetActive(false);
        programmerText.SetActive(true);
        yield return new WaitForSeconds(5);
        StartCoroutine("Audio");
    }

    IEnumerator Audio()
    {
        programmerText.SetActive(false);
        audioText.SetActive(true);
        yield return new WaitForSeconds(5);
        StartCoroutine("Narrative");
    }
    IEnumerator Narrative()
    {
        audioText.SetActive(false);
        narrativeText.SetActive(true);
        yield return new WaitForSeconds(5);
        StartCoroutine("QA");
    }

    IEnumerator QA()
    {
        narrativeText.SetActive(false);
        QAText.SetActive(true);
        yield return new WaitForSeconds(5);
        StartCoroutine("Producer");
    }

    IEnumerator Producer()
    {
        QAText.SetActive(false);
        producerText.SetActive(true);
        yield return new WaitForSeconds(5);
        StartCoroutine("Stake");
    }

    IEnumerator Stake()
    {
        producerText.SetActive(false);
        stakeText.SetActive(true);
        yield return new WaitForSeconds(5);
        StartCoroutine("Instructor");
    }

    IEnumerator Instructor()
    {
        stakeText.SetActive(false);
        instructorText.SetActive(true);
        yield return new WaitForSeconds(5);
        StartCoroutine("Music");
    }

    IEnumerator Music()
    {
        instructorText.SetActive(false);
        musicText.SetActive(true);
        yield return new WaitForSeconds(5);
        StartCoroutine("Ending");
    }

    IEnumerator Ending()
    {
        musicText.SetActive(false);
        endingText.SetActive(true);
        yield return new WaitForSeconds(10);
        Application.Quit();
    }
    IEnumerator PlaceOreVoice()
    {
        audioManager.Play("place ore");
        yield return new WaitForSeconds(4);
        if (secondStage)
        {
            audioManager.Play("crucible");
        }
    }
    IEnumerator CharcoalVoice()
    {
        audioManager.Play("charcoal");
        yield return new WaitForSeconds(5);
        if (fourthStage)
        {
            audioManager.Play("nourishment");
        }
    }

    IEnumerator DirtPileVoice()
    {
        audioManager.Play("separate");
        yield return new WaitForSeconds(3);
        StartCoroutine("DirtPileVoice2");
    }

    IEnumerator DirtPileVoice2()
    {
        if (ninthStage)
        {
            audioManager.Play("liquified");
        }
        yield return new WaitForSeconds(6);
        if (ninthStage)
        {
            audioManager.Play("dirt pile");
        }
    }

    IEnumerator GetCopperVoice()
    {
        audioManager.Play("get copper");
        yield return new WaitForSeconds(6);
        if (twelvethStage || thirteenthStage)
        {
            audioManager.Play("born");
        }
    }

}