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
		"�l",
		"�\",
		"��",
		"��",
		"��",
		"��",
		"��"
	};
	public static List<string> finalCompounds = new List<string>
	{
		"�Y",
		"�x",
		"��",
		"��",
		"��",
		"��",
		"��",
		"��",
		"��",
		"�I",
		"�X",
		"��",
		"��",
		"�`",
		"�B",
		"��",
		"��",
		"��"
	};
	public static List<string> kanji = new List<string>
	{
		"�l",
		"�\",
		"��",
		"��",
		"��",
		"��",
		"��",
		"��",
		"��",
		"��",
		"��",
		"��",
		"��",
		"��",
		"��",
		"��",
		"�Y",
		"�x",
		"��",
		"��",
		"��",
		"��",
		"��",
		"��",
		"��",
		"�I",
		"�X",
		"��",
		"��",
		"�`",
		"�B",
		"��",
		"��",
		"��"
	};
	public static Dictionary<string, Dictionary<string, string>>
		kanjiCompounds = new Dictionary<string, Dictionary<string, string>>
	{
			{"�l", new Dictionary<string, string>{ { "�\", "�Y" }, { "��", "�x" }, { "��", "��" }, { "��", "��" }, { "��", "��" } } },
			{"�\", new Dictionary<string, string>{ { "�l", "�Y" }, { "��", "��" }, { "��", "��" }, { "��", "�`" } } },
			{"��", new Dictionary<string, string>{ { "�\", "��" }, { "��", "��" }, { "��", "��" } } },
			{"��", new Dictionary<string, string>{ { "�\", "��" }, { "��", "��" }, { "��", "�B" }, { "��", "��" }, { "��", "��" } } },
			{"��", new Dictionary<string, string>{ { "��", "��" }, { "��", "��" }, { "��", "��" }, { "��", "��" }, { "��", "��" } } },
			{"��", new Dictionary<string, string>{ { "�l", "�x" }, { "��", "��" }, { "��", "�I" }, { "��", "�X" }, { "��", "��" }, { "��", "��" }, { "��", "��" }, { "��", "��" }, { "��", "��" }, { "��", "��" } } },
			{"��", new Dictionary<string, string>{ { "�\", "�`" }, { "��", "�B" }, { "��", "��" }, { "��", "��" }, { "��", "��" }, { "��", "��" } } }
	};
	public static Dictionary<string, string> kanjiMeanings = new Dictionary<string, string>
	{
		{"�l", "person" },//hito person
		{"�\", "ten" },//juu ten
		{"��", "mouth" },//kuchi mouth
		{"��", "sun" },//hi sun; nichi day
		{"��", "moon" },//tsuki moon
		{"��", "tree" },//ki tree
		{"��", "water" },//mizu water
		{"��", "old" },//furui old
		{"��", "be amazed" },//non-jouyou akireru to be amazed; akiregao amazed look
		{"��", "prosperous" },//nonjouyou shouhei peace, tranquility
		{"��", "wither" },//jouyou kareru to wither; karasu to kill (vegetation)
		{"��", "buying and selling" },//non-jouyou kosei simony; koken dignity, credit, reputation
		{"��", "companion" },//non-jouyou hooyuu friend, hoobai comrade
		{"��", "grove" },//jouyou hayashi woods; shinrin forest; rimboku forest tree
		{"��", "barbarian" },//non-jouyou goma sesame seed
		{"��", "sparkle" },//jouyou shouka crystallization
		{"�Y", "utensil" },//non-jouyou juuki utensil, appliance, furniture
		{"�x", "rest" },//jouyou kyuujitsu holiday; yasumu to rest
		{"��", "price" },//non-jouyou rarely used koken; akinau, atai
		{"��", "guarantee" },//jouyou hozon preservation; hozen integrity
		{"��", "actor" },//non-jouyou shouyou wandering; shouwa cheering in chorus
		{"��", "chant" },//jouyou tonaeru to recite, to chant; shouwa cheering in chorus
		{"��", "early" },//jouyou hayai fast; sassoku at once; hayahaya quickly
		{"��", "clearness" },//jouyou akarui bright, ashita tomorrow
		{"��", "cryptomeria" },//non-jouyou sugi cryptomeria
		{"�I", "shelf" },//jouyou tana shelf tanaage pigeonholing
		{"�X", "forest" },//jouyou mori forest, shrine grove; shinrin forest; shinshin deeply forested
		{"��", "walnut" },//non-jouyou kurumi walnut; koshou pepper
		{"��", "straight grain" },//non-jouyou rarely used (subsititue for ��), mainly used in place names masame straight grain; masaki spindle tree
		{"�`", "soup" },//jouyou shiru juice, soup; kajuu fruit juice; otsuyu broth, soup
		{"�B", "shoes" },//non-jouyou kutsu shoe; kutsushita socks; kanokutsu black-laquered cowhide boots with curved toes
		{"��", "wash" },//non-jouyou mokuyoku ablution; mokusuru to wash one's hair or body, to bathe in water
		{"��", "lonely" },//jinmeiyou rinpa lymph; rinkin gonococcus
		{"��", "lake" }//jouyou mizuumi lake; koshou wetland; kohan lake shore
	};
	public static Dictionary<string, string> kanjiWords = new Dictionary<string, string>
	{
		{"�l", "�l hito - person" },//hito person
		{"�\", "�\ juu - ten\n�\�� tooka - ten days" },//juu ten
		{"��", "�� kuchi - mouth" },//kuchi mouth
		{"��", "�� hi - sun\n���X hibi - daily\n���j�� nichiyoubi - Sunday" },//hi sun; nichi day
		{"��", "�� tsuki - moon\n���j�� getsuyoubi - Monday" },//tsuki moon
		{"��", "�� ki - tree\n�ؗj�� mokuyoubi - Thursday" },//ki tree
		{"��", "�� mizu - water\n���j�� suiyoubi - Wednesday" },//mizu water
		{"��", "�Â� furui - old" },//furui old
		{"��", "����� akireru to be amazed\n����� akiregao - amazed look" },//hyougai but common akireru to be amazed; akiregao amazed look
		{"��", "���� shouhei - peace" },//jinmeiyou shouhei peace, tranquility
		{"��", "�͂�� kareru - to wither\n�͂炷 karasu - to let dry" },//jouyou kareru to wither; karasu to kill (vegetation)
		{"��", "���� koken - dignity,\ndeed of sale (for a land, forest or house)" },//hyougai kosei simony; koken dignity, credit, reputation
		{"��", "���F houyuu - friend\n���y houbai - comrade" },//jinmeiyou hooyuu friend, hoobai comrade
		{"��", "�� hayashi - woods\n�X�� shinrin - forest\n�і� rimboku - forest tree" },//jouyou hayashi woods; shinrin forest; rimboku forest tree
		{"��", "�Ӗ� goma - sesame seeds\n�ӓ� kurumi - walnut\n�ӉZ kyuuri - cucumber\n�Ӟ� koshou - pepper" },//jinmeiyou goma sesame seed
		{"��", "���� shouka - crystallization\n" },//jouyou shouka crystallization
		{"�Y", "�Y�� juuki - utensil" },//hyougai juuki utensil, appliance, furniture
		{"�x", "�x�� yasumu - to rest\n�x�� kyuujitsu - holiday" },//jouyou kyuujitsu holiday; yasumu to rest
		{"��", "�˘� iko unfairness" },//hyougai rarely used koken; akinau, atai
		{"��", "�ۑ� hozon - preservation\n�ۑS hozen - integrity" },//jouyou hozon preservation; hozen integrity
		{"��", "��� shouyou - wandering" },//hyougai shouyou wandering; shouwa cheering in chorus
		{"��", "������ tonaeru - to recite\n���a shouwa - cheering in chorus" },//jouyou tonaeru to recite, to chant; shouwa cheering in chorus
		{"��", "���� hayai - fast\n���� sassoku - at once\n���X hayabaya - promptly" },//jouyou hayai fast; sassoku at once; hayahaya quickly
		{"��", "���邢 akarui - bright\n���� ashita - tomorrow" },//jouyou akarui bright, ashita tomorrow
		{"��", "�� sugi - cryptomeria" },//hyougai sugi cryptomeria
		{"�I", "�I tana - shelf\n�I�グ tanaage - pigeonholing" },//jouyou tana shelf tanaage pigeonholing
		{"�X", "�X mori - forest\n�X�� shinrin - forest\n�X�X shinshin - deeply forested" },//jouyou mori forest, shrine grove; shinrin forest; shinshin deeply forested
		{"��", "���P�� kurumigahara - place in Japan" },//hyougai kurumi walnut; koshou pepper
		{"��", "alternate for �� in\n���� masame - straight grain\n�� masaki - spindletree" },//hyougai, yuurei rarely used (subsititue for ��), mainly used in place names masame straight grain; masaki spindle tree
		{"�`", "�` shiru juice, soup\n�ʏ` kajuu - fruit juice" },//jouyou shiru juice, soup; kajuu fruit juice; otsuyu broth, soup
		{"�B", "�B�J kutsunoya - place in Japan" },//jinmeiyou kutsu shoe; kutsushita socks; kanokutsu black-laquered cowhide boots with curved toes
		{"��", "���� mokuyoku - ablution" },//hyougai mokuyoku ablution; mokusuru to wash one's hair or body, to bathe in water
		{"��", "�Ҕb rinpa - lymph\n�ҋ� rinkin - gonococcus" },//jinmeiyou rinpa lymph; rinkin gonococcus
		{"��", "�� mizuumi - lake\n �Ώ� koshou - wetland\n�Δ� kohan - lake shore" }//jouyou mizuumi lake; koshou wetland; kohan lake shore
	};
	public enum Commonality
	{
		Common,
		Uncommon,
		Rare
	};
	public static Dictionary<string, Commonality> kanjiCommonality = new Dictionary<string, Commonality>
	{
		{"�l", Commonality.Common },//hito person
		{"�\", Commonality.Common },//juu ten
		{"��", Commonality.Common },//kuchi mouth
		{"��", Commonality.Common },//hi sun; nichi day
		{"��", Commonality.Common },//tsuki moon
		{"��", Commonality.Common },//ki tree
		{"��", Commonality.Common },//mizu water
		{"��", Commonality.Common },//furui old
		{"��", Commonality.Rare },//hyougai but common akireru to be amazed; akiregao amazed look
		{"��", Commonality.Uncommon },//jinmeiyou shouhei peace, tranquility
		{"��", Commonality.Common },//jouyou kareru to wither; karasu to kill (vegetation)
		{"��", Commonality.Rare },//hyougai kosei simony; koken dignity, credit, reputation
		{"��", Commonality.Uncommon },//jinmeiyou hooyuu friend, hoobai comrade
		{"��", Commonality.Common },//jouyou hayashi woods; shinrin forest; rimboku forest tree
		{"��", Commonality.Uncommon },//jinmeiyou goma sesame seed
		{"��", Commonality.Common },//jouyou shouka crystallization
		{"�Y", Commonality.Rare },//hyougai juuki utensil, appliance, furniture
		{"�x", Commonality.Common },//jouyou kyuujitsu holiday; yasumu to rest
		{"��", Commonality.Uncommon },//hyougai rarely used koken; akinau, atai
		{"��", Commonality.Common },//jouyou hozon preservation; hozen integrity
		{"��", Commonality.Rare },//hyougai shouyou wandering; shouwa cheering in chorus
		{"��", Commonality.Common },//jouyou tonaeru to recite, to chant; shouwa cheering in chorus
		{"��", Commonality.Common },//jouyou hayai fast; sassoku at once; hayahaya quickly
		{"��", Commonality.Common },//jouyou akarui bright, ashita tomorrow
		{"��", Commonality.Rare },//hyougai sugi cryptomeria
		{"�I", Commonality.Common },//jouyou tana shelf tanaage pigeonholing
		{"�X", Commonality.Common },//jouyou mori forest, shrine grove; shinrin forest; shinshin deeply forested
		{"��", Commonality.Rare },//hyougai kurumi walnut; koshou pepper
		{"��", Commonality.Rare },//hyougai, yuurei rarely used (subsititue for ��), mainly used in place names masame straight grain; masaki spindle tree
		{"�`", Commonality.Common },//jouyou shiru juice, soup; kajuu fruit juice; otsuyu broth, soup
		{"�B", Commonality.Uncommon },//jinmeiyou kutsu shoe; kutsushita socks; kanokutsu black-laquered cowhide boots with curved toes
		{"��", Commonality.Rare },//hyougai mokuyoku ablution; mokusuru to wash one's hair or body, to bathe in water
		{"��", Commonality.Uncommon },//jinmeiyou rinpa lymph; rinkin gonococcus
		{"��", Commonality.Common }//jouyou mizuumi lake; koshou wetland; kohan lake shore
	};
}
