using UnityEngine;
using System.Collections;

public class PickupDrop : MonoBehaviour
{
    public float pickupDistance = 5.0f;
    public float holdDistance = 5.0f;
    public bool isHoldingSomething = false;
    public GameObject heldObj;
    
	// Update is called once per frame
	void Update ()
    {
        RaycastHit hitinfo;
        if (!isHoldingSomething)
        {
            if (Physics.Raycast(transform.position, transform.forward, out hitinfo, pickupDistance))
            {
                if (Input.GetMouseButtonDown(0))
                {
                    if (hitinfo.collider.tag == "Interactive")
                    {
                        hitinfo.collider.transform.parent = transform.parent;
                        hitinfo.collider.GetComponent<Rigidbody>().isKinematic = true;
                        Vector3 newPosition = transform.position;
                        newPosition += transform.forward * holdDistance;
                        hitinfo.collider.transform.position = newPosition;
                        heldObj = hitinfo.collider.gameObject;
                        isHoldingSomething = !isHoldingSomething;
                    }
                }
                Debug.Log("looking at " + hitinfo.collider);
            }
        }
        else
        {
            Vector3 newPosition = transform.position;
            newPosition += transform.forward * holdDistance;
            heldObj.gameObject.transform.position = newPosition;
            if (Input.GetMouseButtonDown(0))
            {
                heldObj.GetComponent<Rigidbody>().isKinematic = false;
                heldObj.transform.parent = null;
                heldObj = null;
                isHoldingSomething = !isHoldingSomething;
            }
        }
	}
}
