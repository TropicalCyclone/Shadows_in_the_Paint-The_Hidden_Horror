using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hide : MonoBehaviour
{
    [SerializeField] private MeshRenderer _meshRenderer;
    [SerializeField] private Material _originalColor;
    [SerializeField] private PlayerGrab _playerGrab;
    [SerializeField] private bool _isHiding;

    private Paint _paintColor;
    private string[] _tags = new string[2] { "SafeZone", "PaintWall" };

    
    public bool GetStatus { get { return _isHiding; } }

    private void Awake()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (_playerGrab && _playerGrab.GetHandBaseItem())
        {
            _paintColor = _playerGrab.GetHandBaseItem().GetPaint();
        }
        else
        {
            _paintColor = null;
        }

         if (_paintColor && (other.tag == _tags[1] && _paintColor.GetPaint().GetPaintColor().color == other.GetComponent<MeshRenderer>().material.color) || other.tag == _tags[0]) 
        {
            HidePlayer();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (_paintColor && other.tag == _tags[1] || other.tag == _tags[0])
        {
            ShowPlayer();
        }
    }

    private void setColor(Color inputColor)
    {
        _meshRenderer.material.color = inputColor;
    }

    public void HidePlayer()
    {
        if (_paintColor)
        {
            _originalColor = _paintColor.GetPaintColor();
            Color color = _originalColor.color;
            Debug.Log("Player is Hiding");
            _isHiding = true;
            color.a = 0.5f;
            _meshRenderer.material.SetColor("_BaseColor", color);
        }
    }

    public void ShowPlayer()
    {
        if (_isHiding)
        {
            Debug.Log("Player is Visible");
            _isHiding = false;
            _meshRenderer.material = _originalColor;
        }
        _isHiding = false;
    }

}

