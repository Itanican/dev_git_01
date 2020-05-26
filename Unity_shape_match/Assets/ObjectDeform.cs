using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDeform : MonoBehaviour
{
    private Sequence squashSequence;

    private bool isSquashing = false;

    private float scaleX;
    private float scaleY;
    private float scaleZ;
    private float targetScale;

    private float severity = 0;

    [SerializeField] float threshold;

    [SerializeField] float scaleFactor = 1f; // = 0.75f;
    [SerializeField] float time1 = 0.2f;
    [SerializeField] float time2 = 0.2f;

    private Rigidbody rb;

    private void Start()
    {
        scaleX = transform.localScale.x;
        scaleY = transform.localScale.y;
        scaleZ = transform.localScale.z;

         rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.CompareTag("ArenaFloor"))
        {

            Vector3 vel = rb.velocity;

            var yVel = rb.velocity.y;

            //print(yVel);
            severity = 1.0f;
            /*

            if (yVel <= threshold)
            {
                severity = 5.0f;
                print("hard! " + yVel);
            }
            else
            {
                print("soft! " + yVel);
                severity = 1.0f;
            }
            */
            
            
            TrySquash(severity);

        }
    }

    //private void OnMouseDown() => TrySquash();

    private void TrySquash(float severity)
    {
        if (isSquashing) { return; } //if it is already performing the squash coroutine, bomb out
        StartCoroutine(ChangeTurn(severity)); //otherwise start the routine
    }


    private IEnumerator ChangeTurn(float severity)
    {
        
        isSquashing = true;

        var camSequence = DOTween.Sequence();
        targetScale = scaleY * scaleFactor * severity;

        //print("severity: " + severity);

        var tweener1 = DOTween.To(() => scaleY, y => scaleY = y, targetScale, time1) //0.2f
                    .SetEase(Ease.OutSine)
                    .OnUpdate(() => transform.localScale = new Vector3(scaleX, scaleY, scaleZ));
                camSequence.Append(tweener1);
        
                float targetScale2 = scaleY;
                var tweener2 = DOTween.To(() => scaleY, y => scaleY = y, targetScale2, time2) // 0.25f
                    .SetEase(Ease.OutBounce)
                    .OnUpdate(() => transform.localScale = new Vector3(scaleX, scaleY, scaleZ));
                camSequence.Append(tweener2);
                
                camSequence.Play();

            while (camSequence.IsActive()) { yield return null; }
       isSquashing = false;
    }
}
