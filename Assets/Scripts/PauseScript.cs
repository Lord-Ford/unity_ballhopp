using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PauseScript : MonoBehaviour {

	public bool hasTapped = false;
	public bool isPaused = false;
	public bool isGameOver = false;
	//Reffrences
	public PlayerController thePlayer;//Ref to a class
	//public AudioManager theAudio;
	public GameObject startPanel;//Start screen
	public GameObject pausePanel;//Pause menu
	public GameObject gameOverPanel;//Game over screen
	//public Score scoreM;

	void Awake()
	{
		thePlayer = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerController> ();//Find the gameobject and assign the component
		//scoreM = GameObject.FindGameObjectWithTag ("Score").GetComponent<Score> ();
	}
	void Start()
	{
		hasTapped = false;
		//theAudio.MusicPlay();
	}

	void Update ()
	{
//Start
		if (!hasTapped) {
			WaitForTap (true);
		} else {
			WaitForTap (false);
		}
//Pause
		if (isPaused) {
			PauseGame (true);
		} else {
			PauseGame(false);
		}
//Game over
		if (isGameOver) {
			GameOver (true);
		} else {
			GameOver(false);
		}
#if UNITY_EDITOR
		if(Input.GetKeyDown(KeyCode.S))
		{
			Play ();//Call the toggle function
		}

		if(Input.GetKeyDown(KeyCode.P))
		{
			SwitchPause ();//Call the toggle function
		}

		if(Input.GetKeyDown(KeyCode.R))
		{
			Restart ();//Call the toggle function
		}
#endif
	}
//Time manipulation
	public void StartTime()
	{
		Time.timeScale = 1.0f;
	}
	public void StopTime()
	{
		Time.timeScale = 0.0f;
	}
	
//Tap to Start stuff
	void WaitForTap(bool state)//Only stoping player from moving forward, meaning we can have Animations
	{
		if (state)//If state is true do...
		{
			thePlayer.forwardSpeed = 0f;//Halt player forward movment
		} else 
		{
			thePlayer.forwardSpeed = thePlayer.speed;//Allow player to move forward
		}
		startPanel.SetActive (state);//If state is true this is true and vice-versa

	}

	public void Play()//A switch to for the 'wait to tap' funtion
	{
		if (!hasTapped)
		{
			hasTapped = true;//Changes the value
		}
	}
//Pause stuff
	void PauseGame(bool state)//Pause function
	{
		if (isPaused)
		{
			StopTime ();
		}
		if (!isPaused)
		{
			StartTime ();
		}
		pausePanel.SetActive (state);//If state is true this is true and vice-versa
	}

	public void SwitchPause()//Alternate between paused and !paused
	{
		if (isPaused)
		{
			isPaused = false;
		} else if(!isGameOver)
		{
			isPaused = true;
		}
	}
//Game over stuff
	public void GameOver(bool state)
	{
		if (state)//If state is true do...
		{
			StopTime ();
		} else if(!isPaused) 
		{
			StartTime ();
		}
		gameOverPanel.SetActive (state);//If state is true this is true and vice-versa
	}
//Restart stuff
	public void Restart()//Restart function relods the level
	{
			Application.LoadLevel(0);
	}
}
