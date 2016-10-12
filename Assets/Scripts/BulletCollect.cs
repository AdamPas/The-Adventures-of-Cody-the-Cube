using UnityEngine;
using System.Collections;

public class BulletCollect : MonoBehaviour {

	void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag ("Player")) 
		{
			other.GetComponent<PlayerController> ().CollectBullet ();
			Destroy (this.gameObject);
		}
	}
}
