using UnityEngine;
using System.Collections;

public class PixelEffector : MonoBehaviour {

	public GameObject quadPrefab;

	GameObject emptyObj;

	public int sizeX = 300;
	public int sizeY = 300;
	int [,] pixelArray;

	void Start () 
	{
		pixelArray = new int [sizeY, sizeX];
		clearTab();
	}

	public void startTransition()
	{
		pixelFX();
	}

	void pixelFXInverse()
	{
		int quadCount = 0;
		GameObject [] allObj = GameObject.FindGameObjectsWithTag("Finish"); 
		while (quadCount < sizeX * sizeY)
		{
			int randPos = Random.Range(0, sizeX * sizeY);
			if (randPos > allObj.Length - 1)
				randPos = 0;
			if (allObj[randPos] != null)
			{
				Destroy(allObj[randPos], quadCount * 0.002f);
				allObj[randPos] = null;
			}
			else
			{
				while (randPos < sizeX * sizeY)
				{
					if (allObj[randPos] != null)
					{
						Destroy(allObj[randPos], quadCount * 0.002f);
						allObj[randPos] = null;
                        break;
					}
					++randPos;
				}
				if (randPos >= sizeX * sizeY)
				{
					randPos = 0;
					while (randPos < sizeX * sizeY)
					{
						if (allObj[randPos] != null)
						{
							Destroy(allObj[randPos], quadCount * 0.002f);
							allObj[randPos] = null;
                            
                            break;
						}
						++randPos;
					}
				}
			}
			++quadCount;
		}
		clearTab();
	}

	void pixelFX()
	{
		int quadCount = 0;
		emptyObj = new GameObject();
		emptyObj.transform.parent = transform;
		emptyObj.name = "PixelParent";
		while (quadCount < sizeX * sizeY)
		{
			int randX = Random.Range(0, sizeX);
			int randY = Random.Range(0, sizeY);

			if (pixelArray[randY, randX] == 0)
			{
				StartCoroutine(delaySpawn(randX, randY, quadCount));
				pixelArray[randY, randX] = 1;
			}
			else
			{
				bool mustBreak = false;

				for (int j = randY; j < sizeY; j++)
				{
					for (int i = randX; i < sizeX; i++)
					{
						if (pixelArray[j, i] == 0)
						{
							StartCoroutine(delaySpawn(i, j, quadCount));
							pixelArray[j, i] = 1;
							mustBreak = true;
							break;
						}
					}
					if (mustBreak)
						break;
				}
				if (!mustBreak)
				{
					for (int j = 0; j < sizeY; j++)
					{
						for (int i = 0; i < sizeX; i++)
						{
							if (pixelArray[j, i] == 0)
							{
								StartCoroutine(delaySpawn(i, j, quadCount));
								pixelArray[j, i] = 1;
								mustBreak = true;
								break;
							}
						}
						if (mustBreak)
							break;
					}
				}
			}
			++quadCount;
		}
        Invoke("pixelFXInverse", 0.9f + quadCount * 0.002f);  
    }

	IEnumerator delaySpawn(int i, int j, int delay)
	{
		yield return new WaitForSeconds(0.5f + delay * 0.002f);
		GameObject tmp;
		tmp = (GameObject) Instantiate(quadPrefab, Vector3.zero, Quaternion.identity);
		tmp.tag = "Finish";
		tmp.transform.position = new Vector3(i + transform.position.x, j + transform.position.y, -8);
		tmp.transform.parent = emptyObj.transform;
	}

	void clearTab()
	{
		for (int j = 0; j < sizeY; j++)
		{
			for (int i = 0; i < sizeX; i++)
			{
				pixelArray[j,i] = 0;
			}
		}
	}
}
