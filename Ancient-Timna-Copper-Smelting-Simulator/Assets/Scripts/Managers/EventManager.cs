using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventManager : MonoBehaviour
{
    private VesselCollision vesselCollision;
    private FurnaceCollision furnaceCollision;
    private BlowPipeCollision blowPipeCollision;
    private bool firstStage = true;
    private bool secondStage,thirdStage, fourthStage = false;
    public bool ovrGrabbableCheck = false;
    public GameObject playerControllerPrefab;
    public GameObject largeOrePrefab;
    public GameObject smallOrePrefab;
    public GameObject vesselPrefab;
    public GameObject blowpipePrefab;
    public GameObject fireUIPrefab;
    public GameObject chooseOreText;
    public GameObject firstStagetext;
    public GameObject secondStagetext;
    public GameObject thirdStagetext;
    public GameObject fourthStageText;
    void Start()
    {
        vesselCollision = FindObjectOfType<VesselCollision>();
        furnaceCollision = FindObjectOfType<FurnaceCollision>();
        blowPipeCollision = FindObjectOfType<BlowPipeCollision>();
}
    void Update()
    {
        //need to refactor
        if (firstStage)
        {

            if (OVRInput.GetDown(OVRInput.Button.One))
            {
                firstStagetext.SetActive(false);
                Destroy(smallOrePrefab);
                //need to refactor
                firstStage = false;
                secondStage = true;
                chooseOreText.SetActive(false);
}
            else if (OVRInput.GetDown(OVRInput.Button.Two))
            {
                firstStagetext.SetActive(false);
                Destroy(largeOrePrefab);
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
            playerControllerPrefab.GetComponent<OVRPlayerController>().EnableLinearMovement = true;
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
           if(blowPipeCollision.grabbedBlowPipe == true)
            {
                fourthStageText.SetActive(false);
                fourthStage = false;
                fireUIPrefab.SetActive(true);
            }

        }

    }
}
