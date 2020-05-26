using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEditor;
using UnityEngine; 

public class GcubeBehaviour : MonoBehaviour
{

    GameObject thisGcube;
    //thisGcube = gameObject;

    // public float speed;
    //public GameObject bulletPrefab;

    void Start()
    {


        //References.thePlayer = gameObject;
    }


    void Update()     // Update is called once per frame
    {
        MousePick();
    }


    void MousePick()
    {

        Ray rayFromCameraToCursor = Camera.main.ScreenPointToRay(Input.mousePosition);
        Plane playerPlane = new Plane(Vector3.up, gameObject.transform.position);
        playerPlane.Raycast(rayFromCameraToCursor, out float distanceFromCamera);
        Vector3 cursorPosition = rayFromCameraToCursor.GetPoint(distanceFromCamera);

        if (Input.GetButton("Fire1"))
        {
            gameObject.transform.position = cursorPosition;
            //transform.position = cursorPosition += Vector3.up * 1.1f;
        }


    }

}
