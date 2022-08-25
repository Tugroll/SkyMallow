using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    [Range(-1f,1f)]
    public float speed = .5f;
    float offset;
    Material mat;

    public static float divided;

    void Start()
    {
        mat = GetComponent<Renderer>().material;
        divided = 10f;
    }

    // Update is called once per frame
    void Update()
    {
        offset += (Time.deltaTime * speed) / divided;
        mat.SetTextureOffset("_MainTex", new Vector2(0, offset));


    }
}
