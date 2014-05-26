using UnityEngine;
using System.Collections;

public class MainMenuScript : MonoBehaviour {

	public Texture2D newGameButton;
	public Texture2D quitGameButton;
	public GUISkin guiSkin;

	// Use this for initialization
	void Start () {
		Screen.lockCursor = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI()
	{
		Screen.lockCursor = false;
		GUI.skin = guiSkin;
		if (GUI.Button (new Rect (20, Screen.height - 200, 200, 61), newGameButton)) {
			Application.LoadLevel ("LevelOne");
		}

		if (GUI.Button (new Rect (20, Screen.height - 100, 200, 61), quitGameButton)) {
			Application.Quit ();
				}
	}
}
