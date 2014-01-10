using UnityEngine;
using System.Collections;

public class DroneController : MonoBehaviour {

	void Start () {
		
	}

	void Update () {
		//	@TODO: Add rotation to drone, depending on direction  
		Vector3 direction = this.rigidbody.transform.position - transform.position;
        if (Input.GetKey("w"))
        { 
			// move forward
			this.rigidbody.AddForce(Vector3.forward * 10); 
			//this.transform.RotateAround(this.transform.position, Vector3.up, 1);
		}
        if (Input.GetKey("s"))
        { 	
			// move back
			this.rigidbody.AddForce(Vector3.back * 10); 
		}
        if (Input.GetKey("a"))
        { 
			// move left
			this.rigidbody.AddForce(Vector3.left * 10); 
		}
        if (Input.GetKey("d"))
        { 	
			// move right
			this.rigidbody.AddForce(Vector3.right * 10); 
		}
		
	}
}
