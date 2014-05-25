using UnityEngine;
using System.Collections;

public class MusicPlayer : MonoBehaviour {

	public AudioClip music;
	private float currentMusicTime;

	// Use this for initialization
	void Start () {
		DontDestroyOnLoad(this.gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		currentMusicTime = audio.time;
	}

	void Awake ()
	{
		GameObject go = GameObject.Find ("Game Music");
		if (go.audio.clip != music) {
			go.audio.clip = music; //Replaces the old audio with the new one
			go.audio.Play ();
		}

	}

	void OnLevelWasLoaded(int level)
	{
		audio.time = currentMusicTime;
	}
}
