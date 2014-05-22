using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{

		Transform player;
		CharacterController controller;
		public float moveSpeed = 10.0f;
		public float gravity = 0.7f;
		private float yVelocity = 0.0f;

		public float sightRange = 30.0f;
		public float attackRange = 5.0f;
		public int attackDamage = 20;

		public float attackSpeed = 1.15f; //matches animation
		private float attackDelay = -1.0f;
		private bool targetInRange = false;

		Animation animation;

		// Use this for initialization
		void Start ()
		{
	
				GameObject playerGameObject = GameObject.FindGameObjectWithTag ("Player");
				player = playerGameObject.transform;

				controller = GetComponent<CharacterController> ();

				animation = GetComponentInChildren<Animation> ();
				animation ["Run"].wrapMode = WrapMode.Loop;
				animation ["Idle_01"].wrapMode = WrapMode.Loop;
				animation ["Attack_01"].wrapMode = WrapMode.Once;
				animation.Play ("Idle_01");
				animation ["Idle_01"].normalizedTime = Random.value; //randomize starting anim position, dont all walk in step.
		}
	
		// Update is called once per frame
		void Update ()
		{
	
				float distance = Vector3.Distance (player.position, transform.position);

				Vector3 direction = player.position - transform.position;
				direction.Normalize ();
		
				Vector3 velocity = direction * moveSpeed;
		
				if (!controller.isGrounded) {
						yVelocity -= gravity;
				}
		
				velocity.y = yVelocity;
		
				direction.y = 0;

				if (distance >= sightRange) {
						animation.Play ("Idle_01");
						targetInRange = false;
				}
				else {
						if (distance <= attackRange)
							targetInRange = true;
						else
							targetInRange = false;

						//gogo combat
						if (!targetInRange)
						{
								transform.rotation = Quaternion.LookRotation (direction);
								controller.Move (velocity * Time.deltaTime);
								animation.Play ("Run");
						} 
						else
			         	{
								if (Time.time >= attackDelay)
								{
									animation.Play ("Attack_01");
									animation.PlayQueued ("Idle_01", QueueMode.CompleteOthers);
									Health playerHealth = player.GetComponent<Health> ();
									playerHealth.Damage (attackDamage);
									attackDelay = Time.time + attackSpeed;
								}
						}

					}
	}}
		

