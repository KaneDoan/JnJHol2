using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SnapToObject : MonoBehaviour
{
    public string ObjectINeedToSnap;
    //public Vector3 LocalCo_OrdToSnap;

    public UnityEvent IfObjectSnapped;

    private void OnTriggerEnter(Collider other) {
        string otherName = other.name;
        
        if (ObjectINeedToSnap == otherName) {
            ///---- Commented code in for learning. Could not snap and then disable the object manipulator script to allow the object to move away from the persons hand.
            ///Instead, until we can learn otherwise. I am disabling the object entirely and enabling a ghosted object which is not interactable.

            //other.transform.parent = gameObject.transform;
            //other.GetComponent<BoxCollider>().enabled = false;
            //other.GetComponent<Rigidbody>().detectCollisions = false;
            //other.transform.localPosition = LocalCo_OrdToSnap;
            //Cannot disable ObjectManipulator.

            //Turn off the object for now.
            other.gameObject.SetActive(false);

            IfObjectSnapped.Invoke();
        }
    }
}
