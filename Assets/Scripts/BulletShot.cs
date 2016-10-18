using UnityEngine;
using System.Collections;

public class BulletShot : MonoBehaviour 
{

	void OnTriggerEnter(Collider other)
	{
		//If the enemy is shot, reduce its HP by 1
		if (other.CompareTag ("Enemy")) {
			Enemy enemy = other.gameObject.GetComponent<Enemy> (); //get a reference to the enemy
			enemy.ReceiveDamage (1); //apply damage to enemy
			enemy.Knockback(Mathf.Sign(this.GetComponent<Rigidbody>().velocity.x)); //knock back the enemy
		}

		Destroy (this.gameObject);
	}
}
