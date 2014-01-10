using UnityEngine;
using System.Collections;

public class DroneController : MonoBehaviour {

	void Start () {
		
	}

	void Update () {
		//	@TODO: Add rotation to drone, depending on direction  
        if (Input.GetKey("w"))
        { 
			// move forward
			this.rigidbody.AddForce(Vector3.forward * 10); 
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
