using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BetterJump : MonoBehaviour
{
    public float fallmultiplier = 2.5f;
    public float lowfallmultiplier = 2f;
    int extrajump;
   

    Rigidbody2D rb;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity += Vector2.up * Physics2D.gravity * (fallmultiplier - 1) * Time.deltaTime;

     
    }
}
