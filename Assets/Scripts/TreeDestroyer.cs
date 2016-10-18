using UnityEngine;
using System.Collections;

public class TreeDestroyer : MonoBehaviour {

	public GameObject tree; //the parent tree game object

	void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag ("Enemy")) {
			Destroy (tree);
		}
	}
}
