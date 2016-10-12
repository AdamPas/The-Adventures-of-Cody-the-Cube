using UnityEngine;
using System.Collections;

/* Attach to the main player object (Cody)
 * Controls the player according to input
 * Offers 2 directional control + jumping
 */
public class PlayerController : Character
{
	//Public variables 

	[Tooltip("Player's horizontal speed.")]
	public float speed = 400.0f;

	[Tooltip("Player's jumping speed")]
	public float jumpPower = 300.0f;

	[Tooltip("The shooting power of the player.")]
	public float shootPower = 5000.0f;

	[SerializeField] //Hide the variable, but keep it public for the ground checker
	public bool isGrounded = false;

	public GameObject bullPrefab; //bullet prefab


	//Private variables

	Rigidbody _rb = new Rigidbody();
	public int bullets = 10; //number of bullets available to throw



	// Use this for initialization
	void Start ()
	{
		_rb = this.GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		
		//Deal with movement
		float horizMov = Input.GetAxisRaw("Horizontal"); //Get horizontal input
		if(horizMov != 0)
			Move (speed, horizMov); //Move the player


		//Deal with jumping
		checkIfGrounded(out isGrounded); //check if the player is on the ground
		bool jump = Input.GetKeyDown (KeyCode.W); //Get input from jumping button 
		if (jump && isGrounded) 
				Jump (jumpPower);


		//Deal with shooting
		bool shoot = Input.GetKeyDown(KeyCode.Space);
		if (shoot && (bullets > 0))
			Shoot(shootPower);
	}


	//Moves the character its attached to through its rigidbody, according to speed and input
	void Move(float movSpeed, float horizInput)
	{
		//Feed it to the player, while keeping his vertical velocity unaltered (so that gravity and jumping can perform)
		Vector3 movVector = new Vector3 (horizInput * speed * Time.deltaTime, _rb.velocity.y, 0);
		_rb.velocity = movVector;
	}


	//Jumps according to power of the jump
	void Jump(float power)
	{
		_rb.AddForce (new Vector3 (0, power, 0));
	}


	public void CollectBullet()
	{
		bullets++;
	}


	//Shoots a bullet vertically depending on the shooting power of Cody
	void Shoot(float power)
	{		
		bullets--; //Reduce the number of bullets
		float marginPos = (transform.localScale.x / 2.0f) + 0.3f; //distance from Cody's body to instantiate the bullet

		//If Cody is moving to the left, shoot to the left
		if (_rb.velocity.x < 0) {
			marginPos = -marginPos;
			power = -power;
		}

		Vector3 bulletPos = transform.position + new Vector3 (marginPos, 0, 0); //bullet instantiation position
		GameObject bull = Instantiate (bullPrefab, bulletPos, Quaternion.identity) as GameObject;
		bull.GetComponent<Rigidbody> ().AddForce (new Vector3 (power, 0, 0)); //Launch the bullet
	}

	//Checks if the player is on the ground and updates the boolean isGrounded at class level
	void checkIfGrounded(out bool onGround)
	{
		float checkDistance = this.transform.localScale.y / 2.0f + 0.1f;

		if (Physics.Raycast (this.transform.position, Vector3.down, checkDistance)) 
			onGround = true;
		else 
			onGround = false;
	}


	public override void Die ()
	{
		throw new System.NotImplementedException ();
	}
}
