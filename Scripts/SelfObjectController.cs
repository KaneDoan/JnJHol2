using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfObjectController : MonoBehaviour
{
    public bool I_AmBeingUsed;
    public Vector3 MyShiftObject;
    public Vector3 MyAnglesToShift;
    public string MyName;

    GameObject ControllerHoldingMe;

    public int Countdown;
    bool BeginCount;

    private void Start() {
        InvokeRepeating("RestartMyCollider", 0, 1f);
    }

    public void ImHoldingYou(GameObject palm) {
        ControllerHoldingMe = palm;
        gameObject.GetComponent<MeshCollider>().enabled = false;
        BeginCount = true; 
    }

    public void LetGoOfMe() {
        if (ControllerHoldingMe != null) {
            gameObject.GetComponent<MeshCollider>().enabled = false;
            ControllerHoldingMe.GetComponent<ObjectGrabbing>().DropTheObject();
            BeginCount = true;
        }
        
    }

    void RestartMyCollider() {
        if (BeginCount) {
            Countdown -= 1;
            if (Countdown <= 0) {
                gameObject.GetComponent<MeshCollider>().enabled = true;
            }
        }
    }

}
