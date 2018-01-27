using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicUnitMovement : MonoBehaviour
{
	public float MoveSpeed;
	public float GoalRadius = 0.1f;
	private Vector3 _goal;

	
	public void MoveOrder(Vector3 newGoal)
	{
		_goal = newGoal;
	}

	void Start()
	{
		_goal = gameObject.transform.position;
	}

	void Update()
	{
		


		//move towards our goal
		transform.position += (_goal - transform.position).normalized * MoveSpeed * Time.deltaTime;

		//My Simple Distance Check
		if (Vector3.Distance(transform.position, _goal) < 0.05)
			transform.position = _goal;
		
		/*
		//his crazy radius check
		
			foreach (Collider obj in Physics.OverlapSphere(_goal, GoalRadius))
			{
				if (obj.gameObject == gameObject)
				{
					
					transform.position = _goal;
				}
			}
		*/
	}
}
