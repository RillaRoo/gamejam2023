using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum SurfaceTrees
{
	Shot,
	Basic,
	SemiBasic,
	Bomb,
	Test1,
	Test2
}
public enum UndergroundTrees
{
	Shot,
	Bomb,
	Test1,
	Test2,
	Test3,
	Test4
}
public class slots : MonoBehaviour
{
	public GameObject[] inferior;
	public GameObject[] superior;
	[SerializeField] Image selectorDown;
	[SerializeField] Image selectorUp;
	int currentSlotDown = 0;
	int currentSlotUp = 0;
	

	private void Start()
	{
		SelectSeedDown(0);
		SelectSeedUp(0);
        for (int i = 0; i < inferior.Length; i++)
        {
			inferior[i].GetComponent<BulbManager>().SeedAmount = inferior[i].GetComponent<BulbManager>().originalSeedAmount;
		}
		for (int i = 0; i < superior.Length; i++)
		{
			superior[i].GetComponent<BulbManager>().SeedAmount = superior[i].GetComponent<BulbManager>().originalSeedAmount;
		}
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

		if (Input.GetKeyDown(KeyCode.RightShift))
		{
            if (inferior[currentSlotDown].GetComponent<BulbManager>().SeedAmount > 0)
            {
				InventoryManager.Instance.playerB.Shoot(inferior[currentSlotDown].GetComponent<BulbManager>().UndergroundType);
				inferior[currentSlotDown].GetComponent<BulbManager>().SeedAmount--;
				inferior[currentSlotDown].transform.GetChild(1).GetComponent<Text>().text =
				inferior[currentSlotDown].GetComponent<BulbManager>().SeedAmount.ToString();
			}
		}
			
		if (Input.GetKeyUp(KeyCode.Space))
		{
			if (superior[currentSlotUp].GetComponent<BulbManager>().SeedAmount > 0)
			{
				InventoryManager.Instance.playerT.Shoot(superior[currentSlotUp].GetComponent<BulbManager>().surfaceType);
				superior[currentSlotUp].GetComponent<BulbManager>().SeedAmount--;
				superior[currentSlotUp].transform.GetChild(1).GetComponent<Text>().text =
				superior[currentSlotUp].GetComponent<BulbManager>().SeedAmount.ToString();
			}
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
