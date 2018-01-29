using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateGameObjectsWhenSelected : MonoBehaviour
{

	public GameObject[] ObjectsToActivate;

	
	private UnitManager _unitManager;
	// Use this for initialization
	void Start () {
		_unitManager = GameObject.FindGameObjectWithTag("PlayerUnitManager").GetComponent<UnitManager>();
	}
	
	// Update is called once per frame
	void Update () {

		if (_unitManager.IsSelected(gameObject))
		{
			foreach (GameObject obj in ObjectsToActivate)
			{
				obj.SetActive(true);
			}
		}
		else
		{
			foreach (GameObject obj in ObjectsToActivate)
			{
				obj.SetActive(false);
			}
		}
	}
}
