using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    //ground
    [Header("StateGround")] //*3
    public bool isGrounded;
    public bool wasGroundedLastFrame;
    public bool justGrounded;
    public bool justNOTGrounded;
    public bool isFalling;

    //top
    [Header("StateTop")] //*3
    public bool isTop;
    public bool wasTopLastFrame;
    public bool justTop;
    public bool justNOTTop;
    public bool isOnair;

    //wall
    [Header("StateWall")] //*3
    public bool isWall;
    public bool wasWallLastFrame;
    public bool justWall;
    public bool justNOTWall;
    public bool isOnWall;

    //Ground
    [Header("BoxesGround")] //*3
    public Vector2 groundBoxPos;
    public Vector2 groundBoxSize;

    //Top
    [Header("BoxesTop")] //*3
    public Vector2 TopBoxPos;
    public Vector2 TopBoxSize;

    //Wall
    [Header("BoxesWall")] //*3
    public Vector2 WallBoxPos;
    public Vector2 WallboxSize;

    //Ground
    [Header("Properties Ground")] 
    public int maxHits = 1;
    public bool detectGround = true;
    public ContactFilter2D filter;

    //Top
    [Header("Properties Top")]
    public int maxHitsTop = 1;
    public bool detectTop = true;
    public ContactFilter2D filterTop;

    //Wall
    [Header("Properties Wall")]
    public int maxHitsWall = 1;
    public bool detectWall = true;
    public ContactFilter2D filterWall;


    private void FixedUpdate()
    {
        ResetState();
        ResetStateTop();
        ResetStateWall();
        DetectGround();
        DetectTop();
        DetectWall();
    }

    //Ground
    void ResetState()
    {
        wasGroundedLastFrame = isGrounded;
        isGrounded = false;
        justNOTGrounded = false;
        justGrounded = false;
        isFalling = true;
    }

    //Top
    void ResetStateTop()
    {
        wasTopLastFrame = isTop;
        isTop = false;
        justNOTTop = false;
        justTop = false;
        isOnair = true;
    }

    //Wall
    void ResetStateWall()
    {
        wasWallLastFrame = isWall;
        isWall = false;
        justNOTWall = false;
        justWall = false;
        isWall = true;
    }

    //Ground
    void DetectGround() //*3
    {
        if(!detectGround) return;

        Collider2D[] results = new Collider2D[maxHits];
        Vector3 newPos = (Vector3)groundBoxPos + transform.position;
        int numHits = Physics2D.OverlapBox(newPos, groundBoxSize, 0, filter, results);

        if(numHits > 0)
        {
            isGrounded = true;
        }
        isFalling = !isGrounded;

        if(!wasGroundedLastFrame && isGrounded)
        {
            Debug.Log("JUST GROUNDED");
            justGrounded = true;
        }
        if(wasGroundedLastFrame && !isGrounded)
        {
            Debug.Log("JUST NOT GROUNDED");
            justNOTGrounded = true;
        }
    }

    //Top
    void DetectTop() //*3
    {
        if (!detectTop) return;

        Collider2D[] results = new Collider2D[maxHits];
        Vector3 newPosTop = (Vector3)TopBoxPos + transform.position;
        int numHits = Physics2D.OverlapBox(newPosTop, TopBoxSize, 0, filter, results);

        if (numHits > 0)
        {
            isTop = true;
        }
        isOnair = !isTop;

        if (!wasTopLastFrame && isTop)
        {
            Debug.Log("JUST TOP");
            justTop = true;
        }
        if (wasTopLastFrame && !isTop)
        {
            Debug.Log("JUST NOT TOP");
            justNOTTop = true;
        }
    }

    //Wall
    void DetectWall() //*3
    {
        if (!detectWall) return;

        Collider2D[] results = new Collider2D[maxHits];
        Vector3 newPosWall = (Vector3)WallBoxPos + transform.position;
        int numHits = Physics2D.OverlapBox(newPosWall, WallboxSize, 0, filter, results);

        if (numHits > 0)
        {
            isWall = true;
        }
        isOnWall = !isWall;

        if (!wasWallLastFrame && isWall)
        {
            Debug.Log("JUST WALL");
            justWall = true;
        }
        if (wasWallLastFrame && !isWall)
        {
            Debug.Log("JUST NOT WALL");
            justNOTWall = true;
        }
    }

    //Ground
    private void OnDrawGizmosSelected() //*3
    {
        //Top
        Gizmos.color = Color.blue;
        Vector3 newPos = (Vector3)groundBoxPos + transform.position;
        Gizmos.DrawWireCube(newPos, groundBoxSize);

        //Top
        Gizmos.color = Color.red;
        Vector3 newPosTop = (Vector3)TopBoxPos + transform.position;
        Gizmos.DrawWireCube(newPosTop, TopBoxSize);

        //Wall
        Gizmos.color = Color.yellow;
        Vector3 newPosWall = (Vector3)WallBoxPos + transform.position;
        Gizmos.DrawWireCube(newPosWall, WallboxSize);
    }

    
}