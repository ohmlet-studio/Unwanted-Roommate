using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
	public int CURRENT_STATE;
	public const int START_STATE = 0;
	public const int PHONE_RINGING = 1;
	public const int CONVERSATION1 = 2;
	public const int CONVERSATION2 = 3;
	public const int MAKEBED = 4;

	public const int END = -1;
	public const int IDLE = -2;

	public bool phonePickedUp1 = false;
	public bool bureau_fait = false;
	public bool bed_done = false;

	GameManager gm;
	private TextManager tm;

	void Start()
	{
		gm = GameObject.FindObjectOfType<GameManager>();
		tm = FindObjectOfType<TextManager>();


		OnStateChange();
	}

	void Update() {
		if(gm.interactKeyDown) {
			switch (CURRENT_STATE) {
				case CONVERSATION1:
					CURRENT_STATE = CONVERSATION2;
					OnStateChange();
					break;

				case CONVERSATION2:
					CURRENT_STATE = MAKEBED;
					OnStateChange();
					break;
			}
		}
	}

	public void OnStateChange()
	{
			switch (CURRENT_STATE)
			{
				case START_STATE:
					tm.clearText(tm.text_light);
					tm.clearText(tm.text_dark);
					StartCoroutine(ExecuteAfterTime(5));
					break;

				case PHONE_RINGING:
					if (phonePickedUp1) {
						tm.clearText(tm.text_light);
						CURRENT_STATE = CONVERSATION1;
						OnStateChange();
					} else {
						tm.clearText(tm.text_light);
						tm.sendText(tm.text_light, "*Ring* *Ring*");
					}

					break;

				case CONVERSATION1:
					tm.sendText(tm.text_light, "[20:15] Deb : Hey Jess is throwing a party tonight! You comin' ?");
					tm.sendText(tm.text_light, "[20:16] Max : Mhhh... sure I guess, just gimme a sec");
					tm.sendText(tm.text_light, "\n [...]");
					gm.lockControls();
					break;

				case CONVERSATION2:
					gm.switchWorld();
					tm.sendText(tm.text_dark, "...");
					break;

				case MAKEBED:
					gm.switchWorld();
				gm.unlockControls();
				tm.clearText(tm.text_light);
					tm.sendText(tm.text_light, "I should be making my bed first");
					break;
		}
	}


	// COROUTINE RING RING
	private bool isCoroutineExecuting = false;
	IEnumerator ExecuteAfterTime(float time)
	{
		if (isCoroutineExecuting)
			yield break;

		isCoroutineExecuting = true;

		yield return new WaitForSeconds(time);

		CURRENT_STATE = PHONE_RINGING;
		OnStateChange();

		isCoroutineExecuting = false;
	}

}
