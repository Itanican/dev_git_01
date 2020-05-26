using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public bool busy;

    private void OnTriggerEnter(Collider thisHit)
    {
        if (thisHit.CompareTag("Selectable"))
        {
            busy = true;
        }
    }

    private void OnTriggerExit(Collider thisHit)
    {
        if (thisHit.CompareTag("Selectable"))
        {
            busy = false;
        }
    }

}
