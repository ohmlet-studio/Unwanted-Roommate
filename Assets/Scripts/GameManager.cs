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

    public bool normalWorld;

    private List<KeyCode> shiftWorldKeys = new List<KeyCode> { KeyCode.LeftShift, KeyCode.RightShift };
    private List<KeyCode> upKeys = new List<KeyCode> { KeyCode.UpArrow, KeyCode.Z, KeyCode.W };
    private List<KeyCode> downKeys = new List<KeyCode> { KeyCode.DownArrow, KeyCode.S};
    private List<KeyCode> leftKeys = new List<KeyCode> { KeyCode.LeftArrow, KeyCode.Q, KeyCode.A };
    private List<KeyCode> rightKeys = new List<KeyCode> { KeyCode.RightArrow, KeyCode.D };

    public GameObject hider_reg, hider_mind;
    public GameObject text_reg, text_mind;

    public GameObject brightTheme, darkTheme;
    IEnumerator volumeTransition;
    IEnumerator canvasTransition;

    SpriteRenderer brightHider, darkHider;
    AudioSource darkSource, brightSource;
    private bool hidden_reg, hidden_mind;

    void Start()
    {
        this.normalWorld = true;

        brightTheme = GameObject.Find("BrightTheme");
        darkTheme = GameObject.Find("DarkTheme");
        darkSource = darkTheme.GetComponent<AudioSource>();
        brightSource = brightTheme.GetComponent<AudioSource>();
        brightHider = hider_reg.GetComponent<SpriteRenderer>();
        darkHider = hider_mind.GetComponent<SpriteRenderer>();
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

    }

    public void switchWorld() {
        this.normalWorld = !this.normalWorld;

        if (volumeTransition != null) {
            StopCoroutine(volumeTransition);
        }

        volumeTransition = volumeTransitionCoroutine(brightSource.volume, darkSource.volume);
        StartCoroutine(volumeTransition);
       
        if (canvasTransition != null)
        {
            StopCoroutine(canvasTransition);
        }

        canvasTransition = canvasTransitionCoroutine(this.brightHider.color.a, this.darkHider.color.a);
        this.hidden_reg = !this.hidden_reg;
        this.hidden_mind = !this.hidden_mind;
        

        this.hider_reg.SetActive(this.hidden_reg);
        this.text_reg.SetActive(!this.hidden_reg);

        this.hider_mind.SetActive(this.hidden_mind);
        this.text_mind.SetActive(!this.hidden_mind);
    }

    // MUSIC COROUTINE
    IEnumerator volumeTransitionCoroutine(float brightVolume, float darkVolume)
    {
        float brightTarget, darkTarget, progress = 0.0f;
        if (this.normalWorld)
        {
            brightTarget = 1.0f;
            darkTarget = 0.0f;  
        }
        else
        {
            brightTarget = 0.0f;
            darkTarget = 1.0f;
        }

        while (progress < 1.0)
        {
            progress += Time.unscaledDeltaTime;
            brightSource.volume = Mathf.Lerp(brightVolume, brightTarget, progress);
            darkSource.volume = Mathf.Lerp(darkVolume, darkTarget, progress);
            yield return null;
        }
    }

    // CANVAS COROUTINE

    IEnumerator canvasTransitionCoroutine(float brightAlpha, float darkAlpha)
    {
        float brightTarget, darkTarget, progress = 0.0f;
        if (this.normalWorld)
        {
            brightTarget = 0.0f;
            darkTarget = 1.0f;
        }
        else
        {
            brightTarget = 1.0f;
            darkTarget = 0.0f;
        }

        while (progress < 1.0)
        {
            progress += Time.unscaledDeltaTime;
            //brightHider.color.a = Mathf.Lerp(brightAlpha, brightTarget, progress);

            yield return null;
        }
    }
}