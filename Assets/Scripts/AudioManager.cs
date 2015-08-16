using UnityEngine;
using System.Collections;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour {

	/*While on the start screen the 'MainMenu' music will play.
	 * When the player starts playing the 'DuringPlay' music will play
	 * SFX will play when buttons are activated and the player jumps, lands and dies.
	 */

	//Music
	public AudioSource musicPlayer;//The source
	public AudioClip[] gameMenuMusic;//Music clips
	public AudioClip[] gamePlayMusic;//Music clips
	public Image musicUI;
	public Sprite[] musicOnOffSprite;
	//SFX
	public AudioSource sfxPlayer;
	public Image sfxUI;
	public Sprite[] sfxOnOffSprite;
	void Start()
	{
		MusicSelector ();//Start playing music at start
	}
//DuringPlay music & Toggle

	void MusicSelector()
	{
		int randomPlayMusic = Random.Range (0, gamePlayMusic.Length);//Pick a random Audio clip from the array
		musicPlayer.clip = gamePlayMusic [randomPlayMusic];//The AudioSource will use an array of AudioClips

		musicPlayer.Play ();
	}
	public void ToggleMusic()
	{
		if (musicPlayer.isPlaying)
		{
			musicPlayer.Stop ();
			musicUI.sprite = musicOnOffSprite[0];//Off Icon
		} else
		{
			musicPlayer.Play ();
			musicUI.sprite = musicOnOffSprite[1];//On Icon
		}
	}

	public void ToggleSFX()
	{
		if (sfxPlayer.isPlaying)
		{
			sfxPlayer.Stop ();
			sfxUI.sprite = musicOnOffSprite[0];//Off Icon
		} else
		{
			sfxPlayer.Play ();
			sfxUI.sprite = sfxOnOffSprite[1];//On Icon
		}
	}
//Button

//Jump

//Land

//Death
	
}
