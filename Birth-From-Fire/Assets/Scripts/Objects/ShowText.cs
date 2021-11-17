using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowText : MonoBehaviour
{
    public GameObject bigOreText;
    public GameObject smallOreText;
    public GameObject charcoalText;
    public GameObject vesselText;
    public GameObject blowPipeText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowBigOreText()
    {
        bigOreText.SetActive(true);
    }

    public void ShowSmallOreText()
    {
        smallOreText.SetActive(true);
    }

    public void ShowCharcoalText()
    {
        charcoalText.SetActive(true);
    }
    public void ShowVesselText()
    {
        vesselText.SetActive(true);
    }

    public void ShowBlowPipeText()
    {
        blowPipeText.SetActive(true);
    }
    public void HideBigOreText()
    {
        bigOreText.SetActive(false);
    }

    public void HideSmallOreText()
    {
        smallOreText.SetActive(false);
    }

    public void HideCharcoalText()
    {
        charcoalText.SetActive(false);
    }

    public void HideVesselText()
    {
        vesselText.SetActive(false);
    }

    public void HideBlowPipeText()
    {
        blowPipeText.SetActive(false);
    }

}
