using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class MyFirstCustomWidow : EditorWindow
{
    [MenuItem("Window/UI Toolkit/MyFirstCustomWidow")]
    public static void ShowExample()
    {
        MyFirstCustomWidow wnd = GetWindow<MyFirstCustomWidow>();
        wnd.titleContent = new GUIContent("MyFirstCustomWidow");
    }

    public void CreateGUI()
    {
        // Each editor window contains a root VisualElement object
        VisualElement root = rootVisualElement;

        // VisualElements objects can contain other VisualElement following a tree hierarchy.
        VisualElement label = new Label("Hello World! From C#");
        root.Add(label);

    }
}
