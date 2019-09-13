using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
	private Camera camMain;
	private Rigidbody rigidBody;
	public float Speed = 1;
	public float JumpSpeed = 1;
	private const float onGroundHeight = 1.5f;
	private Ray groundCheckRay;
	private RaycastHit groundCheckRayHit;

	// Use this for initialization
	void Start () {
		camMain = Camera.main;
		rigidBody = GetComponent<Rigidbody> ();
		groundCheckRay = new Ray (transform.position, Vector3.down);
	}
	
	// Update is called once per frame
	void Update () {
		// Get Movement Input
		float xSpeed = Input.GetAxis ("Horizontal");
		float zSpeed = Input.GetAxis ("Vertical");

		// Calculate Left/Right Direction
		Vector3 horizontalAxis = camMain.transform.right;
		horizontalAxis.Scale (new Vector3 (1, 0, 1));
		horizontalAxis.Normalize ();

		// Calculate Up/Down Direction
		Vector3 verticalAxis = Vector3.Cross (horizontalAxis, Vector3.up).normalized;

		// Apply Movement
		Vector3 force = (horizontalAxis * xSpeed + verticalAxis * zSpeed).normalized * Speed;
		rigidBody.AddForce (force);

		// Apply Jump
		if (Input.GetButtonDown ("Jump")) {
			groundCheckRay.origin = transform.position;
			if (Physics.Raycast(groundCheckRay, out groundCheckRayHit) && groundCheckRayHit.distance < onGroundHeight)
				rigidBody.AddForce (Vector3.up * JumpSpeed);
		}
	}
}
