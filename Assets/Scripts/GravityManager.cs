//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//
//public class GravityManager : MonoBehaviour {
//	GameObject[] gravBodies;
//
//	// Use this for initialization
//	void Start () {
////		gravBodies = GameObject.FindObjectsOfType ("GravityBody");
//	}
//	
//	// Update is called once per frame
//	//	butfixedupdate needed for physics
//	void FixedUpdate () {
////		GameObject[] gravTargets = GameObject.FindObjectOfType ("GravityTarget");
//
//		foreach(GameObject gravBody in gravBodies) {
//			foreach( GameObject gravTarget in gravTargets ) {
//				
//				float dist = Vector3.Distance(gravBody.transform.position, gravTarget.transform.position);
//
//				Vector3 v = gravBody.transform.position - gravTarget.transform.position;
//			
//				GetComponent< Rigidbody2D >().AddForce(v.normalized * ( gravBody.mass * gravTarget.mass * gravBody.scalar ) / dist^2 );
//			}
//		}	
//	}
//}
