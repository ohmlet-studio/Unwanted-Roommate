using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : Interactable
{
    GameStateManager gsm;

    // Start is called before the first frame update
    void Start()
    {
        base.Start();
        gsm = GameObject.Find("GameManager").GetComponent<GameStateManager>();
    }

    // Update is called once per frame
    void Update()
    {
        base.Update();
    }

    public override void Interact()
    {
        if (gsm.CURRENT_STATE == GameStateManager.LASTCONV)
        {
            gsm.wentout = true;
            gsm.OnStateChange();
        }
    }
}
