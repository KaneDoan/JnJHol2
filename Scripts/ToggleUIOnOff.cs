using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Toggle the UI and tooltips on and off.
/// -------------------------------------------------
/// Bradley HJ - 12 Jan 2021
/// </summary>
public class ToggleUIOnOff : MonoBehaviour
{

    public GameObject[] Tooltips;
    private bool TipBool;

    public void ToggleUI() {
        //Toggle the boolean
        TipBool = !TipBool;
        foreach (GameObject Tip in Tooltips) {
            Tip.SetActive(TipBool);
        }
    }
}
