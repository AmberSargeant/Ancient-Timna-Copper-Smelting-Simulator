﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
public class OffsetGrabbable : MonoBehaviour
{
    public GameObject tongs;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (tongs.activeInHierarchy)
        {
            this.transform.position = new Vector3(0, 0, -0.14f);
        }
    }
}
