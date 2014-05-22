using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

	public int maxHealth = 100;
	private int currentHealth = 0;

	// Use this for initialization
	void Start () {
		currentHealth = maxHealth;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Damage(int damageValue)
	{
		currentHealth -= damageValue;

		if (currentHealth <= 0)
		{
			currentHealth = 0;
		}
	}

	public bool IsDead { get{ return currentHealth <= 0; } }

	override public string ToString()
	{
		return currentHealth + "/" + maxHealth;
	}
}
