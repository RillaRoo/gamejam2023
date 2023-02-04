using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawn : MonoBehaviour
{
	public Transform[] spawners;
	public GameObject[] enemyPrefabs;
	private float timer;
	public float startingTimer;
	[SerializeField] BoxCollider2D bxcd2d;
	int randomEnemy;
	int randomSpawn;
	Vector3 spawnPos;



	// Start is called before the first frame update
	void Awake()
	{
		timer = startingTimer;
	}

	// Update is called once per frame
	void Update()
	{
		if (timer <= 0)
		{
			GenerateSpawnLocation();
			
			Instantiate(enemyPrefabs[randomEnemy], spawners[randomSpawn].position, transform.rotation);
			startingTimer -= 0.05f;
			if (startingTimer <= 1) startingTimer = 1;
			timer = startingTimer;
		}
		else
		{
			timer -= Time.deltaTime;
		}
	}

	private void GenerateSpawnLocation()
	{
		randomEnemy = Random.Range(0, enemyPrefabs.Length);
		randomSpawn = Random.Range(0, spawners.Length);
		spawnPos = spawners[randomSpawn].position;
		if (bxcd2d.bounds.Intersects(spawners[randomSpawn].gameObject.GetComponent<BoxCollider2D>().bounds))
		{
			GenerateSpawnLocation();
		}

	}

}
