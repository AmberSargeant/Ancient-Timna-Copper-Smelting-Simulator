using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleGravity : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void enableGravity() {
        this.GetComponent<Rigidbody>().isKinematic = false;
        this.GetComponent<Rigidbody>().useGravity = true;
    }

    //public void disableGravity()
    //{
    //    this.GetComponent<Rigidbody>().isKinematic = true;
    //    this.GetComponent<Rigidbody>().useGravity = false;
    //}
}
