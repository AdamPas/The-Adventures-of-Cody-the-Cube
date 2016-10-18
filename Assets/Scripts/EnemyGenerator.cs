using UnityEngine;
using System.Collections;

public class EnemyGenerator : MonoBehaviour 
{
	public GameObject enemyPrefab; //the enemy prefab to instantiate

	[Tooltip("The minimum time an enemy will be generated.")]
	public float minTime;
	[Tooltip("The maximum time an enemy will be generated.")]
	public float maxTime;


	//Private variables

	Timer timer = new Timer (); //the timer variable of the generator


	// Use this for initialization
	void Start () 
	{
		float duration = Timer.RandomDuration (minTime, maxTime);
		timer.SetAndStartTimer (duration);
	}

	// Update is called once per frame
	void Update () 
	{ //When the timer runs off, generate bullet and restart the timer
		if(timer.CheckTimer()){

			//Generate a bullet collectable on the player's Z depth
			float bullX = this.transform.position.x;
			float bullY = this.transform.position.y;
			float bullZ = this.transform.position.z -2.0f;
			Vector3 bulletPos = new Vector3(bullX, bullY, bullZ);
			Instantiate (enemyPrefab, bulletPos, Quaternion.identity);

			//Restart the timer with a random duration
			float duration = Timer.RandomDuration (minTime, maxTime);
			timer.SetAndStartTimer (duration);
		}
	}


}
