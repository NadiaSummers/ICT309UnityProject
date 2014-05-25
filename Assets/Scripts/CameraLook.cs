using UnityEngine;
using System.Collections;

public class CameraLook : MonoBehaviour {

	private float mouseX = 0.0f;
	public float mouseSensitivity = 5.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.timeScale == 0) {
			//we're paused, so don't update the camera.
		}
		else {
			mouseX = Input.GetAxis ("Mouse X");

			Vector3 rotation = transform.localEulerAngles;
			rotation.y += mouseX * mouseSensitivity;
			transform.localEulerAngles = rotation;
		}
	}
}
