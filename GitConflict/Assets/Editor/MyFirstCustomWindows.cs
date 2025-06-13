using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class MyFirstCustomWindows : EditorWindow
{
    [MenuItem("XR25/Tools/MyFirstCustomWindows")]
    public static void ShowExample()
    {
        MyFirstCustomWindows wnd = GetWindow<MyFirstCustomWindows>();
        wnd.titleContent = new GUIContent("MyFirstCustomWindows");
    }

    public void CreateGUI()
    {
        // Each editor window contains a root VisualElement object
        VisualElement root = rootVisualElement;

        // VisualElements objects can contain other VisualElement following a tree hierarchy.
        VisualElement label = new Label("Hello World! From C#");
        VisualElement label2 = new Label("Hello World from Nath");
        Button SayHelloButton = new Button();
     
        SayHelloButton.clicked += Onclick;
        root.Add(label);
        root.Add(label2);

    }

    private void Onclick()
    {
        Debug.Log("Onclick");
    }
}
