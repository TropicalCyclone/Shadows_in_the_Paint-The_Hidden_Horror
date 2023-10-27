using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : MonoBehaviour
{
    [SerializeField] private ItemManager _itemManager;
    [SerializeField] private PlayerGrab _playerGrab;
    private BaseItem _item;
    private GameObject door;
    private bool _unlockable;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (_unlockable)
            {
                if (door)
                {
                    door.gameObject.SetActive(false);
                }
                if (_item)
                {
                    _itemManager.RemoveItem(_item);
                    Destroy(_item.gameObject);
                }
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        
        if(other.gameObject.tag == "Door")
        {
            if (_playerGrab.GetHandBaseItem())
            {
                _item = _playerGrab.GetHandBaseItem();
            }
            door = other.gameObject;
        }
        else
        {
            door = null;
        }
            if (_item)
        {
            if (other.gameObject == _item.GetDoor)
            {
                _unlockable = true;
                
            }
            else
            {
                _unlockable = false;
            }
        }
    }
}
