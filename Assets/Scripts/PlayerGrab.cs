using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGrab : MonoBehaviour
{
    [SerializeField]
    private Transform hand;
    private bool Grabbed = false;
    private bool keyDown;
    [SerializeField]
    GameObject handObject;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    private void OnTriggerStay(Collider other)
    {
        
        if (!Grabbed)
        {
            if (other.tag == "Item")
            {
                if (keyDown)
                {
                    Rigidbody rb = other.GetComponent<Rigidbody>();
                    rb.isKinematic = true;
                    other.transform.parent = hand;
                    other.transform.localPosition = Vector3.zero;
                    other.transform.localRotation = Quaternion.identity;
                    handObject = other.gameObject;
                    if (hand.GetComponentInChildren<Rigidbody>().tag == "Item")
                    {
                        
                        Grabbed = true;
                    }
                }

            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
               
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        keyDown = Input.GetKey(KeyCode.E);

        
        
        if (Grabbed && keyDown)
        {
            handObject.GetComponent<Rigidbody>().isKinematic = false;
            handObject.transform.parent = null;
            Grabbed = false;
        }
    }
}
