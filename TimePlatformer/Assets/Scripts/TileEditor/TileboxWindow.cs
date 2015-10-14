using UnityEngine;
using UnityEditor;
using System.Collections;

public class TileboxWindow : EditorWindow
{
    Grid grid;
   
    public int selectedTile;
    [MenuItem("Window/Tile Placement Toolbox")]
    static void Init()
    {
        TileboxWindow window = EditorWindow.GetWindow<TileboxWindow>();
        window.grid = FindObjectOfType<Grid>();

        window.Show();
        SceneView.onSceneGUIDelegate = window.GridUpdate;
    }

    public void OnDestroy()
    {
        SceneView.onSceneGUIDelegate = null;
    }

    private void GridUpdate(SceneView sceneview)
    {
        Event e = Event.current;

        if (e.type == EventType.KeyUp && e.keyCode == KeyCode.A)
        {
            GameObject obj;
            Ray r = Camera.current.ScreenPointToRay(new Vector3(e.mousePosition.x, -e.mousePosition.y + Camera.current.pixelHeight));
            Vector3 mousePos = r.origin;
            Vector3 aligned = new Vector3(Mathf.Floor(mousePos.x / grid.width) * grid.width + grid.width / 2.0f,
                                  Mathf.Floor(mousePos.y / grid.height) * grid.height + grid.height / 2.0f, 0.0f);
            Object prefab = grid.tileTypes[selectedTile].prefab;

            if (prefab)
            {
                Undo.IncrementCurrentGroup();
                obj = (GameObject)PrefabUtility.InstantiatePrefab(prefab);
                obj.transform.position = aligned;
                Undo.RegisterCreatedObjectUndo(obj, "Create " + obj.name);
            }
        }
    }

    void OnGUI()
    {
        if (grid == null) return;
        for (int i = 0; i < grid.tileTypes.Count; ++i)
        {
            selectedTile = GUILayout.Button(grid.tileTypes[i].name, GUILayout.Width(255)) ? i : selectedTile;
        }

        GUILayout.Label("\n\n If shit's broke, this might fix it! ");
        if (GUILayout.Button("Fix the bug", GUILayout.Width(255)))
        {
            SceneView.onSceneGUIDelegate = GridUpdate;
        }

        Debug.Log("Selected Tile is: " + grid.tileTypes[selectedTile].name);
    }

}