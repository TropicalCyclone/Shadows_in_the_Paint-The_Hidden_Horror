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
                Debug.Log("detected" + other);
                if (keyDown)
                {
                    Debug.Log("grabbed" + other);
                    Rigidbody rb = other.GetComponent<Rigidbody>();
                    rb.isKinematic = true;
                    other.transform.parent = hand;
                    while (other.transform.localPosition != Vector3.zero)
                    {
                        other.transform.localPosition = Vector3.Lerp(other.transform.localPosition, Vector3.zero, 2f);
                    }
                    other.transform.localRotation = Quaternion.identity;
                    handObject = other.gameObject;
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


        if (hand.GetComponentInChildren<Rigidbody>() != null)
        {
            if (hand.GetComponentInChildren<Rigidbody>().tag == "Item")
            {
                Grabbed = true;
                Debug.Log("grabbed");
            }
        }

        if (Grabbed && keyDown)
        {
            handObject.GetComponent<Rigidbody>().isKinematic = false;
            handObject.transform.parent = null;
            if (!hand.GetComponentInChildren<Rigidbody>())
                Grabbed = false;
        }
    }
}
