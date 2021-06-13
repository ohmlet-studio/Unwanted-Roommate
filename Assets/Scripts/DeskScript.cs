using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeskScript : Interactable
{
    GameStateManager gsm;
    public Sprite bureau_fait;

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
        if (gsm.CURRENT_STATE == GameStateManager.SHOWER_AFTER)
        {
            GetComponent<SpriteRenderer>().sprite = bureau_fait;
            gsm.bureau_fait = true;
            gsm.OnStateChange();
        }

        if (gsm.CURRENT_STATE == GameStateManager.LASTCONV)
        {
            gsm.stayedinside = true;
            gsm.OnStateChange();
        }
    }
}
