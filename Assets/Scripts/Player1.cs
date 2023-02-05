using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1 : MonoBehaviour
{
	[SerializeField] LevelTransition levelTransition;
	public AudioSource audioSource;
	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.collider.tag == "FinalPlatform")
		{
			levelTransition.FadeToLevel(2);
		}
	}
	public void PlaySound(AudioClip audioClip)
	{
		audioSource.PlayOneShot(audioClip); //som de atingir a plataforma final
	}
}
