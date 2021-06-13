using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Globalization;


public class Conversation : MonoBehaviour
{
	private List<string> conversationLines;
	private GameManager gm;
	private TextManager tm;

	public delegate void CustomFun();

	void Start()
	{
		gm = GetComponent<GameManager>();
		tm = GetComponent<TextManager>();
		newConversation();
	}

	public void sendText(string content)
	{
		conversationLines.Add(content);
	}
	public void sendLoading()
	{
		conversationLines.Add("{loading}");
	}
	public void sendPause()
	{
		conversationLines.Add("{pause}");
	}
	public void sendClear()
	{
		conversationLines.Add("{clear}");
	}

	public void clearText(Text target)
	{
		target.text = "";
	}

	public void loadConversation(List<string> conversation) {
		this.conversationLines = conversation;
	}

	public void newConversation() {
		this.conversationLines = new List<string>();
	}

	public void launchConversation(TextAnchor textAnchor = TextAnchor.MiddleLeft, bool freezePlayer = false, List<CustomFun> customs = null)
	{
		tm.currentText.alignment = textAnchor;
		StartCoroutine(conversationStart(freezePlayer, customs));
	}

	IEnumerator conversationStart(bool freezePlayer, List<CustomFun> customs) {
		string builder = "";

		gm.conversationRunning = true;
		gm.playerCanMove = !freezePlayer;

		foreach (string s in conversationLines)
		{
			Text target = tm.currentText;
			GameObject pauseIndicator = tm.currentIndic;
			if (s == "{loading}")
			{
				for (var i = 0; i < 3; i++)
				{
					yield return new WaitForSeconds(0.3f);
					clearText(target);
					target.text = builder + ".";
					yield return new WaitForSeconds(0.3f);
					clearText(target);
					target.text = builder + "..";
					yield return new WaitForSeconds(0.3f);
					clearText(target);
					target.text = builder + "...";
				}
			}
			else if (s == "{pause}")
			{
				pauseIndicator.SetActive(true);
				yield return new WaitUntil(() => gm.interactKeyDown);
				pauseIndicator.SetActive(false);

			}
			else if (s == "{clear}")
			{
				builder = "";
				target.text = builder;
			}
			else if (s.StartsWith("{wait")) {
				string f = s.Substring(5, s.Length - 6).Replace('.','.');
				yield return new WaitForSeconds(float.Parse(f, CultureInfo.InvariantCulture));
			}
			else if (s.StartsWith("{custom"))
			{
				string f = s.Substring(7, s.Length - 8);
				customs[int.Parse(f)]();
			}
			else if (s == "") {
				builder += "\n";
				target.text = builder;
			}
			else
			{
				builder += s;
				target.text = builder;
			}
		}

		gm.conversationRunning = false;
		gm.playerCanMove = true;

	}
}
