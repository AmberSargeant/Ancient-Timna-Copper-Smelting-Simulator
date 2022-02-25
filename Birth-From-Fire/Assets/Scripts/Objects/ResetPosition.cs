using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPosition : MonoBehaviour
{
    // Start is called before the first frame update
    Vector3 startPos;
    public bool resetPosition = false;
    void Start()
    {
        startPos = transform.position;
    }

    private void Update()
    {
        if (resetPosition)
        {
            transform.position = startPos;
        }
    }
}
