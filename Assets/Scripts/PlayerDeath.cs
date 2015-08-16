using UnityEngine;
using System.Collections;

public class PlayerDeath : MonoBehaviour {
	
	public PauseScript pause;

	void OnCollisionEnter(Collision other)
	{
		if (other.gameObject.tag == "Hazard")//If player hit hazard then...
		{
			pause.isGameOver = true;//...do this
		}
	}
}
