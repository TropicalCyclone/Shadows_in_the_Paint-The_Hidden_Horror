using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveTrigger : MonoBehaviour
{
    [SerializeField] private SaveSystem _system = SaveSystem.Instance;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            _system.SavePlayerPosition();
            Destroy(gameObject);
        }
    }
}
