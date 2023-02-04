using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rangedEnemy : MonoBehaviour
{
	public Transform player;
	public GameObject bullet;

	private float shootCd;

	public float startShootCd;
	// Start is called before the first frame update
	void Start()
	{
		shootCd = startShootCd;
	}

	// Update is called once per frame
	void Update()
	{
		Vector2 dir = new Vector2(player.position.x - transform.position.x, player.position.y - transform.position.y);

		transform.up = dir; //enemy looks to player 

		if (shootCd <= 0)
		{
			Instantiate(bullet, transform.position, transform.rotation);
			shootCd = startShootCd;
		}
		else
		{
			shootCd -= Time.deltaTime;
		}
	}
}
