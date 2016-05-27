﻿using UnityEngine;
using System.Collections;
using UnityEditor;
using BulletUnity;

[CustomEditor(typeof(BCapsuleShape))]
public class BCapsuleShapeEditor : Editor {

	BCapsuleShape script;
	SerializedProperty radius;
	SerializedProperty height;
    SerializedProperty upAxis;

	void OnEnable() {
		script = (BCapsuleShape)target;
		GetSerializedProperties();
	}

	void GetSerializedProperties() {
		radius = serializedObject.FindProperty("radius");
		height = serializedObject.FindProperty("height");
        upAxis = serializedObject.FindProperty("upAxis");
	}

	public override void OnInspectorGUI() {
		if(script.transform.localScale != Vector3.one) {
			EditorGUILayout.HelpBox("This shape doesn't support scale of the object.\nThe scale must be one", MessageType.Warning);
		}
		EditorGUILayout.PropertyField(radius);
		EditorGUILayout.PropertyField(height);
        EditorGUILayout.PropertyField(upAxis);
		serializedObject.ApplyModifiedProperties();
	}
}
