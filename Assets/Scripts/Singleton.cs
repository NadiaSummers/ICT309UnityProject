using UnityEngine;
using System.Collections;

public class Singleton : MonoBehaviour {

	private static Singleton instance;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	public static Singleton GetInstance(){
		return instance;
	}
	
	void Awake() {
		if (instance != null && instance != this) {
			Destroy(this.gameObject);
			return;
		} else {
			instance = this;
		}
		DontDestroyOnLoad(this.gameObject);
	}
}
