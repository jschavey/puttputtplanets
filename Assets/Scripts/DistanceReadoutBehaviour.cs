using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DistanceReadoutBehaviour : MonoBehaviour {
    public GameObject gravityTarget;
    public GameObject outOfBoundsIndicator;

	// Use this for initialization
	void Start () {
        //this.transform.localScale = new Vector2(2f, 2f);
    }

    // Update is called once per frame
    void Update()
    {
        //Distance from center of screen
        float distance = Vector2.Distance(this.gravityTarget.transform.position, Vector2.zero);

        //Convert distance to artificial kilometers
        this.GetComponent<Text>().text = (distance * 100).ToString("#") + "km";

        //Follow the out of bounds indicator
        this.transform.position = this.outOfBoundsIndicator.transform.position;

        Debug.Log(this.transform.position);
    }
}
