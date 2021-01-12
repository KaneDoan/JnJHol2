using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Method controls how the trigger object is interacted with and how it is locked/unlocked.
/// -------------------------------------------------
/// Bradley HJ - 12 Jan 2021
/// </summary>

public class TriggerToJaw : MonoBehaviour
{
    public GameObject TriggerObject; //The trigger object
    public bool Locked; //Identify if the trigger is locked.
    private bool PullTriggerIn;

    public float TriggerRotateSpeedIn;
    public float TriggerRotateSpeedOut;

    // Update is called once per frame
    void Update()
    {
        //If you are locked then dont move. If you are unlocked check to see if you are being interacted with.
        if (!Locked) {
            if (PullTriggerIn) {

            } else { 
            
            }
        } else { 
        
        }
    }


    public void PullTheTriggerIn() {
        PullTriggerIn = true;
    }
    public void PullTheTriggerOut() {
        PullTriggerIn = false;
    }

    //Lock the trigger.
    public void LockTrigger() {
        Locked = true;
    }

    //Unlock the trigger
    public void UnlockTrigger() {
        Locked = false;
    }
}
