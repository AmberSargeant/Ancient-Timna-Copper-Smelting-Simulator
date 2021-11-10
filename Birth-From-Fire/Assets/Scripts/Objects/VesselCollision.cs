using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VesselCollision : MonoBehaviour
{
    [SerializeField]
    public int countOre;
    public bool enableCollision = false;
    private bool hitted = false;
    void Start()
    {

    }

    void Update()
    {

    }

    void OnCollisionEnter(Collision other)
    {
        if (enableCollision)
        {
            if (other.collider.tag == "Big Ore")
            {
                other.gameObject.SetActive(false);
                countOre++;
            }
            else if(other.collider.tag == "Small Ore")
            {
                other.gameObject.SetActive(false);
                countOre++;
            }

        }
    }

    private void OnCollisionExit(Collision other)
    {
        if ((hitted == true))
        {
            hitted = false;
        }

    }

}
