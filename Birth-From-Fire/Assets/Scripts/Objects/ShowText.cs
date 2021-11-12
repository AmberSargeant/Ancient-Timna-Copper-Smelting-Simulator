using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowText : MonoBehaviour
{
    public GameObject bigOreText;
    public GameObject smallOreText;
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

    public void HideBigOreText()
    {
        bigOreText.SetActive(false);
    }

    public void HideSmallOreText()
    {
        smallOreText.SetActive(false);
    }

}
