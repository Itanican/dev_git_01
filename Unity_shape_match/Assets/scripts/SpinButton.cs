using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinButton : MonoBehaviour
{

    [SerializeField] float spinTime = 0.5f;
    [SerializeField] AnimationCurve curve = AnimationCurve.EaseInOut(0, 0, 1, 1);
    [SerializeField] float angle = 0f ;
    public void Spin()
    {
        StartCoroutine(StartSpinning());
    }

    private IEnumerator StartSpinning()
    {
        if (spinTime <= 0)
        {
            yield break;
        }

        float elapsed = 0f;

        while (elapsed <= spinTime)
        {
            elapsed += Time.deltaTime;

            //Calculate how far along the animation we are, measured between 0 and 1
            var t = elapsed / spinTime;

            //Use this value to figure out how many degrees we should be rotated at on this frame
            angle = curve.Evaluate(t) * 360f;

            //Calculate the rotation by rotating this many angles around the x-axis
            transform.localRotation = Quaternion.AngleAxis(angle, Vector3.left);

            //Wait a new frame
            yield return null;

        }

        //Animation is now complete. Reset the rotation to normal
        transform.localRotation = Quaternion.identity;
    }

}
