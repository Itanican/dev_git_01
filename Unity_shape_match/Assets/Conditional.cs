using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conditional : MonoBehaviour
{
    public int score;
    public bool checkpoint;

    public Functions otherScript;

    private void Update()
    {
        if (score == 50)
        {
            if (checkpoint)
            {
                // Debug.Log("Score is 50!");
                //otherScript.GetComponent<Functions>().Death();
            }
        }

        else if (score == 40 && !checkpoint)
        {
            Debug.Log("Score is 40!");
        }

        else
        {
            Debug.Log("Score is 0!");
        }
        /*
        void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Selectable"))
            {
                Debug.Log("score is 0!");
            }

        }
        */
    }
}
