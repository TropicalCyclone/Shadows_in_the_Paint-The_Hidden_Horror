using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camo : MonoBehaviour
{
    [SerializeField] private Material _playerMat;
    [SerializeField] private PlayerGrab _playerGrab;
    private MeshRenderer _playerRenderer;
    private Paint _paintContainer;
    private BaseItem _lastBaseItem;
    private Material _paint;
    // Start is called before the first frame update
    void OnEnable()
    {
        _playerRenderer = GetComponent<MeshRenderer>();  
    }

    // Update is called once per frame
    void Update() 
    {
        BaseItem baseItem = _playerGrab.GetHandBaseItem();
        if (baseItem && baseItem.isPaint())
        {
            _paintContainer = _playerGrab.GetHandBaseItem().GetPaint();
            _paint = _paintContainer.GetPaintColor();
            
        }

        if (baseItem != _lastBaseItem)
        {
            //Debug.Log("Paint!");
            _lastBaseItem = baseItem;
            if (!baseItem)
            {
                SetPaint(_playerMat);
                //Debug.Log("Return Material");
                return;
            }
            SetPaint(_paint);
            //Debug.Log("Set Material");
        }


    }

        void SetPaint(Material material)
    {
        _playerRenderer.material = material;
    }
}
 
