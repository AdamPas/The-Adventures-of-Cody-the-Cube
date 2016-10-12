using UnityEngine;
using System.Collections;

public abstract class Character : MonoBehaviour 
{
	[Tooltip("Number of lives of the character.")]
	public int lives = 3;

	public void ReceiveDamage(int damage)
	{
		lives -= damage;
		if (lives <= 0)
			Die ();
	}

	//Each character has a different way of deing
	public abstract void Die ();


}
