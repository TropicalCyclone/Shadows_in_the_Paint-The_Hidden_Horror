using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGrab : MonoBehaviour
{
    [SerializeField]
    private Transform hand;
    [SerializeField]
    private bool Grabbed = false;
    private bool keyDown;
    [SerializeField]
    Rigidbody handObject;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    private void OnTriggerStay(Collider other)
    {
     
        if (!Grabbed && !handObject)
        {
            if (other.tag == "Item")
            {
                //Debug.Log("detected" + other);
                if (keyDown)
                {
                    //Debug.Log("grabbed" + other);
                    handObject = other.attachedRigidbody;
                    handObject.isKinematic = true;
                    handObject.transform.parent = hand;
                    handObject.transform.localPosition = Vector3.zero;
                    handObject.transform.localRotation = Quaternion.identity;
                    handObject.GetComponent<Collider>().enabled = false;
                    return;
                }
            }
        }

       
        /*else
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
               
            }
        }*/
    }

    // Update is called once per frame
    void Update()
    {
        keyDown = Input.GetKeyDown(KeyCode.E);


        if (handObject)
        {
            if (handObject.tag == "Item")
            {
                Grabbed = true;
                //Debug.Log("grabbed");
            }
        }

        if (Grabbed && keyDown)
        {
            handObject.GetComponent<Collider>().enabled = true;
            handObject.isKinematic = false;
            handObject.transform.parent = null;
            Grabbed = false;
            handObject = null;
            return;
        }
    }
}
