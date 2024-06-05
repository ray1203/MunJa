using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMaker : MonoBehaviour
{
	int step;
	public int mapNum;

	public Texture2D[] enemyMap;

	public ColorToPrefab[] colorEnemyMappings;
	public ColorToPrefab[] colorEnemyMappings2;
	public ColorToPrefab[] colorEnemyMappings3;

	int[] enemyNum = { 3, 4, 5, 5, 6, 8, 8, 8, 8, 9 };
	public int realNum;
	// Use this for initialization
	public void MakeEnemy(int num)
	{
		mapNum = num;
		realNum = enemyNum[num];
		GenerateLevel();
	}

	void GenerateLevel()
	{
		for (int x = 0; x < enemyMap[mapNum].width; x++)
		{
			for (int y = 0; y < enemyMap[mapNum].height; y++)
			{
				GenerateTileEnemy(x, y);
			}
		}
	}

	void GenerateTileEnemy(int x, int y)
	{
		Color pixelColor = enemyMap[mapNum].GetPixel(x, y);

		if (pixelColor.a == 0)
		{
			// The pixel is transparrent. Let's ignore it!
			return;
		}

		foreach (ColorToPrefab colorMapping in colorEnemyMappings3)
		{
			if (colorMapping.color.Equals(pixelColor))
			{
				//Vector2 position = new Vector2(x * 0.64f - 8.57f, y * 0.64f - 4.92f);
				Vector2 position = new Vector2(x * 0.64f - 8.6f, y * 0.64f - 4.68f);
				Instantiate(colorMapping.prefab, position, Quaternion.identity, transform);
			}
		}
	}

}
