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

	public static List<string> text_conv1 = new List<string>{
		"[17:48] Deb : Hey are you still up for tonight ?", "",
		"{loading}",
		"[17:49] Max : Mhhh", "{loading}", "... I don't know ", "{wait1}", " *sigh*", "",
		"{loading}",
		"[17:49] Deb : well sasha and todd are going and they said they really wanted to see you !", "",
		"{wait1}",
		"[17:50] Max : ...", "",
		"{loading}",
		"[17:50] Deb : Anyway bring apple juice ", "{loading}", " I'll see you soon !", "{wait1}", "Bye !", "",
		"{pause}"
	};

	public static List<string> dotdotdot = new List<string> { "...", "{pause}" };

	public static List<string> beforeshower = new List<string> {
		"{loading}",
		"I should at least drop by to say hi", "",
		"I haven't seen Sasha in a long time", "{loading}", "... *sigh* ", "",
		"{pause}", "", "Anyway, I need a shower"
	};

	public static List<string> aftershower1 = new List<string>
	{
		"Ahhh that's better...", "{wait0.5}", "",
		"Ok, I think I'm ready to go, have I forgotten anything?", "{pause}"
	};

	public static List<string> aftershower2 = new List<string>
	{
		"Wait", "{loading}", "We can't leave the our home like this"
	};
}