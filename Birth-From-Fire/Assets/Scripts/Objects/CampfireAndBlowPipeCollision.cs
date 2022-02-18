using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CampfireAndBlowPipeCollision : MonoBehaviour
{
    public bool pipeInFurnace = false;
    // Start is called before the first frame update

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "BlowPipe")
        {
            pipeInFurnace = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        pipeInFurnace = false;
    }
}
