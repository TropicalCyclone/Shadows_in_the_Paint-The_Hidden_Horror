using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : MonoBehaviour
{
    [SerializeField] private ItemManager _itemManager;
    [SerializeField] private PlayerGrab _playerGrab;
    [SerializeField] private UIManager _uiManager;
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
                
                if (_item)
                {
                    if (door)
                    {
                        foreach (GameObject doors in _item.GetDoor)
                        {
                            Destroy(doors.gameObject);
                        }
                    }
                    _itemManager.RemoveItem(_item);
                    _uiManager.SetGrabVisual(false);
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
        if (_item && door)
        {
            foreach (GameObject doors in _item.GetDoor)
            {
                if (door.gameObject == doors)
                {
                    _uiManager.SetGrabVisual(true);
                    _uiManager.SetText("Open Door");
                    _unlockable = true;
                }
                else
                {
                    _unlockable = false;
                }
            }
        }
        else
        {
            _unlockable = false;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (_item)
        {
            foreach (GameObject doors in _item.GetDoor)
            {
                if (other.gameObject == doors)
                {

                    _unlockable = false;
                    _uiManager.SetGrabVisual(false);
                }
            }
        }
        else
        {
            _unlockable = false;
            _uiManager.SetGrabVisual(false);
        }
    }
}
