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
    // Start is called before the first frame update
    void Start()
    {
       
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Item")
        {
           itemDetect = other.attachedRigidbody;

        }
         
    }

        // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (!handObject)
            {
                    handObject = itemDetect;
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

        }   
    }
}
