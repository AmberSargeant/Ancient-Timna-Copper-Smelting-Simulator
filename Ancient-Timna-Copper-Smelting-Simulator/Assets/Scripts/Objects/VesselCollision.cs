using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VesselCollision : MonoBehaviour
{
    public bool bigOre1, bigOre2, bigOre3, bigOre4, bigOre5 = false;
    public bool smallOre1, smallOre2, smallOre3, smallOre4, smallOre5 = false;
    public int countOre;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        //Check for a match with the specified name on any GameObject that collides with your GameObject
        if (collision.gameObject.name == "Big Ore 1")
        {
            bigOre1 = true;
            countOre++;
        }

        if (collision.gameObject.name == "Big Ore 2")
        {
            bigOre2 = true;
            countOre++;
        }

        if (collision.gameObject.name == "Big Ore 3")
        {
            bigOre3 = true;
            countOre++;
        }

        if (collision.gameObject.name == "Big Ore 4")
        {
            bigOre4 = true;
            countOre++;
        }

        if (collision.gameObject.name == "Big Ore 5")
        {
            bigOre5 = true;
            countOre++;
        }

        if (collision.gameObject.name == "Small Ore 1")
        {
            smallOre1 = true;
            countOre++;
        }

        if (collision.gameObject.name == "Small Ore 2")
        {
            smallOre2 = true;
            countOre++;
        }

        if (collision.gameObject.name == "Small Ore 3")
        {
            smallOre3 = true;
            countOre++;
        }

        if (collision.gameObject.name == "Small Ore 4")
        {
            smallOre4 = true;
            countOre++;
        }

        if (collision.gameObject.name == "Small Ore 5")
        {
            smallOre5 = true;
            countOre++;
        }


    }
}
