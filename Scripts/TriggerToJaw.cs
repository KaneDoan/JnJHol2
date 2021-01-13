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
    public GameObject TopJaw;
    public bool Locked = false; //Identify if the trigger is locked.
    public bool PullTriggerIn = false;

    public float TriggerRotateSpeedIn;
    public float TriggerRotateSpeedOut;
    private float initXAngle, xAngle, finalXangle;
    // 
    private void Start()
    {
        initXAngle = TriggerObject.transform.rotation.eulerAngles.x;
        finalXangle = Mathf.Round(initXAngle - 20);

    }
    // Update is called once per frame
    void Update()
    {
       
        xAngle =  Mathf.Round(TriggerObject.transform.rotation.eulerAngles.x);
       
        print(xAngle);
        //If you are locked then dont move. If you are unlocked check to see if you are being interacted with.
        if (!Locked) {
            if (PullTriggerIn &&  xAngle >= finalXangle) {
                print(xAngle);
                
                TriggerObject.transform.Rotate(0,-TriggerRotateSpeedIn * Time.deltaTime,0,Space.Self);
                TopJaw.transform.Rotate(0,  -TriggerRotateSpeedIn * Time.deltaTime * 0.5f ,0, Space.Self);
                if ( xAngle == finalXangle)
                {
                    PullTriggerIn = false;
                    LockTrigger();
                }
               // PullTriggerIn = false;

            } else if ( xAngle <= initXAngle)
            {
                //TriggerObject.transform.Rotate(TriggerRotateSpeedOut * Time.deltaTime, 0, 0);
                TriggerObject.transform.Rotate(0, TriggerRotateSpeedIn * Time.deltaTime, 0, Space.Self);
                TopJaw.transform.Rotate(0, TriggerRotateSpeedIn * Time.deltaTime * 0.5f,0, Space.Self);
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
       // print("LockTrigger()");
        Locked = true;
    }

    //Unlock the trigger
    public void UnlockTrigger() {
        Locked = false;
    }
}
