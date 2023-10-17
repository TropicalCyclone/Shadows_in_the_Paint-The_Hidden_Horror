using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hide : MonoBehaviour
{
    [SerializeField] private MeshRenderer meshRenderer;

    [SerializeField] private Material originalColor;
    [SerializeField] private PlayerGrab playerGrab;
    private Paint paintColor;
    private string[] tags = new string[2] { "SafeZone", "PaintWall" };


    private void Awake()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (playerGrab && playerGrab.GetHandBaseItem())
        {
            paintColor = playerGrab.GetHandBaseItem().GetPaint();
        }
        else
        {
            paintColor = null;
        }

            if (paintColor && (other.tag == tags[1] && paintColor.GetPaint().GetPaintColor().color == other.GetComponent<MeshRenderer>().material.color) || other.tag == tags[0]) 
        {
            HidePlayer();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (paintColor && other.tag == tags[1] || other.tag == tags[0])
        {
            ShowPlayer();
        }
    }

    private void setColor(Color inputColor)
    {
        meshRenderer.material.color = inputColor;
    }

    public void HidePlayer()
    {
        if (paintColor)
        {
            originalColor = paintColor.GetPaintColor();
            Color color = originalColor.color;
            Debug.Log("Player is Hiding");
            PlayerPrefs.SetInt("isHiding", 1);
            color.a = 0.5f;
            meshRenderer.material.SetColor("_BaseColor", color);
        }
    }

    public void ShowPlayer()
    {
        Debug.Log("Player is Visible");
        PlayerPrefs.SetInt("isHiding", 0);
        meshRenderer.material = originalColor;
    }
}

