using UnityEditor;
using UnityEngine;
using UnityEditor.UIElements;
using UnityEngine.UIElements;


public class SimpleBindingExample : EditorWindow
{
    TextField m_ObjectNameBinding;
    Button m_ButtonBinding;
    Button m_ButtonBinding2;

    [MenuItem("Window/UIToolkitExamples/Simple Binding Example")]
    public static void ShowDefaultWindow()
    {
        var wnd = GetWindow<SimpleBindingExample>();
        wnd.titleContent = new GUIContent("Simple Binding");
    }

    public void CreateGUI()
    {
        m_ObjectNameBinding = new TextField("Object Name Binding");
        // Note: the "name" property of a GameObject is "m_Name" in serialization.
        m_ObjectNameBinding.bindingPath = "m_Name";
        rootVisualElement.Add(m_ObjectNameBinding);

        
        //EditorGUILayout.BeginHorizontal();
        
        m_ButtonBinding = new Button();
        m_ButtonBinding.text = "First Person Character Controller";
        m_ButtonBinding.clicked += TaskOnClick;
        rootVisualElement.Add(m_ButtonBinding);
        
        //EditorGUILayout.Space(1);

        m_ButtonBinding2 = new Button();
        m_ButtonBinding2.text = "button2";
        m_ButtonBinding2.clicked += TaskOnClick;
        rootVisualElement.Add(m_ButtonBinding2);
        //EditorGUILayout.EndHorizontal();
        
        //OnSelectionChange();

        //EditorGUILayout.BeginHorizontal("box");

        if(GUILayout.Button("This button 1", EditorStyles.toolbarButton))
        {
            Debug.Log("Activate first person contoller TBD");
        }
        if (GUILayout.Button("This button 2", EditorStyles.toolbarButton))
        {
            Debug.Log("button pressed 2");
        }

        //EditorGUILayout.EndHorizontal();

    }

    void TaskOnClick()
    {
        Debug.Log("button pressed");
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
}
