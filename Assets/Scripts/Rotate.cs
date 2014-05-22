using UnityEngine;
using System.Collections;

public class Rotate : MonoBehaviour {

	public int rotateSpeed = 100;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (new Vector3(0, 0, rotateSpeed) * Time.deltaTime);
	}
}
