using UnityEngine;

public class VisualizeAABBOBB : MonoBehaviour
{

    public bool AABB = true;


    private void OnDrawGizmos()
    {
        if (AABB)
        {
            // Get the renderer component attached to this object
            Renderer renderer = GetComponent<Renderer>();

            if (renderer != null)
            {
                // Renderer.bounds gives you the world-space AABB
                Bounds bounds = renderer.bounds;


                Gizmos.color = Color.green;
                Gizmos.DrawWireCube(bounds.center, bounds.size);
                Gizmos.color = new Color(0, 1, 0, 0.2f);
                Gizmos.DrawCube(bounds.center, bounds.size);
            }
        }

        else {
            
            MeshFilter meshFilter = GetComponent<MeshFilter>();

            if (meshFilter != null && meshFilter.sharedMesh != null)
            {
                // sharedMesh.bounds gives the local unrotated bounding box of the geometry
                Bounds localBounds = meshFilter.sharedMesh.bounds;

                Matrix4x4 previousMatrix = Gizmos.matrix;
                Gizmos.matrix = transform.localToWorldMatrix;

                Gizmos.color = Color.cyan;
                Gizmos.DrawWireCube(localBounds.center, localBounds.size);

                Gizmos.color = new Color(0, 1, 1, 0.2f);
                Gizmos.DrawCube(localBounds.center, localBounds.size);

                Gizmos.matrix = previousMatrix;
            }

        }
        
    }
}
