using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FurnaceCollision : MonoBehaviour
{
    private AudioManager audioManager;
    public GameObject flame;
    public bool inFurnace;
    public bool pipeInFurnace;
    public int countCharcoal;

    private void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
    }
    void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Vessel")
        {
            inFurnace = true;
        }

        if (other.tag == "BlowPipe")
        {
            pipeInFurnace = true;
        }
        if(other.tag == "Charcoal")
        {
            audioManager.Play("fire after adding coals");
            other.gameObject.SetActive(false);
            flame.SetActive(true);
            countCharcoal++;
        }
    }
}
