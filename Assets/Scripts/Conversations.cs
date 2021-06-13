using System.Collections.Generic;

public static class Conversations
{
	public static List<string> ring = new List<string> { "*Ring* *Ring*" };

	public static List<string> conversation1 = new List<string>{
	"[20:15] Deb : Hey Jess is throwing a party tonight! You comin' ?", "",
	"{loading}",
	"[20:16] Max : Mhhh", "{loading}", "... sure, I guess, just gimme a sec",
	"{pause}"};

	public static List<string> conversation2 = new List<string> { "...", "{pause}"};

	public static List<string> conversation3 = new List<string> { "I should be making my bed first",
	"{wait}", "",
	"Press SPACE to interract on bed" };
}