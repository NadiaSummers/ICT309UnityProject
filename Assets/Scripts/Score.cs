using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour {

	int startScore = 0;
	int currentScore;
	int friendCount = 0;
	int totalFriends;

	// Use this for initialization
	void Start () {
		currentScore = startScore;
		GameObject[] friends = GameObject.FindGameObjectsWithTag ("Friend");
		totalFriends = friends.Length;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void addScore(int points)
	{
		currentScore += points;
		}

	public void addFriend()
	{
		friendCount ++;
	}

	public string displayFriends()
	{
		return friendCount + "/" + totalFriends;
	}

	override public string ToString()
	{
		return " " + currentScore;
	}
}
