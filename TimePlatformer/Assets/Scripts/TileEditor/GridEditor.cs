using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomEditor (typeof(Grid))]
public class GridEditor : Editor
{
    private Grid grid;

    public void OnEnable()
    {
        grid = (Grid)target;
        SceneView.onSceneGUIDelegate = GridUpdate;
    }

    private void GridUpdate(SceneView sceneview)
    {
        Event e = Event.current;

        if (e.type == EventType.KeyUp && e.character == 'a')
        {
            GameObject obj;
            Ray r = Camera.current.ScreenPointToRay(new Vector3(e.mousePosition.x, -e.mousePosition.y + Camera.current.pixelHeight));
            Vector3 mousePos = r.origin;
            Vector3 aligned = new Vector3(Mathf.Floor(mousePos.x/grid.width)*grid.width + grid.width/2.0f,
                                  Mathf.Floor(mousePos.y/grid.height)*grid.height + grid.height/2.0f, 0.0f);
            Object prefab = PrefabUtility.GetPrefabParent(Selection.activeObject);

            if (prefab)
            {
                Undo.IncrementCurrentGroup();
                obj = (GameObject)PrefabUtility.InstantiatePrefab(prefab);
                obj.transform.position = aligned;
                Undo.RegisterCreatedObjectUndo(obj, "Create " + obj.name);
            }
        }
    }

    public override void OnInspectorGUI()
    {
        GUILayout.BeginHorizontal();
        GUILayout.Label(" Grid Width ");
        grid.width = EditorGUILayout.FloatField(grid.width, GUILayout.Width(50));
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        GUILayout.Label(" Grid Height ");
        grid.height = EditorGUILayout.FloatField(grid.height, GUILayout.Width(50));
        GUILayout.EndHorizontal();

        SceneView.RepaintAll();
    }
}
