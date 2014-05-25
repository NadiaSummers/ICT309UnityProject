using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{

		Transform player;
		CharacterController controller;
		Vector3 initialPosition;

		public float moveSpeed = 10.0f;
		public float gravity = 0.7f;
		private float yVelocity = 0.0f;

		public float sightRange = 80.0f;
		public float attackRange = 5.0f;
		public int attackDamage = 20;

		public float attackSpeed = 1.15f; //matches animation
		private float attackDelay = -1.0f;
		private bool targetInRange = false;

		private new Animation animation;

		private Vector3 velocity;
		private Vector3 direction;

		// Use this for initialization
		void Start ()
		{
	
				GameObject playerGameObject = GameObject.FindGameObjectWithTag ("Player");
				player = playerGameObject.transform;

				controller = GetComponent<CharacterController> ();
				initialPosition = transform.position;

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
				float homeDistance = Vector3.Distance (initialPosition, transform.position);
				float homeToPlayerDistance = Vector3.Distance (initialPosition, player.position);


				//if we're at our spawn
				if (homeToPlayerDistance > sightRange && homeDistance <= 2) {
						animation.Play ("Idle_01");
						targetInRange = false;
						doGravity();
						//Debug.Log("Troll At Home");
				}
				//if we should stop chasing and return home (because we're too far from home)
				else if (homeToPlayerDistance > sightRange)
				{
						targetInRange = false;
						direction = initialPosition - transform.position;
						direction.Normalize ();
						velocity = direction * moveSpeed;
						doGravity();
						transform.rotation = Quaternion.LookRotation (direction);
						controller.Move (velocity * Time.deltaTime);
						animation.Play ("Run");
						//Debug.Log("Troll Going Home :(");

				}
				else if (homeToPlayerDistance < sightRange)
				{
					if (distance <= attackRange)
						targetInRange = true;
					else
						targetInRange = false;
						
						//gogo combat
						if (!targetInRange)
						{
								direction = player.position - transform.position;
								direction.Normalize ();
								transform.rotation = Quaternion.LookRotation (direction);
								if (!animation.IsPlaying ("Attack_01"))
								{
									velocity = direction * moveSpeed;
									doGravity();
									transform.rotation = Quaternion.LookRotation (direction);
									controller.Move (velocity * Time.deltaTime);
									animation.Play ("Run");
									//Debug.Log("Troll Chasing!");
								}
						} 
						else
			         	{
								if (Time.time >= attackDelay)
								{
									animation.Play ("Attack_01");
									animation.PlayQueued ("Run", QueueMode.CompleteOthers);
									Health playerHealth = player.GetComponent<Health> ();
									playerHealth.Damage (attackDamage);
									attackDelay = Time.time + attackSpeed;
									//Debug.Log("Troll Smash!");
									
								}
						}
					}
					}

	
	private void doGravity()
	{
					if (!controller.isGrounded) {
						yVelocity -= gravity;
				}
		
				velocity.y = yVelocity;
		
				direction.y = 0;
	}
	}
		

