using UnityEngine.Audio;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
	public AudioSource musicSource;
	public AudioSource audioSource;
	public static AudioManager instance { get; private set; }
	public AudioClip audio { get; private set; }
	[SerializeField] AudioClip[] ui;
	[SerializeField] AudioClip[] main;
	[SerializeField] AudioClip[] soundEffects;

	public void PlaySound(int clipNumber)
	{
		switch (clipNumber)
		{
			case 0:
				audioSource.PlayOneShot(ui[0]);
				break;
			case 1:
				audioSource.PlayOneShot(ui[1]);
				break;
			case 2:
				musicSource.PlayOneShot(main[0]);
				break;
			case 3:
				musicSource.PlayOneShot(main[1]);
				break;
			case 4:
				musicSource.PlayOneShot(main[2]);
				break;
			case 5:
				audioSource.PlayOneShot(soundEffects[0]);
				break;
			case 6:
				audioSource.PlayOneShot(soundEffects[1]);
				break;
			case 7:
				audioSource.PlayOneShot(soundEffects[2]);
				break;
			case 8:
				audioSource.PlayOneShot(soundEffects[3]);
				break;
			case 9:
				audioSource.PlayOneShot(soundEffects[4]);
				break;
			case 10:
				audioSource.PlayOneShot(soundEffects[5]);
				break;
			case 11:
				audioSource.PlayOneShot(soundEffects[6]);
				break;
			case 12:
				audioSource.PlayOneShot(soundEffects[7]);
				break;
			case 13:
				audioSource.PlayOneShot(soundEffects[8]);
				break;
			case 14:
				audioSource.PlayOneShot(soundEffects[9]);
				break;
			case 15:
				audioSource.PlayOneShot(soundEffects[10]);
				break;
			case 16:
				audioSource.PlayOneShot(soundEffects[11]);
				break;
			case 17:
				audioSource.PlayOneShot(soundEffects[12]);
				break;
			case 18:
				audioSource.PlayOneShot(soundEffects[13]);
				break;
			case 19:
				audioSource.PlayOneShot(soundEffects[14]);
				break;
			case 20:
				audioSource.PlayOneShot(soundEffects[15]);
				break;
			case 21:
				audioSource.PlayOneShot(soundEffects[16]);
				break;
			case 22:
				audioSource.PlayOneShot(soundEffects[17]);
				break;
			case 23:
				audioSource.PlayOneShot(soundEffects[18]);
				break;
			case 24:
				audioSource.PlayOneShot(soundEffects[19]);
				break;
			case 25:
				audioSource.PlayOneShot(soundEffects[20]);
				break;
		}
	}

	private void Awake() 
	{
		if (instance != null && instance != this)
			Destroy(gameObject);

		else
		{
			instance = this;
		}
	}
}


