using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InputManager : MonoBehaviour
{

    public Vector3 initialPosition = new Vector3(-8.79f, 4, 0);
    public AudioSource defeat;
    public GameObject sprite;
    public GameObject life;
    public GameObject life_break;
    public Change change;
    public Return return1;
    public CollisionDetection collisionDetection;
    public Rigidbody2D rb2D;
    public GameObject restart_button;
    public GameObject player;
    public bool shipEnable;
    public Camera camera;
    public GameObject lose_image;

    public float iniPosX;
    public float iniPosY;
    public float levelSpeed;
    public float jumpForce;

    public int characterHP;

    private float continueSpeed;
    private float currentPosX;
    public AudioSource startSound;
    public AudioSource song;
    public GameObject ship;
    public bool gameStart = false;
    public GameObject menu;
    public float hitForce = 3;
    public float hitForceX;
    public float hitForceY;
    public float stunTime = 1.5f;
    public GameObject black;
    public GameObject win;
    public bool canJump = true;
    public bool start = false;
    public float counterToJump;
    public float counterToAppearImage;
    public GameObject image;
    public bool jumpSystem;

    public bool fly = false;
    // Use this for initialization
    void Start()
    {
        menu.SetActive(true);
        continueSpeed = levelSpeed;

    }

    // Update is called once per frame
    void Update()
    {
        if(gameStart)
        {
            counterToAppearImage++;
            if (counterToAppearImage < 10) image.SetActive(false);
            if (counterToAppearImage < 20 && counterToAppearImage > 10) image.SetActive(true);
            if (counterToAppearImage < 30 && counterToAppearImage > 20) image.SetActive(false);
            if (counterToAppearImage < 40 && counterToAppearImage > 30) image.SetActive(true);
            if (counterToAppearImage < 50 && counterToAppearImage > 40) image.SetActive(false);
            if (counterToAppearImage < 60 && counterToAppearImage > 50) image.SetActive(true);
            if (counterToAppearImage < 70 && counterToAppearImage > 60) image.SetActive(false);
            if (counterToAppearImage < 80 && counterToAppearImage > 70) image.SetActive(true);
            if (counterToAppearImage < 90 && counterToAppearImage > 80) image.SetActive(false);
            if (counterToAppearImage > 90 ) image.SetActive(true);


            if (!collisionDetection.isWalled) rb2D.velocity = new Vector2(levelSpeed, rb2D.velocity.y);
            else rb2D.velocity = new Vector2(0, rb2D.velocity.y);

            if (Input.GetKeyDown(KeyCode.Space) && collisionDetection.isGrounded == true)
            {
                jumpSystem = true;
                rb2D.AddForce(player.transform.up * jumpForce, ForceMode2D.Impulse);    
            }
        }
        else
        {
            rb2D.velocity = new Vector2(0, rb2D.velocity.y);
        }

        if(shipEnable) collisionDetection.isGrounded = true;

    }

    public void Restart()
    {
        player.transform.position = initialPosition;

        restart_button.SetActive(false);
        counterToAppearImage = 0;

        sprite.SetActive(false);
        life.SetActive(true);
        life_break.SetActive(false);
        lose_image.SetActive(false);
        gameStart = true;
        shipEnable = false;
        ship.SetActive(false);
        collisionDetection.GetComponent<CollisionDetection>().enabled = true;
        collisionDetection.GetComponent<Fly>().enabled = false;
        change.disappear.SetActive(true);
        return1.disappear.SetActive(true);

    }

    public void StartGame()
    {
        menu.SetActive(false);
        startSound.Play();
        song.Play();
        black.SetActive(true);
        gameStart = true;
    }

    public void Exit()
    {
        Application.Quit();
    }
    public void Dead()
    {
        restart_button.SetActive(true);

        Debug.Log("Die");
        defeat.Play();
        gameStart = false;
        sprite.SetActive(true);
        life.SetActive(false);
        life_break.SetActive(true);
        lose_image.SetActive(true);
    }

    public void Win()
    {
        Debug.Log("Win");

        win.SetActive(true);
    }

    public void Change()
    {
        shipEnable = true;
        ship.SetActive(true);
        collisionDetection.GetComponent<CollisionDetection>().enabled = false;
        collisionDetection.GetComponent<Fly>().enabled = true;
    }

    public void Return()
    {
        shipEnable = false;
        ship.SetActive(false);
        collisionDetection.GetComponent<CollisionDetection>().enabled = true;
        collisionDetection.GetComponent<Fly>().enabled = false;
    }


}
