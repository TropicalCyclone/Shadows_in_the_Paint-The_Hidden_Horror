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
    private Paint paintContainer;
    BaseItem lastBaseItem;
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
            paintContainer = playerGrab.GetHandBaseItem().GetPaint();
            paint = paintContainer.GetPaintColor();
            
        }

        if (baseItem != lastBaseItem)
        {
            Debug.Log("Paint!");
            lastBaseItem = baseItem;
            if (!baseItem)
            {
                SetPaint(playerMat);
                Debug.Log("Return Material");
                return;
            }
            SetPaint(paint);
            Debug.Log("Set Material");
        }


    }

        void SetPaint(Material material)
    {
        playerRenderer.material = material;
    }
}
 
