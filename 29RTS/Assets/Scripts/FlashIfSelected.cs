using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashIfSelected : MonoBehaviour
{

	public float FlashRate = 1.0f; //DO NOT CHANGE THIS IN EDITOR DURING PLAY MODE, CAN BE DANGEROUS

	private Color _originalColor;

	private Renderer _myRenderer;

	private UnitManager _unitManager;

	private bool _coroutineRunning = false;
	
	// Use this for initialization
	void Start ()
	{
		 
		_unitManager = GameObject.FindGameObjectWithTag("PlayerUnitManager").GetComponent<UnitManager>();
		_myRenderer = gameObject.GetComponent<Renderer>();
		_originalColor = _myRenderer.material.color;
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (_unitManager.IsSelected(gameObject) )
		{
			if (!_coroutineRunning)
			{
				_coroutineRunning = true;
				Debug.Log("starting Coroutine");
				StartCoroutine("Flash");
			}
		}
		else
		{
			_coroutineRunning = false;
			StopAllCoroutines();
			_myRenderer.material.color = _originalColor;
		}
			
	}

	IEnumerator Flash()
	{
		float t = 0;

		while (t < FlashRate)
		{
			_myRenderer.material.color = Color.Lerp(_originalColor, Color.white, t / FlashRate);
			t += Time.deltaTime;
			yield return null;
		}
		_myRenderer.material.color = Color.white;

		StartCoroutine("Return");
	}

	IEnumerator Return()
	{
		float t = 0;

		while (t < FlashRate)
		{
			_myRenderer.material.color = Color.Lerp(Color.white, _originalColor, t / FlashRate);
			t += Time.deltaTime;
			yield return null;
		}
		_myRenderer.material.color = _originalColor;

		StartCoroutine("Flash");
	}
	
}
