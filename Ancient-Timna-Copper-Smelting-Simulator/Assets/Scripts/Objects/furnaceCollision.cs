using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FurnaceCollision : MonoBehaviour
{
    public bool inFurnace;
    void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Vessel")
        {
            inFurnace = true;
            Destroy(other.gameObject);
        }
    }
}
