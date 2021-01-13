using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableTop_ToolReturn : MonoBehaviour
{
    public string[] ObjectsICanHold;

    private void OnTriggerEnter(Collider other) {
        string othersName = other.name;
        foreach (string names in ObjectsICanHold) {
            if (othersName == names) {
                var SelfObjectVariables = other.GetComponent<SelfObjectController>();
                SelfObjectVariables.I_AmBeingUsed = false;
                SelfObjectVariables.LetGoOfMe();
                other.gameObject.transform.parent = gameObject.transform;

                break;
            }
        }
    }
}
