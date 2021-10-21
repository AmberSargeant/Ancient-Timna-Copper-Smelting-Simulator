using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ore : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> typeOre = new List<GameObject>();
    [SerializeField]
    private GameObject oreStorage;

    private void Awake()
    {
    }
    private void Start()
    {
        oreStorage = GameObject.Find("Ore");
        Transform oreTransform = oreStorage.GetComponent<Transform>();
        foreach(Transform child in oreTransform)
        {
            typeOre.Add(child.gameObject);
        }
    }

    private void Update()
    {
        Debug.Log(OVRInput.GetConnectedControllers());
        print(UnityEngine.Input.GetJoystickNames());
        OVRInput.Update();
        OVRInput.FixedUpdate();
    }



}
