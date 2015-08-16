using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	//Movment
	public float speed;//Value holder for 'forwardSpeed'
	public float forwardSpeed;//What is used in functions
	//Jump
	public float jumpHeight;
	public bool isGrounded = false;
	Transform groundCheck;
	public LayerMask playerMask;
	int taps = 0;
	int maxTaps = 3;
	public float delay;//Delay to destroy hazard
	//Touch
	private Touch initialTouch = new Touch();
	public bool hasTaped = false;//So it wont call every update
	//Refrnces
	Rigidbody rBody;
	public Score scoreM;

	void Start ()
	{
		rBody = GetComponent<Rigidbody> ();
		//scoreM = GameObject.FindGameObjectWithTag ("Score").GetComponent<Score> ();
		groundCheck = GameObject.FindGameObjectWithTag ("GroundCheck").transform;
	}

	
	void FixedUpdate ()
	{
		//The plyer bounces off the ground causing a collision miss fire so I used LineCasting
		isGrounded = Physics.Linecast (transform.position, groundCheck.position, playerMask);//Ensure player is grounded
		if (isGrounded)
			taps = 0;

		Move ();//Forward automatic movment

		foreach (Touch tk in Input.touches)//Touch controls
		{
			if(tk.phase == TouchPhase.Began)
			{
				Jump();
			}
			
			//else if(tk.phase == TouchPhase.Moved && !hasTaped)
			//{
			
			//	hasTaped = true;//So long there finger is touching they cant tap again
			//}
			
			else if(tk.phase == TouchPhase.Ended)//Finger lifted
			{
				initialTouch = new Touch();//Reset
				hasTaped = false;//Now they can tap again
				
			}

		}
#if UNITY_EDITOR
		if(Input.GetKeyDown (KeyCode.J))
		{
			Jump ();
		}
#endif

	}

	public void Move()
	{
		rBody.velocity = new Vector3 (rBody.velocity.x, rBody.velocity.y, forwardSpeed);//Forward movment speed
	}

	public void Jump()
	{
		if (isGrounded) {
			rBody.velocity = new Vector3 (rBody.velocity.x, jumpHeight, rBody.velocity.z);
			taps++;
		} else if (!isGrounded && taps < maxTaps)
		{
			rBody.velocity = new Vector3 (rBody.velocity.x, jumpHeight, rBody.velocity.z);
			taps++;
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Goal")
		{
			scoreM.AddPoints ();//Add a point
			Destroy(other.transform.parent.gameObject, delay);//Triggers a count down to destroy hazard
		}
	}
}
