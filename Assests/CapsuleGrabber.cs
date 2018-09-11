using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Oculus;

public class CapsuleGrabber : MonoBehaviour {
	private bool isHoldingObject = false;
	private GameObject holdTarget = null;
	private Vector3 holdOffsetPos = new Vector3(0f,0f,0f);
	private Quaternion holdOffsetRot = new Quaternion();
	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag == "Capsule" && !isHoldingObject)
		{
			holdTarget= other.gameObject;
		}

	}

	void OnTriggerExit(Collider other)
	{
		if(holdTarget != null && other.gameObject.GetInstanceID() == holdTarget.GetInstanceID() && !isHoldingObject)
		{
			holdTarget= null;
		}
	}
	// Update is called once per frame
	void Update () {
		float gripValue = OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger,OVRInput.Controller.RTouch);

		if(gripValue > 0.5f)
		{
			if(!isHoldingObject && holdTarget != null)
			{
				isHoldingObject = true;
				holdOffsetPos = holdTarget.transform.position - transform.position;
				holdOffsetRot = Quaternion.Inverse(transform.rotation) * holdTarget.transform.rotation;
				Rigidbody rb = holdTarget.GetComponent<Rigidbody>();
				rb.isKinematic = true;
				rb.velocity = new Vector3(0f,0f,0f);
				rb.angularVelocity = new Vector3(0f,0f,0f); 
			}
		} else
		{
			if(isHoldingObject)
			{
				Rigidbody rb = holdTarget.GetComponent<Rigidbody>();
				rb.isKinematic = false;
				isHoldingObject = false;
			}
		}

		if (isHoldingObject)
		{
			holdTarget.transform.position = transform.position + transform.rotation * holdOffsetPos;
			holdTarget.transform.rotation = transform.rotation * holdOffsetRot;
		}
		
	}
}
