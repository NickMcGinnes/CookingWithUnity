using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class PickupDrop : MonoBehaviour
{
    public float PickupDistance = 2.0f;
    public float holdDistance = 2.0f;

    private bool isHolding = false;

    private GameObject heldGameObject;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (heldGameObject != null)
        {
        }

        RaycastHit hitInfo;
        if (!isHolding)
        {
            if (Physics.Raycast(transform.position, transform.forward, out hitInfo, PickupDistance))
            {
                if (Input.GetMouseButtonDown(0))
                {
                    if (hitInfo.collider.CompareTag("Interactive"))
                    {
                        hitInfo.collider.transform.parent = gameObject.transform.parent;
                        hitInfo.collider.GetComponent<Rigidbody>().isKinematic = true;

                        Vector3 newPos = hitInfo.collider.transform.position;
                        newPos += transform.forward * holdDistance;

                        hitInfo.collider.transform.position = newPos;
                        heldGameObject = hitInfo.collider.gameObject;
                        isHolding = true;
                    }
                }
            }
        }
        else
        {
            if (heldGameObject != null)
            {
                Vector3 newPos = transform.position;
                newPos += transform.forward * holdDistance;
                heldGameObject.transform.position = newPos;
                if (Input.GetMouseButtonDown(0))
                {
                    heldGameObject.GetComponent<Rigidbody>().isKinematic = false;
                    heldGameObject.transform.parent = null;
                    heldGameObject = null;
                    isHolding = false;
                }
            }
        }
    }
}