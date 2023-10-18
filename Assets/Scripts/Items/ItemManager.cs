using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    [SerializeField]
    private HashSet<BaseItem> items = new(); 
   
    Transform[] SpawnPoints;
    GameObject Go;
    // Start is called before the first frame update
    void Start()
    {
        Go = gameObject;

        foreach(Transform child in transform)
        { 
            items.Add(child.gameObject.GetComponentInChildren<BaseItem>());
        }
    }

    public HashSet<BaseItem> GetItems()
    {
        return items;
    }

    // Update is called once per frame
    void Update()
    {
   
    }

    private void OnTransformChildrenChanged()
    {
        
    }
}
