using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FurnaceCollision : MonoBehaviour
{
    private AudioManager audioManager;
    private Vector3 lightScale;
    public GameObject flame;
    public GameObject light;
    public bool inFurnace;
    public bool pipeInFurnace;
    public int countCharcoal;

    private void Start()
    {
        lightScale = new Vector3(0.10f, 0.10f, 0.10f);
        audioManager = FindObjectOfType<AudioManager>();
    }
    void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Vessel")
        {
            inFurnace = true;
        }

        if (other.tag == "BlowPipe")
        {
            pipeInFurnace = true;
        }
        if(other.tag == "Charcoal")
        {
            StartCoroutine(IncreaseLight());
            audioManager.Play("fire after adding coals");
            other.gameObject.SetActive(false);
            flame.SetActive(true);
            countCharcoal++;
        }
    }

    IEnumerator IncreaseLight()
    {
        while (light.transform.localScale.x <= 7 && light.transform.localScale.y <= 7 && light.transform.localScale.z <= 7)
        {
            yield return new WaitForSeconds(0.06f);
            light.transform.localScale += lightScale;
            if(light.transform.localScale.x >= 7 && light.transform.localScale.y >= 7 && light.transform.localScale.z >= 7)
            {
                StartCoroutine(DecreaseLight());
                yield break;
            }
        }
    }

    IEnumerator DecreaseLight()
    {
        while (light.transform.localScale.x > 1  && light.transform.localScale.y > 1 && light.transform.localScale.z > 1)
        {
            yield return new WaitForSeconds(0.06f);
            light.transform.localScale -= lightScale;
            if (light.transform.localScale.x <= 1f && light.transform.localScale.y <= 1 && light.transform.localScale.z <= 1f)
            {
                yield break;
            }
        }
    }
}
