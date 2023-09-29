using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Paint : Item
{
    [SerializeField]
    public Material PaintColor;
    [SerializeField]
    private MeshRenderer paintLiquid;

    private void OnEnable()
    {
        if(paintLiquid != null)
        PaintBucket(PaintColor);
    }

    void PaintBucket(Material material)
    {
        paintLiquid.material = material;
    }
}
