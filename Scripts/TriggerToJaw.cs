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
    public bool PullTriggerIn = false;

    public float TriggerRotateSpeedIn;
    public float TriggerRotateSpeedOut;
    private float initXAngle, xAngle, yAngle;
    // 
    private void Start()
    {
        initXAngle = TriggerObject.transform.rotation.eulerAngles.x;

    }
    // Update is called once per frame
    void Update()
    {
       
        xAngle =  TriggerObject.transform.rotation.eulerAngles.x;
        print(xAngle);
        //If you are locked then dont move. If you are unlocked check to see if you are being interacted with.
        if (!Locked) {
            if (PullTriggerIn && xAngle >= (initXAngle - 20)) {
                print(xAngle);
                
                TriggerObject.transform.Rotate(0,-TriggerRotateSpeedIn * Time.deltaTime,0,Space.Self);
                

            } else {
                //TriggerObject.transform.Rotate(TriggerRotateSpeedOut * Time.deltaTime, 0, 0);
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
