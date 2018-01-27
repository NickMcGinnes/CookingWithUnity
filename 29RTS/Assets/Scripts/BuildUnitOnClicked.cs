using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildUnitOnClicked : MonoBehaviour
{

	public GameObject factory;

	void Clicked()
	{
		factory.SendMessage("AddUnitToQueue");
	}
}
