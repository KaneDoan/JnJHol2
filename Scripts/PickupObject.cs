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
    public bool CanPickUp;
    public string Palm = "Palm Proxy Transform";
    public Vector3 offset;


    private GameObject Hand;
    private GameObject Table;
    
    // Start is called before the first frame update
    void Start()
    {
        IsObjectInUse = false;
        CanPickUp = false;
    }

    void OnTriggerEnter(Collider other)
    {
            if (other.gameObject.name == NameOfObjectsHand) //on the object you want to pick up, in this case NameOfObjectsHand
            {
                Debug.Log("Name of :" + NameOfObjectsHand);
                Hand = other.gameObject; //set the gameobject you collided with to one you can reference
                Debug.Log("Collided with: " + other.name);
                ToHand();
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
                //find child of hand palm proxy make hand = palm
                this.transform.parent = Hand.transform;
                //Hand = GetChildWithName(Hand, "CleanUpHandleV2");//get object with the name of the Palm string
                IsObjectInUse = true;
                //this.GetComponent<Collider>().enabled = true;//turn on the collider if hand exist.
            }
        }

        else if (IsObjectInUse)
        {
            
            if (Hand == null)
            {
                // hand = GameObject.Find(NameOfHand);
                //Debug.Log("Hand is empty"); //This function use to debug if hand is null
                IsObjectInUse = false;
                
                //this.GetComponent<Collider>().enabled = false;//turn off the collider if there no hand.
                //this.transform.position = center;//return to (0,0,0) if there no hand.
            }

            //Set gameobject transform == to hand
            //SetParent(hand);
            else if (Hand != null)
            {
                this.transform.position = Hand.transform.position;
                IsObjectInUse = true;
                //Debug.Log("This object's position: " + this.transform.position); //Debug to see this object's position
                //Debug.Log("Hand's position: " + hand.transform.position); //Debug to see hand's position
            }

        }
    }

    //Go to the table.
    private void ToTable() { 
    
    }

    GameObject GetChildWithName(GameObject obj, string name)
    {
        Transform trans = obj.transform;
        Transform childTrans = trans.Find(name);
        if (childTrans != null)
        {
            return childTrans.gameObject;
        }
        else
        {
            return null;
        }
    }

   
}
