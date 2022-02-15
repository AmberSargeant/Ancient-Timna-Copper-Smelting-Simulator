using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSpotMovement : MonoBehaviour
{
    private Vector3 target;
    private float speed = 0.1f;
    public bool mirror = false;
    // Start is called before the first frame update
    void Start()
    {
        target = new Vector3(transform.localPosition.x, -7.309f, transform.localPosition.z);
    }

    // Update is called once per frame
    void Update()
    {

        float step = speed * Time.deltaTime;
        transform.localPosition = Vector3.MoveTowards(transform.localPosition, target, step);
        if(transform.localPosition == target)
        {
            mirror = true;
        }
    }
}
