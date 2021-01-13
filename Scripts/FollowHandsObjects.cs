using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft;
using Microsoft.MixedReality.Toolkit.Utilities;
using Microsoft.MixedReality.Toolkit.Input;

public class FollowHandsObjects : MonoBehaviour
{
    public GameObject FingerObject;
    public GameObject PalmObject;

    public float distance;

    Vector3 FingerTipL = new Vector3();
    Vector3 FingerTipR = new Vector3();
    Vector3 PalmL = new Vector3();
    Vector3 PalmR = new Vector3();

    GameObject FingerR;
    GameObject FingerL;
    GameObject PalmRight;
    GameObject PalmLeft;

    MixedRealityPose pose;
    
    
    // Start is called before the first frame update
    /// <summary>
    /// Instantiate all of the object colliders you will be using.
    /// </summary>
    void Start()
    {
        FingerR = Instantiate(FingerObject, this.transform);
        FingerL = Instantiate(FingerObject, this.transform);

        PalmRight = Instantiate(PalmObject, this.transform);
        PalmLeft = Instantiate(PalmObject, this.transform);
    }

    // Update is called once per frame
    void Update()
    {
        //We only want the objects to be active if the hand is active. Turn off the objects for now.
        TurnOffObjects();

        //We want to check if the palm is active, if so then turn on the objects and position objects.
        TurnOnObjects();

        //Assign new vector 3 based on the hand tracking.
        UpdateObjectPositions();
    }

    /// <summary>
    /// We are turning off the objects colliders if the palm is not in view, this is to prevent accidental triggers. 
    /// </summary>
    void TurnOffObjects() {
        FingerR.GetComponent<MeshCollider>().enabled = false;
        FingerL.GetComponent<MeshCollider>().enabled = false;
        PalmRight.GetComponent<MeshCollider>().enabled = false;
        PalmLeft.GetComponent<MeshCollider>().enabled = false;
    }

    /// <summary>
    /// If the object is out and can be seen then assign a Vector 3 and turn on colliders.
    /// </summary>
    void TurnOnObjects() {
        ///=-- Series of if statements checking to see the tracked hand via the hololens.
        
        if (HandJointUtils.TryGetJointPose(TrackedHandJoint.IndexTip, Handedness.Right, out pose)) {
            //Assign Vector3 of the tip right to the hand tracked vector 3.
            FingerTipR = pose.Position;
            //Turn on the collider as it is now able to be seen.
            FingerR.GetComponent<MeshCollider>().enabled = true;
        }

        if (HandJointUtils.TryGetJointPose(TrackedHandJoint.IndexTip, Handedness.Left, out pose)) {
            //Assign Vector3 of the tip right to the hand tracked vector 3.
            FingerTipL = pose.Position;
            //Turn on the collider as it is now able to be seen.
            FingerL.GetComponent<MeshCollider>().enabled = true;
        }

        if (HandJointUtils.TryGetJointPose(TrackedHandJoint.Palm, Handedness.Right, out pose)) {
            //Assign Vector3 of the tip right to the hand tracked vector 3.
            PalmR = pose.Position;
            //Turn on the collider as it is now able to be seen.
            PalmRight.GetComponent<MeshCollider>().enabled = true;
        }

        if (HandJointUtils.TryGetJointPose(TrackedHandJoint.Palm, Handedness.Left, out pose)) {
            //Assign Vector3 of the tip right to the hand tracked vector 3.
            PalmL = pose.Position;
            //Turn on the collider as it is now able to be seen.
            PalmLeft.GetComponent<MeshCollider>().enabled = true;
        }
    }

    /// <summary>
    /// Place the saved vector 3 onto the finger and palms
    /// </summary>
    void UpdateObjectPositions() {
        PalmRight.transform.position = PalmR;
        PalmLeft.transform.position = PalmL;
        FingerR.transform.position = FingerTipR;
        FingerL.transform.position = FingerTipL;
    }
}
