using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    [SerializeField]
    public List<BaseItem> items = new List<BaseItem> { }; 
    Transform[] SpawnPoints;
    GameObject Go;
    // Start is called before the first frame update
    void Start()
    {
        Go = gameObject;
        foreach(Transform child in transform)
        {
            BaseItem equalItem = null;
            foreach (BaseItem item in items)
            {
                if(child == item.transform)
                {
                     equalItem = item;
                }
            }
            if (equalItem)
            {
                return;
            }
                
            items.Add(gameObject.GetComponentInChildren<BaseItem>());
        }
    }

    // Update is called once per frame
    void Update()
    {
   
    }

    private void OnTransformChildrenChanged()
    {
        
    }
}
