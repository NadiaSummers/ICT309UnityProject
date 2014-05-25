using UnityEngine;
using System.Collections;

public class PauseMenu : MonoBehaviour {

	public Texture2D resumeGameButton;
	public Texture2D quitGameButton;
	public GUISkin guiSkin;
	private bool isPaused = false;
	
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("escape")) {
			isPaused = true;
			Screen.lockCursor = false;
		}
	}
	
	void OnGUI()
	{
		if (isPaused) {
			Time.timeScale = 0;
						GUI.skin = guiSkin;
						if (GUI.Button (new Rect (20, Screen.height - 200, 200, 61), resumeGameButton)) {
							isPaused = false;
							Time.timeScale = 1;
							Screen.lockCursor = true;
						}
		
						if (GUI.Button (new Rect (20, Screen.height - 100, 200, 61), quitGameButton)) {
							//Application.LoadLevel (0);
							Application.Quit ();
						}
		}
	}
}