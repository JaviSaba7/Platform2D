using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    public InputManager inputBehaviour;

    public int hitDamage = 1;

    // Use this for initialization


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            inputBehaviour.Damage(hitDamage);
            Debug.Log("HELLO");
        }
    }
}
