using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changingcolor : MonoBehaviour
{
    SpriteRenderer imageColor;
    BoxCollider2D boxCollider;
    void Start()
    {
        imageColor = GetComponent<SpriteRenderer>();
        boxCollider = GetComponent<BoxCollider2D>();
        StartCoroutine(changeTheColor());

    }

    // Update is called once per frame

    private void Update()
    {
        ColorControl();
    }

    IEnumerator changeTheColor()
    {
        while (true)
        {
            yield return new WaitForSeconds(1.5f);
            imageColor.color = Color.cyan;
            yield return new WaitForSeconds(1.5f);
            imageColor.color = Color.red;
            yield return new WaitForSeconds(1.5f);
        }
        
    }

    void ColorControl()
    {
        if(imageColor.color == Color.cyan)
        {
            boxCollider.isTrigger = true;
        }
        else if(imageColor.color == Color.red)
        {
            boxCollider.isTrigger = false;
        }
        
    }
}
