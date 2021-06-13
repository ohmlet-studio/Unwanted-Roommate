using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Conversation : MonoBehaviour
{
	private List<string> conversationLines;
	private GameManager gm;

	void Start()
	{
		gm = GetComponent<GameManager>();
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

	public void launchConversation(Text target, GameObject pauseIndicator, TextAnchor textAnchor = TextAnchor.MiddleLeft, bool freezePlayer = false)
	{
		target.alignment = textAnchor;

		StartCoroutine(conversationStart(target, pauseIndicator, freezePlayer));
	}

	IEnumerator conversationStart(Text target, GameObject pauseIndicator, bool freezePlayer) {
		string builder = "";

		gm.conversationRunning = true;
		gm.playerCanMove = !freezePlayer;

		foreach (string s in conversationLines)
		{
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
			else if (s == "{wait10}") {
				yield return new WaitForSeconds(10);
			}
			else if (s == "{wait5}")
			{
				yield return new WaitForSeconds(5);
			}
			else if (s == "{wait4}")
            {
				yield return new WaitForSeconds(4);
			}
			else if (s == "{wait3.5}")
			{
				yield return new WaitForSeconds(3.5f);
			}
			else if (s == "{wait3}")
			{
				yield return new WaitForSeconds(3);
			}
			else if (s == "{wait2}")
            {
				yield return new WaitForSeconds(2);
			}
			else if (s == "{wait1.5}")
			{
				yield return new WaitForSeconds(1.5f);
			}
			else if (s == "{wait1}")
            {
				yield return new WaitForSeconds(1);
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
