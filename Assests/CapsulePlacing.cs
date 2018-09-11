using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Oculus;
public class CapsulePlacing : MonoBehaviour {
	public GameObject capsulePrefab;
	private bool wasButtonPressed = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		bool buttonDown = OVRInput.Get(OVRInput.Button.One,  OVRInput.Controller.RTouch);
		Debug.Log(buttonDown);
		if (buttonDown)
		{
			if(!wasButtonPressed)
			{
				wasButtonPressed = true;
				GameObject newCapsule = (GameObject)Instantiate(capsulePrefab);
				newCapsule.transform.position = transform.position;
			}
		} else {
			wasButtonPressed = false;
		}
	}
}
