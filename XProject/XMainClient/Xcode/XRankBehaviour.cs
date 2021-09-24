using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XMainClient.Utility;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XRankBehaviour : DlgBehaviourBase
	{

		private void Awake()
		{
			this.m_close = (base.transform.Find("Bg/Close").GetComponent("XUIButton") as IXUIButton);
			string[] array = new string[]
			{
				"BaseList",
				"GuildList",
				"TwoNameList",
				"GuildBossList",
				"PetList",
				"QualifyList",
				"BigMeleeList",
				"TroopList",
				"SkyArenaList",
				"WorldBossList",
				"CampDuelList",
				"TeamMysterious"
			};
			Transform tabTpl = base.transform.FindChild("Bg/TabList/Panel/TabTpl");
			this.m_tabcontrol.SetTabTpl(tabTpl);
			for (uint num = 0U; num < XRankBehaviour.RANK_UI_TYPE_COUNT; num += 1U)
			{
				this.m_ListPanel[(int)num] = (base.transform.FindChild("Bg/Bg/Panel/" + array[(int)num]).GetComponent("XUIWrapContent") as IXUIWrapContent);
				this.m_MyRankFrame[(int)num] = base.transform.FindChild("Bg/Bg/MyRankFrame/" + array[(int)num]).gameObject;
				this.m_TitleFrame[(int)num] = base.transform.Find("Bg/Bg/Titles/" + array[(int)num]).gameObject;
			}
			this.m_CharacterInfoFrame = base.transform.FindChild("Bg/Bg/CharacterInfoFrame").gameObject;
			this.m_CharName = (this.m_CharacterInfoFrame.transform.FindChild("TitleFrame/Name").GetComponent("XUILabel") as IXUILabel);
			this.m_CharName.SetText("");
			this.m_CharProfession = (this.m_CharacterInfoFrame.transform.FindChild("TitleFrame/ProfIcon").GetComponent("XUISprite") as IXUISprite);
			this.m_GuildName = (this.m_CharacterInfoFrame.transform.FindChild("TitleFrame/Guild").GetComponent("XUILabel") as IXUILabel);
			this.m_GuildName.SetText("");
			this.m_GuildIcon = (this.m_CharacterInfoFrame.transform.FindChild("TitleFrame/GulidIcon").GetComponent("XUISprite") as IXUISprite);
			this.m_CharacterDummyFrame = (this.m_CharacterInfoFrame.transform.Find("CharacterFrame").GetComponent("XUISprite") as IXUISprite);
			this.m_PetInfoFrame = base.transform.FindChild("Bg/Bg/PetInfoFrame").gameObject;
			this.m_PetDummyFrame = (this.m_PetInfoFrame.transform.Find("PetFrame").GetComponent("XUISprite") as IXUISprite);
			this.m_ListIXUIPanel = (base.transform.FindChild("Bg/Bg/Panel").GetComponent("XUIPanel") as IXUIPanel);
			this.m_ListPositionGroup = (base.transform.FindChild("Bg/Bg/Panel").GetComponent("PositionGroup") as IXPositionGroup);
			this.m_ListScrollView = (base.transform.FindChild("Bg/Bg/Panel").GetComponent("XUIScrollView") as IXUIScrollView);
			this.m_EmptyRankLabel = (base.transform.FindChild("Bg/Bg/Panel/EmptyRank").GetComponent("XUILabel") as IXUILabel);
			this.m_EmptyRankLabel.SetText("");
			this.m_EmptyRankLabelGroup = (this.m_EmptyRankLabel.gameObject.transform.GetComponent("PositionGroup") as IXPositionGroup);
			this.m_PlayerSnapshot = (this.m_CharacterInfoFrame.transform.FindChild("CharacterFrame/Snapshot").GetComponent("UIDummy") as IUIDummy);
			this.m_PetSnapshot = (this.m_PetInfoFrame.transform.FindChild("PetFrame/Snapshot").GetComponent("UIDummy") as IUIDummy);
			this.m_SpriteSnapshot = (this.m_CharacterInfoFrame.transform.FindChild("CharacterFrame/SpriteSnapshot").GetComponent("UIDummy") as IUIDummy);
			this.m_PopularSprite = (base.transform.FindChild("Bg/Bg/Titles/GuildList/Popularity/Tips").GetComponent("XUISprite") as IXUISprite);
			this.m_PopularLabel = (base.transform.FindChild("Bg/Bg/Titles/GuildList/PopularityTips").GetComponent("XUILabel") as IXUILabel);
			this.m_OriginalRank = base.transform.Find("Bg/Bg").gameObject;
			this.m_FlowerRankRoot = base.transform.Find("Bg/FlowerRankRoot");
			this.m_DragonGuildHelp = (base.transform.FindChild("Bg/Bg/Titles/TroopList/Help").GetComponent("XUIButton") as IXUIButton);
		}

		public static readonly uint RANK_UI_TYPE_COUNT = 12U;

		public IXUIButton m_close;

		public XUITabControl m_tabcontrol = new XUITabControl();

		public IXUIWrapContent[] m_ListPanel = new IXUIWrapContent[XRankBehaviour.RANK_UI_TYPE_COUNT];

		public IXUISprite m_PopularSprite;

		public IXUILabel m_PopularLabel;

		public GameObject[] m_MyRankFrame = new GameObject[XRankBehaviour.RANK_UI_TYPE_COUNT];

		public GameObject[] m_TitleFrame = new GameObject[XRankBehaviour.RANK_UI_TYPE_COUNT];

		public XUIPool m_RankGuildPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		public IXUIPanel m_ListIXUIPanel;

		public IXPositionGroup m_ListPositionGroup = null;

		public IXUIScrollView m_ListScrollView;

		public GameObject m_CharacterInfoFrame;

		public IXUILabel m_CharName;

		public IXUISprite m_CharProfession;

		public IXUILabel m_GuildName;

		public IXUISprite m_GuildIcon;

		public IXUILabel m_EmptyRankLabel;

		public IXPositionGroup m_EmptyRankLabelGroup = null;

		public GameObject m_PetInfoFrame;

		public IUIDummy m_PlayerSnapshot;

		public IUIDummy m_PetSnapshot;

		public IUIDummy m_SpriteSnapshot;

		public IXUISprite m_CharacterDummyFrame;

		public IXUISprite m_PetDummyFrame;

		public GameObject m_OriginalRank;

		public Transform m_FlowerRankRoot;

		public IXUIButton m_DragonGuildHelp;
	}
}
