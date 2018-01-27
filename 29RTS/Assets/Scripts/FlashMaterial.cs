using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashMaterial : MonoBehaviour
{

	public float FlashRate = 1.0f; //DO NOT CHANGE THIS IN EDITOR DURING PLAY MODE, CAN BE DANGEROUS

	private Color _originalColor;
	
	// Use this for initialization
	void Start ()
	{
		_originalColor = gameObject.GetComponent<Renderer>().material.color;
		StartCoroutine("Flash");
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	IEnumerator Flash()
	{
		float t = 0;

		while (t < FlashRate)
		{
			gameObject.GetComponent<Renderer>().material.color = Color.Lerp(_originalColor, Color.white, t / FlashRate);
			t += Time.deltaTime;
			yield return null;
		}
		gameObject.GetComponent<Renderer>().material.color = Color.white;

		StartCoroutine("Return");
	}

	IEnumerator Return()
	{
		float t = 0;

		while (t < FlashRate)
		{
			gameObject.GetComponent<Renderer>().material.color = Color.Lerp(Color.white, _originalColor, t / FlashRate);
			t += Time.deltaTime;
			yield return null;
		}
		gameObject.GetComponent<Renderer>().material.color = _originalColor;

		StartCoroutine("Flash");
	}
	
}
