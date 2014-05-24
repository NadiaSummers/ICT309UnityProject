using UnityEngine;
using System.Collections;

public class GameGUI : MonoBehaviour {

	Health playerHealth;
	public Texture2D gameOverImage;
	Score playerScore;
	bool isNearCage = false;
	public string toOpenCage = "Press 'E' to free your friend!";

	// Use this for initialization
	void Start () {
		GameObject playerGameObject = GameObject.FindGameObjectWithTag ("Player");
		playerHealth = playerGameObject.GetComponent<Health> ();
		playerScore = playerGameObject.GetComponent<Score> ();

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	//set from Cage.cs on it's triggerentry/exit
	void IsNearCage(bool isNear)
	{
		isNearCage = isNear;
	}




	void OnGUI()
	{
		if (playerHealth.IsDead) {
			GUI.DrawTexture(new Rect((Screen.width - gameOverImage.width) / 2, (Screen.height - gameOverImage.height) / 2, gameOverImage.width, gameOverImage.height), gameOverImage);
		}
		if (isNearCage) {
			GUI.Label (new Rect (Screen.width / 2 - 90, Screen.height / 2 + 70, 200, 20), " " + toOpenCage);
		}

		GUI.Label(new Rect(5, 5, 100, 100), "Health: " + playerHealth);
		GUI.Label(new Rect(5, 20, 100, 100), "Score: " + playerScore);
		GUI.Label (new Rect(5, 35, 100, 100), "Friends: " + playerScore.displayFriends());
	}
}
