using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeMovement : MonoBehaviour
{
    private Vector3 target;
    private Vector3 target2;
    private Vector3 target3;
    private Vector3 target4;
    private float speed = 0.02f;
    private float speed2 = 0.01f;
    private float speed3 = 0.03f;
    private float speed4 = 0.015f;
    public GameObject snake;
    public GameObject snake2;
    public GameObject snake3;
    public GameObject snake4;
    public Animator snakeAnimator;
    public Animator snakeAnimator2;
    public Animator snakeAnimator3;
    public Animator snakeAnimator4;
    // Start is called before the first frame update
    void Start()
    {
        target = new Vector3(-5.136f, snake.transform.localPosition.y, -0.381f);
        target2 = new Vector3(-5.098f, snake2.transform.localPosition.y, -0.855f);
        target3 = new Vector3(-5.136f, snake3.transform.localPosition.y, -0.297f);
        target4 = new Vector3(-5.097f, snake4.transform.localPosition.y, -0.801f);
    }

    // Update is called once per frame
    void Update()
    {

        float step = speed * Time.deltaTime;
        float step2 = speed2 * Time.deltaTime;
        float step3 = speed3 * Time.deltaTime;
        float step4 = speed4 * Time.deltaTime;
        snake.transform.localPosition = Vector3.MoveTowards(snake.transform.localPosition, target, step);
        if (snake.transform.localPosition == target)
        {
            snakeAnimator.SetBool("isWalking", false);
        }

        snake2.transform.localPosition = Vector3.MoveTowards(snake2.transform.localPosition, target2, step2);
        if (snake2.transform.localPosition == target2)
        {
            snakeAnimator2.SetBool("isWalking", false);
        }
        snake3.transform.localPosition = Vector3.MoveTowards(snake3.transform.localPosition, target3, step3);
        if (snake3.transform.localPosition == target3)
        {
            snakeAnimator3.SetBool("isWalking", false);
        }
        snake4.transform.localPosition = Vector3.MoveTowards(snake4.transform.localPosition, target4, step4);
        if (snake4.transform.localPosition == target4)
        {
            snakeAnimator4.SetBool("isWalking", false);
        }
    }
}
