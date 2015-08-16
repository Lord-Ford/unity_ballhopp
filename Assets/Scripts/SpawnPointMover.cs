using UnityEngine;
using System.Collections;

public class SpawnPointMover : MonoBehaviour {

	//public float speed;

	Rigidbody rBody;
	public PlayerController playerC;

	// Use this for initialization
	void Start ()
	{
		playerC = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerController>();
		rBody = GetComponent<Rigidbody> ();
		//speed = playerC.forwardSpeed;
	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{
		rBody.velocity = new Vector3 (rBody.velocity.x, rBody.velocity.y, playerC.forwardSpeed);//
	}
}
