using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FurnaceCollision : MonoBehaviour
{
    public bool inFurnace;
    public bool pipeInFurnace;
    public int countCharcoal;
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
            other.gameObject.SetActive(false);
            countCharcoal++;
        }
    }
}
