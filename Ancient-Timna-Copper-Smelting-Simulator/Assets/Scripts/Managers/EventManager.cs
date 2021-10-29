using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventManager : MonoBehaviour
{
    private PlayerCollision playerCollision;
    private VesselCollision vesselCollision;
    private FurnaceCollision furnaceCollision;
    private bool firstStage = true;
    private bool secondStage,thirdStage, fourthStage = false;
    public bool ovrGrabbableCheck = false;
    public GameObject largeOrePrefab;
    public GameObject largeOreTable;
    public GameObject smallOrePrefab;
    public GameObject smallOreTable;
    public GameObject vesselPrefab;
    public GameObject blowpipePrefab;
    public GameObject largeOreText;
    public GameObject smallOreText;
    public GameObject chooseOreText;
    public GameObject firstStagetext;
    public GameObject secondStagetext;
    public GameObject thirdStagetext;
    public GameObject fourthStageText;
    void Start()
    {
        playerCollision = FindObjectOfType<PlayerCollision>();
        vesselCollision = FindObjectOfType<VesselCollision>();
        furnaceCollision = FindObjectOfType<FurnaceCollision>();
    }
    void Update()
    {
        //need to refactor
        if (firstStage)
        {
            if (playerCollision.smallOre)
            {
                //need to refactor
                smallOreText.SetActive(true);
            }
            else
            {
                //need to refactor
                smallOreText.SetActive(false);
            }

            if (playerCollision.largeOre)
            {
                //need to refactor
                largeOreText.SetActive(true);
            }
            else
            {
                //need to refactor
                largeOreText.SetActive(false);
            }

            if (OVRInput.GetDown(OVRInput.Button.One))
            {
                firstStagetext.SetActive(false);
                smallOrePrefab.SetActive(false);
                smallOreTable.SetActive(false);
                //need to refactor
                firstStage = false;
                secondStage = true;
                chooseOreText.SetActive(false);
}
            else if (OVRInput.GetDown(OVRInput.Button.Two))
            {
                firstStagetext.SetActive(false);
                largeOrePrefab.SetActive(false);
                largeOreTable.SetActive(false);
                //need to refactor
                firstStage = false;
                secondStage = true;
                chooseOreText.SetActive(false);
            }
        }

        //need to refactor
        if (secondStage)
        {
            //need to refactor
            secondStagetext.SetActive(true);
            largeOreText.SetActive(false);
            smallOreText.SetActive(false);
            vesselCollision.enableCollision = true;
           
            if(vesselCollision.countOre == 5)
            {
                //need to refactor
                secondStage = false;
                thirdStage = true;
                secondStagetext.SetActive(false);
                vesselPrefab.GetComponent<OVRGrabbable>().allowOffhandGrab = true;
            }

        }
        //need to refactor
        if (thirdStage)
        {
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
            blowpipePrefab.GetComponent<OVRGrabbable>().allowOffhandGrab = true;
           

        }

    }
}
