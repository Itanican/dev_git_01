using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Functions : MonoBehaviour
{

    public void Touch(Collider withHit )
    {
        Debug.Log("We touched!" + withHit);
    }

    public void TouchExit(Collider withHit)
    {
        Debug.Log("We exited");
    }

    public void TouchStay(Collider withHit)
    {
        Debug.Log("We are colliding");
    }


}
