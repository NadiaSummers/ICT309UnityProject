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
	
	void OnTriggerStay(Collider other)
	{
		if(other.tag == "Player")
		{
			if(Input.GetKeyDown("e"))
			{
				Score playerScore = player.GetComponent<Score> ();
				playerScore.addFriend();
				Destroy(gameObject);
			}
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player") {
			//sends message to the GameGUI class. (attached to player)
			player.SendMessageUpwards("IsNearCage", true);
		}
	}

	void OnTriggerExit(Collider other)
	{
		if (other.tag == "Player") {
			player.SendMessage("IsNearCage", false);
		}
	}
	
}
