using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camo : MonoBehaviour
{
    Material LastPaint;
    Material paint;
    [SerializeField]
    Transform hand;
    [SerializeField]
    Material playerMat;
    [SerializeField]
    PlayerGrab playerGrab;
    MeshRenderer playerRenderer;
    // Start is called before the first frame update
    void OnEnable()
    {
        playerRenderer = GetComponent<MeshRenderer>();  
    }

    // Update is called once per frame
    void Update() 
    {
        BaseItem baseItem = playerGrab.GetHandBaseItem();
        if (baseItem && baseItem.isPaint())
        {
            Paint paintContainer = playerGrab.GetHandBaseItem().GetPaint();
            paint = paintContainer.GetPaintColor();
            SetPaint(paint);
        }
        else if(!baseItem)
        {
            SetPaint(playerMat);
        }
        /*
        if (LastPaint != paint)
        {
            if (paint)
            {
               
            }
            else
            {
                SetPaint(playerMat);
            }
            LastPaint = paint;
        }*/
        
    }

    void SetPaint(Material material)
    {
        playerRenderer.material = material;
    }
}
 
