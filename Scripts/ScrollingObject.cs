using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingObject : MonoBehaviour
{
    // Start is called before the first frame update
    public string NameOfObjectsHand; //Name of the object that is used for the Hand.
    private GameObject Hand;
    private GameObject ScollingObject;
    bool rotating = false;
    public float smoothTime = 5.0f;

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.name == NameOfObjectsHand && !rotating) // we dont want to call this if the object is already rotating, so we check if it is
        {
            Hand = other.gameObject;
            if (!Hand) 
            {
                rotating = false;
            }
            else if (Hand)
            {
                rotating = true;
                float rando = Random.Range(0, 100); // pick a random number between 1 and 100
                int multiplier = 1;
                if (rando > 50)
                {
                    multiplier = -1;
                }
                StartCoroutine(RotateOverTime(ScollingObject.transform.localEulerAngles.y, ScollingObject.transform.localEulerAngles.y + (90 * multiplier), smoothTime));
            }
            //Rotate rotatedObject by 90 degrees on the Y axis
           
        }
    }
    IEnumerator RotateOverTime(float currentRotation, float desiredRotation, float overTime)
    {
        float i = 0.0f;
        while (i <= 1)
        {
            ScollingObject.transform.localEulerAngles = new Vector3(ScollingObject.transform.localEulerAngles.x, Mathf.Lerp(currentRotation, desiredRotation, i), ScollingObject.transform.localEulerAngles.z);
            i += Time.deltaTime / overTime;
            yield return null;
        }
        yield return new WaitForSeconds(overTime);
        rotating = false; // no longer rotating
    }

    void Start()
    {
        ScollingObject = this.transform.parent.gameObject;
    }

}
