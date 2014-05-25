using UnityEngine;
using System.Collections;

public class MainMenuScript : MonoBehaviour {

	public Texture2D newGameButton;
	public Texture2D quitGameButton;
	public GUISkin guiSkin;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI()
	{
		GUI.skin = guiSkin;
		if (GUI.Button (new Rect (20, Screen.height - 200, 200, 61), newGameButton)) {
			Application.LoadLevel ("LevelOne");
		}

		if (GUI.Button (new Rect (20, Screen.height - 100, 200, 61), quitGameButton)) {
			Application.Quit ();
				}
	}
}
