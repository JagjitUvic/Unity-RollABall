using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityOSC;

public class TestOsc : MonoBehaviour {

	public string inName = "OSC Receiver";
	public int port = 10500;

	private SimpleOSCReceiver oscIn;
	private SimpleOSCSender oscOut;

	// Use this for initialization
	void Start () {

		// Test Creating and registering an OSC Server
		oscIn = new SimpleOSCReceiver(inName, port);							// Create a new OSC Receiver
		oscIn.OnMessageReceived ("/vrmin/vol", TestCallback);					// Register an address to a specfied callback function
		StartCoroutine (oscIn.GetEnumerator());									// Start the OSC Receiver thread (kind of a hack for now...)


		// Test sending a message (Must have an OSC Server Open Somewhere...)
		oscOut = new SimpleOSCSender("OSC Sender", "127.0.0.1", 10101);			// Create a new Sender
		List<object> values = new List<object> ();								// Create a populate a list of values to send in an OSC Message
		values.AddRange (new object[]{ 1.5f, 3.0f });
		oscOut.SendMessage ("/test/1", values);									// Send the message
	}

	public void TestCallback(OSCMessage message){
		// Callback function with example Code for parsing the OSC Message


		UnityEngine.Debug.Log ("Function Running\nOSC Address is:  " + message.Address);

	}
}
