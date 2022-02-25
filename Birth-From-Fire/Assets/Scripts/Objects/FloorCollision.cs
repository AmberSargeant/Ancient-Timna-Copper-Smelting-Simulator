using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorCollision : MonoBehaviour
{
    private EventManager eventManager;
    public bool charcoalOnFloor = false;
    public GameObject copper;
    public GameObject finalCopper;
    public GameObject vessel;
    public GameObject vesselSlag;
    public GameObject charcoal;
    // Start is called before the first frame update
    void Start()
    {
        eventManager = FindObjectOfType<EventManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Small Ore")
        {
            copper.GetComponent<ResetPosition>().resetPosition = true;
        }

        if (other.tag == "Copper")
        {
            finalCopper.GetComponent<ResetPosition>().resetPosition = true;
        }

        if (other.tag == "Charcoal")
        {
            charcoal.GetComponent<ResetPosition>().resetPosition = true;
        }

        if (other.tag == "Vessel")
        {
            vessel.GetComponent<ResetPosition>().resetPosition = true;
        }

        if (other.tag == "Vessel Slag")
        {
            vesselSlag.GetComponent<ResetPosition>().resetPosition = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Small Ore")
        {
            copper.GetComponent<ResetPosition>().resetPosition = false;
        }
        if (other.tag == "Copper")
        {
            finalCopper.GetComponent<ResetPosition>().resetPosition = false;
        }
        if (other.tag == "Charcoal")
        {
            charcoal.GetComponent<Rigidbody>().isKinematic = true;
            charcoal.GetComponent<Rigidbody>().useGravity = false;
            charcoal.GetComponent<ResetPosition>().resetPosition = false;
        }

        if (other.tag == "Vessel")
        {
            vessel.GetComponent<ResetPosition>().resetPosition = false;
        }

        if (other.tag == "Vessel Slag")
        {
            vesselSlag.GetComponent<Rigidbody>().isKinematic = true;
            vesselSlag.GetComponent<Rigidbody>().useGravity = false;
            vesselSlag.GetComponent<ResetPosition>().resetPosition = false;
        }
    }
}
