using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DistanceReadoutBehaviour : MonoBehaviour {
    public GameObject gravityTarget;

	// Use this for initialization
	void Start () {
        //this.transform.localScale = new Vector2(2f, 2f);
    }
	
	// Update is called once per frame
	void Update () {
        float distance = Vector2.Distance(this.gravityTarget.transform.position, Vector2.zero);

        //Convert distance to artificial kilometers
        this.GetComponent<Text>().text = (distance * 100).ToString("#") + "km";
        this.transform.position = this.gravityTarget.transform.position; //camera.WorldToScreenPoint(this.gravityTarget.transform.position);
	}
}
