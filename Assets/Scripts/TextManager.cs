using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextManager : MonoBehaviour
{
    public Text text_light;
    public Text text_dark;

	public GameObject pauseIndicatorLight;
	public GameObject pauseIndicatorDark;

	public Conversation conv;

	private void Start()
	{
		conv = GetComponent<Conversation>();
	}

	public void startConversation(Text text, List<string> conversation, TextAnchor anchor = TextAnchor.MiddleCenter, bool freezePlayer = false, List<Conversation.CustomFun> customs = null) {
		GameObject indic;
		if(text == text_light) {
			indic = pauseIndicatorLight;
		} else {
			indic = pauseIndicatorDark;
		}

		conv.loadConversation(conversation);

		conv.launchConversation(text, indic, anchor, freezePlayer, customs);
	}
}
