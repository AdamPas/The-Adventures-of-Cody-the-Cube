using UnityEngine;
using System.Collections;

public class Enemy : Character 
{
	public float knockBackForce = 5000.0f; //the force with wich the character is knocked back

	Rigidbody _rb;


	void Start()
	{
		_rb = this.GetComponent<Rigidbody> ();
	}


	public void Knockback(float dir)
	{
		_rb.AddForce (new Vector3(dir * knockBackForce, 0, 0));
	}



	public override void Die()
	{
		Destroy (this.gameObject);
	}


}
