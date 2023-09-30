using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hide : MonoBehaviour
{
    private MeshRenderer m_Renderer;
    // Start is called before the first frame update
    void Awake()
    {
        m_Renderer = GetComponent<MeshRenderer>();
        PlayerPrefs.SetInt("hiding", 0);
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("found "+other.gameObject.tag);
        if (m_Renderer.sharedMaterial == other.GetComponent<MeshRenderer>().sharedMaterial && other.tag == "PaintWall"|| other.tag == "SafeZone")
        {
            Debug.Log("Player is Hiding");
            PlayerPrefs.SetInt("isHiding", 1);
        }
       
    }

    private void OnTriggerExit(Collider other)
    {
        MeshRenderer mat = other.GetComponent<MeshRenderer>();
        if ((m_Renderer.sharedMaterial == other.GetComponent<MeshRenderer>().sharedMaterial && other.tag == "PaintWall") || other.tag == "SafeZone")
        {
            Debug.Log("Player is Visble");
            PlayerPrefs.SetInt("isHiding", 0);
        }
    }
}
