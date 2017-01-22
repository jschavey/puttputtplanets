using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunCircles : MonoBehaviour {

    //put this script on per "Sun" or star object in the object hierarchy.
    //change the radius values per planet flight orbit.
    private void OnDrawGizmos()
    {
        //first planet
        Gizmos.DrawWireSphere(transform.position, 12);

        //second planet
        Gizmos.DrawWireSphere(transform.position, 14);

        //third planet
        Gizmos.DrawWireSphere(transform.position, 16);

        //fourth planet
        Gizmos.DrawWireSphere(transform.position, 18);

        //you get the idea...
        Gizmos.DrawWireSphere(transform.position, 20);
        Gizmos.DrawWireSphere(transform.position, 22);
        Gizmos.DrawWireSphere(transform.position, 24);
        Gizmos.DrawWireSphere(transform.position, 26);
        Gizmos.DrawWireSphere(transform.position, 28);
    }
}
