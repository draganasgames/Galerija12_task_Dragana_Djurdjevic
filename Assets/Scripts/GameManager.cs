using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameObject SelectedObject;

    private List<Objects> _objectsBuffer = new List<Objects>();

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            Undo();
        }
    }

    public void SaveCommand()
    {
        var obj = new Objects(SelectedObject.transform.localPosition, SelectedObject.GetComponent<MeshRenderer>().material.color, SelectedObject.name); // SelectedObject.GetComponent<Objects>(); //.SetObject();
        _objectsBuffer.Add(obj);
    }
    public void Undo()
    {
        if (_objectsBuffer.Count > 0)
        {
            var obj = _objectsBuffer[_objectsBuffer.Count - 1];
            var gameObj = GameObject.Find(obj.Name);
            gameObj.transform.localPosition = obj.Position;
            gameObj.GetComponent<MeshRenderer>().material.SetColor("_Color", obj.MaterialColor);
            _objectsBuffer.RemoveAt(_objectsBuffer.Count - 1);
        }
    }

    public void OnRedButtonClicked()
    {
        SaveCommand();
        SelectedObject.GetComponent<MeshRenderer>().material.SetColor("_Color", Color.red);
    }

    public void OnBlueButtonClicked()
    {
        SaveCommand();
        SelectedObject.GetComponent<MeshRenderer>().material.SetColor("_Color", Color.blue);
    }

    public void OnGreenButtonClicked()
    {
        SaveCommand();
        SelectedObject.GetComponent<MeshRenderer>().material.SetColor("_Color", Color.green);
    }
}