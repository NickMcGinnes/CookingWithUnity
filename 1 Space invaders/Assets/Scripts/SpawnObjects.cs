using UnityEngine;
using System.Collections;

public class SpawnObjects : MonoBehaviour
{

	public GameObject item;

	public float spawnWidth;
	public float spawnHeight;
	public int numberMobsX;
	public int numberMobsY;

	// Use this for initialization
	void Start ()
	{
		for (int i = 0; i < numberMobsX; i++) 
		{
			for (int j = 0; j < numberMobsY; j++) 
			{
				Vector3 spawnPosition = transform.position;
				spawnPosition.x += i * (spawnWidth/numberMobsX);
				spawnPosition.y -= j * (spawnHeight/numberMobsY);
				Instantiate(item,spawnPosition,item.transform.rotation);
			}
		}

	}
	void OnDrawGizmos()
	{
		for (int i = 0; i < numberMobsX; i++) 
		{
			for (int j = 0; j < numberMobsY; j++) 
			{
				Vector3 spawnPosition = transform.position;
				spawnPosition.x += i * (spawnWidth/numberMobsX);
				spawnPosition.y -= j * (spawnHeight/numberMobsY);
				Gizmos.DrawLine(spawnPosition + Vector3.left, spawnPosition + Vector3.right);
				Gizmos.DrawLine(spawnPosition + Vector3.up, spawnPosition + Vector3.down);
				Gizmos.DrawLine(spawnPosition + Vector3.forward, spawnPosition + Vector3.back);
			}
		}

	}
}
