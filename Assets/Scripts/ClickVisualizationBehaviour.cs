using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickVisualizationBehaviour : MonoBehaviour {
    protected SpriteRenderer srend;
    protected int ticksShown;
    protected bool grow = false;
    protected Renderer rend;
    protected float oldRadius = 0;

    public float adjustedScale { get; set; }

    public ClickVisualizationBehaviour setAdjustedScale(float radius)
    {
        this.transform.localScale = Vector2.one;

        //Treat this object as round
        if (this.oldRadius == 0)
            this.oldRadius = Mathf.Ceil((this.rend.bounds.extents.x + this.rend.bounds.extents.y) / 2);

        float scale = this.oldRadius != 0 ? radius / this.oldRadius : 0;

        Debug.Log("scale:" + scale + " oldRadius:" + this.oldRadius + " radius: " + radius);
        
        //this.transform.localScale = new Vector2(radius, radius);
        this.adjustedScale = scale;

        return this;
    }

    const int ticksToMaxSize = 30; //60 ticks pre frame

    // Use this for initialization
    void Start() {
        this.srend = this.GetComponent<SpriteRenderer>();

        //Hide on construction
        //this.srend.enabled = false;
    }

    void Awake()
    {
        if (this.rend == null)
            this.rend = this.GetComponent<Renderer>();
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

            float scale = (this.adjustedScale + 0.5f) * (Mathf.Abs(Mathf.Sin(this.ticksShown * (2f * 3.14159f) / ticksToMaxSize)) + 0.15f);

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
