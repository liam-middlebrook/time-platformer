using UnityEngine;
using System.Collections;

public class Grid : MonoBehaviour
{
    public float width = 1.28f;
    public float height = 1.28f;

    void OnDrawGizmos()
    {
        for(float y = -25.6f; y < 25.6f; y+= height)
        {
            Gizmos.DrawLine(new Vector3(-25.6f, Mathf.Floor(y/height) * height),
                            new Vector3(25.6f, Mathf.Floor(y/height) * height));
        }

        for(float x = -25.6f; x < 25.6f; x+= width)
        {
            Gizmos.DrawLine(new Vector3(Mathf.Floor(x/width) * width, -25.6f),
                            new Vector3(Mathf.Floor(x/width) * width, 25.6f));
        }
    }
}
