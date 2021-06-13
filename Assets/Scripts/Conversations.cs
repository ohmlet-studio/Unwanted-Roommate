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
		"","",

		"My name is Max, by the way. " , "{wait1}", "Pleased to meet you. " , "{wait3.5}",
		"", "",
		"You'll be able to tell me where to go using your arrow keys. " , "{wait4}",
		"If you need to interact with an object, get me in front of it and press your spacebar. " , "{wait4}",
		"", "",
		"Whenever you see [...] at the bottom of the screen, press your spacebar to display the next dialogue. ",
		"{pause}",

		"", "", "{clear}",

		"That's it. ", "{wait2}", "Just like that. ",  "{wait2}",  "I think you're ready. I hope you have fun :)", "{pause}"
	};

	public static List<string> ring = new List<string> { "*Ring* *Ring*" };

	public static List<string> text_conv1 = new List<string>{
		"[17:48] Deb : Hey are you still up for tonight ?", "",
		"{wait1}",
		"[17:49] Max : Mhhh", "{loading}", "... I don't know ", "{wait1}",
		
		"", "", " *sigh*", "", "",

		"{loading}",
		"[17:49] Deb : well Sasha and Todd are going and they said they really wanted to see you!", "",
		"{wait1}",
		"[17:50] Max : ...", "",
		"{loading}",
		"[17:50] Deb : Anyway bring apple juice ", "{loading}", " I'll see you soon!", "{wait1}", " Bye!", "",
		"{pause}"
	};

	public static List<string> dotdotdot = new List<string> { "...", "{pause}" };

	public static List<string> beforeshower = new List<string> {
		"{loading}",
		"I should at least drop by to say hi", "",
		"I haven't seen Sasha in a long time...", "{wait3}",
		"", "", " *sigh* ",
		"{pause}", "{clear}", "Anyway, I need a shower"
	};

	public static List<string> aftershower1 = new List<string>
	{
		"Ahhh that's better...", "{wait1}", "",
		"Ok, I think I'm ready to go, have I forgotten anything?", "{pause}",

		"{custom1}", "{clear}",
		"Wait", "{loading}", "...",
		"",
		"We can't leave our room like this",
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
		"Stop exagerating,", "{wait1}", "",
		"I'm not dressed up for a fancy party but I don't  even think it's going to be that kind of party.", "{wait1}", "",
		"I don't think i look that bad.",
		"{wait0.5}", "{pause}",

		"{custom1}", "{clear}",
		"{loading}", "... Look in the mirror, then.",
		"{wait0.5}", "{pause}", "{custom0}"
	};
	// STATE BED

	// ***************** MIRROR CONVERSATION ***************** //
	// ******************************************************* //

	public static List<string> mirrorConv = new List<string>
	{
		"{custom2}", "{clear}",
		"I don't look that bad, but I FEEL bad.", "{wait0.5}", "{pause}",

		"{custom3}", "{clear}",
		"I don't think we should go. ", "{wait1}", "", "", "We look terrible and have loads of things to finish here first.", "{pause}",

		"{custom2}", "{clear}",
		"But I haven't seen my friends in a while...", "{wait0.5}", "{pause}",

		"{custom3}", "{clear}",
		"You don't need them. ", "{wait1}", "We are fine on our own.", "{wait0.5}", "{pause}",

		"{custom2}", "{clear}",
		"You're not healthy for me. ", "{wait1}", "I can't think with you around here. ", "{wait0.5}", "{pause}",

		"{custom3}", "{clear}",
		"{loading}", "{pause}",

		"{custom2}", "{clear}",
		"You're not always here. ", "{wait1}", "Why are you here now?", "{wait0.5}", "{pause}",

		"{custom3}", "{clear}",
		"You were scared, I came to help.", "{wait0.5}", "{pause}",

		"{custom2}", "{clear}",
		"You're not helping. ", "{wait1}", "You are making things worse. ", "{wait1}", "", "", "I want to go to a part and you're making me tidy my appartment.",
		"{wait0.5}", "{pause}",

		"{custom3}", "{clear}",
		"We're not ready to go outside.", "{wait0.5}", "{pause}",

		"{custom2}", "{clear}",
		"Yes I am. ", "{wait1}", "Stop telling me what to do. ", "", "", "{wait1}", "I don't want you here", "{wait0.5}", "{pause}",

		"{custom3}", "{clear}",
		"But I am you...", "{wait0.5}", "{pause}",

		"{custom2}", "{clear}",
		"...", "{wait0.5}", "{pause}",

		"{custom3}", "{clear}",
		"I don't wanna go. ", "{wait1}", "I'm scared.", "{wait0.5}", "{pause}",

		"{custom2}", "{clear}",
		"{loading}", "... I understand, but I cannot live like this.", "{wait0.5}", "{pause}",

		"{custom3}", "{clear}",
		"...", "{wait0.5}", "{pause}",

		"{custom2}", "{clear}",
		"It's too hard to even think.", "", "", "{wait1}", "I don't feel like I have full control of my mind right now.", "{wait0.5}", "{pause}",

		"{custom3}", "{clear}",
		"I can't just leave. ", "", "{wait1}", "We are not simply joined together.", "", "", "{wait1.5}", "We are one.", "{wait0.5}", "{pause}",

		"{custom2}", "{clear}",
		"Then let's try and fix this together. ", "{wait0.5}", "{pause}"
	};


	public static List<string> windowConv = new List<string> {
		"{custom1}", "{clear}",
		"I'm scared. ", "{wait0.5}", "I don't know if we", "{loading}", "... if I can. ", "{wait1}", "There's too much.",
		"{wait0.5}", "{pause}",

		"{custom0}", "{clear}",
		"Don't worry, try and trust me. ", "", "{wait1}", "You're right, I can't leave the appartment yet.", "", "",
		"{wait1}", "I'm not ready.",
		"{wait0.5}", "{pause}",

		"{custom1}", "{clear}",
		"I'm scared of all the monsters outside. ", "","{wait1}", "What if they come in?",
		"{wait0.5}", "{pause}",

		"{custom0}", "{clear}",
		"Let's just close the windows first.",
		"{wait0.5}", "{pause}",
	};

	public static List<string> bedConv = new List<string> {
		"{custom1}", "{clear}",
		"I feel a bit better already. ", "", "", "{wait1}", "But what if some of them are already inside?",
		"{wait0.5}", "{pause}",

		"{custom0}", "{clear}",
		"We can get rid of them together. ", "{wait1}", "Follow my lead.",
		"{wait0.5}", "{pause}",
	};

	public static List<string> shiftTuto = new List<string>
	{
		"You can now swap between the two worlds by pressing the shift Key", "{wait0.1}", "{pause}"
	};

	public static List<string> endingConv = new List<string> {
	"{custom0}", "{clear}",
	"Ahhhh the rooms nice and tidy now, how do you feel? ",
	"{wait0.1}", "{pause}",

	"{custom1}", "{clear}",
	"Better but I'm still not sure about tonight, and we are already late...",
	"{wait0.1}", "{pause}",

	"{custom0}", "{clear}",
	"It's ok, try not to panic. ", "{wait1}", "We feel better, that's the main thing.", "", "", "{wait1}", "We're fine, everything's going to be ok.",
	"{wait0.1}", "{pause}",

	"{custom1}", "{clear}",
	" Should we go?",
	"{wait0.1}", "{pause}",

	"{custom0}", "{clear}",
	"I don't know. ", "{wait1}", "Let's make the decision together. ",
	"{wait0.5}", "{pause}",
};

	public static List<string> conclusionTheyWentOut = new List<string> {
	"Me and my anxiety had a nice time tonight.", "{wait1}", "", "",
	"We didn't socialize muchn but we didn't want to push ourselves.", "{wait1}", "", "",
	"At least i saw Sasha and ate some amazing guacamole.", "{wait1}", "", "",
	"We left with a friend a little early but I'm really happy that we went.", "{wait2}", "", "", "",
	"It was fun!"
};

	public static List<string> conclusionTheyDidnt = new List<string> {
	"Me and my anxiety spent the whole night being creative. ", "{wait1}", "", "",
	"We watched a really cool film and made a lasagna.", "{wait1}", "", "",
	"Honestly, it was delicious.", "{wait1}", "", "",
	"After that we drew a little bit and then went to bed.", "{wait1}", "", "",
	"We managed to make this decision together and not feel guilty.", "{wait2}", "", "", "",
	"I'm really happy"
};
}