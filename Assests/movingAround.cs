using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Oculus;
public class movingAround : MonoBehaviour {
	public GameObject player;
	public float speed = 10;
	public Rigidbody rb;
	// Use this for initialization
	void Start () {
		rb = player.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		Vector2 moving = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick, OVRInput.Controller.LTouch);
		Debug.Log(moving);

		rb.AddForce(moving *speed);
	}
}
