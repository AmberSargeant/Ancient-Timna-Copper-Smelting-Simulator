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

    //void OnControllerColliderHit(ControllerColliderHit hit)
    //{
    //    //Check for a match with the specified name on any GameObject that collides with your GameObject
    //    if (hit.gameObject.name == "Large Ore")
    //    {
    //        largeOre = true;
    //        //If the GameObject's name matches the one you suggest, output this message in the console
    //        print(largeOre);
    //    }

    //    if (hit.gameObject.name == "Small Ore")
    //    {
    //        smallOre = true;
    //        //If the GameObject's name matches the one you suggest, output this message in the console
    //        print(smallOre);
    //    }
    //}

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Large Ore")
        {
            largeOre = true;
     
            print(largeOre + "Large Ore");
        }
        if (other.gameObject.name == "Small Ore")
        {
            smallOre = true;
            print(smallOre + "Small Ore");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        largeOre = false;
        smallOre = false;
    }

}
   
