using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hide : MonoBehaviour
{
    private MeshRenderer m_Renderer;
    Material OriginalColor;
    Color m_Color;
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
            OriginalColor = m_Renderer.sharedMaterial;
            m_Color = m_Renderer.material.color;
            Debug.Log("Player is Hiding");
            PlayerPrefs.SetInt("isHiding", 1);
            m_Color.a = 0.5f;
            m_Renderer.material.SetColor("_BaseColor", m_Color);
        }
       
    }

    void setColor(Color inputColor)
    {
        m_Renderer.material.color = inputColor;
    }

    private void OnTriggerExit(Collider other)
    {
        if ((OriginalColor == other.GetComponent<MeshRenderer>().sharedMaterial && other.tag == "PaintWall") || other.tag == "SafeZone")
        {
            m_Color = m_Renderer.material.color;
            Debug.Log("Player is Visble");
            PlayerPrefs.SetInt("isHiding", 0);
            m_Renderer.material = OriginalColor;
        }
    }
}
