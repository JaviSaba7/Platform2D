using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(NewScript))]
public class NewScriptEditor : Editor
{
    SerializedProperty gameobject;
    static bool showProperties = true;
    static bool showBase;

    private void OnEnable()
    {
        gameobject = serializedObject.FindProperty("go");
    }

    public override void OnInspectorGUI()
    {
        NewScript newScript = (NewScript)target;

        showProperties = EditorGUILayout.Foldout(showProperties, "Properties", true, EditorStyles.toolbarDropDown);
        EditorGUILayout.Space();
        EditorGUI.indentLevel = 3;
        if(showProperties)
        {
            EditorGUILayout.BeginVertical(EditorStyles.textField);

            newScript.entero = EditorGUILayout.IntField("Int Value: ", newScript.entero);
            newScript.dec = EditorGUILayout.FloatField("Dec", newScript.dec);
            newScript.frase = EditorGUILayout.TextField("Frase", newScript.frase);
            newScript.isTrue = EditorGUILayout.Toggle("IsTrue?", newScript.isTrue);

            EditorGUILayout.EndVertical();
        }

        EditorGUI.indentLevel = 0;
        EditorGUILayout.PropertyField(gameobject);

        if(GUILayout.Button("Escribir frase"))
        {
            newScript.Write();
        }


        GUIStyle myStyle = new GUIStyle(EditorStyles.boldLabel);

        //Ground
        if(newScript.isTrue) myStyle.normal.textColor = Color.green;
        else myStyle.normal.textColor = Color.red;
        EditorGUILayout.LabelField("IsGrounded", myStyle);
        //justNOTGrounded
        if(newScript.isTrue) myStyle.normal.textColor = Color.green;
        else myStyle.normal.textColor = Color.red;
        EditorGUILayout.LabelField("justNOTGrounded", myStyle);
        //justGrounded
        if(newScript.isTrue) myStyle.normal.textColor = Color.green;
        else myStyle.normal.textColor = Color.red;
        EditorGUILayout.LabelField("justGrounded", myStyle);
        //wasGroundedLastFrame
        if(newScript.isTrue) myStyle.normal.textColor = Color.green;
        else myStyle.normal.textColor = Color.red;
        EditorGUILayout.LabelField("wasGroundedLastFrame", myStyle);
        // isFalling
        if(newScript.isTrue) myStyle.normal.textColor = Color.green;
        else myStyle.normal.textColor = Color.red;
        EditorGUILayout.LabelField(" isFalling", myStyle);


        //Top
        if(newScript.isTrue) myStyle.normal.textColor = Color.green;
        else myStyle.normal.textColor = Color.red;
        EditorGUILayout.LabelField("IsTOP", myStyle);
        //JustTop
        if(newScript.isTrue) myStyle.normal.textColor = Color.green;
        else myStyle.normal.textColor = Color.red;
        EditorGUILayout.LabelField("justTop", myStyle);
        //justNOTTop
        if(newScript.isTrue) myStyle.normal.textColor = Color.green;
        else myStyle.normal.textColor = Color.red;
        EditorGUILayout.LabelField("justNOTTop", myStyle);
        //wasTopLastFrame
        if(newScript.isTrue) myStyle.normal.textColor = Color.green;
        else myStyle.normal.textColor = Color.red;
        EditorGUILayout.LabelField("wasTopLastFrame", myStyle);
        //isOnair
        if(newScript.isTrue) myStyle.normal.textColor = Color.green;
        else myStyle.normal.textColor = Color.red;
        EditorGUILayout.LabelField("isOnair", myStyle);


        //Wall
        if(newScript.isTrue) myStyle.normal.textColor = Color.green;
        else myStyle.normal.textColor = Color.red;
        EditorGUILayout.LabelField("IsWall", myStyle);
        //JustNotWall
        if(newScript.isTrue) myStyle.normal.textColor = Color.green;
        else myStyle.normal.textColor = Color.red;
        EditorGUILayout.LabelField("justNOTWall", myStyle);
        //wasWallLastFrame
        if(newScript.isTrue) myStyle.normal.textColor = Color.green;
        else myStyle.normal.textColor = Color.red;
        EditorGUILayout.LabelField("wasWallLastFrame", myStyle);
        //isOnWall
        if(newScript.isTrue) myStyle.normal.textColor = Color.green;
        else myStyle.normal.textColor = Color.red;
        EditorGUILayout.LabelField("isOnWall", myStyle);
        //DetectWall
        if(newScript.isTrue) myStyle.normal.textColor = Color.green;
        else myStyle.normal.textColor = Color.red;
        EditorGUILayout.LabelField("detectWall", myStyle);

        showBase = EditorGUILayout.Foldout(showBase, "BaseInspector", true, EditorStyles.toolbarDropDown);
        if(showBase) base.OnInspectorGUI();
    }
}