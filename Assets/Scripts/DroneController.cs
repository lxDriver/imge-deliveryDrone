using UnityEngine;
using System.Collections;

public class DroneController : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	float speedfwd = 0;
    float speedbwd = 0;
    float speedright = 0;
    float speedleft = 0;


	void Update () {
        if (Input.GetKey("w"))
        { this.rigidbody.AddForce(Vector3.forward * 10); }
        if (Input.GetKey("s"))
        { this.rigidbody.AddForce(Vector3.back * 10); }
        if (Input.GetKey("a"))
        { this.rigidbody.AddForce(Vector3.left * 10); }
        if (Input.GetKey("d"))
        { this.rigidbody.AddForce(Vector3.right * 10); }
		
	}
}
