using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
	public int CURRENT_STATE;
	public int DEBUG_STATE;

	public const int INIT = -2;
	public const int INTRO = -1;
	public const int START_STATE = 0;
	public const int PHONE_RINGING = 1;
	public const int CONVERSATION1 = 2;
	public const int CONVERSATION2 = 3;
	public const int SHOWER_BEFORE = 4;
	public const int SHOWER_AFTER = 5;
	public const int DESK = 6;
	public const int MIRROR = 7;

	public const int MIRROR_DIALOG = 8;
	public const int SHIFT_INSTRUCTION = 9;

	//public const int CLOSEWINDOW_LIGHT = 10;
	public const int CLOSEWINDOW_DARK = 11;
	public const int MAKEBED_LIGHT = 12;
	//public const int MAKEBED_DARK = 13;

	public const int LASTCONV = 14;
	public const int END1 = 15;
	public const int END2 = 16;

	public const int IDLE = -5;
	public const int MAKEBED = -3;

	public bool introDone = false;
	public bool phonePickedUp1 = false;
	public bool shower_done = false;
	public bool bureau_fait = false;
	public bool mirror = false;
	public bool bed_done = false;
	public bool bed_done_light = false;
	public bool window_done = false;
	public bool mirror_conv_done = false;
	public bool wentout = false;
	public bool stayedinside = false;
	GameManager gm;
	private TextManager tm;

	void Start()
	{
		gm = GameObject.FindObjectOfType<GameManager>();
		tm = FindObjectOfType<TextManager>();

		OnStateChange();
	}

	void Update() {
		switch (CURRENT_STATE)
		{
			case INTRO:
				if (!gm.conversationRunning)
				{
					CURRENT_STATE = START_STATE;
					tm.conv.clearText(tm.text_light);
					OnStateChange();
				}
				break;
			case CONVERSATION1:
				if (!gm.conversationRunning)
				{
					CURRENT_STATE = CONVERSATION2;
					OnStateChange();
				}
				break;

			case CONVERSATION2:
				if (!gm.conversationRunning)
				{
					CURRENT_STATE = SHOWER_BEFORE;
					OnStateChange();
				}
				break;

			case MIRROR_DIALOG:
				if (!gm.conversationRunning)
				{
					CURRENT_STATE = SHIFT_INSTRUCTION;
					gm.hideCanvas();
					gm.canSwapFunction();
					OnStateChange();
				}
				break;

			case SHIFT_INSTRUCTION:
				if (!gm.conversationRunning)
				{
					CURRENT_STATE = CLOSEWINDOW_DARK;
					OnStateChange();
				}
				break;
		}
	}

	public void OnStateChange()
	{
		List<Conversation.CustomFun> cust = new List<Conversation.CustomFun>();
		cust.Add(() => {
			gm.goWorldLight();
			tm.currentIndic = tm.pauseIndicatorLight;
			tm.currentText = tm.text_light;
		});

		cust.Add(() => {
			gm.goWorldDark();
			tm.currentIndic = tm.pauseIndicatorDark;
			tm.currentText = tm.text_dark;
		});
		cust.Add(() =>
		{
			tm.currentIndic = tm.pauseIndicatorLight;
			tm.currentText = tm.text_mirror;
			tm.currentText.alignment = TextAnchor.UpperLeft;
		});

		cust.Add(() =>
		{
			tm.currentIndic = tm.pauseIndicatorDark;
			tm.currentText = tm.text_mirror;
			tm.currentText.alignment = TextAnchor.UpperRight;
		});

		cust.Add(() =>
		{
			tm.currentIndic = tm.pauseIndicatorMirror;
			tm.currentText = tm.text_mirror;
			tm.currentText.alignment = TextAnchor.UpperLeft;
		});

		cust.Add(() =>
		{
			tm.currentIndic = tm.pauseIndicatorMirror;
			tm.currentText = tm.text_mirror;
			tm.currentText.alignment = TextAnchor.UpperRight;
		});

		switch (CURRENT_STATE)
			{
			case INIT:
				StartCoroutine(StartRoutine(0.1f));					
				break;

			case INTRO:
				tm.currentIndic = tm.pauseIndicatorLight;
				tm.currentText = tm.text_light;
				tm.startConversation(Conversations.intro, TextAnchor.MiddleLeft, freezePlayer: true);	
				break;

			case START_STATE:
				StartCoroutine(PhoneCountdown(5));
				break;

			case PHONE_RINGING:
				if (phonePickedUp1) {
					CURRENT_STATE = CONVERSATION1;
					OnStateChange();
				} else {
				tm.currentIndic = tm.pauseIndicatorLight;
				tm.currentText = tm.text_light;
				tm.startConversation(Conversations.ring);
				}

				break;

			case CONVERSATION1:
				tm.currentIndic = tm.pauseIndicatorLight;
				tm.currentText = tm.text_light;
				tm.startConversation(Conversations.text_conv1, TextAnchor.MiddleLeft, freezePlayer: true);
				break;

			case CONVERSATION2:
				gm.switchWorld();
				tm.currentIndic = tm.pauseIndicatorDark;
				tm.currentText = tm.text_dark;
				tm.startConversation(Conversations.dotdotdot, freezePlayer: true);
				break;

			case SHOWER_BEFORE:
				if (shower_done)
				{
					CURRENT_STATE = SHOWER_AFTER;
					OnStateChange();
				} else {
					gm.switchWorld();
					gm.playerCanMove = true;

					tm.currentIndic = tm.pauseIndicatorLight;
					tm.currentText = tm.text_light;
					tm.startConversation(Conversations.beforeshower);
				}
				break;

			case SHOWER_AFTER:
				if(bureau_fait) {
					CURRENT_STATE = DESK;
					OnStateChange();
				} else {
					tm.currentIndic = tm.pauseIndicatorLight;
					tm.currentText = tm.text_light;
					tm.startConversation(Conversations.aftershower1, customs: cust);
				}
				break;

			case DESK:
				if (mirror)
				{
					CURRENT_STATE = MIRROR_DIALOG;
					OnStateChange();
				}
				else
				{
					tm.currentIndic = tm.pauseIndicatorLight;
					tm.currentText = tm.text_light;
					tm.startConversation(Conversations.afterdesk, customs: cust);
				}
				break;

			case MIRROR_DIALOG:
				gm.displayCanvas();
				tm.currentIndic = tm.pauseIndicatorLight;
				tm.currentText = tm.text_mirror;
				tm.startConversation(Conversations.mirrorConv, customs: cust, freezePlayer: true);
				break;

			case SHIFT_INSTRUCTION:
				tm.currentIndic = tm.pauseIndicatorLight;
				tm.currentText = tm.text_light;
				tm.startConversation(Conversations.shiftTuto, customs: cust);
				break;

			case CLOSEWINDOW_DARK:
				if (window_done)
				{
					CURRENT_STATE = MAKEBED_LIGHT;
					OnStateChange();
				}
				else
				{
					tm.startConversation(Conversations.windowConv, customs: cust);
				}
				break;

			case MAKEBED_LIGHT:
				if (bed_done)
				{
					CURRENT_STATE = LASTCONV;
					OnStateChange();
				}
				else
				{
					tm.startConversation(Conversations.bedConv, customs: cust);
				}
				break;

			case LASTCONV:
				if (wentout)
				{
					CURRENT_STATE = END1;
					OnStateChange();
				} else if (stayedinside){
					CURRENT_STATE = END2;
					OnStateChange();
				} else
				{
					tm.startConversation(Conversations.endingConv, customs: cust);
				}
				break;

			case END1:
				gm.displayEnd();
				tm.currentText = tm.text_ending;
				tm.startConversation(Conversations.conclusionTheyWentOut, customs: cust);
				break;

			case END2:
				gm.displayEnd();
				tm.currentText = tm.text_ending;
				tm.startConversation(Conversations.conclusionTheyDidnt, customs: cust);
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
		CURRENT_STATE = DEBUG_STATE;
		OnStateChange();

	}
}
