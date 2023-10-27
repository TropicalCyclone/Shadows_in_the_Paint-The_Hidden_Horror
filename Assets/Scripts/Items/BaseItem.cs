using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseItem : MonoBehaviour
{
    [SerializeField]
    private int id;
    [SerializeField]
    private string itemName;
    [SerializeField]
    [TextArea]
    private string description;
    [SerializeField]
    private GameObject door;
    [SerializeField]
    private Sprite itemImage;
    private GameObject itemGameObject;
    [SerializeField]
    private Rigidbody itemRigidbody;
    [SerializeField]
    private Collider itemCollider;
    public bool _isPaint;
    [SerializeField]
    private Paint _paint;
    public bool IsPaint { get { return _isPaint; } set { _isPaint = value; } }

    public GameObject GetDoor{get{return door;}}

    private void OnEnable()
    {
        itemGameObject = gameObject;
    }

  public Rigidbody GetItemRigidbody()
    {
        return itemRigidbody;
    }

    public void ToggleRigidBody(bool value)
    {
        if(itemRigidbody != null)
            itemRigidbody.isKinematic = value;
    }
  public Collider GetItemCollider()
    {
        return itemCollider;
    }

    public void SetBool(bool value)
    {
        _isPaint = value;
    }

    public bool isPaint()
    {
        return _isPaint;
    }

    public Paint GetPaint()
    {
        return _paint;
    }

    public void SetPaint(Paint paint)
    {
        _paint = paint;
    }
}

public interface IPaintMaterial
{
    void SetMaterial(Material material);
}