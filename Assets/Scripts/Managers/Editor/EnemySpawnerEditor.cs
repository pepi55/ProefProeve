// Created by: Jesse Stam.
// Date: 07/03/2016

using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(EnemySpawner))]
public class EnemySpawnerEditor : Editor
{
	protected void OnSceneGUI()
	{
		EnemySpawner t = (EnemySpawner)target;

		EditorGUI.BeginChangeCheck();
		Vector3 pos1 = Handles.FreeMoveHandle(t.transform.position + t.SpawnMax, Quaternion.identity, .5f, new Vector3(.5f, .5f, .5f), Handles.RectangleCap);
		Vector3 pos2 = Handles.FreeMoveHandle(t.transform.position + t.SpawnMin, Quaternion.identity, .5f, new Vector3(.5f, .5f, .5f), Handles.RectangleCap);
		if (EditorGUI.EndChangeCheck())
		{
			Undo.RecordObject(target, "Free Move LookAt Point");
			t.SpawnMax = pos1 - t.transform.position;
			t.SpawnMin = pos2 - t.transform.position;
			//t.Update();
		}
	}
}
