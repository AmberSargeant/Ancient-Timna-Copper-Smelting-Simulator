using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventManager : MonoBehaviour
{
    private PlayerCollision playerCollision;
    private VesselCollision vesselCollision;
    private bool firstStage = true;
    private bool secondStage,thirdStage, fourthStage = false;
    public List<GameObject> ore = new List<GameObject>();
    public GameObject largeOrePrefab;
    public GameObject largeOreTable;
    public GameObject smallOrePrefab;
    public GameObject smallOreTable;
    public GameObject largeOreText;
    public GameObject smallOreText;
    public GameObject firstStagetext;
    public GameObject secondStagetext;
    public GameObject thirdStagetext;
    void Start()
    {
        playerCollision = FindObjectOfType<PlayerCollision>();
        vesselCollision = FindObjectOfType<VesselCollision>();
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
            }
            else if (OVRInput.GetDown(OVRInput.Button.Two))
            {
                firstStagetext.SetActive(false);
                largeOrePrefab.SetActive(false);
                largeOreTable.SetActive(false);
                //need to refactor
                firstStage = false;
                secondStage = true;
            }
        }

        //need to refactor
        if (secondStage)
        {
            //need to refactor
            secondStagetext.SetActive(true);
            largeOreText.SetActive(false);
            smallOreText.SetActive(false);
            //need to refactor
            if (vesselCollision.bigOre1)
            {
                ore[0].SetActive(false);
            }
            if (vesselCollision.bigOre2)
            {
                ore[1].SetActive(false);
            }
            if (vesselCollision.bigOre3)
            {
                ore[2].SetActive(false);
            }
            if (vesselCollision.bigOre4)
            {
                ore[3].SetActive(false);
            }
            if (vesselCollision.bigOre5)
            {
                ore[4].SetActive(false);
            }
            if (vesselCollision.smallOre1)
            {
                ore[5].SetActive(false);
            }
            if (vesselCollision.smallOre2)
            {
                ore[6].SetActive(false);
            }
            if (vesselCollision.smallOre3)
            {
                ore[7].SetActive(false);
            }
            if (vesselCollision.smallOre4)
            {
                ore[8].SetActive(false);
            }
            if (vesselCollision.smallOre5)
            {
                ore[9].SetActive(false);
            }
            if(vesselCollision.countOre == 5)
            {
                //need to refactor
                secondStage = false;
                thirdStage = true;
            }

        }

        //need to refactor
        if (thirdStage)
        {
            thirdStagetext.SetActive(true);
        }
    }
}
