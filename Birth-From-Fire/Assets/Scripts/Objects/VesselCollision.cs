using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VesselCollision : MonoBehaviour
{
    private Vector3 vesselTransform;
    private EventManager eventManager;
    public bool vesselGrabbable = true;
    public bool celebration = false;
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

        if (eventManager.checkVesselPosition)
        {
            if(other.collider.tag == "VesselPosition")
            {
                vesselGrabbable = false;
                this.transform.position = eventManager.vesselTransform;
            }
        }

        if(other.collider.tag == "Reput Vessel")
        {
            celebration = true;
        }
    }
}
