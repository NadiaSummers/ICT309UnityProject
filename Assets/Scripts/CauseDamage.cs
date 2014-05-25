using UnityEngine;
using System.Collections;

public class CauseDamage : MonoBehaviour {

	public int damageTaken;
	public bool singleUse;
	public string[] tags;
	public GameObject[] unfreezeTargets;


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

					if (damageTaken > 0)
						thisGuy.Damage(damageTaken);
					
					for (int j = 0; j < unfreezeTargets.Length; j++)
					{
						unfreezeTargets[i].rigidbody.constraints = RigidbodyConstraints.None;
					}
				}
			}


	}
}