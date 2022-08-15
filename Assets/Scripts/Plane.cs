// COMP30019 - Graphics and Interaction
// (c) University of Melbourne, 2022

using UnityEngine;

public class Plane : SceneEntity
{
    [SerializeField] private Vector3 center;
    [SerializeField] private Vector3 normal;
    
    public Vector3 Center => this.center;
    public Vector3 Normal => this.normal;
    
    public override RaycastHit? Intersect(Ray ray)
    {
        // By default we use the Unity engine for ray-entity collisions.
        // See the parent 'SceneEntity' class definition for details.
        // Task: Replace with your own intersection computations.
        var denom = Vector3.Dot(ray.direction,normal);

        if (Mathf.Abs(denom) > 0) {
            var t = Vector3.Dot(center-ray.origin,normal)/denom;

            if (Mathf.Abs(t)>0) {
                var hitPos = ray.GetPoint(t);
                return new RaycastHit {
                    distance = (hitPos-center).magnitude
                };
            }
        }
        
        
        return null;
    }
}
