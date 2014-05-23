using UnityEngine;
using System.Collections;

public class CoinPickup : MonoBehaviour {

	Transform player;
	public int coinValue = 1;

	// Use this for initialization
	void Start () {
		GameObject playerGameObject = GameObject.FindGameObjectWithTag ("Player");
		player = playerGameObject.transform;
	}
	
	// Update is called once per frame
	void Update () {

		//TODO
		//check for collision w/ player
			//add to score
			//remove object from world
	}

	void OnTriggerEnter(Collider other)
	{
		if(other.tag == "Player")
		{
			Score playerScore = player.GetComponent<Score> ();
			playerScore.addScore (coinValue);
			Destroy(gameObject);
		}
	}
}
