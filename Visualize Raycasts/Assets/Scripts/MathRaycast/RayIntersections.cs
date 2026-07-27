using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayIntersections : MonoBehaviour
{
    // Start is called before the first frame update

    public Vector3 rayStart = Vector3.zero;
    public Vector3 rayDirection = new Vector3(0,0,1);
    public float rayLength = 5f;

    public GameObject sphere;

    public GameObject plane;

    float radius;
    Vector3 sphereCenter;

    Vector3 planePoint;

    Vector3 planeNormal;
    void Start()
    {
        rayStart = transform.position;
        radius = sphere.GetComponent<SphereCollider>().radius;
        sphereCenter = sphere.transform.position;

        planePoint = plane.transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        float t1, t2;
        bool isIntersect = RayIntersectsSphereDirect(rayStart, rayDirection, sphereCenter, radius, out t1, out t2);

        if (isIntersect)
        {
            Debug.DrawRay(rayStart, rayDirection * rayLength, Color.green);

        }
        else
        {
            Debug.DrawRay(rayStart, rayDirection * rayLength, Color.red);
        }


        
    }


    bool RayIntersectsSphere(Vector3 rayOrigin, Vector3 rayDirection, Vector3 sphereCenter, float sphereRadius, out float t1, out float t2)
    {
        // Calculate the vector from the ray origin to the sphere center
        Vector3 oc = rayOrigin - sphereCenter;

        // Translate the quadratic equation to code
        float a = Vector3.Dot(rayDirection, rayDirection); // (xD^2 + yD^2 + zD^2)
        float b = 2.0f * Vector3.Dot(oc, rayDirection); // 2 * (xE*xD + yE*yD + zE*zD)
        float c = Vector3.Dot(oc, oc) - sphereRadius * sphereRadius; // (xE^2 + yE^2 + zE^2 - r^2)

        // Discriminant
        float discriminant = b * b - 4 * a * c;

        if (discriminant < 0)
        {
            // No intersection
            t1 = t2 = 0;
            return false;
        }
        else
        {
            // Compute the two possible solutions for t
            float sqrtDiscriminant = Mathf.Sqrt(discriminant);
            t1 = (-b - sqrtDiscriminant) / (2.0f * a);
            t2 = (-b + sqrtDiscriminant) / (2.0f * a);

            Debug.Log($"{t1}    {t2}");

            return true;
        }
    }


    bool RayIntersectsSphereDirect(Vector3 rayOrigin, Vector3 rayDirection, Vector3 sphereCenter, float sphereRadius, out float t1, out float t2)
    {

        float xD = rayDirection.x;
        float yD = rayDirection.y;
        float zD = rayDirection.z;

        float xE = rayOrigin.x - sphereCenter.x;
        float yE = rayOrigin.y - sphereCenter.y;
        float zE = rayOrigin.z - sphereCenter.z;

        float a = xD * xD + yD * yD + zD * zD; // Same as Vector3.Dot(rayDirection, rayDirection)
        float b = 2.0f * (xE * xD + yE * yD + zE * zD); // Same as 2.0f * Vector3.Dot(oc, rayDirection)
        float c = xE * xE + yE * yE + zE * zE - sphereRadius * sphereRadius; // Same as Vector3.Dot(oc, oc) - sphereRadius * sphereRadius

        // Discriminant
        float discriminant = b * b - 4 * a * c;

        if (discriminant < 0)
        {
            // No intersection
            t1 = t2 = 0;
            return false;
        }
        else
        {
            // Compute the two possible solutions for t
            float sqrtDiscriminant = Mathf.Sqrt(discriminant);
            t1 = (-b - sqrtDiscriminant) / (2.0f * a);
            t2 = (-b + sqrtDiscriminant) / (2.0f * a);

            Debug.Log($"{t1}    {t2}");

            return true;
        }
    }

    public static bool RayIntersectsPlane(Vector3 rayOrigin, Vector3 rayDirection, Vector3 planePoint, Vector3 planeNormal, out float t)
    {
        // Calculate the dot product of the ray direction and the plane normal
        float denominator = Vector3.Dot(planeNormal, rayDirection);

        // Check if the ray is parallel to the plane
        if (Mathf.Abs(denominator) < 1e-6)
        {
            // Ray is parallel to the plane, so no intersection
            t = 0f;
            return false;
        }

        // Calculate the vector from the ray origin to a point on the plane
        Vector3 rayToPlane = planePoint - rayOrigin;

        // Calculate the distance along the ray to the intersection point
        t = Vector3.Dot(rayToPlane, planeNormal) / denominator;

        

        // Check if the intersection is in the forward direction of the ray
        return t >= 0;
    }

}
