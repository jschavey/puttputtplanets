using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityBody : MonoBehaviour {
	public GravityTarget target;

    public GameObject clickVisualization;

	public int mass = 1;
	public float scalar = 1.0f;
	public int time = 0;

	public bool mouseDown = false;

	// Use this for initialization
	void Start () {}
	
	// Update is called once per frame
	void FixedUpdate () {

		float dist = Vector3.Distance(this.transform.position, target.transform.position);

		Vector3 v = this.transform.position - target.transform.position;
	
		if (this.mouseDown) {
			this.time++;
		} else {
			if (this.time > 0) {
				this.time--;
			}
		}

		this.scalar = 10000/(1 + Mathf.Exp(-1*(this.time - 7)));
				
		target.GetComponent< Rigidbody2D >().AddForce(v.normalized * ( this.mass * target.mass * (this.scalar/10 ) ) / Mathf.Pow( dist, 2 ) );
	}

	void OnMouseDown() {
		this.mouseDown = true;
        //Add click visualization
        //this.clickVisualization = Instantiate(clickVisualization, transform.position, new Quaternion(0,0,0,0));
	}

	void OnMouseUp() {
		this.mouseDown = false;
        //Destory click visualization
        //Destroy(this.clickVisualization);
	}

	void Update() {
		transform.Rotate (0,0,50*Time.deltaTime); //rotates 50 degrees per second around z axis
	}
}
