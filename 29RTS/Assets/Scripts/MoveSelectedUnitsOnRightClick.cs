using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSelectedUnitsOnRightClick : MonoBehaviour
{

	public GameObject MoveEffectObject;
	
	private UnitManager _unitManager;

	private void Start()
	{
		_unitManager = GameObject.FindGameObjectWithTag("PlayerUnitManager").GetComponent<UnitManager>();
	}
	
	void RightClicked(Vector3 clickPosition)
	{
		bool unitsSelected = false;
		foreach (GameObject unit in _unitManager.GetSelectedUnits())
		{
			unitsSelected = true;
			unit.SendMessage("MoveOrder", clickPosition);
		}
		if (unitsSelected)
		Instantiate(MoveEffectObject, clickPosition, MoveEffectObject.transform.rotation);
		
	}
}
