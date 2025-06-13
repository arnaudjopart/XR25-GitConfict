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
        root.Add(createPrefabButton);
        root.Add(getSceneInfoButton);
        
        
    }

    private void GetSceneInfo()
    {
        var currentScene = EditorSceneManager.GetActiveScene();
        var nbOfRootGAmeObject = currentScene.rootCount;
        //_nbOfGameObjects.text = $"Number of GameObject in Scene" nbOfRootGAmeObject.ToString();
    }

    private void CreatePrefabButton()
    {

        if (Selection.activeGameObject != null)
        {
           GameObject currentGamerObject = Selection.activeGameObject;
           if (!currentGamerObject.TryGetComponent(out TestScript testScript))
           {
               currentGamerObject.AddComponent<TestScript>();
           }

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
}
