using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityBody : MonoBehaviour {
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
}
