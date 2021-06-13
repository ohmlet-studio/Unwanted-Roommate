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
		"{wait1}",
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
		"I haven't seen Sasha in a long time...", "{wait3}", " *sigh* ", "",
		"{pause}", "{clear}", "Anyway, I need a shower"
	};

	public static List<string> aftershower1 = new List<string>
	{
		"Ahhh that's better...", "{wait0.5}", "",
		"Ok, I think I'm ready to go, have I forgotten anything?", "{pause}",

		"{custom1}", "{clear}",
		"Wait", "{loading}", "...",
		"",
		"We can't leave the our home like this",
		"{wait1}", "{pause}",

		"{custom0}", "{clear}",
		"Hummm you're right",
		"{wait0.5}", "{pause}",

		"{custom1}", "{clear}",
		"You should tidy your desk, it's a mess.",
		"{wait0.5}", "{pause}",

		"{custom0}", "{clear}",
		"It's not that messy, I've been working on a projet for school with...",
		"{wait0.5}", "{pause}",

		"{custom1}", "{clear}",
		"I don't want to leave without cleaning our desk", "{loading}", "", "You should clean it",
		"{wait0.5}", "{pause}",

		"{custom0}", "{clear}",
		"I guess you're right.", "",
		"{wait1,5}", " I don't want to be at the party too early anyway","{loading}",
		"", "", " Ok,", "{wait1.5}", " let's get this desk tidy!",
		"{wait0.5}", "{pause}"
	};

	public static List<string> afterdesk = new List<string>
	{
		"Ahhh I'm happy we did that, I feel a bit better. I should probably get going now.",
		"{wait0.5}", "{pause}",

		"{custom1}", "{clear}",
		"It only takes 30 minute to get there. We'll probably still be early. We still have time to get things done here. The rooms still a mess.",
		"{wait0.5}", "{pause}",

		"{custom0}", "{clear}",
		"It's not that bad!",
		"{wait0.5}", "{pause}",

		"{custom1}", "{clear}",
		"Have you seen our face. We're not ready to face the outside world yet.",
		"{wait0.5}", "{pause}",

		"{custom0}", "{clear}",
		"Stop exagerating, I'm not dressed up for a fancy party but I don't  even think it's going to be that kind of party. I don't think i look that bad.",
		"{wait0.5}", "{pause}",

		"{custom1}", "{clear}",
		"{loading}", "... Look in the mirror, then.",
		"{wait0.5}", "{pause}",
	};
	// STATE BED

	// ***************** MIRROR CONVERSATION ***************** //
	// ******************************************************* //

	// REAL SIDE ********************************************* //

	public static List<string> mirrorReal1 = new List<string> { "I don't look that bad, but I FEEL bad." };

	public static List<string> mirrorReal2 = new List<string> { "But I haven't seen my friends in a while..." };

	public static List<string> mirrorReal3 = new List<string> { "You're not healthy for me. ", "{wait1}", "I can't think with you around here. "};

	public static List<string> mirrorReal4 = new List<string> { "You're not always here. ", "{wait1.5}", "Why are you here now?" };

	public static List<string> mirrorReal5 = new List<string> { "You're not helping. ", "{wait1}", "You are making things worse. ", "{wait3}", "", "", "I want to go to a part and you're making me tidy my appartment." };

	public static List<string> mirrorReal6 = new List<string> { "Yes I am. ", "{wait1}", "Stop telling me what to do. ", "", "", "{wait2}", "I don't want you here" };

	public static List<string> mirrorReal7 = new List<string> { "{loading}" };

	public static List<string> mirrorReal8 = new List<string> { "{loading}", "... I understand, but I cannot live like this." };

	public static List<string> mirrorReal9 = new List<string> { "It's too hard to even think.", "", "", "{wait2}", "I don't feel like I have full control of my mind right now." };
	
	public static List<string> mirrorReal10 = new List<string> { "Then let's try and fix this together. " };



	public static List<string> mirrorReal11 = new List<string> { "Don't worry, try and trust me. ", "", "{wait2}", "You're right, I can't leave the appartment yet.", "", "", "{wait2}", "I'm not ready." };

	public static List<string> mirrorReal12 = new List<string> { "Let's just close the windows first." };

	public static List<string> mirrorReal13 = new List<string> { "We can get rid of them together. ", "{wait2}", "Follow my lead." };

	// MIND SIDE ********************************************* //

	public static List<string> mirrorMind1 = new List<string> { "I don't think we should go. ", "{wait1}", "", "", "We look terrible and have loads of things to finish here first." };

	public static List<string> mirrorMind2 = new List<string> { "You don't need them. ", "{wait2}", "We are fine on our own." };

	public static List<string> mirrorMind3 = new List<string> { "{loading}" };

	public static List<string> mirrorMind4 = new List<string> { "You were scared, I came to help." };

	public static List<string> mirrorMind5 = new List<string> { "We're not ready to go outside." };

	public static List<string> mirrorMind6 = new List<string> { "But I am you..." };

	public static List<string> mirrorMind7 = new List<string> { "I don't wanna go. ", "{wait1}", "I'm scared." };

	public static List<string> mirrorMind8 = new List<string> { "{loading}" };

	public static List<string> mirrorMind9 = new List<string> { "I can't just leave. ", "", "{wait2}", "We are not simply joined together.", "", "", "{wait3}", "We are one." };

	public static List<string> mirrorMind10 = new List<string> { "I'm scared. ", "{wait1.5}", "I don't know if we", "{loading}", "... if I can. ", "{wait2}", "There's too much." };

	public static List<string> mirrorMind11 = new List<string> { "I'm scared of all the monsters outside. ", "","{wait1}", "What if they come in?" };

	public static List<string> mirrorMind12 = new List<string> { "I feel a bit better already. ", "", "", "{wait2}", "But what if some of them are already inside?" };

}