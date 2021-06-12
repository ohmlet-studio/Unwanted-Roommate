using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneScript : Interactable
{
    GameStateManager gsm;

    bool vibrating;

    public float amount;
    public float speed;

    float x, y, z;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        gsm = GameObject.Find("GameManager").GetComponent<GameStateManager>();
        x = transform.position.x;
        y = transform.position.y;
        z = transform.position.z;
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        if(gsm.CURRENT_STATE == GameStateManager.PHONE_RINGING) {
            vibrating = true;
        }
    }

    public override void Interact() {
        if (gsm.CURRENT_STATE == GameStateManager.PHONE_RINGING) {
            gsm.phonePickedUp1 = true;
            vibrating = false;
            gsm.OnStateChange();
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
