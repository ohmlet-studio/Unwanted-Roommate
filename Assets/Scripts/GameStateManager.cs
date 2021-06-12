using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
	public int CURRENT_STATE;
	public const int START_STATE = 0;
	public const int PHONE_RINGING = 1;
	public const int CONVERSATION1 = 2;

	public const int END = -1;
	public const int IDLE = -2;

	public bool phonePickedUp1 = false;

	GameManager gm;
	private TextManager tm;

	void Start()
	{
		gm = GameObject.FindObjectOfType<GameManager>();
		tm = FindObjectOfType<TextManager>();

		OnStateChange();
	}

	public void OnStateChange()
	{
			switch (CURRENT_STATE)
			{
				case START_STATE:
					tm.clearText(tm.text_light);
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
				tm.sendText(tm.text_light, "[20:15] Hey beautiful, Jess is throwing a party tonight! You comin' ?");
				tm.sendText(tm.text_light, "[20:16] Mhhh... I guess, just gimme a sec");
				CURRENT_STATE = END;
				OnStateChange();
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
