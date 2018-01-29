using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootAtUnitsInRange : MonoBehaviour
{
	public GameObject Bullet;
	public float Speed = 100.0f;
	public float FireDelay = 1.0f;

	public float Radius = 1.0f;

	public LayerMask Mask;

	private GameObject _targetEnemy;

	void Start()
	{
		Invoke("Shoot", FireDelay);
	}
	// Update is called once per frame
	void Update ()
	{
		Collider[] enemeyArray = Physics.OverlapSphere(transform.position, Radius, Mask);
		if (enemeyArray.Length > 0)
		{
			_targetEnemy = enemeyArray[0].gameObject;
		}
		else
		{
			_targetEnemy = null;
		}
	}

	void Shoot()
	{
		if (_targetEnemy != null)
		{
			GameObject instance = Instantiate(Bullet, transform.position, Bullet.transform.rotation);
			if (instance.GetComponent<Rigidbody>())
			{
				instance.GetComponent<Rigidbody>()
					.AddForce((_targetEnemy.transform.position - transform.position).normalized * Speed * Time.deltaTime,ForceMode.VelocityChange);
			}
		}
		Invoke("Shoot", FireDelay);
	}
}
