using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Method finds the right or left hand, however it is instantiated and then it attaches itself onto the hand object.
/// -------------------------------------------------
/// Bradley HJ - 5 Jan 2021
/// </summary>
public class GripToHand : MonoBehaviour
{
    public string NameOfHand; //Insert the string of the object that the hand is associated with.
    public bool HandObtained; //If the hand is found, attach yourself to it. Set as parent and follow the transform.
    private Transform Hand; //The identified hand and its Transform.
    
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("FindHand", 0, 1f); //Every second try and find the hand.
    }


    private void FindHand() {
        if (!HandObtained) { 
        
        }
    }
}
