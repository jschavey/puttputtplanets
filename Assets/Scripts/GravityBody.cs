﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GravityBody : MonoBehaviour {
	private static int _diff = 0;	//	0 = easy, 1 = hard

	public GravityTarget target;

    public ClickVisualizationBehaviour visualizationPrototype; //We will make a copy of this instance
    protected ClickVisualizationBehaviour clickVisualization;

    protected Renderer rend;

	public int mass = 1;
	public float scalar = 1.0f;
	public int time = 0;

	public bool mouseDown = false;

	// Use this for initialization
	void Start () {}
  
	// Update is called once per frame
	void FixedUpdate () {
		//	Start preliminary calculations needed for determing gravitational force
		float dist = Vector3.Distance(this.transform.position, target.transform.position);
		Vector3 v = this.transform.position - target.transform.position;
	
		//	this is for amplification of gravity scalar
		if (this.mouseDown) {
			this.time++;
		} else {
			if (this.time > 0) {
				this.time--;
			}
		}
		this.scalar = 10000/(1 + Mathf.Exp(-1*(this.time - 7)));

		//	final gravityational force calculated and applied
		target.GetComponent< Rigidbody2D >().AddForce(v.normalized * ( this.mass * target.mass * (this.scalar/10 ) ) / Mathf.Pow( dist, 2 ) );

		//	give b odies UCM
		if (_diff == 1) {
			float degreesPerSecond = -5.0f;
			Vector2 pos = Quaternion.AngleAxis (degreesPerSecond * Time.deltaTime, Vector3.forward) * (this.transform.position);
			transform.position = pos;
		}
	}

	void OnMouseDown() {
		this.mouseDown = true;

        //Init click visualization        
        if (this.clickVisualization == null && this.visualizationPrototype != null)
        {
            this.clickVisualization = Instantiate(visualizationPrototype, transform.position, new Quaternion(0, 0, 0, 0));
            this.visualizationPrototype = null;
        }

        //Trigger visualization
        if (this.clickVisualization != null)
        {
            if (this.rend == null)
                this.rend = this.GetComponent<Renderer>();

            float radius = this.rend.bounds.extents.x;
            this.clickVisualization.setMaxRadius(radius);
            this.clickVisualization.transform.position = this.transform.position;
            this.clickVisualization.Grow();
        }
	}

	void OnMouseUp() {
		this.mouseDown = false;

        //Hide click visualization
        if (this.clickVisualization != null)
        {
            if (time > 0)
                this.clickVisualization.Shrink();                   
        }
	}

	void Update() {
		transform.Rotate (0,0,50*Time.deltaTime); //rotates 50 degrees per second around z axis
	}

	public void ToggleDiff( bool val ) {
		GravityBody._diff = val ? 1 : 0;
	}
}