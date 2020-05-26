using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PooledObject : MonoBehaviour
{
    public ObjectPool owner;
   // public GameObject myPool;
}

// A class that adds a new method to the GameObject class: ReturnToPool.
public static class PooledGameObjectExtensions
{
    //This method is an extension method (note the 'this' parameter)
    //This means that it's a new method that's added to all instances
    //of the GameObject class; you call it like this:

    // GameObject.ReturnToPool();

    //Returns an object to the object pool that it was created from
    public static void ReturnToPool(this GameObject gameObject)
    {
        //Find the PooledObject component
        var pooledObject = gameObject.GetComponent<PooledObject>();

        //Does it exist?
        if (pooledObject == null)
        {
            //If it doesn't, it means that this object never came from a pool
            Debug.LogErrorFormat(gameObject, "Cannot return {0} to object pool, because it was not" + "created from one", gameObject);
            return;
        }

        //Tell the pool we came from that this object should be returned
        pooledObject.owner.ReturnObject(gameObject);
       // pooledObject.owner.GetComponent<ObjectPool>().currentSpawns -= 1;
    }

}