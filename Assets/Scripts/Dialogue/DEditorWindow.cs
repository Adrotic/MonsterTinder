using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;
using UnityEngine.UIElements;

public class DEditorWindow : EditorWindow
{
    [MenuItem("Graph/Dialogue Graph")]
    public static void Open()
    {
        GetWindow<DEditorWindow>("Dialogue Graph");
    }

    private void OnEnable()
    {
        AddGraphView();
    }

    private void AddGraphView()
    {
        DGraphView graphView = new DGraphView();
        graphView.StretchToParentSize();
        rootVisualElement.Add(graphView);
    }
}
