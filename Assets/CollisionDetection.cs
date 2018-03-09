using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    public bool isWalled;
    public bool isGrounded;

    public Collider2D ground;

    public float distance;
    public float distanceBetweenRays;
    public Vector2  rayOffset;
    public ContactFilter2D filter;


    private void FixedUpdate()
    {
        //CheckGround();
    }

    void CheckGround()
    {
        isGrounded = false;

        Vector2 rayPos = this.transform.position + (Vector3)rayOffset;
        rayPos.x -= distanceBetweenRays / 2;

        for(int i = 0; i < 2; ++i)
        {
            RaycastHit2D[] hits = new RaycastHit2D[1];
            int numHits = Physics2D.Raycast(rayPos, Vector2.down, filter, hits, distance);

            if(numHits != 0)
            {
                isGrounded = true;
                break;
            }
            rayPos.x += distanceBetweenRays;
        }
    }

    private void OnDrawGizmos()
    {
        Vector2 rayPos = this.transform.position + (Vector3)rayOffset;
        rayPos.x -= distanceBetweenRays / 2;

        Gizmos.color = Color.red;
        Gizmos.DrawRay(rayPos, Vector2.down * distance);
        rayPos.x += distanceBetweenRays;
        Gizmos.DrawRay(rayPos, Vector2.down * distance);
    }
}