using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityTarget : MonoBehaviour {
	public int mass = 10;
    public GameObject sun;
    protected float rightConstraint;
    protected float topConstraint;
    protected float leftConstraint;
    protected float bottomConstraint;
    protected float buffer = 0f;
    Rigidbody2D rb;
    Renderer rend;

	// Use this for initialization
	void Start () {
		this.rb = this.GetComponent< Rigidbody2D > ();
		this.rb.isKinematic = false;

        this.rb = this.GetComponent<Rigidbody2D>();
        this.rb.isKinematic = false;
        this.rend = GetComponent<Renderer>();
        this.buffer = rend.bounds.extents.magnitude;

        //Set constraints just outside of screen boundaries, base on object size
        this.leftConstraint = Camera.main.ScreenToWorldPoint(new Vector2(0.0f, 0.0f)).x;
        this.bottomConstraint = Camera.main.ScreenToWorldPoint(new Vector2(0.0f, 0.0f)).y;
        this.rightConstraint = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0.0f)).x;
        this.topConstraint = Camera.main.ScreenToWorldPoint(new Vector2(0.0f, Screen.height)).y;
    }
	
	// Update is called once per frame
	void FixedUpdate () {
		if( this.rb.velocity.magnitude > 10.0f ) {
			//Debug.Log ("clamping velocity");
			this.rb.velocity = Vector2.ClampMagnitude( this.rb.velocity, 10.0f );
		}
	}

    /**
     * Makes Gravity Target wrap around edges of the screen
     * @return void
     */
    protected void WrapAroundScreen()
    {
        float curX = this.transform.position.x;
        float curY = this.transform.position.y;
        float newX = curX;
        float newY = curY;

        if (curX < leftConstraint - buffer)   // object is past world-space view / off screen
            newX = rightConstraint + buffer;  // move object to opposite side
        else if (curX > rightConstraint + buffer)
            newX = leftConstraint - buffer;

        if (curY > topConstraint + buffer)
            newY = bottomConstraint - buffer;
        else if (curY < bottomConstraint - buffer)
            newY = topConstraint + buffer;

        //Set new position
        this.transform.position = new Vector2(newX, newY);
    }

    /**
     * Returns true if Gravity Target is outside of screen bounds
     * @return bool
     */
    public bool IsOutOfBounds()
    {
        bool outOfBounds = false;
        float curX = this.transform.position.x;
        float curY = this.transform.position.y;

        if (curX < leftConstraint - buffer ||
            curX > rightConstraint + buffer ||
            curY < bottomConstraint - buffer ||
            curY > topConstraint + buffer)
            outOfBounds = true;

        return outOfBounds;
    }

}
