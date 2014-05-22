using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	CharacterController controller;

	public float moveSpeed = 18.0f;
	public float jumpSpeed = 20.0f;
	public float gravity = 0.7f;
	private float yVelocity = 0.0f;


	// Use this for initialization
	void Start () {
		controller = GetComponent<CharacterController> ();
		Screen.lockCursor = true;
	}
	
	// Update is called once per frame
	void Update () {
	
		Vector3 direction = new Vector3 (Input.GetAxis ("Horizontal"), 0, Input.GetAxis ("Vertical"));
		Vector3 velocity = direction * moveSpeed;



		if (controller.isGrounded) {
			if (Input.GetButtonDown ("Jump")) {
				yVelocity = jumpSpeed;
			}
		}
		else {
			yVelocity -= gravity;
		}


		velocity.y = yVelocity;


		velocity = transform.TransformDirection (velocity);
		controller.Move (velocity * Time.deltaTime);
	}

}
