using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VesselCollision : MonoBehaviour
{
    private EventManager eventManager;
    void Start()
    {
        eventManager = FindObjectOfType<EventManager>();
    }

    void Update()
    {

    }

    void OnCollisionEnter(Collision other)
    {
        if (eventManager.enableVesselCollision)
        {
            if (other.collider.tag == "Big Ore")
            {
                eventManager.countOre++;
                other.gameObject.SetActive(false);
            }
            else if (other.collider.tag == "Small Ore")
            {
                eventManager.countOre++;
                other.gameObject.SetActive(false);
            }

        }
    }
}
