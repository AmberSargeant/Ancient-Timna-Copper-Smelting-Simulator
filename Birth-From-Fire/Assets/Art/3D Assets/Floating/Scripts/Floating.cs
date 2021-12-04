using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floating : MonoBehaviour
{
    //Type of plane substance, identified by the Scriptable Object of the substance. 
    private SubstancesScriptableObject _substanceType;
    //Transform (position) of the plane substance in the scene. 
    private Transform _substanceTransform;
    //Particle substance that is inside the substance plane.
    private GameObject _substanceParticle;
    //Object that will float on the substance plane. 
    private GameObject _floater;
    //Distance from the substance plane.
    private float _substanceDistance;
    //Força que o plano substância exerce sobre o objeto flutuador.
    private Vector3 _substanceForce;
    //Boolean that indicates whether the floating object is in contact with the substance plane.
    private bool _insideSubstance = false;


    // Start is called before the first frame update
    void Start()
    {
        //Indicates that the floating object is the object with this script 
        _floater = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        //If the boolean inside Distance is true, identifying that the floating object is in contact with the substance plane
        if (_insideSubstance)
        {
            //Debug.Log(_substanceTransform);
            //Debug.Log(_substanceType.substanceResistence);
            //Debug.Log(_substanceType.substanceFloatingForce);
            //Debug.Log(_substanceType.soundSubstanceEnter);
            //Debug.Log(_substanceType.soundSubstanceExit);

            //Identifies the distance of the substance by taking the position of the y - axis of the floating object and subtracting the position of the y-axis from the substance plane.
            _substanceDistance = _floater.transform.position.y - _substanceTransform.position.y;
            //Calculation of the strength of the substance that is composed of the force of gravity multiplied by the distance of the substance subtracted by the speed of the floating object on the y axis multiplied by the resistance of the scriptable object's substance. 
            _substanceForce.y = (Physics.gravity.y * _substanceDistance - _floater.GetComponent<Rigidbody>().velocity.y * _substanceType.substanceResistence);
            //Adds strength to the floating object by multiplying the strength of the substance acquired above and the strength of the substance of the scriptable object of the substance.
            _floater.GetComponent<Rigidbody>().AddForce(_substanceForce * _substanceType.substanceFloatingForce);
        }

    }

    //Enters a trigger collider.
    void OnTriggerEnter(Collider coll)
    {
        //Checks if the collider has the Scriptable Object and the script substantiates inside indicating that it is a substance that the floating object collided with. 
        if (coll.gameObject.GetComponent<Substance>().substanceType != null)
        {
            //Takes the scriptable object of the substance.
            _substanceType = coll.gameObject.GetComponent<Substance>().substanceType;
            //Takes the transform (position) of the substance. 
            _substanceTransform = coll.gameObject.transform;
            //Makes the Boolean variable inside substance true.
            _insideSubstance = true;
            //Takes the particle of the substance that is the daughter of the substance plane.
            _substanceParticle = coll.gameObject.transform.GetChild(0).gameObject;
            //It puts the particle in the position of the floating object when it comes in contact with the collider trigger of the substance plane. 
            _substanceParticle.transform.position = _floater.transform.position;
            //Play on the particle when the floating object comes into contact with the substance plane.
            _substanceParticle.GetComponent<ParticleSystem>().Play();
            //Plays the enter sound for the substance. 
            GetComponent<AudioSource>().PlayOneShot(_substanceType.soundSubstanceEnter);
        }
        
    }

    //Exit a trigger collider.
    void OnTriggerExit(Collider coll)
    {
        //Checks if the floating object is leaving the substance it was in contact with previously. 
        if (coll.transform == _substanceTransform)
        {
            //Makes the Boolean variable inside substance true.
            _insideSubstance = false;
            //Plays the exit sound for the substance. 
            GetComponent<AudioSource>().PlayOneShot(_substanceType.soundSubstanceExit);
        }
    }
}
