using System.Collections.Generic;

public static class Conversations
{
	public static List<string> hello = new List<string>
	{
		"Hey! Welcome. "
	};
	public static List<string> intro = new List<string>
	{
		"Hey! Welcome. ", "{wait1.5}", "", "This little game was made during the GMTK 2021 Game Jam. ", "{wait2}",
		"", "",
		"The goal is to help me overcome my overwhelming anxiety. ", "{wait1.5}" ,"You will get to meet it soon enough. " , "{wait1.5}" ,
		"", "",
		"We live at the same place anyway.",
		"", "",
		"{loading}",
		"...",
		"",
		"My name is Max, by the way. " , "{wait1}", "Pleased to meet you. " , "{wait3.5}",
		"", "",
		"You'll be able to tell me where to go using your arrow keys. " , "{wait4}",
		"If you need to interact with an object, get me in front of it and press your spacebar. " , "{wait4}",
		"", "",
		"Whenever you see [...] at the bottom of the screen, press your spacebar to display the next dialogue. ",
		"{pause}",
		"", "",
		"That's it. ", "{wait2}", "Just like that. ",  "{wait2}",  "I think you're ready. I hope you have fun :)", "{pause}"
	};

	public static List<string> ring = new List<string> { "*Ring* *Ring*" };

	public static List<string> conversation1 = new List<string>{
	"[20:15] Deb : Hey Jess is throwing a party tonight! You comin' ?", "",
	"{loading}",
	"[20:16] Max : Mhhh", "{loading}", "... sure, I guess, just gimme a sec",
	"{pause}"};

	public static List<string> conversation2 = new List<string> { "...", "{pause}"};

	public static List<string> conversation3 = new List<string> { "I should be making my bed first" };
}