using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Spawner : MonoBehaviour {

	//Floor
	public GameObject currentFloor;
	public GameObject[] floorPrefab;//Collection of floors
	//Hazard
	public GameObject currentHazard;//The curretn hazard
	public GameObject[] hazardPrefab;//Collection of hazards
	public GameObject spawnPoint;//Ref to spawn point
	private float dist;//Holder for dist between currentHazard and spawnPoint
	//private float timer;
	//Pooling
	private Stack<GameObject> floor = new Stack<GameObject>();//Creat a stack for floors
	private static Spawner instance;

	public Stack<GameObject> Floor
	{
		get{return floor;}
		set{ floor = value;}
	}
	public static Spawner Instance
	{
		get
		{
			if(instance == null)
			{
				instance = GameObject.FindObjectOfType<Spawner>();
			}
			return instance;
		}
	}
	void Awake()
	{
		CreateFloors (30);//Have _ floors made and ready before game starts
		//timer = Time.time + 3;//Sets the timer 3 seconds in the future
	}
	
	void Start ()
	{
		for (int i = 0; i < 20; i++)//Place 20 floors in game at start
		{
			SpawnFloor();
		}
		SpawnHazard ();
	}

	void FixedUpdate()
	{
		//If distance between hazard block and spawnpoint is greater than _ to _ spawn a hazard
		//float randomDist = Random.Range (6, 8);//
		dist = Vector3.Distance(currentHazard.transform.position, spawnPoint.transform.position);//Dist between hazard and spawnpoint

		if (dist < 7.5)//If dist less than...; return
		{
			return;
		}
		else if(dist > 7.5)//If dist greatter than...; Spawn Hazard
		{
			SpawnHazard();
		}
		/*if (timer < Time.time)//When Time reaches Timer
		{
			SpawnHazard();
			//timer = Time.time + 3;//Sets the timer 3 seconds in the future
		}*/

	}

	public void CreateFloors(int amount)//Creat floors, ready for use
	{
		for (int i = 0; i < amount; i++)
		{
			floor.Push (Instantiate(floorPrefab[0]));//Add to floorprefab list
			floor.Peek ().name = "Floor";//Will no longer have '(clone)' at the end
			floor.Peek ().SetActive(false);//Set activity to false
		}
	}

	public void SpawnFloor ()
	{
		if (floor.Count == 0)//If list empty create more floors
		{
			CreateFloors(10);//Create 10
		}

		GameObject tnp = floor.Pop ();//Tenporary floor is = to floor
		tnp.SetActive(true);//Show object
		tnp.transform.position = currentFloor.transform.GetChild(0).transform.GetChild(0).position;//Set position
		currentFloor = tnp;//The new floor becomes the current floor
	}

	public void SpawnHazard ()
	{
		int randomIndex = Random.Range (0, hazardPrefab.Length);//Pick a random hazard out of the array
		
		currentHazard = (GameObject)Instantiate (hazardPrefab[randomIndex]
		                                         ,spawnPoint.transform.position,
		                                         Quaternion.identity);//Spawn a hazard on 'spawnpoint'
	}

}
