using UnityEditor;
using UnityEngine;


public class MyScript : MonoBehaviour
{
    public bool usePlayerMovement;
    public bool usePlayerController;
}


[CustomEditor(typeof(MyScript))]
public class MyScriptEditor : Editor
{
    public MonoScript scriptMovement;
    public MonoScript scriptController;
 
    override public void OnInspectorGUI()
    {
        var pMovement = target as MyScript;


        pMovement.usePlayerMovement =
            GUILayout.Toggle(pMovement.usePlayerMovement, "PlayerMovement");

        if (pMovement.usePlayerMovement) {
            pMovement.usePlayerController = false;
            scriptMovement = EditorGUILayout.ObjectField("Script:", scriptMovement, typeof(MonoScript), false) as MonoScript;
        }


        pMovement.usePlayerController =
            GUILayout.Toggle(pMovement.usePlayerController, "PlayerController");

        if (pMovement.usePlayerController)
        {
            pMovement.usePlayerMovement = false;
            scriptController = EditorGUILayout.ObjectField("Script:", scriptController, typeof(MonoScript), false) as MonoScript;
        }
    }
}