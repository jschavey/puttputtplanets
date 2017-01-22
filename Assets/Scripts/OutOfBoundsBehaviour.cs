﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OutOfBoundsBehaviour : MonoBehaviour {
    protected GravityTarget gravityTarget;
    protected Canvas distanceReadout;

    //Constraints of screen
    protected float rightConstraint;
    protected float topConstraint;
    protected float leftConstraint;
    protected float bottomConstraint;

    // Use this for initialization
    void Start () {
        //Set constraints just outside of screen boundaries, base on object size
        this.leftConstraint = Camera.main.ScreenToWorldPoint(new Vector2(0.0f, 0.0f)).x;
        this.bottomConstraint = Camera.main.ScreenToWorldPoint(new Vector2(0.0f, 0.0f)).y;
        this.rightConstraint = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0.0f)).x;
        this.topConstraint = Camera.main.ScreenToWorldPoint(new Vector2(0.0f, Screen.height)).y;
    }

    void Awake()
    {
        //Find our only GravityTarget object (THERE CAN ONLY BE ONE!)
        this.gravityTarget = GameObject.FindGameObjectWithTag("GravityTarget").gameObject.GetComponent<GravityTarget>();
    }
	
	// Update is called once per frame
    void Update()
    {
        this.TrackGravityTargetOutOfBounds();
        this.UpdateDistanceReadout();
    }

    protected void TrackGravityTargetOutOfBounds()
    {
        SpriteRenderer sprender = this.GetComponent<SpriteRenderer>();

        //Hide/show sprite if gravityTarget is outside screen bounds
        sprender.enabled = this.gravityTarget.IsOutOfBounds();

        if (sprender.enabled)
        {
            //Move indicator
            this.transform.position = this.gravityTarget.transform.position;
            this.clampToScreenEdge();
            //this.scaleToGravityTargetDistance();

            //Rotate to match angle from center of screen to indicator position
            Vector3 direction = transform.position;

            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }

    protected void clampToScreenEdge()
    {
        float curX = this.transform.position.x;
        float curY = this.transform.position.y;
        float newX = curX;
        float newY = curY;

        if (curX < leftConstraint)   // object is past world-space view / off screen
            newX = leftConstraint;  // move object to opposite side
        else if (curX > rightConstraint)
            newX = rightConstraint;

        if (curY > topConstraint)
            newY = topConstraint;
        else if (curY < bottomConstraint)
            newY = bottomConstraint;

        //Set new position
        this.transform.position = new Vector2(newX, newY);
    }

    protected void scaleToGravityTargetDistance()
    {
        //MAGIC NUMBERS! - FIT THESE TO TASTE
        float minimumScale = 0.02f;
        float maximumScale = 0.05f;
        float maxDistanceScale = 2; //This distance is where the arrow is at it's maximum scale

        //Scale indicator size based on distance between it and the Gravity Target
        float distance = Vector2.Distance(this.transform.position, this.gravityTarget.transform.position);
        float scale = distance == 0 ? 0 : minimumScale + ((maximumScale - minimumScale) * maxDistanceScale/distance);

        //Clamp our scale
        if (scale < minimumScale)
            scale = minimumScale;
        else if (scale > maximumScale)
            scale = maximumScale;

        //Apply scale
        this.transform.localScale = new Vector3(scale, scale, scale);
    }

    protected void UpdateDistanceReadout()
    {
        //Change the text
        //Text distanceText = this.distanceReadout.GetComponent<Text>();
        //distanceText.text = Vector2.Distance(this.gravityTarget.transform.position, Vector2.zero).ToString("#.00");
        //Debug.Log("distance: " + distanceText.text);

        //Make it follow the indicator
        //this.distanceReadout.transform.localPosition = this.transform.position;
    }
}
