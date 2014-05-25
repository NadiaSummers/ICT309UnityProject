using UnityEngine;
using System.Collections;

public class CauseDamage : MonoBehaviour {

	public int damageTaken;
	public bool singleUse;
	public string[] tags;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other)
	{
		for (int i = 0; i < tags.Length; i++)
		{
			if (other.tag == tags[i])
			{
				if (singleUse)
					Destroy (this.gameObject);
				
				Health thisGuy = other.GetComponent<Health>();
				thisGuy.Damage(damageTaken);
			}
		}
	}
}
