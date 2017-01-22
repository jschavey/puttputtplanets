using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityTarget : MonoBehaviour {
	public int mass = 10;
	Rigidbody2D rb;

	// Use this for initialization
	void Start () {
		this.rb = this.GetComponent< Rigidbody2D > ();
		this.rb.isKinematic = false;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if( this.rb.velocity.magnitude > 10.0f ) {
			//Debug.Log ("clamping velocity");
			this.rb.velocity = Vector2.ClampMagnitude( this.rb.velocity, 10.0f );
		}
	}
}
