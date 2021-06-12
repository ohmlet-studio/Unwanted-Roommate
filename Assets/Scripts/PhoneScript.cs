using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneScript : MonoBehaviour
{
    GameStateManager gsm;

    bool vibrating;

    public float amount;
    public float speed;

    float x, y, z;

    // Start is called before the first frame update
    void Start()
    {
        gsm = FindObjectOfType<GameStateManager>();
        x = transform.position.x;
        y = transform.position.y;
        z = transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        if(gsm.CURRENT_STATE == GameStateManager.PHONE_RINGING) {
            vibrating = true;
        }
    }

    void FixedUpdate() {
        if(vibrating) {
            var t = (Time.time * 100) % 1000;
            if(t < 300 || (t > 400 && t < 700)) {
                transform.position = new Vector3(x, y + Mathf.Sin(Time.time * speed) * amount, z);
            }
        }
    }
}
