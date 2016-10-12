using UnityEngine;
using System.Collections;

public class TimedDestroyer : MonoBehaviour {

	[Tooltip("The gameobject will self-destroy in this amount of seconds.")]
	public float timer = 3.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (timer <= 0)
			Destroy (this.gameObject);
		else
			timer -= Time.deltaTime;
	}
}
