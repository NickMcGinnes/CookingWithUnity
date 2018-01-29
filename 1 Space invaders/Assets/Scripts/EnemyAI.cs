using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour
{

	public float speed;
	public float leftEdge;
	public float rightEdge;
	public float dropDistance = 1.0f;

	private int direction = 1;


	// Use this for initialization
	void Start ()
	{
		//speed *= Random.value;
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		float cameraObjectZDiff = transform.position.z - Camera.main.transform.position.z;
		
		Vector3 newPosition = transform.position;
		newPosition.x += speed * direction * Time.deltaTime;
		transform.position = newPosition;

		if (Camera.main.WorldToScreenPoint (transform.position).x > Screen.width) {
			direction = -1;
			newPosition = transform.position;
			//Debug.Log (Camera.main.ScreenToWorldPoint (new Vector3(Screen.width,0,cameraObjectZDiff)).x);
			newPosition.x = Camera.main.ScreenToWorldPoint (new Vector3(Screen.width,0,cameraObjectZDiff)).x;
			newPosition.y -= dropDistance;
			transform.position = newPosition;
		} else if (Camera.main.WorldToScreenPoint (transform.position).x < 0) {
			direction = 1;
			newPosition = transform.position;
			//Debug.Log (Camera.main.ScreenToWorldPoint (new Vector3(Screen.width,0,cameraObjectZDiff)).x);
			newPosition.x = Camera.main.ScreenToWorldPoint (new Vector3(0,0,cameraObjectZDiff)).x;
			newPosition.y -= dropDistance;
			transform.position = newPosition;
		}
	}
}
