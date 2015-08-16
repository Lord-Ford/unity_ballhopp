using UnityEngine;
using System.Collections;

public class DestroyByTime : MonoBehaviour {

	public float delay;

	void Start()
	{
		Destroy (gameObject, delay);
	}
}
