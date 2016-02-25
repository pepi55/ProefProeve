using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomEditor(typeof(EnemySpawner))]
public class EnemySpawnerEditor : Editor
{
    void OnSceneGUI()
    {
        EnemySpawner t = (EnemySpawner)target;

        EditorGUI.BeginChangeCheck();
        Vector3 pos1 = Handles.FreeMoveHandle(t.transform.position + t.spawnMax, Quaternion.identity, .5f, new Vector3(.5f, .5f, .5f), Handles.RectangleCap);
        Vector3 pos2 = Handles.FreeMoveHandle(t.transform.position + t.spawnMin, Quaternion.identity, .5f, new Vector3(.5f, .5f, .5f), Handles.RectangleCap);
        if (EditorGUI.EndChangeCheck())
        {
            Undo.RecordObject(target, "Free Move LookAt Point");
            t.spawnMax = pos1 - t.transform.position;
            t.spawnMin = pos2 - t.transform.position;
            //t.Update();
        }
    }
}
