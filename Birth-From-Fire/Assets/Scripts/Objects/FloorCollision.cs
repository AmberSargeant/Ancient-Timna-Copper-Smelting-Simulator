using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorCollision : MonoBehaviour
{
    private EventManager eventManager;
    public bool charcoalOnFloor = false;
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
        if (eventManager.enableFloorCollision)
        {
            if (other.tag == "vCharcoal")
            {
                other.gameObject.SetActive(false);
                charcoalOnFloor = true;
            }
        }
    }
}
