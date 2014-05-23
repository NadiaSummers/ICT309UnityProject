using UnityEngine;
using System.Collections;

public class GameGUI : MonoBehaviour {

	Health playerHealth;
	public Texture2D gameOverImage;
	Score playerScore;

	// Use this for initialization
	void Start () {
		GameObject playerGameObject = GameObject.FindGameObjectWithTag ("Player");
		playerHealth = playerGameObject.GetComponent<Health> ();
		playerScore = playerGameObject.GetComponent<Score> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}



	void OnGUI()
	{
		if (playerHealth.IsDead) {
			GUI.DrawTexture(new Rect((Screen.width - gameOverImage.width) / 2, (Screen.height - gameOverImage.height) / 2, gameOverImage.width, gameOverImage.height), gameOverImage);
				}
		GUI.Label(new Rect(5,5,100,100), "Health: " + playerHealth);
		GUI.Label(new Rect(5,20,100,100), "Score: " + playerScore);
		GUI.Label (new Rect(5, 35, 100, 100), "Friends: " + playerScore.displayFriends());
	}
}
