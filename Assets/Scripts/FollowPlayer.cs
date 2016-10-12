using UnityEngine;
using System.Collections;

/*
 * Attach on Main Camera
 * Makes sure the camera follows the player appropriately
 */
public class FollowPlayer : MonoBehaviour {

	[Tooltip("Vector in space, describing the constant position from the player.")]
	public Vector3 posFromPlayer = new Vector3(2, 2, -10);

	GameObject _player;

	// Use this for initialization
	void Start () 
	{
		//Find the player in the scene
		_player = GameObject.FindGameObjectWithTag ("Player");

	}
	
	// Update is called once per frame
	void Update () 
	{
		transform.position = _player.transform.position + posFromPlayer;
	}
}
