using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fallingobject : MonoBehaviour
{
    Rigidbody2D rg;
    void Start()
    {
        rg = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.name.Equals("Player"))
        {
            Invoke("isKinematic",1f);
           
        }
    }

    void isKinematic()
    {
        rg.isKinematic = false;
    }
}
