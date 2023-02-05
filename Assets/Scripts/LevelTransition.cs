using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelTransition : MonoBehaviour
{
	public Animator animator;

	private int levelToLoad;

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.collider.tag == "FinalPlatform")
		{
			FadeToLevel(2);
		}
	}

	public void FadeToLevel(int levelIndex)
	{
		animator.SetTrigger("FadeOut");
		levelToLoad = levelIndex;
	}

	public void OnFadeComplete()
	{
		SceneManager.LoadScene(levelToLoad);
	}
}
