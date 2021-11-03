using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    public Material CyanSelectedMaterial;
    public Material DefaultMaterial;

    private Vector3 _mOffset;
    private float _mZCoord;

    public void OnMouseDown()
    {
        _mZCoord = Camera.main.WorldToScreenPoint(this.transform.position).z;
        _mOffset = this.transform.position - GetMouseWorldPosition();
        GameManager.Instance.SelectedObject = this.gameObject;
        GameManager.Instance.SaveCommand();
        DefaultMaterial = this.GetComponent<MeshRenderer>().material;
        this.GetComponent<MeshRenderer>().material = CyanSelectedMaterial;
    }

    public void OnMouseUp()
    {
        this.GetComponent<MeshRenderer>().material = DefaultMaterial;
    }

    public void OnMouseDrag()
    {
        transform.position = GetMouseWorldPosition() + _mOffset;
    }

    private Vector3 GetMouseWorldPosition()
    {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = _mZCoord;
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }
}