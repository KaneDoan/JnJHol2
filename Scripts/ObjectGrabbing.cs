using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectGrabbing : MonoBehaviour
{
    GameObject ObjectImHolding;
    public string[] ObjectsICanPickup;
    Vector3 ShiftObject;
    Vector3 AnglesToShift;

    //If there is something already in my hand, make true.
    bool HandFull;

    private void Update() {
        //Keep an eye on the object I am holding. If the object is no longer active then drop the object.
        if (ObjectImHolding != null) {
            bool StillActive = ObjectImHolding.activeSelf;
            if (!StillActive) {
                DropTheObject();
            }            
        }        
    }


    private void OnTriggerEnter(Collider other) {
        //If I dont have anything in my hand.
        if (!HandFull) {
          string othersName = other.name;
            foreach (string names in ObjectsICanPickup) {
                //Is the object that you are colliding with an object you can pickup. If you can then move the object to this object as its parent and shift the object if needed.
                if (othersName == names) {
                    ObjectImHolding = other.gameObject;
                    ObjectImHolding.transform.parent = gameObject.transform;
                    
                    //Collect variables from the object.
                    var SelfObjectVariables = ObjectImHolding.GetComponent<SelfObjectController>();
                    ShiftObject = SelfObjectVariables.MyShiftObject;
                    AnglesToShift = SelfObjectVariables.MyAnglesToShift;
                    SelfObjectVariables.I_AmBeingUsed = true;
                    SelfObjectVariables.ImHoldingYou(gameObject);

                    ObjectImHolding.transform.localPosition = new Vector3(ShiftObject.x, ShiftObject.y, ShiftObject.z);
                    ObjectImHolding.transform.localEulerAngles = new Vector3(AnglesToShift.x, AnglesToShift.y, AnglesToShift.z);
                    
                    HandFull = true;

                    break;
                }
            }
        }
    }

    public void DropTheObject() {
        //Clear the object I am holding.
        ObjectImHolding = null;
        HandFull = false;
    }
}
