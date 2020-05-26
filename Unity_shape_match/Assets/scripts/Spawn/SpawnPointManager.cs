using UnityEngine;
//using System;
using System.Collections.Generic;

public class SpawnPointManager : MonoBehaviour
{
    // array of reference to spawn point GameObjects in the scene
    [SerializeField] public GameObject[] spawnPoints;
    [SerializeField] public float timeBetweenSpawns;

    List<GameObject> _unBusyList = new List<GameObject>();

    void Start()
    {
        spawnPoints = GameObject.FindGameObjectsWithTag("Respawn"); 
        // log Error if array empty
        if (spawnPoints.Length < 1) Debug.LogError("SpawnPointManager - cannot find any objects tagged 'Respawn'!");
    }

    public GameObject RandomSpawnPoint()
    {
        //check the Array spawnPoints for entries with .busy being set to 0. Add those GameObjects to the short-lived sub List _myInts
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            GameObject candidateSpawnPoint = spawnPoints[i];
            if (candidateSpawnPoint.GetComponent<SpawnPoint>().busy == false) _unBusyList.Add(candidateSpawnPoint);
        }

        if (_unBusyList.Count == 0) return null; // theres nothing in the sub List - bomb out

        //randomly choose a GameObject from the sub List of unBusy spawns
        int r = Random.Range(0, _unBusyList.Count);
        GameObject returnedCandidate = _unBusyList[r];

        //clear the List for this frame
        _unBusyList.Clear();
        return returnedCandidate; 
    }
   
}