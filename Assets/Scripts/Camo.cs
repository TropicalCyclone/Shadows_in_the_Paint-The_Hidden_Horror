using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camo : MonoBehaviour
{
    Paint LastPaint;
    Paint paint;
    [SerializeField]
    Transform hand;
    Material playerMat;
    MeshRenderer playerRenderer;
    // Start is called before the first frame update
    void OnEnable()
    {

        playerMat = GetComponent<MeshRenderer>().material;
        playerRenderer = GetComponent<MeshRenderer>();  
    }

    // Update is called once per frame
    void Update()
    {
        
        paint = hand.GetComponentInChildren<Paint>();
        if (LastPaint != paint)
        {
            if (paint)
            {
                SetPaint(paint.PaintColor);
            }
            else
            {
                SetPaint(playerMat);
            }
            LastPaint = paint;
        }
        if (!paint)
        {
            SetPaint(playerMat);
        }
        
    }

    void SetPaint(Material material)
    {
        playerRenderer.material = material;
    }
}
 
