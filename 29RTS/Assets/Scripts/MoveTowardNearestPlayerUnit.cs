using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class MoveTowardNearestPlayerUnit : MonoBehaviour
{


	public float MovementSpeed = 1.0f;

	private float _smallestDistance = float.MaxValue;

	private GameObject _target;
	
	// Use this for initialization
	void Start () {
		foreach (GameObject obj in GameObject.FindGameObjectsWithTag("PlayerUnits"))
		{
			float squareDistance = (transform.position - obj.transform.position).sqrMagnitude;
			if (squareDistance < _smallestDistance)
			{
				_smallestDistance = squareDistance;
				_target = obj;
			}
		}
	}
	
	// Update is called once per frame
	void Update ()
	{
		transform.position += (_target.transform.position - transform.position).normalized * MovementSpeed * Time.deltaTime;
	}
}
