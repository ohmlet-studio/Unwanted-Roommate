using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
	public int CURRENT_STATE;
	public const int INTRO = -1;
	public const int START_STATE = 0;
	public const int PHONE_RINGING = 1;
	public const int CONVERSATION1 = 2;
	public const int CONVERSATION2 = 3;
	public const int SHOWER = 4;
	public const int DESK = 5;
	public const int MIRROR = 6;

	public const int MIRROR_DIALOG = 7;

	public const int MAKEBED_LIGHT = 8;
	public const int MAKEBED_DARK = 9;

	public const int CLOSEWINDOW_DARK = 10;

	public const int END = -4;
	public const int IDLE = -2;
	public const int MAKEBED = -3;

	public bool phonePickedUp1 = false;
	public bool bureau_fait = false;
	public bool bed_done = false;
	public bool bed_done_dark = false;
	public bool window_done = false;

	GameManager gm;
	private TextManager tm;

	void Start()
	{
		gm = GameObject.FindObjectOfType<GameManager>();
		tm = FindObjectOfType<TextManager>();

		OnStateChange();
	}

	void Update() {
		switch (CURRENT_STATE) {
			case CONVERSATION1:
				if(!gm.conversationRunning) {
					CURRENT_STATE = CONVERSATION2;
					OnStateChange();
				}
				break;

			case CONVERSATION2:
				if (!gm.conversationRunning)
				{
					CURRENT_STATE = MAKEBED;
					OnStateChange();
				}
				break;
		}
	}

	public void OnStateChange()
	{
			switch (CURRENT_STATE)
			{
				case INTRO:
					StartCoroutine(StartRoutine(0.1f));
					break;

				case START_STATE:
					StartCoroutine(PhoneCountdown(5));
					break;

				case PHONE_RINGING:
					if (phonePickedUp1) {
						CURRENT_STATE = CONVERSATION1;
						OnStateChange();
					} else {
					    tm.startConversation(tm.text_light, Conversations.ring);
					}

					break;

				case CONVERSATION1:
					tm.startConversation(tm.text_light, Conversations.conversation1, TextAnchor.MiddleLeft, freezePlayer: true);
				break;

				case CONVERSATION2:
					gm.switchWorld();
					tm.startConversation(tm.text_dark, Conversations.conversation2, freezePlayer: true);
				break;

				case MAKEBED:
					gm.switchWorld();
					gm.playerCanMove = true;
					tm.startConversation(tm.text_light, Conversations.conversation3);
				break;
		}
	}


	// COROUTINE RING RING
	private bool isCoroutineExecuting = false;
	IEnumerator PhoneCountdown(float time)
	{
		if (isCoroutineExecuting)
			yield break;

		isCoroutineExecuting = true;

		yield return new WaitForSeconds(time);

		CURRENT_STATE = PHONE_RINGING;
		OnStateChange();

		isCoroutineExecuting = false;
	}


	IEnumerator StartRoutine(float time) {
		yield return new WaitForSeconds(time);
		tm.startConversation(tm.text_light, Conversations.intro, TextAnchor.MiddleLeft, freezePlayer: true);
	}
}
