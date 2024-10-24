using UnityEngine;
using UnityEditor;
public class CrossProductEditor : CommonEditor, IUpdateSceneGUI
{
    public Vector3 m_p;
    public Vector3 m_q;
    public Vector3 m_pxq;

    private SerializedObject obj;
    private SerializedProperty propP;
    private SerializedProperty propQ;
    private SerializedProperty propPXQ;


    [MenuItem("Tools/Chapter 2/Cross Product")]
    public static void ShowWindow()
    {
        GetWindow(typeof(CrossProductEditor), true, "Cross Product");
    }
    private void SetDefaultValues()
    {
        m_p = new Vector3(0.0f, 1.0f, 0.0f);
        m_q = new Vector3(1.0f, 0.0f, 0.0f);
    }

    private void OnEnable()
    {
        if (m_p == Vector3.zero && m_q == Vector3.zero)
        {
            SetDefaultValues();
        }

        obj = new SerializedObject(this);
        propP = obj.FindProperty("m_p");
        propQ = obj.FindProperty("m_q");
        propPXQ = obj.FindProperty("m_pxq");

        SceneView.duringSceneGui += SceneGUI;
    }
    private void OnDisable()
    {
        SceneView.duringSceneGui -= SceneGUI;
    }
    private void OnGUI()
    {
        obj.Update();

        DrawBlockGUI("P", propP);
        DrawBlockGUI("Q", propQ);
        DrawBlockGUI("PXQ", propPXQ);

        if (obj.ApplyModifiedProperties())
        {
            SceneView.RepaintAll();
        }

        if (GUILayout.Button("Reset Values"))
        {
            SetDefaultValues();
        }
    }

    public void SceneGUI(SceneView view)
    {
        
    }
}