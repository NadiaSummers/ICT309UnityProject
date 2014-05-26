using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	CharacterController controller;
	GameObject playerGameObject;
	Vector3 spawnPoint;
	Health myHealth;

	public float moveSpeed = 18.0f;
	public float jumpSpeed = 20.0f;
	public float gravity = 0.7f;
	private float yVelocity = 0.0f;
	private float speedTimer = 3.0f;


	// Use this for initialization
	void Start () {
		controller = GetComponent<CharacterController> ();
		Screen.lockCursor = true;
		playerGameObject = GameObject.FindGameObjectWithTag ("Player");
		spawnPoint = playerGameObject.transform.position;
		myHealth = playerGameObject.GetComponent<Health> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (myHealth.IsDead)
				DoRespawn ();
	
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

	public void SetSpawn(Vector3 position)
	{
		spawnPoint = position;
	}

	public void DoRespawn()
	{
		playerGameObject.SendMessage ("IsFadeTime", true);
		playerGameObject.transform.position = spawnPoint;
		myHealth.Reset ();
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "SpeedBoost") 
		{
			moveSpeed = moveSpeed * 2;
			jumpSpeed = jumpSpeed * 2;
			Invoke ("ResetSpeed", speedTimer);
		} 
		else if (other.gameObject.tag == "HealthBoost") 
		{
			if(myHealth.GetHealth() < 100)
			{
				myHealth.SetHealth(myHealth.GetHealth() + 20);
				other.gameObject.SetActive(false);
			}
		}

	}

	public void ResetSpeed()
	{
		moveSpeed = 18.0f;
		jumpSpeed = 20.0f;
	}
}
