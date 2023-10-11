using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseItem : MonoBehaviour
{
    [SerializeField]
    private int id; 
    [SerializeField]
    private string itemName;
    [SerializeField]
    [TextArea]
    private string description;
    [SerializeField]
    private Transform door;
    [SerializeField]
    private Sprite itemImage;
    GameObject itemGameObject;

    private void OnEnable()
    {
        itemGameObject = gameObject;
    }
}
