using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextManager : MonoBehaviour
{
    public Text text_light;
    public Text text_dark;
	public Text text_mirror;

	public Text currentText;
	public GameObject currentIndic;

	public GameObject pauseIndicatorLight;
	public GameObject pauseIndicatorDark;

	public Conversation conv;

	private void Start()
	{
		conv = GetComponent<Conversation>();
	}

	public void startConversation(List<string> conversation, TextAnchor anchor = TextAnchor.MiddleCenter, bool freezePlayer = false, List<Conversation.CustomFun> customs = null) {		
		conv.loadConversation(conversation);
		conv.launchConversation(anchor, freezePlayer, customs);
	}
}
