using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

class GameManager : MonoBehaviour
{
    // KEYS
    public bool shiftWorldKeyDown;
    public bool upKeyDown;
    public bool downKeyDown;
    public bool leftKeyDown;
    public bool rightKeyDown;
    public bool interactKeyDown;

    public bool normalWorld;

    private List<KeyCode> shiftWorldKeys = new List<KeyCode> { KeyCode.LeftShift, KeyCode.RightShift };
    private List<KeyCode> upKeys = new List<KeyCode> { KeyCode.UpArrow, KeyCode.Z, KeyCode.W };
    private List<KeyCode> downKeys = new List<KeyCode> { KeyCode.DownArrow, KeyCode.S};
    private List<KeyCode> leftKeys = new List<KeyCode> { KeyCode.LeftArrow, KeyCode.Q, KeyCode.A };
    private List<KeyCode> rightKeys = new List<KeyCode> { KeyCode.RightArrow, KeyCode.D };
    private List<KeyCode> interactKeys = new List<KeyCode> { KeyCode.RightControl, KeyCode.Space, KeyCode.E };

    public GameObject hider_reg, hider_mind;
    public GameObject text_reg, text_mind;
    private bool hidden_reg, hidden_mind;

    void Start()
    {
        this.normalWorld = true;

        hidden_reg = false;
        hidden_mind = true;

        this.hider_reg.SetActive(this.hidden_reg);
        this.text_reg.SetActive(!this.hidden_reg);

        this.hider_mind.SetActive(this.hidden_mind);
        this.text_mind.SetActive(!this.hidden_mind);
    }

    void Update()
    {
        updateKeys();

        if (this.shiftWorldKeyDown)
        {
            switchWorld();
        }
    }

    void updateKeys()
    {
        this.shiftWorldKeyDown = false;
        foreach (KeyCode k in shiftWorldKeys)
        {
            this.shiftWorldKeyDown |= Input.GetKeyDown(k);
        }

        this.upKeyDown = false;
        foreach (KeyCode k in upKeys)
        {
            this.upKeyDown |= Input.GetKeyDown(k);
        }

        this.downKeyDown = false;
        foreach (KeyCode k in downKeys)
        {
            this.downKeyDown |= Input.GetKeyDown(k);
        }

        this.leftKeyDown = false;
        foreach (KeyCode k in leftKeys)
        {
            this.leftKeyDown |= Input.GetKeyDown(k);
        }

        this.rightKeyDown = false;
        foreach (KeyCode k in rightKeys)
        {
            this.rightKeyDown |= Input.GetKeyDown(k);
        }

        this.interactKeyDown = false;
        foreach (KeyCode k in interactKeys)
        {
            this.interactKeyDown |= Input.GetKeyDown(k);
        }

    }

    public void switchWorld() {
        this.normalWorld = !this.normalWorld;

        this.hidden_reg = !this.hidden_reg;
        this.hidden_mind = !this.hidden_mind;

        this.hider_reg.SetActive(this.hidden_reg);
        this.text_reg.SetActive(!this.hidden_reg);

        this.hider_mind.SetActive(this.hidden_mind);
        this.text_mind.SetActive(!this.hidden_mind);
    }
}