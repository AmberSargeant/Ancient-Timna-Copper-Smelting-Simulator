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
        if (other.collider.tag == "Ore" &&!hitted)
        {
            Destroy(other.gameObject);
            hitted = true;
            countOre++;
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
