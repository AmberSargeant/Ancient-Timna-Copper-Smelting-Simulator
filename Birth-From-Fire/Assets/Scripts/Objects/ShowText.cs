using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowText : MonoBehaviour
{
    private CampfireCollision campfireCollision;
    public GameObject oreGlow;
    public GameObject charcoalGlow;
    public GameObject vCharcoalGlow;
    public GameObject vesselGlow;
    public GameObject blowPipeGlow;
    public GameObject smallOreText;
    public GameObject charcoalText;
    //public GameObject vesselText;
    public GameObject blowPipeText;
    public GameObject furnaceText;
    // Start is called before the first frame update
    void Start()
    {
        campfireCollision = FindObjectOfType<CampfireCollision>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowSmallOreText()
    {
        smallOreText.SetActive(true);
    }

    public void ShowCharcoalText()
    {
        charcoalText.SetActive(true);
    }
    //public void ShowVesselText()
    //{
    //    vesselText.SetActive(true);
    //}

    public void ShowBlowPipeText()
    {
        blowPipeText.SetActive(true);
    }

    public void ShowFurnaceText()
    {
        furnaceText.SetActive(true);
    }
    public void HideSmallOreText()
    {
        smallOreText.SetActive(false);
    }

    public void HideCharcoalText()
    {
        charcoalText.SetActive(false);
    }

    public void HideBlowPipeText()
    {
        blowPipeText.SetActive(false);
    }

    public void HideFurnaceText()
    {
        furnaceText.SetActive(false);
    }

    public void ShowOreGlow()
    {
        oreGlow.SetActive(true);
    }

    public void HideOreGlow()
    {
        oreGlow.SetActive(false);
    }

    public void ShowCharcoalGlow()
    {
        charcoalGlow.SetActive(true);
    }

    public void HideCharcoalGlow()
    {
        charcoalGlow.SetActive(false);
    }

    public void HideVCharcoalGlow()
    {
        vCharcoalGlow.SetActive(false);
    }

    public void ShowVesselGlow()
    {
        vesselGlow.SetActive(true);
    }

    public void HideVesselGlow()
    {
        vesselGlow.SetActive(false);
    }

    public void ShowBlowPipeGlow()
    {
        if (!campfireCollision.pipeInFurnace)
        {
            blowPipeGlow.SetActive(true);
        }
    }

    public void HideBlowPipeGlow()
    {
        blowPipeGlow.SetActive(false);
    }
}
