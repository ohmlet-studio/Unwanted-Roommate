using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
	public int CURRENT_STATE;
	public const int START_STATE = 0;
	public const int PHONE_RINGING = 1;
	public const int IDLE = 2;

	GameManager gm;
	private TextManager tm;

	void Start()
	{
		gm = GameObject.FindObjectOfType<GameManager>();
		tm = FindObjectOfType<TextManager>();
	}

	void Update()
	{
		switch(CURRENT_STATE) {
			case START_STATE:
				tm.clearText(tm.text_light);
				StartCoroutine(ExecuteAfterTime(5));
				break;

			case PHONE_RINGING:
				tm.clearText(tm.text_light);
				tm.sendText(tm.text_light, "*Ring* *Ring*");
				CURRENT_STATE = IDLE;
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

		isCoroutineExecuting = false;
	}

}
