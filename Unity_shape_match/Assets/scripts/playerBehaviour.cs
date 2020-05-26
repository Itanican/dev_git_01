using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEditor;
using UnityEngine; 

public class playerBehaviour : MonoBehaviour
{

    public float speed;
    public GameObject bulletPrefab;
    public float secondsBetweenShots;

    float secondsSinceLastShot;

    // Start is called before the first frame update
    void Start()
    {
        secondsSinceLastShot = secondsBetweenShots;
        References.thePlayer = gameObject;
    }

    // Update is called once per frame
    void Update()
    {

        //WASD to move
        /*
        Vector3 inputVector = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        Rigidbody ourRigidBody = GetComponent<Rigidbody>();
        ourRigidBody.velocity = inputVector * speed;
        */

        mousePick();

       


        /*
        //find the new position we'll move to
        Vector3 lookAtPosition = cursorPosition;
        transform.LookAt(lookAtPosition); //face the new positions
        */

        /*
     secondsSinceLastShot += Time.deltaTime;




     if (secondsSinceLastShot >= secondsBetweenShots && Input.GetButton("Fire1"))
     {

         Instantiate(bulletPrefab, transform.position + transform.forward, transform.rotation);
         secondsSinceLastShot = 0;
     }
     */
    }


    void mousePick()
    {

        Ray rayFromCameraToCursor = Camera.main.ScreenPointToRay(Input.mousePosition);
        Plane playerPlane = new Plane(Vector3.up, transform.position);
        playerPlane.Raycast(rayFromCameraToCursor, out float distanceFromCamera);
        Vector3 cursorPosition = rayFromCameraToCursor.GetPoint(distanceFromCamera);

        if (Input.GetButton("Fire1"))
        {
            transform.position = cursorPosition;
            //transform.position = cursorPosition += Vector3.up * 1.1f;
        }


    }

}
