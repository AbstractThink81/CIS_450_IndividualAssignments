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
		"人",
		"十",
		"口",
		"日",
		"月",
		"木",
		"水"
	};
	public static List<string> finalCompounds = new List<string>
	{
		"什",
		"休",
		"估",
		"保",
		"倡",
		"唱",
		"早",
		"明",
		"椙",
		"棚",
		"森",
		"楜",
		"橸",
		"汁",
		"沓",
		"沐",
		"淋",
		"湖"
	};
	public static List<string> kanji = new List<string>
	{
		"人",
		"十",
		"口",
		"日",
		"月",
		"木",
		"水",
		"古",
		"呆",
		"昌",
		"枯",
		"沽",
		"朋",
		"林",
		"胡",
		"晶",
		"什",
		"休",
		"估",
		"保",
		"倡",
		"唱",
		"早",
		"明",
		"椙",
		"棚",
		"森",
		"楜",
		"橸",
		"汁",
		"沓",
		"沐",
		"淋",
		"湖"
	};
	public static Dictionary<string, Dictionary<string, string>>
		kanjiCompounds = new Dictionary<string, Dictionary<string, string>>
	{
			{"人", new Dictionary<string, string>{ { "十", "什" }, { "木", "休" }, { "古", "估" }, { "呆", "保" }, { "昌", "倡" } } },
			{"十", new Dictionary<string, string>{ { "人", "什" }, { "日", "早" }, { "口", "古" }, { "水", "汁" } } },
			{"口", new Dictionary<string, string>{ { "十", "古" }, { "昌", "唱" }, { "木", "呆" } } },
			{"日", new Dictionary<string, string>{ { "十", "早" }, { "月", "明" }, { "水", "沓" }, { "日", "昌" }, { "昌", "晶" } } },
			{"月", new Dictionary<string, string>{ { "日", "明" }, { "枯", "楜" }, { "沽", "湖" }, { "月", "朋" }, { "古", "胡" } } },
			{"木", new Dictionary<string, string>{ { "人", "休" }, { "昌", "椙" }, { "朋", "棚" }, { "林", "森" }, { "胡", "楜" }, { "晶", "橸" }, { "水", "沐" }, { "口", "呆" }, { "木", "林" }, { "古", "枯" } } },
			{"水", new Dictionary<string, string>{ { "十", "汁" }, { "日", "沓" }, { "木", "沐" }, { "林", "淋" }, { "胡", "湖" }, { "古", "沽" } } }
	};
	public static Dictionary<string, string> kanjiMeanings = new Dictionary<string, string>
	{
		{"人", "person" },//hito person
		{"十", "ten" },//juu ten
		{"口", "mouth" },//kuchi mouth
		{"日", "sun" },//hi sun; nichi day
		{"月", "moon" },//tsuki moon
		{"木", "tree" },//ki tree
		{"水", "water" },//mizu water
		{"古", "old" },//furui old
		{"呆", "be amazed" },//non-jouyou akireru to be amazed; akiregao amazed look
		{"昌", "prosperous" },//nonjouyou shouhei peace, tranquility
		{"枯", "wither" },//jouyou kareru to wither; karasu to kill (vegetation)
		{"沽", "buying and selling" },//non-jouyou kosei simony; koken dignity, credit, reputation
		{"朋", "companion" },//non-jouyou hooyuu friend, hoobai comrade
		{"林", "grove" },//jouyou hayashi woods; shinrin forest; rimboku forest tree
		{"胡", "barbarian" },//non-jouyou goma sesame seed
		{"晶", "sparkle" },//jouyou shouka crystallization
		{"什", "utensil" },//non-jouyou juuki utensil, appliance, furniture
		{"休", "rest" },//jouyou kyuujitsu holiday; yasumu to rest
		{"估", "price" },//non-jouyou rarely used koken; akinau, atai
		{"保", "guarantee" },//jouyou hozon preservation; hozen integrity
		{"倡", "actor" },//non-jouyou shouyou wandering; shouwa cheering in chorus
		{"唱", "chant" },//jouyou tonaeru to recite, to chant; shouwa cheering in chorus
		{"早", "early" },//jouyou hayai fast; sassoku at once; hayahaya quickly
		{"明", "clearness" },//jouyou akarui bright, ashita tomorrow
		{"椙", "cryptomeria" },//non-jouyou sugi cryptomeria
		{"棚", "shelf" },//jouyou tana shelf tanaage pigeonholing
		{"森", "forest" },//jouyou mori forest, shrine grove; shinrin forest; shinshin deeply forested
		{"楜", "walnut" },//non-jouyou kurumi walnut; koshou pepper
		{"橸", "straight grain" },//non-jouyou rarely used (subsititue for 柾), mainly used in place names masame straight grain; masaki spindle tree
		{"汁", "soup" },//jouyou shiru juice, soup; kajuu fruit juice; otsuyu broth, soup
		{"沓", "shoes" },//non-jouyou kutsu shoe; kutsushita socks; kanokutsu black-laquered cowhide boots with curved toes
		{"沐", "wash" },//non-jouyou mokuyoku ablution; mokusuru to wash one's hair or body, to bathe in water
		{"淋", "lonely" },//jinmeiyou rinpa lymph; rinkin gonococcus
		{"湖", "lake" }//jouyou mizuumi lake; koshou wetland; kohan lake shore
	};
	public static Dictionary<string, string> kanjiWords = new Dictionary<string, string>
	{
		{"人", "人 hito - person" },//hito person
		{"十", "十 juu - ten\n十日 tooka - ten days" },//juu ten
		{"口", "口 kuchi - mouth" },//kuchi mouth
		{"日", "日 hi - sun\n日々 hibi - daily\n日曜日 nichiyoubi - Sunday" },//hi sun; nichi day
		{"月", "月 tsuki - moon\n月曜日 getsuyoubi - Monday" },//tsuki moon
		{"木", "木 ki - tree\n木曜日 mokuyoubi - Thursday" },//ki tree
		{"水", "水 mizu - water\n水曜日 suiyoubi - Wednesday" },//mizu water
		{"古", "古い furui - old" },//furui old
		{"呆", "呆れる akireru to be amazed\n呆れ顔 akiregao - amazed look" },//hyougai but common akireru to be amazed; akiregao amazed look
		{"昌", "昌平 shouhei - peace" },//jinmeiyou shouhei peace, tranquility
		{"枯", "枯れる kareru - to wither\n枯らす karasu - to let dry" },//jouyou kareru to wither; karasu to kill (vegetation)
		{"沽", "沽券 koken - dignity,\ndeed of sale (for a land, forest or house)" },//hyougai kosei simony; koken dignity, credit, reputation
		{"朋", "朋友 houyuu - friend\n朋輩 houbai - comrade" },//jinmeiyou hooyuu friend, hoobai comrade
		{"林", "林 hayashi - woods\n森林 shinrin - forest\n林木 rimboku - forest tree" },//jouyou hayashi woods; shinrin forest; rimboku forest tree
		{"胡", "胡麻 goma - sesame seeds\n胡桃 kurumi - walnut\n胡瓜 kyuuri - cucumber\n胡椒 koshou - pepper" },//jinmeiyou goma sesame seed
		{"晶", "晶化 shouka - crystallization\n" },//jouyou shouka crystallization
		{"什", "什器 juuki - utensil" },//hyougai juuki utensil, appliance, furniture
		{"休", "休む yasumu - to rest\n休日 kyuujitsu - holiday" },//jouyou kyuujitsu holiday; yasumu to rest
		{"估", "依估 iko unfairness" },//hyougai rarely used koken; akinau, atai
		{"保", "保存 hozon - preservation\n保全 hozen - integrity" },//jouyou hozon preservation; hozen integrity
		{"倡", "倡佯 shouyou - wandering" },//hyougai shouyou wandering; shouwa cheering in chorus
		{"唱", "唱える tonaeru - to recite\n唱和 shouwa - cheering in chorus" },//jouyou tonaeru to recite, to chant; shouwa cheering in chorus
		{"早", "早い hayai - fast\n早速 sassoku - at once\n早々 hayabaya - promptly" },//jouyou hayai fast; sassoku at once; hayahaya quickly
		{"明", "明るい akarui - bright\n明日 ashita - tomorrow" },//jouyou akarui bright, ashita tomorrow
		{"椙", "椙 sugi - cryptomeria" },//hyougai sugi cryptomeria
		{"棚", "棚 tana - shelf\n棚上げ tanaage - pigeonholing" },//jouyou tana shelf tanaage pigeonholing
		{"森", "森 mori - forest\n森林 shinrin - forest\n森森 shinshin - deeply forested" },//jouyou mori forest, shrine grove; shinrin forest; shinshin deeply forested
		{"楜", "楜ケ原 kurumigahara - place in Japan" },//hyougai kurumi walnut; koshou pepper
		{"橸", "alternate for 柾 in\n柾目 masame - straight grain\n柾 masaki - spindletree" },//hyougai, yuurei rarely used (subsititue for 柾), mainly used in place names masame straight grain; masaki spindle tree
		{"汁", "汁 shiru juice, soup\n果汁 kajuu - fruit juice" },//jouyou shiru juice, soup; kajuu fruit juice; otsuyu broth, soup
		{"沓", "沓谷 kutsunoya - place in Japan" },//jinmeiyou kutsu shoe; kutsushita socks; kanokutsu black-laquered cowhide boots with curved toes
		{"沐", "沐浴 mokuyoku - ablution" },//hyougai mokuyoku ablution; mokusuru to wash one's hair or body, to bathe in water
		{"淋", "淋巴 rinpa - lymph\n淋菌 rinkin - gonococcus" },//jinmeiyou rinpa lymph; rinkin gonococcus
		{"湖", "湖 mizuumi - lake\n 湖沼 koshou - wetland\n湖畔 kohan - lake shore" }//jouyou mizuumi lake; koshou wetland; kohan lake shore
	};
	public enum Commonality
	{
		Common,
		Uncommon,
		Rare
	};
	public static Dictionary<string, Commonality> kanjiCommonality = new Dictionary<string, Commonality>
	{
		{"人", Commonality.Common },//hito person
		{"十", Commonality.Common },//juu ten
		{"口", Commonality.Common },//kuchi mouth
		{"日", Commonality.Common },//hi sun; nichi day
		{"月", Commonality.Common },//tsuki moon
		{"木", Commonality.Common },//ki tree
		{"水", Commonality.Common },//mizu water
		{"古", Commonality.Common },//furui old
		{"呆", Commonality.Rare },//hyougai but common akireru to be amazed; akiregao amazed look
		{"昌", Commonality.Uncommon },//jinmeiyou shouhei peace, tranquility
		{"枯", Commonality.Common },//jouyou kareru to wither; karasu to kill (vegetation)
		{"沽", Commonality.Rare },//hyougai kosei simony; koken dignity, credit, reputation
		{"朋", Commonality.Uncommon },//jinmeiyou hooyuu friend, hoobai comrade
		{"林", Commonality.Common },//jouyou hayashi woods; shinrin forest; rimboku forest tree
		{"胡", Commonality.Uncommon },//jinmeiyou goma sesame seed
		{"晶", Commonality.Common },//jouyou shouka crystallization
		{"什", Commonality.Rare },//hyougai juuki utensil, appliance, furniture
		{"休", Commonality.Common },//jouyou kyuujitsu holiday; yasumu to rest
		{"估", Commonality.Uncommon },//hyougai rarely used koken; akinau, atai
		{"保", Commonality.Common },//jouyou hozon preservation; hozen integrity
		{"倡", Commonality.Rare },//hyougai shouyou wandering; shouwa cheering in chorus
		{"唱", Commonality.Common },//jouyou tonaeru to recite, to chant; shouwa cheering in chorus
		{"早", Commonality.Common },//jouyou hayai fast; sassoku at once; hayahaya quickly
		{"明", Commonality.Common },//jouyou akarui bright, ashita tomorrow
		{"椙", Commonality.Rare },//hyougai sugi cryptomeria
		{"棚", Commonality.Common },//jouyou tana shelf tanaage pigeonholing
		{"森", Commonality.Common },//jouyou mori forest, shrine grove; shinrin forest; shinshin deeply forested
		{"楜", Commonality.Rare },//hyougai kurumi walnut; koshou pepper
		{"橸", Commonality.Rare },//hyougai, yuurei rarely used (subsititue for 柾), mainly used in place names masame straight grain; masaki spindle tree
		{"汁", Commonality.Common },//jouyou shiru juice, soup; kajuu fruit juice; otsuyu broth, soup
		{"沓", Commonality.Uncommon },//jinmeiyou kutsu shoe; kutsushita socks; kanokutsu black-laquered cowhide boots with curved toes
		{"沐", Commonality.Rare },//hyougai mokuyoku ablution; mokusuru to wash one's hair or body, to bathe in water
		{"淋", Commonality.Uncommon },//jinmeiyou rinpa lymph; rinkin gonococcus
		{"湖", Commonality.Common }//jouyou mizuumi lake; koshou wetland; kohan lake shore
	};
}
