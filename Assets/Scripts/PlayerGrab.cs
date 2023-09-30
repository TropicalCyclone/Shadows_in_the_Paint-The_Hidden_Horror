using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGrab : MonoBehaviour
{
    [SerializeField]
    private Transform hand;
    [SerializeField]
    private bool keyDown;
    [SerializeField]
    Rigidbody handObject;
    Rigidbody itemDetect;
    GameObject[] paintBuckets;
    float pickupDistance;
    float pickupMaximum = 2f;
    float distance;
    // Start is called before the first frame update
    void Awake()
    {
        paintBuckets = GameObject.FindGameObjectsWithTag("Item");
    }

        // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            pickupDistance = 2f;
            
                    if (!handObject)
                    {
                        handObject = PickCliosestObject();
                        handObject.isKinematic = true;
                        handObject.transform.parent = hand;
                        handObject.transform.localPosition = Vector3.zero;
                        handObject.transform.localRotation = Quaternion.identity;
                        handObject.GetComponent<Collider>().enabled = false;
                    }
                    else
                    {
                        handObject.GetComponent<Collider>().enabled = true;
                        handObject.isKinematic = false;
                        handObject.transform.parent = null;
                        handObject = null;
                    }
                    pickupDistance = distance;
                
            
        }   
    }
    Rigidbody PickCliosestObject()
    {
    pickupDistance =  pickupMaximum;
    foreach (GameObject paintBucket in paintBuckets)
    {
        distance = Vector3.Distance(transform.position, paintBucket.transform.position);
        if (distance < pickupDistance)
        {
                pickupDistance = distance;
                itemDetect = paintBucket.GetComponent<Rigidbody>();
        }
    }
        return itemDetect;
    }
}


