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
            if (_unlockable && _item && door)
            {

              
                        foreach (GameObject doors in _item.GetDoor)
                        {

                        Destroy(doors.gameObject);
                        }
                    
                    _itemManager.RemoveItem(_item);
                    _uiManager.SetGrabVisual(false);
                    Destroy(_item.gameObject);
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        
        if(other.gameObject.tag == "Door")
        {
            _item = _playerGrab.GetHandBaseItem();
            door = other.gameObject;
            if (_item && door)
            {

                if (CheckDoors(_item))
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
            else
            {
                Debug.Log("NO item or door");
                _unlockable = false;
            }
        }
        
    }


    public bool CheckDoors(BaseItem Input)
    {
        if (_item)
        {
            foreach (GameObject doors in Input.GetDoor)
            {
                if (door == doors)
                {
                    return true;
                }
            }
        }
        return false;
            
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Door")
        {
            if (door)
            {
                if (CheckDoors(_item))
                {
                    door = null;
                    _uiManager.SetGrabVisual(false);
                }
            }
            else
            {
                _uiManager.SetGrabVisual(false);
            }

            _unlockable = false;
        }
    }
}
