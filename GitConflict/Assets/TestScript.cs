using UnityEngine;

[SelectionBase]
public class TestScript : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float moveSpeed;
    [Range(0,100)] [SerializeField] [ContextMenuItem("Reset","ResetSpeed")]private int rotationSpeed;
     
    [Space(50)]
    [Header("Character")]
    [SerializeField,Tooltip("Health of player at start")] float health;
    public string name;
    
    [TextArea(10,20), ContextMenuItem("Add placeholder text", "AddText")]
    public string description;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    [ContextMenu("Say Hello")]
    public void SayHello()
    {
        Debug.Log("Hello");
    }

    private void AddText()
    {
        description =
            "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Maecenas sit amet justo arcu. Nunc blandit, sem at tempus tristique, turpis sem posuere ante, vitae gravida odio quam eu metus. Praesent rutrum odio ut lacus mattis, at varius enim dictum. Donec et venenatis dolor. Nunc sit amet ipsum molestie, euismod eros ac, sodales nisi. Suspendisse aliquam dictum semper. Integer bibendum nibh vitae venenatis feugiat. Nulla facilisi. Suspendisse vulputate arcu lectus, vel aliquet ligula scelerisque in. Nulla tincidunt nisi a lectus dapibus, ac accumsan nisi ornare.";
    }
    public void ResetSpeed()
    {
        rotationSpeed = 50;
    }
}
