// COMP30019 - Graphics and Interaction
// (c) University of Melbourne, 2022

using UnityEngine;

public class Triangle : SceneEntity
{
    [SerializeField] private Vector3 v1, v2, v3;
    

    public override RaycastHit? Intersect(Ray ray)
    {
        // By default we use the Unity engine for ray-entity collisions.
        // See the parent 'SceneEntity' class definition for details.
        // Task: Replace with your own intersection computations.
        var normal = (v2-v1).Cross(v3-v2);
        var denom = Vector3.Dot(ray.direction,normal);

        if (Mathf.Abs(denom) > float.Epsilon) {
            var t = - (Vector3.Dot(ray.origin,normal) + Vector3.Dot(normal,v1))/denom;

            if (t>float.Epsilon) {
                var hitPos = ray.GetPoint(t);
                if (rayInTriangle(hitPos)) {
                    return new RaycastHit {
                    distance = (hitPos-ray.origin).magnitude
                    };
                };
            }
        }
        
        
        return null;
    }
    
    public Vector3[] Vertices()
    {
        return new[] { this.v1, this.v2, this.v3 };
    }

    private bool rayInTriangle(Vector3 P) {
        Vector3 edge1 = v2-v1;
        Vector3 edge2 = v3-v2;
        Vector3 edge3 = v1-v3;
        Vector3 C1 = P-v1;
        Vector3 C2 = P-v2;
        Vector3 C3 = P-v3;

        if (Vector3.Dot(normal, Vector3.Cross(edge1,C1)) > 0 &&
            Vector3.Dot(normal, Vector3.Cross(edge2,C2)) > 0 &&
            Vector3.Dot(normal, Vector3.Cross(edge3,C3)) > 0 ) {
                return true;
            }
        return false;    

    }
}
