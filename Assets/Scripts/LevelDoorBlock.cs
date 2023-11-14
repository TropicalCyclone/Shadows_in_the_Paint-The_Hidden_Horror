using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelDoorBlock : MonoBehaviour
{
    [SerializeField] private GameObject door;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            door.SetActive(false);
        }

    }
}
