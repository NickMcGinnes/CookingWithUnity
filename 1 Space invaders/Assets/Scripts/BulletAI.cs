using UnityEngine;
using System.Collections;

//requires rigidbody

public class BulletAI : MonoBehaviour {

	public float speed = 20;

	// Use this for initialization
	void Start () {
		Vector3 newVelocity = Vector3.zero;
		newVelocity.y = speed;
		GetComponent<Rigidbody>().velocity = newVelocity;
	
	}
	
	// Update is called once per frame
	void Update () {
//		Vector3 newPosition = transform.position;
//		newPosition.y += speed* Time.deltaTime;
//		transform.position = newPosition;
	
	}

}
