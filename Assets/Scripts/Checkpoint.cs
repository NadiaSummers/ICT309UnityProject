using UnityEngine;
using System.Collections;

public class Checkpoint : MonoBehaviour {

	
	GameObject player;
	PlayerMovement pMove;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		pMove = player.GetComponent<PlayerMovement> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	//update player's spawn point to here
	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player") {
			pMove.SetSpawn(transform.position);
			Debug.Log ("Spawn set!");
		}
	}
}
