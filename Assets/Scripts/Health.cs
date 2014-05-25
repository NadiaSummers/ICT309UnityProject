using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

	public int maxHealth = 100;
	private int currentHealth = 0;
	private int lastHealth = 0;
	private bool hasTakenDamage = false;

	// Use this for initialization
	void Start () {
		currentHealth = maxHealth;
		lastHealth = maxHealth;

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Damage(int damageValue)
	{
		hasTakenDamage = true;
		currentHealth -= damageValue;

		if (currentHealth <= 0)
		{
			currentHealth = 0;
		}
	}

	public int GetHealth()
	{
		return currentHealth;
	}

	public bool HasTakenDamage()
	{
		if (hasTakenDamage) {
						hasTakenDamage = false;
						return true;
				} else {
			return false;
				}
	}

	public bool IsDead { get{ return currentHealth <= 0; } }



	override public string ToString()
	{
		return currentHealth + "/" + maxHealth;
	}
}
