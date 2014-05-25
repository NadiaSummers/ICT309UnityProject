using UnityEngine;
using System.Collections;

public class Shrink : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (transform.localScale.x > 0.1)
		transform.localScale -= new Vector3(0.08f, 0.08f, 0.08f);
	}
}
