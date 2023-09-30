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
        MeshRenderer mat = other.GetComponent<MeshRenderer>();

        if (mat.material == m_Renderer.material && other.CompareTag("PaintWall") || other.CompareTag("SafeZone"))
        {
            PlayerPrefs.SetInt("hiding", 1);
        }
        else
        {
            PlayerPrefs.SetInt("hiding", 0);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        MeshRenderer mat = other.GetComponent<MeshRenderer>();
        if (mat.material == m_Renderer.material)
        {
            PlayerPrefs.SetInt("hiding", 0);
        }
    }
}
