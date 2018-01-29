using UnityEngine;
using System.Collections;

public class DestroyOnInvisible : MonoBehaviour {
	public void OnBecameInvisible()
	{
		Destroy (gameObject);
	}
}
