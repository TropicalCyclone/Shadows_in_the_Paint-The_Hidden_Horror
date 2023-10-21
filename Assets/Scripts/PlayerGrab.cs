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
    BaseItem handObject;
    [SerializeField]
    ItemManager itemManager;
    float pickupDistance;
    float pickupMaximum = 2f;
    float distance;
    // Start is called before the first frame update
    void Awake()
    {

    }

    public BaseItem GetHandBaseItem()
    {
        return handObject;
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
                    if (handObject)
                    {
                        handObject.ToggleRigidBody(true);
                        handObject.transform.parent = hand;
                        handObject.transform.localPosition = Vector3.zero;
                        handObject.transform.localRotation = Quaternion.identity;
                        handObject.GetItemCollider().enabled = false;
                    }
                    }
                    else
                    {
                        handObject.GetItemCollider().enabled = true;
                        handObject.ToggleRigidBody(false);
                        handObject.transform.parent = null;
                        handObject = null;
                    }
                    pickupDistance = distance;
                
            
        }   
    }

    BaseItem PickCliosestObject()
    {
        BaseItem itemDetect = null;
        pickupDistance =  pickupMaximum;
        HashSet<BaseItem> Items = itemManager.GetItems();

    foreach (BaseItem item in Items)
    {
        distance = Vector3.Distance(transform.position, item.transform.position);
        if (distance < pickupDistance)
        {
                pickupDistance = distance;
                itemDetect = item;
        }
    }
        return itemDetect;
    }

    
}


