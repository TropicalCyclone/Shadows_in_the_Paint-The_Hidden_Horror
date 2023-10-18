using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Paint : BaseItem, IPaintMaterial
{
    [SerializeField]
    public Material PaintColor;
    [SerializeField]
    private MeshRenderer paintLiquid;

    private void OnEnable()
    {
        if(paintLiquid != null)
        PaintBucket(PaintColor);
        SetBool(true);
        SetPaint(this);
    }

    public Material GetPaintColor()
    {
        return PaintColor;
    }

    public Material GetSharedPaintMaterial()
    {
        return paintLiquid.sharedMaterial;
    }
    void PaintBucket(Material material)
    {
        paintLiquid.material = material;
    }

    public void SetMaterial(Material material)
    {
        paintLiquid.material = material;
    }
}
