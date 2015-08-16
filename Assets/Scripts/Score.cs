using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Score : MonoBehaviour {
	
	static int score = 0;
	static int highScore;
	
	public Text scoreText;
	public Text scoreText2;
	public Text highScoreText;
	public PauseScript pause;

	void Start()
	{
		scoreText = GetComponent<Text> ();//Access Text component
		highScore = PlayerPrefs.GetInt("High Score");//Retrive the high score

		score = 0;//At the start of the game score is 0

		//scoreText2.text = scoreText.text;
	}

	void Update()
	{
		scoreText.text = ("" + score);//Display the score

		if (score > highScore && pause.isGameOver == true)
		{
			highScore = score;
			PlayerPrefs.SetInt ("High Score", highScore);//Store the highscore value in the pref
		}
		highScoreText.text = ("" + highScore);//Display high score
		scoreText2.text = ("" + score);
	}

	public void AddPoints()
	{
		score++;
	}
}
