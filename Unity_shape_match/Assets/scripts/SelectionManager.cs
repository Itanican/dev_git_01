using UnityEngine;
using UnityEngine.UI;

public class SelectionManager : MonoBehaviour
{
    public string selectableTag = "Selectable";
    //public Material highlightMaterial;
    //public Material defaultMaterial;

    //private Transform _selection;
    [SerializeField] public Transform myCurrent; //just for debug - what are we grabbing?
    [SerializeField] float dropHeight = 2.5f;


    private Vector3 cursorPosition;
    private Vector3 offsetPosition;

   // private LayerMask layerMask;

    private void Awake()
    {
       // LayerMask layerMask = LayerMask.GetMask("GCubeLayer");
    }


    void Update()
    {
        DoGrab();
        updateMyCurrentPosition();


    }

    void DoGrab()
    {
        if (Input.GetButtonDown("Fire1")) //one frame only, not held
        {

           int layerMask = 1 << 8; //check only for objects on layer 8 (GCubeLayer)
            //layerMask = ~layerMask; //Don't invert is (but this is how you do)

            Ray rayFromCameraToCursor = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit myHit;

            if (Physics.Raycast(rayFromCameraToCursor, out myHit, 1000, layerMask))
            {
                var selection = myHit.transform;

                if (selection.CompareTag(selectableTag))
               // if (myHit.collider.tag == "Selectable")
                {
                    myCurrent = selection;
                    var ourRigidBody = selection.GetComponent<Rigidbody>();
                    ourRigidBody.isKinematic = true;

                    offsetPosition = transform.position;
                }
                else
                {
                    selection = null;
                    return;
                }

            }
        }

        if (myCurrent != null && !Input.GetButton("Fire1")) //you ARE grabbing something but not HOLDING the mouse button
        {
            Debug.Log("Dropping a carried");
            Drop();
        }

        if (myCurrent != null && !myCurrent.transform.gameObject.activeSelf) // if the grabbed object is not active (i.e. Returned to Pool)
        {
            Debug.Log("Dropping an inactive");
            Drop();
        }
    }


    void updateMyCurrentPosition()
    {
        if (myCurrent != null)
        {

            Ray rayFromCameraToCursor = Camera.main.ScreenPointToRay(Input.mousePosition);
            Plane playerPlane = new Plane(Vector3.up, gameObject.transform.position);
            playerPlane.Raycast(rayFromCameraToCursor, out float distanceFromCamera);
            cursorPosition = rayFromCameraToCursor.GetPoint(distanceFromCamera);

            //cursorPosition =- offsetPosition;

            myCurrent.transform.position = cursorPosition += Vector3.up * dropHeight; // 20.5f ;
        }


    }

    void Drop()
    {
        var ourRigidBody = myCurrent.GetComponent<Rigidbody>();
        ourRigidBody.isKinematic = false; //returns the physics component to Dynamic
        myCurrent = null; //drop the object
    }

}