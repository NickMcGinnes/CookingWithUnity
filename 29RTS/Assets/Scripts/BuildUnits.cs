using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildUnits : MonoBehaviour
{


	public GameObject UnitType;

	public GameObject BuildPositionObject;

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
			if(_numberToBuild > 0)
				Invoke("BuildUnit",BuildTime);
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
}