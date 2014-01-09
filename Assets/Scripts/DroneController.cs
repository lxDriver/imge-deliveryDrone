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
      /*  if (Input.GetKey("w") && speedfwd <= 5)
        {
            speedfwd++;
        }
        else if (speedfwd > 0)
        { speedfwd=speedfwd - 0.1f; }
        //else
        //{ speedfwd = 0; }

        if (Input.GetKey("s") && speedbwd <= 5)
        {
            speedbwd++;
        }
        else if (speedbwd > 0)
        { speedbwd=speedbwd -0.1f; }
        //else
        //{ speedbwd = 0; }

        if (Input.GetKey("a") && speedleft <= 5)
        {
            speedleft++;
        }
        else if (speedleft > 0)
        { speedleft=speedleft - 0.1f; }
        //else
        //{ speedleft = 0; }

        if (Input.GetKey("d") && speedright <= 5)
        {
            speedright++;
        }
        else if (speedright > 0)
        { speedright= speedright - 0.1f; }
        //else
        //{ speedright = 0; }
		

        transform.Translate(Vector3.forward * Time.deltaTime * speedfwd);
        transform.Translate(Vector3.back * Time.deltaTime * speedbwd);
        transform.Translate(Vector3.left * Time.deltaTime * speedleft);
        transform.Translate(Vector3.right * Time.deltaTime * speedright);*/

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
