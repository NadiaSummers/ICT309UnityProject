using UnityEngine;
using System.Collections;

public class Cage : MonoBehaviour {

	Transform player;

	// Use this for initialization
	void Start () {
		GameObject playerGameObject = GameObject.FindGameObjectWithTag ("Player");
		player = playerGameObject.transform;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	//when player rescues friend!
	void OnTriggerStay(Collider other) {
		if (other.tag == "Player") {
						if (Input.GetButtonDown ("Use")) {
								player.SendMessage ("IsNearCage", false);
								Score playerScore = player.GetComponent<Score> ();
								playerScore.addFriend ();
								this.gameObject.AddComponent ("Shrink");
								///add explosion and noise here!
								Destroy (this.gameObject, 0.26f);
						}
				}
		}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player") {
			//sends message to the GameGUI class. (attached to player)
			player.SendMessage("IsNearCage", true);
		}
	}

	void OnTriggerExit(Collider other)
	{
		if (other.tag == "Player") {
			player.SendMessage("IsNearCage", false);
		}
	}
	
}
