using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPosition : MonoBehaviour
{
    // Start is called before the first frame update
    Vector3 startPos;
    void Start()
    {
        startPos = transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Floor")
        {
            transform.position = startPos;
        }
    }
}
