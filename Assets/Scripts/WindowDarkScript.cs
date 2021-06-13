using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowDarkScript : Interactable
{
    GameStateManager gsm;
    public Sprite window_done;

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
        if (gsm.CURRENT_STATE == GameStateManager.CLOSEWINDOW_DARK)
        {
            GetComponent<SpriteRenderer>().sprite = window_done;
            gsm.window_done = true;
            gsm.OnStateChange();
        }
    }
}
