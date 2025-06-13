using System.Collections.Generic;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

public class LocationRandomizerWindow : EditorWindow
{
    private List<Transform> transformList = new List<Transform>();
    private ListView listView;

    [MenuItem("Useless Tools/Location Stuff/Location Randomizer Window")]
    public static void ShowExample()
    {
        LocationRandomizerWindow wnd = GetWindow<LocationRandomizerWindow>();
        wnd.titleContent = new GUIContent("LocationRandomizerWindow");
    }

    public void CreateGUI()
    {
        // Each editor window contains a root VisualElement object
        VisualElement root = rootVisualElement;

        // VisualElements objects can contain other VisualElement following a tree hierarchy.
        VisualElement label = new Label("Put items to randomize here");
        root.Add(label);

        // Create a button to add a new element
        var addButton = new Button(() =>
        {
            transformList.Add(null);
            listView.Rebuild();
            this.Repaint();
        })
        {
            text = "+"
        };
        root.Add(addButton);

        // Create the ListView
        listView = new ListView
        {
            itemsSource = transformList,
            fixedItemHeight = 22,
            makeItem = () =>
            {
                // Create an ObjectField for Transform
                var field = new ObjectField
                {
                    objectType = typeof(Transform),
                    allowSceneObjects = true
                };
                return field;
            },
            bindItem = (element, i) =>
            {
                var field = (ObjectField)element;
                field.value = transformList[i];
                field.RegisterValueChangedCallback(evt =>
                {
                    transformList[i] = evt.newValue as Transform;
                });
            },
            selectionType = SelectionType.None
        };

        root.Add(listView);
                
        Button randomize = new Button(() => {
            foreach (var t in transformList)
            {
                Undo.RecordObject(t, "Randomize Position");
                t.Translate(new Vector3(Random.Range(-10f, 10f), Random.Range(-10f, 10f), Random.Range(-10f, 10f)));
                EditorUtility.SetDirty(t);
            }
        });
        
        randomize.text = "GO";
        root.Add(randomize);
    }
}
