using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Method finds the collider object in the hand to get picked up.
/// This method lives on the object that can be picked up.
/// -------------------------------------------------
/// Bradley HJ - 5 Jan 2021
/// </summary>
public class PickupObject : MonoBehaviour
{
    public string NameOfObjectsHand; //Name of the object that is moving to the hand model
    public string NameOfTable; // Name of the table that the object will be placed upon.
    public bool IsObjectInUse; //Are you currently using the object in your hand.

    private GameObject Hand;
    private GameObject Table;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    /// <summary>
    /// Check the colliders name, if the object is not in use then it wants to check if the hand is the collider, if the object is in use then it should look for the table.
    /// </summary>
    /// <param name="other">This a collision with an object that has a collider.</param>
    private void OnTriggerEnter(Collider other) {
        
    }

    //Go to the hand. 
    private void ToHand() { 
    
    }

    //Go to the table.
    private void ToTable() { 
    
    }
}
