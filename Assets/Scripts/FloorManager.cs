using UnityEngine;
using System.Collections;

public class FloorManager : MonoBehaviour {

	public float fallDelay = 1f;
	
	void OnTriggerExit(Collider other)
	{
		
		if (other.tag == "Player") {

			Spawner.Instance.SpawnFloor();
			StartCoroutine(FallDown());
		}
	}
	
	IEnumerator FallDown(){
		
		yield return new WaitForSeconds (fallDelay);
		GetComponent<Rigidbody> ().isKinematic = false;
		yield return new WaitForSeconds (2);//Wait 2 secs
		switch (gameObject.name)
		{
		case "Floor"://Re-stack the object
			Spawner.Instance.Floor.Push(gameObject);
			gameObject.GetComponent<Rigidbody>().isKinematic = true;
			gameObject.SetActive(false);
			break;
		}
	}
}
