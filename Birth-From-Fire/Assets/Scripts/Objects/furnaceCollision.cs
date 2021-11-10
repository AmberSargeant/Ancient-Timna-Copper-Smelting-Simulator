using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FurnaceCollision : MonoBehaviour
{
    public bool inFurnace;
    public bool pipeInFurnace;
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
    }
}
