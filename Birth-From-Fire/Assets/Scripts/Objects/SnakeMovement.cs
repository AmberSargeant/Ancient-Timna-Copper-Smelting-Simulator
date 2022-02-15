using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeMovement : MonoBehaviour
{
    private Vector3 target;
    private float speed = 0.1f;
    public Animator snakeAnimator;
    // Start is called before the first frame update
    void Start()
    {
        target = new Vector3(-5.166f, transform.localPosition.y, -0.308f);
    }

    // Update is called once per frame
    void Update()
    {

        float step = speed * Time.deltaTime;
        transform.localPosition = Vector3.MoveTowards(transform.localPosition, target, step);
        if (transform.localPosition == target)
        {
            snakeAnimator.SetBool("isWalking", false);
        }
    }
}
