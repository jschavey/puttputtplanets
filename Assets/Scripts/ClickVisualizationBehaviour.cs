using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickVisualizationBehaviour : MonoBehaviour {
    protected SpriteRenderer srend;
    protected int ticksShown;
    protected bool grow = false;
    protected Renderer rend;

    public float maxRadius { get; }

    public ClickVisualizationBehaviour setMaxRadius(float radius)
    {
        /*
        if (this.rend == null)
            this.rend = this.GetComponent<Renderer>();

        //Treat this object as round
        float oldRadius = this.rend.bounds.extents.x;
        float scale = oldRadius != 0 ? radius / oldRadius : 0;

        Debug.Log("scale:" + scale);
        
        this.transform.localScale = new Vector2(scale, scale);
        */

        return this;
    }

    const int ticksToMaxSize = 30; //60 ticks to reach maximum size

    // Use this for initialization
    void Start() {
        this.srend = this.GetComponent<SpriteRenderer>();

        //Hide on construction
        //this.srend.enabled = false;
    }

    // Update is called once per frame
    void Update() {
        if (this.srend.enabled && ticksToMaxSize != 0)
        {           
            if (this.grow)
            {
                if (this.ticksShown >= ticksToMaxSize)
                    this.ticksShown = (int)(ticksToMaxSize / 2); //To keep some size along with oscillation at maximum size
            }
            else
            {
                if (this.ticksShown == 0 /*&& this.rend.enabled*/)
                {
                    //this.rend.enabled = false;                    
                }
                else if (this.ticksShown < 0)
                    this.ticksShown = 0;
            }

            float scale = Mathf.Sin(this.ticksShown * 2f * 3.14159f / ticksToMaxSize) + 0.33f;

            this.transform.localScale = new Vector2(scale * this.ticksShown / ticksToMaxSize, scale * this.ticksShown / ticksToMaxSize);
        }
    }

    void FixedUpdate()
    {
        if (this.grow)
            this.ticksShown++;
        else this.ticksShown--;
    }

    public void Grow()
    {
        this.grow = true;
        //this.srend.enabled = true;
        this.ticksShown = 0;
    }

    public void Shrink()
    {
        this.grow = false;
    }
}
