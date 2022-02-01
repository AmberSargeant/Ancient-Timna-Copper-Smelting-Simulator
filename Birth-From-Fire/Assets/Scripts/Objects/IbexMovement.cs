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
    private MessageListener messageListener;
    private AudioManager audioManager;
    // Start is called before the first frame update
    void Start()
    {
        messageListener = FindObjectOfType<MessageListener>();
        audioManager = FindObjectOfType<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!messageListener.moveIbex)
        {
            ibexAnimator.SetBool("move", false);
        }
        else
        {
            if (!playOnce)
            {
                audioManager.Play("walk sheep");
                playOnce = true;
            }
            ibexAnimator.SetBool("move", true);
            transform.RotateAround(target.transform.position, Vector3.up, speed * Time.deltaTime);
        }
    }
}
