using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GravityBody : MonoBehaviour {
	private static int _diff = 0;	//	0 = easy, 1 = hard

	public GravityTarget target;

    public ClickVisualizationBehaviour visualizationPrototype; //We will make a copy of this instance
    protected ClickVisualizationBehaviour clickVisualization;

    protected Renderer rend;
    protected AudioSource audio;

	public int mass = 1;
	public float scalar = 1.0f;
	public int time = 0;

	public bool mouseDown = false;

	// Use this for initialization
	void Start () {}
  
    void Awake()
    {
        this.audio = this.GetComponent<AudioSource>();
    }

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

        //Make click visualization follow this object
        if (this.clickVisualization != null)
            this.clickVisualization.transform.position = this.transform.position;       
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

            if (this.rend == null)
                this.rend = this.GetComponent<Renderer>();

            float radius = this.rend.bounds.extents.x;
            this.clickVisualization.setAdjustedScale(radius);

        }

        //Trigger visualization
        if (this.clickVisualization != null)
        {            
            this.clickVisualization.transform.position = this.transform.position;
            this.clickVisualization.Grow();
        }

        //Trigger sfx
        audio.pitch = 1.5f;
        audio.loop = true;
        audio.Play();
	}

	void OnMouseUp() {
		this.mouseDown = false;

        //Hide click visualization
        if (this.clickVisualization != null)
        {
            if (time > 0)
                this.clickVisualization.Shrink();                   
        }

        //Trigger sfx
        audio.Stop();
        audio.pitch = -1.5f; //Reverse it
        audio.loop = false;
        audio.Play();
    }

	void Update() {
		transform.Rotate (0,0,50*Time.deltaTime); //rotates 50 degrees per second around z axis
	}

	public void ToggleDiff( bool val ) {
		GravityBody._diff = val ? 1 : 0;
	}
}
