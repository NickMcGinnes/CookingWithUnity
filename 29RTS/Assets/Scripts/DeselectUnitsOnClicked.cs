using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeselectUnitsOnClicked : MonoBehaviour {

	private UnitManager _unitManager;

	private void Start()
	{
		_unitManager = GameObject.FindGameObjectWithTag("PlayerUnitManager").GetComponent<UnitManager>();
	}

	void Clicked()
	{
		_unitManager.DeselectAllUnits();
	}
}
