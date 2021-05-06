using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AI.Pathfinding;
using ExtraUnityEvents;

public class TestConnection : PathfindingConnection
{
    public ConnectionView view;

    private LineRenderer line;

    public EventVariable<bool> isPath;

    private Color defaultColor;
    private Color pathColor;

    public TestConnection(LineRenderer _line, bool _isPath, Color _defaultColor, Color _pathColor)
    {
        isPath = new EventVariable<bool>(_isPath);
        isPath += OnIsPathChanged;
        line = _line;
        pathColor = _pathColor;
        defaultColor = _defaultColor;
    }


    private void OnIsPathChanged()
    {
        if(isPath==true)
        {
            line.endColor = pathColor;
            line.startColor = pathColor;
        }
        else
        {
            line.endColor = defaultColor;
            line.startColor = defaultColor;
        }
    }

}
