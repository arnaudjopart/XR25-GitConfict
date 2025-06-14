using Unity.VisualScripting;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.UIElements;

public class MyFirstCustomWindow : EditorWindow
{
    private Label _label;
    private Label _nbOfGameObjects;

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
        Button deleteGameObjectButton = new Button
        {
            text = "Delete Me"
        };
        deleteGameObjectButton.clicked += () =>
        {
            if (Selection.activeGameObject != null)
            {
                var objectsToDelete = Selection.gameObjects;
                foreach (var obj in objectsToDelete)
                {
                    Undo.DestroyObjectImmediate(obj);
                }
            }
            else
            {
                Debug.Log("No Object Selected");
            }
        };

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

        Button deleteButton = new Button
        {
            text = "Delete Selected Object"
        };
        // Register a callback to be called when the button is clicked
        deleteButton.clicked += Delete;
        var _label2 = new Label("Click the button delete of the selected GameObject to white.");

        root.Add(sayHelloButton);
        
        
        Button createPrefabButton = new Button
        {
            text = "Create Prefab"
        };
        createPrefabButton.clicked += CreatePrefabButton;
        
        Button getSceneInfoButton = new Button
        {
            text = "Get Scene Info"
        };
        createPrefabButton.clicked += GetSceneInfo;

        _nbOfGameObjects = new Label("Nb of GameObjects ?");
        root.Add(deleteGameObjectButton);
        root.Add(_label);
        root.Add(RandomRotateButton);

           PrefabUtility.SaveAsPrefabAsset(
               currentGamerObject, "Assets/My Prefabs/My Prefab.prefab", out bool success);
           if(success) Debug.Log("Success");
        }
        else
        {
            Debug.Log("No Object Selected");
        }
    }

    private void DestroySelectedGameObject()
    {
        if (Selection.activeGameObject != null)
        {
            GameObject[] objectsToDelete = Selection.gameObjects;
            foreach (GameObject obj in objectsToDelete)
            {
                Undo.DestroyObjectImmediate(obj);
            }
        }
        else
        {
            Debug.Log("No Object Selected");
        }
        
    }

    private void Delete()
    {
        if (Selection.activeGameObject != null)
        {
            int count = Selection.activeGameObject.gameObject.GetComponentCount();
            Debug.Log("Count: " + count);

            GameObject[] childs = Selection.gameObjects;

            foreach (GameObject child in childs)
            { 
                Debug.Log("Deleted: " + child.name);
                Undo.DestroyObjectImmediate(child);
            }

        }
        else
        {
            Debug.Log("No Object Selected");
        }
    }

    private void CreationAndSavePrebButton()
    {
        if (Selection.activeGameObject != null)
        {
            GameObject currentGameObject = Selection.activeGameObject;
            if (!currentGameObject.TryGetComponent(out TestScript testScript))
            {
                currentGameObject.AddComponent<TestScript>();
            }

            string path = "Assets/My Prefabs/" + Selection.activeGameObject.name + ".prefab";
            GameObject prefab = PrefabUtility.SaveAsPrefabAsset(Selection.activeGameObject, path, out bool success);
            if (success) Debug.Log("Your Prefab Success save. \n Prefab saved at: " + path);
        }
        else
        {
            Debug.Log("No Object Selected");
        }
}
