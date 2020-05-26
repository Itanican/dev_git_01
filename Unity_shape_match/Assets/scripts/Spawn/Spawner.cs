using JetBrains.Annotations;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    // reference to GameObject prefab to be crated when player hits fire key

    [SerializeField] private ObjectPool pool0 = null;
   // [SerializeField] private ObjectPool pool1 = null;
   // [SerializeField] private ObjectPool pool2 = null;
    // [SerializeField] private ObjectPool pool3 = null;

    // reference to our spawn point manager object
    private SpawnPointManager spawnPointManager;

    /*----------------------------------------------------------
     * cache reference to spawn point manager object
     * and start repeat spawning method call
     */
    void Start()
    {
        spawnPointManager = GetComponent<SpawnPointManager>();
        InvokeRepeating("CreateGcube", 0, spawnPointManager.timeBetweenSpawns);
    }

    /*----------------------------------------------------------
     * retrieve a random spawnpoint from the spawn point manager
     * can create clone of prefab object (and store reference to new object in 'newGCUBE')
     */
    private void CreateGcube()
    {
        


        ObjectPool selectedPool = pool0; //default to 0
        /*
        int r = Random.Range(0, 2);

        //Debug.Log("R: " + r);

        switch (r)
        {
            case 0:
                selectedPool = pool0;
            break;

            case 1:
                selectedPool = pool1;
            break;

            case 2:
                selectedPool = pool21;
            break;
        }
        */
        var max = selectedPool.GetComponent<ObjectPool>().maxSpawns;
        var current = selectedPool.GetComponent<ObjectPool>().currentSpawns;

        if (current >= max)
        {
            //return;
        }

        GameObject spawnPoint = spawnPointManager.RandomSpawnPoint();

        // only try to instantiate prefab if spawnpoint is NOT null
        if (spawnPoint)
            {
            //GameObject newGCUBE = (GameObject)Instantiate(prefabGCUBE, spawnPoint.transform.position + transform.up * 12.5f, Quaternion.identity);

            var o = selectedPool.GetObject();

            //select a random child (1 deep) of the Gcube and set it visible
            int r = Random.Range(0, o.transform.childCount);
            GameObject thisChild = o.transform.GetChild(r).gameObject;
            thisChild.SetActive(true);

            o.GetComponent<GcubeEntity>().currentChild = thisChild;
            o.GetComponent<GcubeEntity>().childID = r;

            //Debug.Log("Setting child " + r + " active");

            var position = spawnPoint.transform.position + transform.up * 12.5f;
            //place it
            o.transform.position = position;
            o.transform.rotation = Quaternion.identity;

        }
        
    }
}