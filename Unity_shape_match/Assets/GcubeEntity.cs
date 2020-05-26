using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEditorInternal;
using UnityEngine;

public class GcubeEntity : MonoBehaviour
{

    // public List<GameObject> Children = new List<GameObject>();

    //public GameObject myPool;
    //public GameObject GameObject myPool;
    // public Functions otherScript;
    //public ObjectPool myPool = null;
   // GameObject thisChild;

    public GameObject currentChild;
    [SerializeField] public int childID = -1;

    //public GameObject objectWithOtherScript;
    GameObject referenceObject;
    SelectionManager referenceScript;


    private void Awake()
    {
        int children = transform.childCount;
        for (int i = 0; i < children; ++i)
        {
            currentChild = transform.GetChild(i).gameObject;
            currentChild.SetActive(false);
            currentChild = null;
        }

            
        
    }
    

    private void Update()
    {
        if (transform.position.y < -2.0f) { gameObject.ReturnToPool();}
    }

    private void OnTriggerEnter(Collider thisHit)
    {
        if (thisHit.CompareTag("Selectable"))
        {
           //otherScript.GetComponent<Functions>().Touch(thisHit);

        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Selectable"))
        {
            if (collision.gameObject.GetComponent<GcubeEntity>().childID == this.childID)
            {
                //If the GameObject's name matches the one you suggest, output this message in the console
                //Debug.Log("Same!");

                //var selected = gameObject.GetComponent<SelectionManager>().myCurrent;

               // referenceScript.GetComponent<SelectionManager>().myCurrent = null;


                collision.gameObject.ReturnToPool();
                gameObject.ReturnToPool();

                /*
                myCurrent = selection;
                var ourRigidBody = selection.GetComponent<Rigidbody>();
                ourRigidBody.isKinematic = true;
                */

            }
            else
            {
                //Debug.Log("NOT same!");
            }
        }
    }


    /*
    private void OnTriggerEnter(Collider thisHit)
    {
        if (thisHit.CompareTag("Selectable"))
        {
            //otherScript.GetComponent<Functions>().Touch(thisHit);

        }
    }
    */

    /*
    private void OnTriggerExit(Collider thisHit)
    {
        if (thisHit.CompareTag("Selectable"))
        {
            //print("Exited");
            otherScript.GetComponent<Functions>().TouchExit(thisHit);
        }
    }
    
    private void OnTriggerStay(Collider thisHit)
    {
        if (thisHit.CompareTag("Selectable"))
        {
            otherScript.GetComponent<Functions>().TouchStay(thisHit);
        }

    }
    */
}
