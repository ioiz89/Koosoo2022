using System;
using UnityEditor;
using UnityEditor.EditorTools;
using UnityEngine;

#if UNITY_EDITOR

public class PlacePoleEditor : EditorWindow
{
    
    private Vector3 originPos = new Vector3(-6.19f, 0, -9.8f);
    private Vector3 originSize = new Vector3(1.2f, 1.2f, 1.2f);

    private int horizontal = 8;
    private int vertical = 8;
    private float distance = 1.8f;

    public UnityEngine.Object source;

    [MenuItem("Window/Pole/Add Poles")]
    private static void Init()
    {
        PlacePoleEditor window = (PlacePoleEditor)GetWindow(typeof(PlacePoleEditor));
        window.Show();
        window.titleContent.text = "Pole Creator";
        window.minSize = new Vector2(340f, 300f);
        window.maxSize = new Vector2(340f, 500f);
    }

    void OnGUI()
    {
        // ±½Àº ±Û¾¾ 
        Color originColor = EditorStyles.boldLabel.normal.textColor;
        EditorStyles.boldLabel.normal.textColor = Color.yellow;

        // Header =====================================================================
        GUILayout.Space(10f);
        GUILayout.Label("Header Label", EditorStyles.boldLabel);

        originPos = EditorGUILayout.Vector3Field("first pole Position", originPos);
        originSize = EditorGUILayout.Vector3Field("pole Size", originSize);

        // ============================================================================
        GUILayout.Space(10f);
        GUILayout.Label("Horizontal", EditorStyles.boldLabel);
        // Horizontal =================================================================
        GUILayout.BeginVertical();

        distance = EditorGUILayout.FloatField("Pole Distance", distance);
        horizontal = EditorGUILayout.IntField("Horizontal Pole Count", horizontal);
        vertical = EditorGUILayout.IntField("Vertical Pole Count", vertical);

        GUILayout.EndVertical();

        // Horizontal =================================================================
        GUILayout.BeginHorizontal();

        GUILayout.Label("Label Left");
        GUILayout.Label("Label Right");

        GUILayout.EndHorizontal();
        // ============================================================================

        EditorStyles.boldLabel.normal.textColor = originColor;
        
        source = EditorGUILayout.ObjectField(source, typeof(UnityEngine.Object), true);

        if (GUILayout.Button("Proceed"))
        {
            AddPoles();
        }
    }

    private void AddPoles()
    {
        if (!source)
            return;
        var parents = new GameObject();
        parents.name = "PoleGrp";
        var currZpos = originPos.z;
        for (int i = 0; i < horizontal; i++)
        {
            currZpos = originPos.z + (distance * i);
            for (int j = 0; j < vertical; j++)
            {
                var pos = new Vector3(originPos.x + (distance * j), originPos.y, currZpos);
                var pole = (GameObject)GameObject.Instantiate(source);
                pole.transform.position = pos;
                pole.transform.localScale = originSize;
                pole.name = $"pole_{i}_{j}";
                pole.transform.SetParent(parents.transform);
            }
        }
    }


}

#endif