using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objects
{
    public string Name;
    public Vector3 Position;
    public Color MaterialColor;

    public Objects(Vector3 pos, Color color, string name)
    {
        MaterialColor = color;
        Position = pos;
        Name = name;
    }
}