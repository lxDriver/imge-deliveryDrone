using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO.Ports;
using System;

public class InputController : MonoBehaviour {
	
	public enum LEDActions {
		turnOff,
        turnOn,
        toggle,
    }

	
	SerialPort stream = new SerialPort("COM3", 115200);
	
	// received data strings
	string receivedSliderData = "";
	string receivedButtonData = "";
	string receivedAccelerationData = "";
	
	// Buttons
	public enum buttonState {
		nothing,
		buttonDown,
        buttonPressed,
    }
	public enum buttons {
		SW1,
		SW2,
		SW3,
		SW4,
		SW5,
		SW6,
	}

	Dictionary<buttons,int> buttonMasks = new Dictionary<buttons,int>();
	// Use this for initialization
	public void Start () {
		stream.Open(); // Open the serial stream
		Debug.Log("Serial Port opened.");
		
		// fill Button Mask List
		/*
		 * 020
		 * 
		 * 060 -> 040
		 * 0A0 -> 080
		 * 120 -> 100
		 * 220 -> 200
		 * 420 -> 400
		 * 820 -> 800
		 */
		buttonMasks.Add(buttons.SW1,0x040);
		buttonMasks.Add(buttons.SW2,0x080);
		buttonMasks.Add(buttons.SW3,0x100);
		buttonMasks.Add(buttons.SW4,0x200);
		buttonMasks.Add(buttons.SW5,0x400);
		buttonMasks.Add(buttons.SW6,0x800);
	}
	
	// Update is called once per frame
	public void Update () {
		//  receive slider data
		stream.Write ("4");
		receivedSliderData = stream.ReadLine();	
		
		stream.Write ("1");
		receivedButtonData = stream.ReadLine();
		
		stream.Write ("a");
		receivedAccelerationData = stream.ReadLine();
	}
	
	void OnGUI () {
		//GUI.Box(new Rect(300,10,300,90), receivedData);
	}
	
	public float GetSliderState(string slider) {
		string[] dataArray = receivedSliderData.Split(' ');
		
		// integer values
		int RV1 = System.Convert.ToInt32(dataArray[1],16);
		int RV2 = System.Convert.ToInt32(dataArray[2],16);
		int RV3 = System.Convert.ToInt32(dataArray[3],16);
		int RV4 = System.Convert.ToInt32(dataArray[4],16);
		
		// normalized floats -1.0 to 1.0
		float normRV1 = ((float)(RV1) / 4095.0f);
		float normRV2 = ((float)(RV2) / 4095.0f);
		
		// normalized floats 0.0 to 1.0
		float normRV3 = ((float)(RV3) / 2047.0f) - 1.0f;
		float normRV4 = ((float)(RV4) / 2047.0f) - 1.0f;
		
		switch(slider) {
			case "RV1":
				return normRV1;
			case "RV2":
				return normRV2;
			case "RV3":
				return normRV3;
			case "RV4":
				return normRV4;
		}
		return 0;
	}
	
	public void SetLED(int led, LEDActions action) {
		
		/* LEDs - l 0-3 0-2\n\r
		 * 0: turn off
		 * 1: turn on
		 * 2: toggle
		 * 
		 * LED 0-3
		 */
		
		String stringToWrite = "l " + led + " ";
		switch(action) {
			case LEDActions.turnOff:
				stringToWrite += "0";
				break;
			case LEDActions.turnOn:
				stringToWrite += "1";
				break;
			case LEDActions.toggle:
				stringToWrite += "2";
				break;
		}
		stringToWrite += "\r\n";
		stream.Write (stringToWrite);
		string output = stream.ReadLine();
	}
	
	public buttonState GetButtonDown(buttons button) {
		buttonState state = buttonState.nothing;
		
		int buttonVal = System.Convert.ToInt32(receivedButtonData,16);
		
		Debug.Log(receivedButtonData);
		
		switch(button) {
			case buttons.SW1:
				if((buttonVal & buttonMasks[buttons.SW1]) != 0) {
					state = buttonState.buttonDown;
					Debug.Log ("Button SW1 pressed");
				}
				break;
			case buttons.SW2:
				if((buttonVal & buttonMasks[buttons.SW2]) != 0) {
					state = buttonState.buttonDown;
					Debug.Log ("Button SW2 pressed");
				}
				break;
			case buttons.SW3:
				if((buttonVal & buttonMasks[buttons.SW3]) != 0) {
					state = buttonState.buttonDown;
					Debug.Log ("Button SW3 pressed");
				}
				break;
			case buttons.SW4:
				if((buttonVal & buttonMasks[buttons.SW4]) != 0) {
					state = buttonState.buttonDown;
					Debug.Log ("Button SW4 pressed");
				}
				break;
			case buttons.SW5:
				if((buttonVal & buttonMasks[buttons.SW5]) != 0) {
					state = buttonState.buttonDown;
					Debug.Log ("Button SW5 pressed");
				}
				break;
			case buttons.SW6:
				if((buttonVal & buttonMasks[buttons.SW6]) != 0) {
					state = buttonState.buttonDown;
					Debug.Log ("Button SW6 pressed");
				}
				break;
		}
		
		return state;
	}
	
	public Vector3 GetAcceleration() {
		
	}
}
