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
    public string NameOfHand; //This is the the hand name
    public string Palm = "Palm Proxy Transform"; //Name of the right hand palm
    //Insert the string of the object that the hand is associated with.
    public bool HandObtained = false; //If the hand is found, attach yourself to it. Set as parent and follow the transform, default state is False.
    private Transform Hand; //The identified hand and its Transform.
    public GameObject hand; //The hand object

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("FindHand", 0, 0.05f); //Every second try and find the hand.
    }

    private void FindHand()
    {
        if (!HandObtained) 
        {
            hand = GameObject.Find(NameOfHand);//find the hand either left or right
            
            if (hand != null) 
            {
                //find child of hand palm proxy make hand = palm
                hand = GetChildWithName(hand, Palm);//get object with the name of the Palm string
                HandObtained = true;
            }
        }
        else if (HandObtained)
        {
            if (hand == null)
            {
                // hand = GameObject.Find(NameOfHand);
                //Debug.Log("Hand is empty"); //This function use to debug if hand is null
                HandObtained = false;
            }

            //Set gameobject transform == to hand
            //SetParent(hand);
            else if (hand != null)
            {
                this.transform.position = hand.transform.position;
                //Debug.Log("This object's position: " + this.transform.position); //Debug to see this object's position
                //Debug.Log("Hand's position: " + hand.transform.position); //Debug to see hand's position
            }

        }

    }

    //public void SetParent(GameObject newParent)
    //{
    //    //Makes the GameObject "newParent" the parent of this GameObject .
    //    this.transform.parent = newParent.transform;

    //    //Display the parent's name in the console.
    //    Debug.Log("This object's Parent: " + this.transform.parent.name);

    //    // Check if the new parent has a parent GameObject.
    //    if (newParent.transform.parent != null)
    //    {
    //        //Display the name of the grand parent of this GameObject.
    //        Debug.Log("This's Grand parent: " + this.transform.parent.parent.name);
    //    }

    //}

    //public void DetachFromParent()
    //{
    //    // Detaches the transform from its parent.
    //    transform.parent = null;
    //}

    //This function return a gameobject which is a child of another object, by enter the child object name. 
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
