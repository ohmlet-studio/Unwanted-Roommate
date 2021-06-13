using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuzzScript : MonoBehaviour
{

    GameStateManager gsm;
    AudioSource audio;

    // Start is called before the first frame update
    void Start()
    {
        gsm = GameObject.Find("GameManager").GetComponent<GameStateManager>();
        audio = GetComponent<AudioSource>();
        audio.mute = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(gsm.CURRENT_STATE == GameStateManager.PHONE_RINGING) {
            audio.mute = false;
        } else {
            audio.mute = true;
        }
    }
}
