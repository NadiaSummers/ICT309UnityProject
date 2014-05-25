using UnityEngine;
using System.Collections;

public class BossDeath : MonoBehaviour {

	public string nextLevel;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}


	//special event script attached to a boss monster
	void OnDestroy()
	{
		Application.LoadLevel (nextLevel);
	}
}
