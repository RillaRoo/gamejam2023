using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class slots : MonoBehaviour
{
	public GameObject[] inferior;
	public GameObject[] superior;
	[SerializeField] Image selectorDown;
	[SerializeField] Image selectorUp;
	int currentSlotDown = 0;
	int currentSlotUp = 0;
	int number = 0;

	private void Start()
	{
		SelectSeedDown(1);
		SelectSeedUp(1);
	}
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.E))
		{
			if (currentSlotDown <= 0)
			{
				currentSlotDown = 0;
			}
			else
			{
				currentSlotDown--;
				SelectSeedDown(currentSlotDown);
			}
		}
		if (Input.GetKeyDown(KeyCode.Q))
		{
			if (currentSlotDown >= 5)
			{
				currentSlotDown = 5;
			}
			else
			{
				currentSlotDown++;
				SelectSeedDown(currentSlotDown);
			}
		}
		if (Input.GetKeyDown(KeyCode.O))
		{
			if (currentSlotUp <= 0)
			{
				currentSlotUp = 0;
			}
			else
			{
				currentSlotUp--;
				SelectSeedUp(currentSlotUp);
			}
		}

		if (Input.GetKeyDown(KeyCode.P))
		{
			if (currentSlotUp >= 5)
			{
				currentSlotUp = 5;
			}
			else
			{
				currentSlotUp++;
				SelectSeedUp(currentSlotUp);
			}
		}

		if (Input.GetKeyDown(KeyCode.Space))
		{
			inferior[currentSlotDown].transform.GetChild(1).GetComponent<Text>().text = number--.ToString();
		}
		if (Input.GetKeyUp(KeyCode.KeypadEnter))
		{
			superior[currentSlotUp].transform.GetChild(1).GetComponent<Text>().text = number--.ToString();
		}
	}
	public void SelectSeedDown(int currentseed)
	{
		selectorDown.gameObject.transform.position = inferior[currentseed].gameObject.transform.position;
	}

	public void SelectSeedUp(int currentseed)
	{
		selectorUp.gameObject.transform.position = superior[currentseed].gameObject.transform.position;
	}
}
