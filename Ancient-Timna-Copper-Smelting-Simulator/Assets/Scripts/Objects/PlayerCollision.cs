using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public bool largeOre = false;
    public bool smallOre = false;
    void Start()
    {

    }

    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "LargeOreTrigger")
        {
            largeOre = true;
        }
        if (other.tag == "SmallOreTrigger")
        {
            smallOre = true;
        }
    }


    private void OnTriggerExit(Collider other)
    {
        largeOre = false;
        smallOre = false;
    }

}
   
