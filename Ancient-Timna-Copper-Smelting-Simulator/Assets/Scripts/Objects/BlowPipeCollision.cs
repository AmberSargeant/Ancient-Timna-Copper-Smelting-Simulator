using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlowPipeCollision : MonoBehaviour
{
    private bool occurOnce = false;
    public bool grabbedBlowPipe = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //needs to be refactored
        if (!occurOnce)
        {
            if (this.transform.GetComponent<OVRGrabbable>().isGrabbed == true)
            {
                occurOnce = true;
                grabbedBlowPipe = true;
            }
        }
    }
}
