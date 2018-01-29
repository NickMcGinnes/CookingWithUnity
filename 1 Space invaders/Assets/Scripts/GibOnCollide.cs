using UnityEngine;
using System.Collections;

public class GibOnCollide : MonoBehaviour 
{

	public GameObject[] physicGibs;
	public GameObject[] staticGibs;

	public float myExplosionForce = 100;
	public float spawnRadius = 1;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	void OnTriggerEnter()
	{
		foreach (GameObject gib in physicGibs) 
		{
			//Instantiate (gib, transform.position + Random.insideUnitSphere * spawnRadius, transform.rotation);
			GameObject gibinstance = Instantiate (gib, transform.position + Random.insideUnitSphere * spawnRadius, transform.rotation) as GameObject;
			gibinstance.GetComponent<Rigidbody> ().AddExplosionForce (myExplosionForce, transform.position, spawnRadius);
		}
		foreach(GameObject gib in staticGibs)
		{
			Instantiate(gib,transform.position,transform.rotation);
		}

		Destroy (gameObject);
	}

}
