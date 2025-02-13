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
        
        var normal  = Vector3.Cross(v2-v1,v3-v2);
        var denom = Vector3.Dot(ray.direction,normal);
        var c1 = (v1.x+v2.x+v3.x)/3;
        var c2 = (v1.y +v2.y +v3.y)/3;
        var c3 = (v1.z +v2.z +v3.z)/3;
        
        var center = new Vector3(c1,c2,c3);
        if (Mathf.Abs(denom) > float.Epsilon) {
            var t = Vector3.Dot(center-ray.origin,normal)/denom;

            if (t>float.Epsilon) {
        
                var hitPos = ray.GetPoint(t);
                if (rayInTriangle(hitPos, normal)) {
                    
                    return new RaycastHit{
                        distance = (hitPos-center).magnitude
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

    private bool rayInTriangle(Vector3 P, Vector3 normal) {
        var edge1 = v2-v1;
        var edge2 = v3-v2;
        var edge3 = v1-v3;
        var C1 = P-v1;
        var C2 = P-v2;
        var C3 = P-v3;

        if (Vector3.Dot(normal, Vector3.Cross(edge1,C1)) > 0 &&
            Vector3.Dot(normal, Vector3.Cross(edge2,C2)) > 0 &&
            Vector3.Dot(normal, Vector3.Cross(edge3,C3)) > 0 ) {
                return true;
            }
        return false;
    }
   
}


