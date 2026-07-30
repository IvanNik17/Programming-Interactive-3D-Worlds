using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToRagdoll : MonoBehaviour
{
    public Collider[] AllColliders;
    public Rigidbody[] AllRigidbodies;
    public Collider mainCollider; // only if you have one

    public Transform impactTargetBone;
    void Awake()
    {
        // Get all child colliders and rigidbodies (excluding the root if necessary)
        AllColliders = GetComponentsInChildren<Collider>();
        AllRigidbodies = GetComponentsInChildren<Rigidbody>();

        // Ignore internal collisions so ragdoll limbs don't push off each other
        for (int i = 0; i < AllColliders.Length; i++)
        {
            for (int j = i + 1; j < AllColliders.Length; j++)
            {
                Physics.IgnoreCollision(AllColliders[i], AllColliders[j], true);
            }
        }

        // Initialize state
        changeRagdoll(false);
    }

    public void changeRagdoll(bool isRagdoll)
    {
        // 1. Toggle Colliders
        foreach (var col in AllColliders)
        {
            if (col != mainCollider)
            {
                col.enabled = isRagdoll;
            }
        }

        // 2. Toggle Rigidbodies
        foreach (var rb in AllRigidbodies)
        {
            if (rb.gameObject != this.gameObject) 
            {
                // When animating, set isKinematic = true (physics off, follows animation)
                // When ragdoll, set isKinematic = false (physics on)
                rb.isKinematic = !isRagdoll;

                
                rb.useGravity = isRagdoll;
            }
        }

        
        if (mainCollider != null)
        {
            mainCollider.enabled = !isRagdoll;
        }

        // 4. Disable animator so it stops forcing bone positions over physics
        Animator animator = GetComponent<Animator>();
        if (animator != null)
        {
            animator.enabled = !isRagdoll;
        }
    }

    public void ActivateRagdollWithForce(Vector3 force, Vector3? hitPoint = null)
    {
        //Turn on ragdoll physics first
        changeRagdoll(true);

        // Apply force
        if (impactTargetBone != null && impactTargetBone.TryGetComponent<Rigidbody>(out Rigidbody targetRb))
        {
            // Apply force to somewhere
            if (hitPoint.HasValue)
                targetRb.AddForceAtPosition(force, hitPoint.Value, ForceMode.Impulse);
            else
                targetRb.AddForce(force, ForceMode.Impulse);
        }
        else
        {
            // OR add it to everything big explosion
            foreach (var rb in AllRigidbodies)
            {
                if (rb.gameObject != this.gameObject)
                {
                    rb.AddForce(force, ForceMode.Impulse);
                }
            }
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Vector3 pushDirection = -transform.forward * 15f + Vector3.up * 5f;
            ActivateRagdollWithForce(pushDirection);
        }
    }
}