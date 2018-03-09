using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    public bool isWalled;
    public bool isGrounded;

    public Collider2D ground;

    private void Start()
    {

    }

    private void Update()
    {
        Detection();
    }

    void Detection()
    {
        if (ground.IsTouching(ground)) isGrounded = true;
       
    }
}