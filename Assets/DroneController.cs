using UnityEngine;
using System.Collections;

public class DroneController : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	int speed = 5;

	void Update () {
		if(Input.GetKey("w")) {
			transform.Translate(Vector3.forward * Time.deltaTime * speed);
		}
		if(Input.GetKey("s")) {
			transform.Translate(Vector3.back * Time.deltaTime * speed);
		}
		if(Input.GetKey("a")) {
			transform.Translate(Vector3.left * Time.deltaTime * speed);
		}
		if(Input.GetKey("d")) {
			transform.Translate(Vector3.right * Time.deltaTime * speed);
		}
	}
}
