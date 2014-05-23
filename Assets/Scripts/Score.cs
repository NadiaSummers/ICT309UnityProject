using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour {

	int startScore = 0;
	int currentScore;

	// Use this for initialization
	void Start () {
		currentScore = startScore;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void addScore(int points)
	{
		currentScore += points;
		}

	override public string ToString()
	{
		return " " + currentScore;
	}
}
