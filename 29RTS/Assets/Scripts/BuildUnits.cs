using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildUnits : MonoBehaviour
{


	public GameObject UnitType;

	public GameObject BuildPositionObject;

	public GameObject Meter;

	public TextMesh QueueDisplay;

	public float BuildTime = 10.0f;

	private int _numberToBuild;

	// Use this for initialization
	void Start()
	{
		if (BuildPositionObject == null)
			BuildPositionObject = gameObject;
	}

	private void Update()
	{
		if (!IsInvoking("BuildUnit"))
		{
			if (_numberToBuild > 0)
			{
				StartCoroutine("BuildMeter");
				Invoke("BuildUnit", BuildTime);
				
			}
		}

		if (_numberToBuild > 0)
		{
			if (!Meter.activeInHierarchy)
			{
				Meter.SetActive(true);
			}
		}
		else
		{
			if (Meter.activeInHierarchy)
			{
				Meter.SetActive(false);
			}
		}
		

		QueueDisplay.text = "Queue: " + _numberToBuild.ToString();
	}

	void BuildUnit()
	{

		Instantiate(UnitType, BuildPositionObject.transform.position, UnitType.transform.rotation);
		_numberToBuild--;
	}

	void AddUnitToQueue()
	{
		_numberToBuild++;
	}

	IEnumerator BuildMeter()
	{
		{
			float t = 0;
			Vector3 newScale;
			while (t < BuildTime)
			{
				newScale = Meter.transform.localScale;
				newScale.x = Mathf.Lerp(0,1,t/BuildTime);
				Meter.transform.localScale = newScale;
				
				t += Time.deltaTime;
				yield return null;
			}

			newScale = Meter.transform.localScale;
			newScale.x = 0.0f;
			Meter.transform.localScale = newScale;
		}
	}
}