using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Change : MonoBehaviour
{

    public InputManager input;
    public GameObject disappear;
    void Start()
    {

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            input.Change();
            disappear.SetActive(false);
        }
    }
}
