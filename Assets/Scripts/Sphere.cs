// COMP30019 - Graphics and Interaction
// (c) University of Melbourne, 2022

using UnityEngine;
using System;
public class Sphere : SceneEntity
{
    [SerializeField] private Vector3 center;
    [SerializeField] private float radius;
    
    public Vector3 Center => this.center;
    public float Radius => this.radius;
    
    public override RaycastHit? Intersect(Ray ray)
    {
        // By default we use the Unity engine for ray-entity collisions.
        // See the parent 'SceneEntity' class definition for details.
        // Task: Replace with your own intersection computations.
        float x0, x1, q;
        var L = ray.origin-center;
        float a = 1;
        float b = 2*Vector3.Dot(ray.direction,L);
        float c = Vector3.Dot(L,L) - radius*radius;

        // Solve Quadratic
        float discr = b * b - 4 * a * c; 
        if (discr < 0) return null; 
        else if (discr == 0) {
            x0 = x1 = -(float) 0.5 * b / a; 
        } 
        else { 
            if (b > 0) {
                q = (float) -0.5 * (b + MathF.Sqrt(discr));
            } else {    
                q = (float) -0.5 * (b - MathF.Sqrt(discr)); 
            }
            x0 = q / a; 
            x1 = c / q; 
        } 
        if (x1>float.Epsilon) {
            var hitPos = ray.GetPoint(x1);
            return new RaycastHit {
                distance = (hitPos-center).magnitude
            }; 
        }
        /*if (x0 > x1) {
            //(x0,x1) = (x1,x0);
            if (x1>float.Epsilon) {
            var hitPos = ray.GetPoint(x1); 
            return new RaycastHit {
                distance = (hitPos-center).magnitude
            };
        }
         };*/         


        
        
        
        
        return null;
    }
}
