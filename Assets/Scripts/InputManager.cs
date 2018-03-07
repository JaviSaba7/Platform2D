using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InputManager : MonoBehaviour
{
    public CollisionDetection collisionDetection;

    public Rigidbody2D rb2D;

    public GameObject player;

    public Camera camera;
    public GameObject[] hpDisplay;


    public float iniPosX;
    public float iniPosY;
    public float levelSpeed;
    public float jumpForce;

    public int characterHP;

    private float continueSpeed;
    private float currentPosX;

    public bool gameStarted = false;

    public float hitForce = 3;
    public float hitForceX;
    public float hitForceY;
    public float stunTime = 1.5f;

    [SerializeField] private bool stun;

    // Use this for initialization
    void Start()
    {

        currentPosX = player.transform.position.x;

        continueSpeed = levelSpeed;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            gameStarted = !gameStarted;
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            Restart();
        }

        if (stun) return;

        if (gameStarted)
        {


            if (!collisionDetection.isWalled) rb2D.velocity = new Vector2(levelSpeed, rb2D.velocity.y);
            else rb2D.velocity = new Vector2(0, rb2D.velocity.y);

            if (Input.GetKeyDown(KeyCode.S) && collisionDetection.isGrounded)
            {
                rb2D.AddForce(player.transform.up * jumpForce, ForceMode2D.Impulse);
            }
        }
        else
        {
            rb2D.velocity = new Vector2(0, rb2D.velocity.y);
        }

        HPUpdate();
    }

    void Restart()
    {
        SceneManager.LoadScene("Gameplay");
    }

    public void Damage(int d)
    {
        characterHP -= d;

        stun = true;
        rb2D.velocity = Vector2.zero;
        rb2D.AddForce(new Vector2(hitForceX, hitForceY) * hitForce, ForceMode2D.Impulse);

        StartCoroutine(StunPlayer());
        if (characterHP <= 0) Dead();
    }

    public void Dead()
    {
        Debug.Log("LOSE");
        gameStarted = false;
    }

    public void HPUpdate()
    {
        if (characterHP == 3)
        {
            hpDisplay[2].SetActive(true);
            hpDisplay[1].SetActive(true);
            hpDisplay[0].SetActive(true);
        }
        if (characterHP == 2)
        {
            hpDisplay[2].SetActive(false);
        }
        if (characterHP == 1)
        {
            hpDisplay[1].SetActive(false);
        }
    }

    public IEnumerator StunPlayer()
    {
        yield return new WaitForSeconds(stunTime);

        stun = false;
        Debug.Log("End stun");
    }
}
