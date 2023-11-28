using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;


namespace UIToolkitExamples
public class SimpleBindingExample : EditorWindow
{
    TextField m_ObjectNameBinding;

    [MenuItem("Window/UIToolKitExamples/Simple Binding Example")] // creates a dropdown menu - needs a method after this line to run when button is clicked
    public static void ShowDefaultWindow()
    {
        var wnd = GetWindow<SimpleBindingExample>(); //creates a window to display when menu item is clicked
        wnd.titleContent = new GUIContent("Simple Binding"); // sets window title
    }

    public void CreateGUI()
    {
        m_ObjectNameBinding = new TextField("Object Name Binding");
        // Note: the "name" property of a GameObject is "m_Name" in serialization.
        m_ObjectNameBinding.bindingPath = "m_name";
        rootVisualElement.Add(m_ObjectNameBinding);
        OnSelectionChange();
    }

    public void OnSelectionChange()
    {
        GameObject selectedObject = Selection.activeObject as GameObject;
        if (selectedObject != null)
        {
            // Create the SerializedObject from the current selection
            SerializedObject so = new SerializedObject(selectedObject);
            // Bind it to the root of the hierarchy. It will find the right object to bind to.
            rootVisualElement.Bind(so);

            // Alternatively you can instead bind it to the TextField itself.
            // m_ObjectNameBinding.Bind(so);
        }
        else
        {
            // Unbind the object from the actual visual element that was bound.
            rootVisualElement.Unbind();
            // If you bound the TextField itself, you'd do this instead:
            // m_ObjectNameBinding.Unbind();

            // Clear the TextField after the binding is removed
            m_ObjectNameBinding.value = "";
        }
    }




    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
