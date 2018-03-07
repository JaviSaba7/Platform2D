using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    public bool isGrounded;
    public bool isWalled;

    public Collider2D groundCollider;
    public Collider2D wallCollider;

    public CompositeCollider2D terrainCollider;

    private void Start()
    {

    }

    private void Update()
    {
        TriggerDetection();
    }

    void TriggerDetection()
    {
        if (groundCollider.IsTouching(groundCollider))
        {
            isGrounded = true;
        }

        /*if (!groundCollider.IsTouching(groundCollider))
        {
           isGrounded = false;
        }*/

       /* if (wallCollider.IsTouching(terrainCollider))
        {
            isWalled = true;
        }

        if (!wallCollider.IsTouching(terrainCollider))
        {
            isWalled = false;
        }*/
    }
}