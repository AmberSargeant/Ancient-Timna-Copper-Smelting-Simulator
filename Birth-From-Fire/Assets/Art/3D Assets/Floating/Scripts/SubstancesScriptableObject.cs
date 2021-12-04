using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Script with scriptable object class creates the menu where you will have access to create the scriptable object of the substance
//Assets > Create > Substance > SubstancesScriptableObject.
[CreateAssetMenu(fileName = "TypeSubstance", menuName = "Substances/SubstancesScriptableObject", order = 1)]
public class SubstancesScriptableObject : ScriptableObject
{
    //Resistance that the substance will have when a floating object comes into contact.The greater the resistance, the more difficult the object will have to enter the substance.
    [Range(0, 50)]
    public float substanceResistence;
    //Buoyancy that the object will have if it will float more or less.The greater the buoyant force the object will remain the more out of the substance.
    [Range(1, 25)]
    public float substanceFloatingForce;
    //Sound of entry and exit of the substance.
    public AudioClip soundSubstanceEnter, soundSubstanceExit;
}
