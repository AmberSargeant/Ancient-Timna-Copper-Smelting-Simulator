using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IbexMovement : MonoBehaviour
{
    public GameObject target;
    public Animator ibexAnimator;
    [SerializeField]
    private float speed;
    private bool playOnce = false;
    private bool move = false;
    private MessageListener messageListener;
    private AudioManager audioManager;
    private int randomNum;
    // Start is called before the first frame update
    void Start()
    {
        messageListener = FindObjectOfType<MessageListener>();
        audioManager = FindObjectOfType<AudioManager>();
        InvokeRepeating("GenerateRandomNumber", 0f, 4f);
    }

    // Update is called once per frame
    void Update()
    {
        IbexState();
    }

    void IbexState()
    {
        if (randomNum == 1)
        {
            ibexAnimator.SetBool("move", false);
            playOnce = false;
            move = false;
        }
        else
        {
            if (!playOnce)
            {
                audioManager.Play("walk sheep");
                playOnce = true;
            }
            ibexAnimator.SetBool("move", true);
            if (ibexAnimator.GetCurrentAnimatorStateInfo(0).IsTag("Idle"))
            {
                if (ibexAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1)
                {
                    move = true;
                }
            }
            else
            {
                move = true;
            }

            if (move)
            {
                transform.RotateAround(target.transform.position, Vector3.up, speed * Time.deltaTime);
            }
        }
    }
        void GenerateRandomNumber()
    {
        randomNum = Random.Range(1, 3);
    }
}
