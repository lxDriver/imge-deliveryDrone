using UnityEngine;
using System.Collections;
using System.IO.Ports;
using System;

public class InputController : MonoBehaviour {
	SerialPort stream = new SerialPort("COM3", 115200);
	string receivedData = "";
	
	public GameObject player1;
	public GameObject player2;
	
	
	float prevNormRV3;
	float prevNormRV4;
	
	float normRV3;
	float normRV4;
	
	int bla ;
	// Use this for initialization
	public void Start () {
		stream.Open(); // Open the serial stream
		Debug.Log("Serial Port opened.");
	}
	
	// Update is called once per frame
	public void Update () {
		stream.Write ("4");
		receivedData = stream.ReadLine();
		
		string[] dataArray = receivedData.Split(' ');
		
		int RV1 = System.Convert.ToInt32(dataArray[1],16);
		int RV2 = System.Convert.ToInt32(dataArray[2],16);
		int RV3 = System.Convert.ToInt32(dataArray[3],16);
		int RV4 = System.Convert.ToInt32(dataArray[4],16);
		
		float normRV1 = ((float)(RV1) / 4095.0f);
		float normRV2 = ((float)(RV2) / 4095.0f);
		
		prevNormRV3 = normRV3;
		prevNormRV4 = normRV4;
		
		normRV3 = ((float)(RV3) / 2047.0f) - 1.0f;
		normRV4 = ((float)(RV4) / 2047.0f) - 1.0f;
		
		float newPosYRV3 = normRV3 * 100; 
		float newPosYRV4 = normRV4 * 100;
		
		Debug.Log("RV 3: " + newPosYRV3 + " RV4: " + newPosYRV4);
		
		player1.SendMessage("setPosY",newPosYRV4);
		player2.SendMessage("setPosY",newPosYRV3);
	}
	
	void OnGUI () {
		//GUI.Box(new Rect(300,10,300,90), receivedData);
	}
	
	public void GetSliderState() {
		Debug.Log(receivedData);
	}
	
}
