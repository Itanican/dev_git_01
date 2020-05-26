using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolNotifier : MonoBehaviour, IObjectPoolNotifier
{

    //public GameObject GameObject myPool;

    //public GameObject myPool = null;

    //Our opportunity to do any setup we need to after we're either
    //created or removed from the pool
    //attach this to every prefab that uses the pool system

    public void OnCreatedOrDequeuedFromPool(bool created)
    {
        //Debug.Log("Dequeued from object pool!");
        //StartCoroutine(DoReturnAfterDelay());
    }

    //Called when we have been returned to the pool
    public void OnEnqueuedToPool()
    {
        //Debug.Log("Enqueued to object pool!");
    }

    /*
    IEnumerator DoReturnAfterDelay()
    {
        yield return new WaitForSeconds(1.0f);

        // Return this object to the pool from whence it came
        gameObject.ReturnToPool();
    }
    */

}
