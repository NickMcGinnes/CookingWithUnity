using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSelectedUnitsOnRightClick : MonoBehaviour {
	
	private UnitManager _unitManager;

	private void Start()
	{
		_unitManager = GameObject.FindGameObjectWithTag("PlayerUnitManager").GetComponent<UnitManager>();
	}
	
	void RightClicked(Vector3 clickPosition)
	{
		foreach (GameObject unit in _unitManager.GetSelectedUnits())
		{
			unit.SendMessage("MoveOrder", clickPosition);
		}
		
	}
}
