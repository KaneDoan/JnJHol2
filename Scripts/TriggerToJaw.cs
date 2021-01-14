using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Method controls how the trigger object is interacted with and how it is locked/unlocked.
/// -------------------------------------------------
/// Bradley HJ - 12 Jan 2021
/// </summary>
public enum Axis
{
    x,
    y,
    z
}
public class TriggerToJaw : MonoBehaviour
{

    public GameObject TriggerObject; //The trigger object
    public GameObject TopJaw;
    public float triggerRange, jawRange, ratio;
    public Axis triggerAxis, jawAxis;

    public bool Locked = false; //Identify if the trigger is locked.
    public bool PullTriggerIn = false;
    public float TriggerRotateSpeedIn;
    private float initAngle, angle, finalAngle;
    // 
    private void Start()
    {
        ratio = jawRange / triggerRange;
        // initAngle = TriggerObject.transform.rotation.eulerAngles.x;
        switch (triggerAxis)
        {
            case Axis.x:
                initAngle = Mathf.Round(TriggerObject.transform.localEulerAngles.x);
                break;
            case Axis.y:
                initAngle = Mathf.Round(TriggerObject.transform.localEulerAngles.y);
                break;
            case Axis.z:
                initAngle = Mathf.Round(TriggerObject.transform.localEulerAngles.z);
                break;
        }

        finalAngle = Mathf.Round(initAngle - triggerRange);



    }
    // Update is called once per frame
    void Update()
    {

        //angle =  Mathf.Round(TriggerObject.transform.rotation.localEulerAngles.x);
        switch (triggerAxis)
        {
            case Axis.x:
                angle = Mathf.Round(TriggerObject.transform.localEulerAngles.x);

                break;
            case Axis.y:
                angle = Mathf.Round(TriggerObject.transform.localEulerAngles.y);
                break;

            case Axis.z:
                angle = Mathf.Round(TriggerObject.transform.localEulerAngles.z);
                break;
        }

        print(angle);
        //If you are locked then dont move. If you are unlocked check to see if you are being interacted with.
        //if (angle == finalAngle || angle == initAngle && !PullTriggerIn)
        // {

        //    LockTrigger();
        //}
        if (!Locked)
        {


            if (PullTriggerIn && angle >= finalAngle)
            {

                          RotateGameObject(TriggerObject, triggerAxis, -TriggerRotateSpeedIn * Time.deltaTime);
                RotateGameObject(TopJaw, jawAxis, -TriggerRotateSpeedIn * Time.deltaTime * ratio);

                if (angle == finalAngle)
                {
                    PullTriggerIn = false;
                    LockTrigger();
                }


            }
            else if (angle < initAngle)
            {

                RotateGameObject(TriggerObject, triggerAxis, TriggerRotateSpeedIn * Time.deltaTime);
                RotateGameObject(TopJaw, jawAxis, TriggerRotateSpeedIn * Time.deltaTime * ratio);


            }
        }



    }


    public void PullTheTriggerIn()
    {
        PullTriggerIn = true;
    }
    public void PullTheTriggerOut()
    {
        PullTriggerIn = false;
    }

    //Lock the trigger.
    public void LockTrigger()
    {
        // print("LockTrigger()");
        Locked = true;
    }
    public void UnlockGrip()
    {
       if(gameObject.CompareTag("Grip") && Locked)
        {
            UnlockTrigger();
        }
    }

    //Unlock the trigger
    public void UnlockTrigger()
    {
        Locked = false;
    }
    private void RotateGameObject(GameObject gameObject, Axis axis, float value)
    {
        switch (axis)
        {
            case Axis.x:
                gameObject.transform.Rotate(value, 0, 0, Space.Self);
                break;
            case Axis.y:
                gameObject.transform.Rotate(0, value, 0, Space.Self);
                break;
            case Axis.z:
                gameObject.transform.Rotate(0, 0, value, Space.Self);
                break;
        }
    }
}
