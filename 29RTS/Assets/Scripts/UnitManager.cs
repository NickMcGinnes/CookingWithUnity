using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitManager : MonoBehaviour
{

	public List<GameObject> SelectedUnits;

	public List<GameObject> GetSelectedUnits()
	{
		return SelectedUnits;
	}
	
	// Use this for initialization
	void Start () 
	{
		SelectedUnits.Clear();
	}

	public void DeselectUnits()
	{
		SelectedUnits.Clear();
	}

	public void SelectSingleUnit(GameObject unit)
	{
		SelectedUnits.Clear();
		
		SelectedUnits.Add(unit);
		//Debug.Log(SelectedUnits);
	}
	
	public void SelectAdditionalUnit(GameObject unit)
	{	
		SelectedUnits.Add(unit);
		//Debug.Log(SelectedUnits);
	}
}
