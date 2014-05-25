using UnityEngine;
using System.Collections;

public class GameGUI : MonoBehaviour {

	Health playerHealth;
	Score playerScore;
	bool isNearCage = false;
	bool isFadeTime = false;
	public string toOpenCage = "Press 'E' to free your friend!";

	int fadeSteps = 1;
	public Texture2D fadeTexture;
	private Color guiColor = Color.white;

	// Use this for initialization
	void Start () {
		GameObject playerGameObject = GameObject.FindGameObjectWithTag ("Player");
		playerHealth = playerGameObject.GetComponent<Health> ();
		playerScore = playerGameObject.GetComponent<Score> ();

		guiTexture.pixelInset = new Rect(0f, 0f, Screen.width, Screen.height);

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	//set from Cage.cs on it's triggerentry/exit
	void IsNearCage(bool isNear)
	{
		isNearCage = isNear;
	}

	void IsFadeTime(bool isFade)
	{
		isFadeTime = isFade;
		fadeSteps = 1;
	}




	void OnGUI()
	{
		if (isFadeTime) {
			doFade();

				}
		/*
						if (playerHealth.IsDead) {
								GUI.DrawTexture (new Rect ((Screen.width - gameOverImage.width) / 2, (Screen.height - gameOverImage.height) / 2, gameOverImage.width, gameOverImage.height), gameOverImage);
						}*/
						if (isNearCage) {
								GUI.Label (new Rect (Screen.width / 2 - 90, Screen.height / 2 + 70, 200, 20), " " + toOpenCage);
						}

						GUI.Label (new Rect (5, 5, 100, 100), "Health: " + playerHealth);
						GUI.Label (new Rect (5, 20, 100, 100), "Score: " + playerScore);
						GUI.Label (new Rect (5, 35, 100, 100), "Friends: " + playerScore.displayFriends ());
				
	}

	//not working :(
	void doFade()
	{
				if (fadeSteps < 240) {
						//guiColor.a = 1 / fadeSteps;
						//GUI.color = guiColor;
						GUI.DrawTexture (new Rect(0, 0, Screen.width, Screen.height), fadeTexture);
						//GUI.color = Color.white;
						//guiColor.a = 1;
					fadeSteps++;
				}
				else {
						fadeSteps = 1;
						isFadeTime = false;
				}


	}
}
