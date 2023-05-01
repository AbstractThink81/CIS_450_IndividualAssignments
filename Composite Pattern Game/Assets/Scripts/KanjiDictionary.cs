/*
* Ian Connors
* KanjiDictionary.cs
* CIS 450 - Assignment 12
* Contains the information for which kanji can be combined and the meanings, sample words, and rarity for each kanji
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class KanjiDictionary
{
	public static List<string> kanjiRadicals = new List<string>
	{
		"l",
		"\",
		"Œû",
		"“ú",
		"Œ",
		"–Ø",
		"…"
	};
	public static List<string> finalCompounds = new List<string>
	{
		"Y",
		"‹x",
		"˜Ä",
		"•Û",
		"˜ç",
		"¥",
		"‘",
		"–¾",
		"š",
		"’I",
		"X",
		"³",
		"ï",
		"`",
		"ŒB",
		"Ÿ”",
		"—Ò",
		"ŒÎ"
	};
	public static List<string> kanji = new List<string>
	{
		"l",
		"\",
		"Œû",
		"“ú",
		"Œ",
		"–Ø",
		"…",
		"ŒÃ",
		"•ğ",
		"¹",
		"ŒÍ",
		"Ÿ˜",
		"•ü",
		"—Ñ",
		"ŒÓ",
		"»",
		"Y",
		"‹x",
		"˜Ä",
		"•Û",
		"˜ç",
		"¥",
		"‘",
		"–¾",
		"š",
		"’I",
		"X",
		"³",
		"ï",
		"`",
		"ŒB",
		"Ÿ”",
		"—Ò",
		"ŒÎ"
	};
	public static Dictionary<string, Dictionary<string, string>>
		kanjiCompounds = new Dictionary<string, Dictionary<string, string>>
	{
			{"l", new Dictionary<string, string>{ { "\", "Y" }, { "–Ø", "‹x" }, { "ŒÃ", "˜Ä" }, { "•ğ", "•Û" }, { "¹", "˜ç" } } },
			{"\", new Dictionary<string, string>{ { "l", "Y" }, { "“ú", "‘" }, { "Œû", "ŒÃ" }, { "…", "`" } } },
			{"Œû", new Dictionary<string, string>{ { "\", "ŒÃ" }, { "¹", "¥" }, { "–Ø", "•ğ" } } },
			{"“ú", new Dictionary<string, string>{ { "\", "‘" }, { "Œ", "–¾" }, { "…", "ŒB" }, { "“ú", "¹" }, { "¹", "»" } } },
			{"Œ", new Dictionary<string, string>{ { "“ú", "–¾" }, { "ŒÍ", "³" }, { "Ÿ˜", "ŒÎ" }, { "Œ", "•ü" }, { "ŒÃ", "ŒÓ" } } },
			{"–Ø", new Dictionary<string, string>{ { "l", "‹x" }, { "¹", "š" }, { "•ü", "’I" }, { "—Ñ", "X" }, { "ŒÓ", "³" }, { "»", "ï" }, { "…", "Ÿ”" }, { "Œû", "•ğ" }, { "–Ø", "—Ñ" }, { "ŒÃ", "ŒÍ" } } },
			{"…", new Dictionary<string, string>{ { "\", "`" }, { "“ú", "ŒB" }, { "–Ø", "Ÿ”" }, { "—Ñ", "—Ò" }, { "ŒÓ", "ŒÎ" }, { "ŒÃ", "Ÿ˜" } } }
	};
	public static Dictionary<string, string> kanjiMeanings = new Dictionary<string, string>
	{
		{"l", "person" },//hito person
		{"\", "ten" },//juu ten
		{"Œû", "mouth" },//kuchi mouth
		{"“ú", "sun" },//hi sun; nichi day
		{"Œ", "moon" },//tsuki moon
		{"–Ø", "tree" },//ki tree
		{"…", "water" },//mizu water
		{"ŒÃ", "old" },//furui old
		{"•ğ", "be amazed" },//non-jouyou akireru to be amazed; akiregao amazed look
		{"¹", "prosperous" },//nonjouyou shouhei peace, tranquility
		{"ŒÍ", "wither" },//jouyou kareru to wither; karasu to kill (vegetation)
		{"Ÿ˜", "buying and selling" },//non-jouyou kosei simony; koken dignity, credit, reputation
		{"•ü", "companion" },//non-jouyou hooyuu friend, hoobai comrade
		{"—Ñ", "grove" },//jouyou hayashi woods; shinrin forest; rimboku forest tree
		{"ŒÓ", "barbarian" },//non-jouyou goma sesame seed
		{"»", "sparkle" },//jouyou shouka crystallization
		{"Y", "utensil" },//non-jouyou juuki utensil, appliance, furniture
		{"‹x", "rest" },//jouyou kyuujitsu holiday; yasumu to rest
		{"˜Ä", "price" },//non-jouyou rarely used koken; akinau, atai
		{"•Û", "guarantee" },//jouyou hozon preservation; hozen integrity
		{"˜ç", "actor" },//non-jouyou shouyou wandering; shouwa cheering in chorus
		{"¥", "chant" },//jouyou tonaeru to recite, to chant; shouwa cheering in chorus
		{"‘", "early" },//jouyou hayai fast; sassoku at once; hayahaya quickly
		{"–¾", "clearness" },//jouyou akarui bright, ashita tomorrow
		{"š", "cryptomeria" },//non-jouyou sugi cryptomeria
		{"’I", "shelf" },//jouyou tana shelf tanaage pigeonholing
		{"X", "forest" },//jouyou mori forest, shrine grove; shinrin forest; shinshin deeply forested
		{"³", "walnut" },//non-jouyou kurumi walnut; koshou pepper
		{"ï", "straight grain" },//non-jouyou rarely used (subsititue for –), mainly used in place names masame straight grain; masaki spindle tree
		{"`", "soup" },//jouyou shiru juice, soup; kajuu fruit juice; otsuyu broth, soup
		{"ŒB", "shoes" },//non-jouyou kutsu shoe; kutsushita socks; kanokutsu black-laquered cowhide boots with curved toes
		{"Ÿ”", "wash" },//non-jouyou mokuyoku ablution; mokusuru to wash one's hair or body, to bathe in water
		{"—Ò", "lonely" },//jinmeiyou rinpa lymph; rinkin gonococcus
		{"ŒÎ", "lake" }//jouyou mizuumi lake; koshou wetland; kohan lake shore
	};
	public static Dictionary<string, string> kanjiWords = new Dictionary<string, string>
	{
		{"l", "l hito - person" },//hito person
		{"\", "\ juu - ten\n\“ú tooka - ten days" },//juu ten
		{"Œû", "Œû kuchi - mouth" },//kuchi mouth
		{"“ú", "“ú hi - sun\n“úX hibi - daily\n“ú—j“ú nichiyoubi - Sunday" },//hi sun; nichi day
		{"Œ", "Œ tsuki - moon\nŒ—j“ú getsuyoubi - Monday" },//tsuki moon
		{"–Ø", "–Ø ki - tree\n–Ø—j“ú mokuyoubi - Thursday" },//ki tree
		{"…", "… mizu - water\n…—j“ú suiyoubi - Wednesday" },//mizu water
		{"ŒÃ", "ŒÃ‚¢ furui - old" },//furui old
		{"•ğ", "•ğ‚ê‚é akireru to be amazed\n•ğ‚êŠç akiregao - amazed look" },//hyougai but common akireru to be amazed; akiregao amazed look
		{"¹", "¹•½ shouhei - peace" },//jinmeiyou shouhei peace, tranquility
		{"ŒÍ", "ŒÍ‚ê‚é kareru - to wither\nŒÍ‚ç‚· karasu - to let dry" },//jouyou kareru to wither; karasu to kill (vegetation)
		{"Ÿ˜", "Ÿ˜Œ” koken - dignity,\ndeed of sale (for a land, forest or house)" },//hyougai kosei simony; koken dignity, credit, reputation
		{"•ü", "•ü—F houyuu - friend\n•ü”y houbai - comrade" },//jinmeiyou hooyuu friend, hoobai comrade
		{"—Ñ", "—Ñ hayashi - woods\nX—Ñ shinrin - forest\n—Ñ–Ø rimboku - forest tree" },//jouyou hayashi woods; shinrin forest; rimboku forest tree
		{"ŒÓ", "ŒÓ–ƒ goma - sesame seeds\nŒÓ“ kurumi - walnut\nŒÓ‰Z kyuuri - cucumber\nŒÓ£ koshou - pepper" },//jinmeiyou goma sesame seed
		{"»", "»‰» shouka - crystallization\n" },//jouyou shouka crystallization
		{"Y", "YŠí juuki - utensil" },//hyougai juuki utensil, appliance, furniture
		{"‹x", "‹x‚Ş yasumu - to rest\n‹x“ú kyuujitsu - holiday" },//jouyou kyuujitsu holiday; yasumu to rest
		{"˜Ä", "ˆË˜Ä iko unfairness" },//hyougai rarely used koken; akinau, atai
		{"•Û", "•Û‘¶ hozon - preservation\n•Û‘S hozen - integrity" },//jouyou hozon preservation; hozen integrity
		{"˜ç", "˜ç˜Ñ shouyou - wandering" },//hyougai shouyou wandering; shouwa cheering in chorus
		{"¥", "¥‚¦‚é tonaeru - to recite\n¥˜a shouwa - cheering in chorus" },//jouyou tonaeru to recite, to chant; shouwa cheering in chorus
		{"‘", "‘‚¢ hayai - fast\n‘‘¬ sassoku - at once\n‘X hayabaya - promptly" },//jouyou hayai fast; sassoku at once; hayahaya quickly
		{"–¾", "–¾‚é‚¢ akarui - bright\n–¾“ú ashita - tomorrow" },//jouyou akarui bright, ashita tomorrow
		{"š", "š sugi - cryptomeria" },//hyougai sugi cryptomeria
		{"’I", "’I tana - shelf\n’Iã‚° tanaage - pigeonholing" },//jouyou tana shelf tanaage pigeonholing
		{"X", "X mori - forest\nX—Ñ shinrin - forest\nXX shinshin - deeply forested" },//jouyou mori forest, shrine grove; shinrin forest; shinshin deeply forested
		{"³", "³ƒPŒ´ kurumigahara - place in Japan" },//hyougai kurumi walnut; koshou pepper
		{"ï", "alternate for – in\n––Ú masame - straight grain\n– masaki - spindletree" },//hyougai, yuurei rarely used (subsititue for –), mainly used in place names masame straight grain; masaki spindle tree
		{"`", "` shiru juice, soup\n‰Ê` kajuu - fruit juice" },//jouyou shiru juice, soup; kajuu fruit juice; otsuyu broth, soup
		{"ŒB", "ŒB’J kutsunoya - place in Japan" },//jinmeiyou kutsu shoe; kutsushita socks; kanokutsu black-laquered cowhide boots with curved toes
		{"Ÿ”", "Ÿ”— mokuyoku - ablution" },//hyougai mokuyoku ablution; mokusuru to wash one's hair or body, to bathe in water
		{"—Ò", "—Ò”b rinpa - lymph\n—Ò‹Û rinkin - gonococcus" },//jinmeiyou rinpa lymph; rinkin gonococcus
		{"ŒÎ", "ŒÎ mizuumi - lake\n ŒÎÀ koshou - wetland\nŒÎ”È kohan - lake shore" }//jouyou mizuumi lake; koshou wetland; kohan lake shore
	};
	public enum Commonality
	{
		Common,
		Uncommon,
		Rare
	};
	public static Dictionary<string, Commonality> kanjiCommonality = new Dictionary<string, Commonality>
	{
		{"l", Commonality.Common },//hito person
		{"\", Commonality.Common },//juu ten
		{"Œû", Commonality.Common },//kuchi mouth
		{"“ú", Commonality.Common },//hi sun; nichi day
		{"Œ", Commonality.Common },//tsuki moon
		{"–Ø", Commonality.Common },//ki tree
		{"…", Commonality.Common },//mizu water
		{"ŒÃ", Commonality.Common },//furui old
		{"•ğ", Commonality.Rare },//hyougai but common akireru to be amazed; akiregao amazed look
		{"¹", Commonality.Uncommon },//jinmeiyou shouhei peace, tranquility
		{"ŒÍ", Commonality.Common },//jouyou kareru to wither; karasu to kill (vegetation)
		{"Ÿ˜", Commonality.Rare },//hyougai kosei simony; koken dignity, credit, reputation
		{"•ü", Commonality.Uncommon },//jinmeiyou hooyuu friend, hoobai comrade
		{"—Ñ", Commonality.Common },//jouyou hayashi woods; shinrin forest; rimboku forest tree
		{"ŒÓ", Commonality.Uncommon },//jinmeiyou goma sesame seed
		{"»", Commonality.Common },//jouyou shouka crystallization
		{"Y", Commonality.Rare },//hyougai juuki utensil, appliance, furniture
		{"‹x", Commonality.Common },//jouyou kyuujitsu holiday; yasumu to rest
		{"˜Ä", Commonality.Uncommon },//hyougai rarely used koken; akinau, atai
		{"•Û", Commonality.Common },//jouyou hozon preservation; hozen integrity
		{"˜ç", Commonality.Rare },//hyougai shouyou wandering; shouwa cheering in chorus
		{"¥", Commonality.Common },//jouyou tonaeru to recite, to chant; shouwa cheering in chorus
		{"‘", Commonality.Common },//jouyou hayai fast; sassoku at once; hayahaya quickly
		{"–¾", Commonality.Common },//jouyou akarui bright, ashita tomorrow
		{"š", Commonality.Rare },//hyougai sugi cryptomeria
		{"’I", Commonality.Common },//jouyou tana shelf tanaage pigeonholing
		{"X", Commonality.Common },//jouyou mori forest, shrine grove; shinrin forest; shinshin deeply forested
		{"³", Commonality.Rare },//hyougai kurumi walnut; koshou pepper
		{"ï", Commonality.Rare },//hyougai, yuurei rarely used (subsititue for –), mainly used in place names masame straight grain; masaki spindle tree
		{"`", Commonality.Common },//jouyou shiru juice, soup; kajuu fruit juice; otsuyu broth, soup
		{"ŒB", Commonality.Uncommon },//jinmeiyou kutsu shoe; kutsushita socks; kanokutsu black-laquered cowhide boots with curved toes
		{"Ÿ”", Commonality.Rare },//hyougai mokuyoku ablution; mokusuru to wash one's hair or body, to bathe in water
		{"—Ò", Commonality.Uncommon },//jinmeiyou rinpa lymph; rinkin gonococcus
		{"ŒÎ", Commonality.Common }//jouyou mizuumi lake; koshou wetland; kohan lake shore
	};
}
