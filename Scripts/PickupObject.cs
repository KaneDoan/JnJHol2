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
        IsObjectInUse = false;
    }

    void OnTriggerEnter(Collider other)
    {
            if (other.gameObject.name == NameOfObjectsHand) //on the object you want to pick up, in this case NameOfObjectsHand
            {
                Hand = other.gameObject; //set the gameobject you collided with to one you can reference
                ToHand();
            }

            if (other.gameObject.name == NameOfTable) //on the object you want to pick up, in this case NameOfTable
        {
                Table = other.gameObject; //set the gameobject you collided with to one you can reference
                ToTable();
            }
    }

    /// <summary>
    /// Check the colliders name, if the object is not in use then it wants to check if the hand is the collider, if the object is in use then it should look for the table.
    /// </summary>
    /// <param name="other">This a collision with an object that has a collider.</param>


    //Go to the hand. 
    private void ToHand() {
        if (!IsObjectInUse)
        {
            //Hand = GameObject.Find("CleanUpHandleV2");
            if (Hand != null)
            {
                this.transform.parent = Hand.transform;
                //this.transform.position = Hand.transform.position;
                //Hand = GetChildWithName(Hand, "CleanUpHandleV2");//get object with the name of the Palm string
                IsObjectInUse = true;
                //this.GetComponent<Collider>().enabled = true;//turn on the collider if hand exist.
            }
        }

        else if (IsObjectInUse)
        {
            if (!Hand)
            {
                //Hand.transform.DetachChildren();
                //Transform child = FindChildTransform(gameObject, this.name);
                //child.parent = null;
                IsObjectInUse = false;
            }


            else if (Hand)
            {
                //this.transform.position = Hand.transform.position;
                IsObjectInUse = true;
            }

        }
    }

    //Go to the table.
    private void ToTable() {
        Table.gameObject.name = NameOfTable;
        Hand.transform.DetachChildren();
        this.transform.position = Table.transform.position + new Vector3(0, 1, 0); ;
        IsObjectInUse = false;
    }
}
