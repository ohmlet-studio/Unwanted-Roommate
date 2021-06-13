using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BedDarkScript : Interactable
{
    GameStateManager gsm;
    public Sprite bed_done;

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
        if (gsm.CURRENT_STATE == GameStateManager.MAKEBED_LIGHT)
        {
            if(gsm.bed_done_light) {
                GetComponent<SpriteRenderer>().sprite = bed_done;
                gsm.bed_done = true;
                gsm.OnStateChange();
            }

        }
    }
}
