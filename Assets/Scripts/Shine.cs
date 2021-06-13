using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shine : MonoBehaviour
{
    public float speed;
    public bool shine = false;
    SpriteRenderer sr;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    void FixedUpdate()
    {
        if (shine)
        {
            float f = ((Mathf.Sin(Time.time * speed) + 1) / 2);
            int color = 191 + (int)(f * 64);
            sr.color = new Color(color / 255f, color / 255f, color / 255f);
        }
    }
}
