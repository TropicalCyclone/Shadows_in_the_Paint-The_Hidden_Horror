using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsSceneTrigger : MonoBehaviour
{
    [SerializeField] private Animator Credits;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Credits.Play("Credits");
        }
    }
}
