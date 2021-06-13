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

    public bool playerCanMove = true;

    public bool normalWorld;

    private List<KeyCode> shiftWorldKeys = new List<KeyCode> { KeyCode.LeftShift, KeyCode.RightShift };
    private List<KeyCode> upKeys = new List<KeyCode> { KeyCode.UpArrow, KeyCode.Z, KeyCode.W };
    private List<KeyCode> downKeys = new List<KeyCode> { KeyCode.DownArrow, KeyCode.S};
    private List<KeyCode> leftKeys = new List<KeyCode> { KeyCode.LeftArrow, KeyCode.Q, KeyCode.A };
    private List<KeyCode> rightKeys = new List<KeyCode> { KeyCode.RightArrow, KeyCode.D };
    private List<KeyCode> interactKeys = new List<KeyCode> { KeyCode.RightControl, KeyCode.Space, KeyCode.E };

    public GameObject hider_reg, hider_mind;
    public GameObject text_reg, text_mind;

    public GameObject brightTheme, darkTheme;
    AudioSource darkSource, brightSource;
    IEnumerator volumeTransition;

    public GameObject brightCanvas, darkCanvas;
    CanvasGroup brightCG, darkCG;
    IEnumerator canvasTransition;

    IEnumerator goToBright, goToDark;
    public GameObject mirrorCanvas;
    public GameObject endCanvas;

    private bool hidden_reg, hidden_mind;
	public bool conversationRunning;
    public bool canSwap;
	void Start()
    {
        this.normalWorld = true;
        canSwap = false;
        darkCanvas = GameObject.Find("Canvas_reg");
        brightCanvas = GameObject.Find("Canvas_mind");
        brightCG = brightCanvas.GetComponent<CanvasGroup>();
        darkCG = darkCanvas.GetComponent<CanvasGroup>();
        
        brightTheme = GameObject.Find("BrightTheme");
        darkTheme = GameObject.Find("DarkTheme");
        darkSource = darkTheme.GetComponent<AudioSource>();
        brightSource = brightTheme.GetComponent<AudioSource>();

        mirrorCanvas = GameObject.Find("Canvas_mirror_discussion");
        endCanvas = GameObject.Find("Canvas_end");
        hideCanvas();
        hideEnd();
        hidden_reg = false;
        hidden_mind = true;

        /*this.hider_reg.SetActive(this.hidden_reg);
        this.text_reg.SetActive(!this.hidden_reg);

        this.hider_mind.SetActive(this.hidden_mind);
        this.text_mind.SetActive(!this.hidden_mind);*/
    }

    void Update()
    {
        updateKeys();

        if (this.shiftWorldKeyDown && canSwap)
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

    public void displayEnd()
    {
        endCanvas.SetActive(true);
    }

    public void hideEnd()
    {
        endCanvas.SetActive(false);
    }
    public void canSwapFunction()
    {
        canSwap = true;
    }
    public void displayCanvas()
    {
        mirrorCanvas.SetActive(true);
    }

    public void hideCanvas()
    {
        mirrorCanvas.SetActive(false);
    }

    public void lockControls() {
        playerCanMove = false;
    }

    public void unlockControls()
    {
        playerCanMove = true;
    }

    public void goWorldLight() {
        this.normalWorld = true;
        this.hidden_reg = false;
        this.hidden_mind = true;

        if (goToBright != null)
        {
            StopCoroutine(goToBright);
        }

        goToBright = goToBrightCoroutine(brightSource.volume, darkSource.volume, brightCG.alpha, darkCG.alpha);
        StartCoroutine(goToBright);
    }

    public void goWorldDark()
    {
        this.normalWorld = false;
        this.hidden_reg = true;
        this.hidden_mind = false;

        if (goToDark != null)
        {
            StopCoroutine(goToDark);
        }

        goToDark = goToDarkCoroutine(brightSource.volume, darkSource.volume, brightCG.alpha, darkCG.alpha);
        StartCoroutine(goToDark);
    }

    public void switchWorld() {
        this.normalWorld = !this.normalWorld;
        this.hidden_reg = !this.hidden_reg;
        this.hidden_mind = !this.hidden_mind;

        if (volumeTransition != null) {
            StopCoroutine(volumeTransition);
        }

        volumeTransition = volumeTransitionCoroutine(brightSource.volume, darkSource.volume);
        StartCoroutine(volumeTransition);
       
        if (canvasTransition != null)
        {
            StopCoroutine(canvasTransition);
        }

        canvasTransition = canvasTransitionCoroutine(brightCG.alpha, darkCG.alpha);
        StartCoroutine(canvasTransition);

        /*this.hider_reg.SetActive(this.hidden_reg);
        this.text_reg.SetActive(!this.hidden_reg);

        this.hider_mind.SetActive(this.hidden_mind);
        this.text_mind.SetActive(!this.hidden_mind);*/
    }
    IEnumerator goToBrightCoroutine(float brightVolume, float darkVolume, float brightAlpha, float darkAlpha)
    {
        float progress = 0.0f;
        while (progress < 1.0)
        {
            progress += Time.unscaledDeltaTime * 2.0f;
            brightSource.volume = Mathf.Lerp(brightVolume, 1.0f, progress);
            darkSource.volume = Mathf.Lerp(darkVolume, 0.0f, progress);
            brightCG.alpha = Mathf.Lerp(brightAlpha, 0.0f, progress);
            darkCG.alpha = Mathf.Lerp(darkAlpha, 1.0f, progress);
            yield return null;
        }
    }

    IEnumerator goToDarkCoroutine(float brightVolume, float darkVolume, float brightAlpha, float darkAlpha)
    {
        float progress = 0.0f;
        while (progress < 1.0)
        {
            progress += Time.unscaledDeltaTime * 2.0f;
            brightSource.volume = Mathf.Lerp(brightVolume, 0.0f, progress);
            darkSource.volume = Mathf.Lerp(darkVolume, 1.0f, progress);
            brightCG.alpha = Mathf.Lerp(brightAlpha, 1.0f, progress);
            darkCG.alpha = Mathf.Lerp(darkAlpha, 0.0f, progress);
            yield return null;
        }
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
            progress += Time.unscaledDeltaTime * 2.0f;
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
            progress += Time.unscaledDeltaTime * 6.0f;
            brightCG.alpha = Mathf.Lerp(brightAlpha, brightTarget, progress);
            darkCG.alpha = Mathf.Lerp(darkAlpha, darkTarget, progress);
            yield return null;
        }
        
    }
}