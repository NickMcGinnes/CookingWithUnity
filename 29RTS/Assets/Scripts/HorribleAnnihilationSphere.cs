using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;

public class HorribleAnnihilationSphere : MonoBehaviour
{
	public string[] annihilationTags;
	
	private void OnCollisionEnter(Collision other)
	{
		foreach (string tag in annihilationTags)
		{
			if (other.collider.tag == tag)
			{
				Destroy(other.gameObject);
				Destroy(gameObject);
				return;
			}
		}	
	}
}
