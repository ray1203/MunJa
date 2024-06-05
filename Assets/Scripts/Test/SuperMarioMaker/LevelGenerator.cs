using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
	public int step;
	public int mapNum;

	public Texture2D[] map;
	public Texture2D[] enemyMap;

	public ColorToPrefab[] colorMappings;
	public ColorToPrefab[] colorMappings2;
	public ColorToPrefab[] colorMappings3;

	public GameObject shop;
	public StepMana stepMana;

	CameraCtrl cameraCtrl;

	private void Start()
	{
		stepMana = GameObject.FindGameObjectWithTag("Maker").GetComponent<StepMana>();
		step = stepMana.step;
		Start_();
	}

	// Use this for initialization
	public void Start_()
	{
		mapNum = Random.Range(0, 10);
		gameObject.GetComponent<EnemyMaker>().MakeEnemy(mapNum);
		cameraCtrl = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraCtrl>();

		if (mapNum == 6 || mapNum == 7 || mapNum == 8 || mapNum == 9 || mapNum == 5)
		{
			cameraCtrl.isMove = true;
		}
		else
		{
			cameraCtrl.isMove = false;
		}

		GenerateLevel();
	}

	void GenerateLevel()
	{
		for (int x = 0; x < map[mapNum].width; x++)
		{
			for (int y = 0; y < map[mapNum].height; y++)
			{
				switch (step)
				{
					case 1:

						GenerateTile1(x, y);
						break;
					case 2:

						GenerateTile1(x, y);
						break;
					case 3:

						GenerateTile1(x, y);
						break;
					case 4:

						GenerateTile1(x, y);
						break;
					case 5:
						GenerateTile1(x, y);
						break;
					case 6:

						Instantiate(shop, transform.position, Quaternion.identity, transform);
						break;
					case 7:
					case 8:
					case 9:
					case 10:
					case 11:

						GenerateTile2(x, y);
						break;
					case 12:

						Instantiate(shop, transform.position, Quaternion.identity, transform);
						break;
					case 13:
					case 14:
					case 15:
					case 16:
					case 17:

						GenerateTile3(x, y);
						break;
					case 18:

						Instantiate(shop, transform.position, Quaternion.identity, transform);
						break;
				}
			}
		}
	}

	void GenerateTile1(int x, int y)
	{
		Color pixelColor = map[mapNum].GetPixel(x, y);

		if (pixelColor.a == 0)
		{
			// The pixel is transparrent. Let's ignore it!
			return;
		}

		foreach (ColorToPrefab colorMapping in colorMappings)
		{
			if (colorMapping.color.Equals(pixelColor))
			{
				//Vector2 position = new Vector2(x * 0.64f - 8.57f, y * 0.64f - 4.92f);
				Vector2 position = new Vector2(x * 0.64f - 8.6f, y * 0.64f - 4.68f);
				Instantiate(colorMapping.prefab, position, Quaternion.identity, transform);
			}
		}
	}

	void GenerateTile2(int x, int y)
	{
		Color pixelColor = map[mapNum].GetPixel(x, y);

		if (pixelColor.a == 0)
		{
			// The pixel is transparrent. Let's ignore it!
			return;
		}

		foreach (ColorToPrefab colorMapping in colorMappings2)
		{
			if (colorMapping.color.Equals(pixelColor))
			{
				//Vector2 position = new Vector2(x * 0.64f - 8.57f, y * 0.64f - 4.92f);
				Vector2 position = new Vector2(x * 0.64f - 8.6f, y * 0.64f - 4.68f);
				Instantiate(colorMapping.prefab, position, Quaternion.identity, transform);
			}
		}
	}

	void GenerateTile3(int x, int y)
	{
		Color pixelColor = map[mapNum].GetPixel(x, y);

		if (pixelColor.a == 0)
		{
			// The pixel is transparrent. Let's ignore it!
			return;
		}

		foreach (ColorToPrefab colorMapping in colorMappings3)
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
