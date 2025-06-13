using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class MyFirstCustomWindow : EditorWindow
{
    private Label _label;

    [MenuItem("XR25/Tools/My First Custom Window")]
    public static void ShowExample()
    {
        MyFirstCustomWindow wnd = GetWindow<MyFirstCustomWindow>();
        wnd.titleContent = new GUIContent("MyFirstCustomWindow");
    }

    public void CreateGUI()
    {
        // Each editor window contains a root VisualElement object
        VisualElement root = rootVisualElement;

        // VisualElements objects can contain other VisualElement following a tree hierarchy.
        _label = new Label("Name of Game Object ?");
        Button sayHelloButton = new Button
        {
            text = "Tell me your name"
        };
        sayHelloButton.clicked += OnClick;

        Button RandomRotateButton = new Button();
        RandomRotateButton.text = "Random Rotation";
        RandomRotateButton.clicked += () =>
        {
            if (Selection.activeGameObject != null)
            {
                var transform = Selection.activeGameObject.transform;
                transform.Rotate(0f,  Random.Range(0f, 360f),0);
            }
            else
            {
                Debug.Log("No Object Selected");
            }
        };
        
        root.Add(sayHelloButton);
        root.Add(_label);
        root.Add(RandomRotateButton);

    }

    private void OnClick()
    {
        if (Selection.activeGameObject != null)
        {
            var meshRenderer = Selection.activeGameObject.GetComponent<MeshRenderer>();
            meshRenderer.sharedMaterial.SetColor("_BaseColor", Color.white);
        }
        else
        {
            Debug.Log("No Object Selected");
        }
        
    }
}
