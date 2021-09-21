using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XMainClient.Utility;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000EFE RID: 3838
	internal class XRankBehaviour : DlgBehaviourBase
	{
		// Token: 0x0600CBC5 RID: 52165 RVA: 0x002E9C78 File Offset: 0x002E7E78
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

		// Token: 0x04005A70 RID: 23152
		public static readonly uint RANK_UI_TYPE_COUNT = 12U;

		// Token: 0x04005A71 RID: 23153
		public IXUIButton m_close;

		// Token: 0x04005A72 RID: 23154
		public XUITabControl m_tabcontrol = new XUITabControl();

		// Token: 0x04005A73 RID: 23155
		public IXUIWrapContent[] m_ListPanel = new IXUIWrapContent[XRankBehaviour.RANK_UI_TYPE_COUNT];

		// Token: 0x04005A74 RID: 23156
		public IXUISprite m_PopularSprite;

		// Token: 0x04005A75 RID: 23157
		public IXUILabel m_PopularLabel;

		// Token: 0x04005A76 RID: 23158
		public GameObject[] m_MyRankFrame = new GameObject[XRankBehaviour.RANK_UI_TYPE_COUNT];

		// Token: 0x04005A77 RID: 23159
		public GameObject[] m_TitleFrame = new GameObject[XRankBehaviour.RANK_UI_TYPE_COUNT];

		// Token: 0x04005A78 RID: 23160
		public XUIPool m_RankGuildPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x04005A79 RID: 23161
		public IXUIPanel m_ListIXUIPanel;

		// Token: 0x04005A7A RID: 23162
		public IXPositionGroup m_ListPositionGroup = null;

		// Token: 0x04005A7B RID: 23163
		public IXUIScrollView m_ListScrollView;

		// Token: 0x04005A7C RID: 23164
		public GameObject m_CharacterInfoFrame;

		// Token: 0x04005A7D RID: 23165
		public IXUILabel m_CharName;

		// Token: 0x04005A7E RID: 23166
		public IXUISprite m_CharProfession;

		// Token: 0x04005A7F RID: 23167
		public IXUILabel m_GuildName;

		// Token: 0x04005A80 RID: 23168
		public IXUISprite m_GuildIcon;

		// Token: 0x04005A81 RID: 23169
		public IXUILabel m_EmptyRankLabel;

		// Token: 0x04005A82 RID: 23170
		public IXPositionGroup m_EmptyRankLabelGroup = null;

		// Token: 0x04005A83 RID: 23171
		public GameObject m_PetInfoFrame;

		// Token: 0x04005A84 RID: 23172
		public IUIDummy m_PlayerSnapshot;

		// Token: 0x04005A85 RID: 23173
		public IUIDummy m_PetSnapshot;

		// Token: 0x04005A86 RID: 23174
		public IUIDummy m_SpriteSnapshot;

		// Token: 0x04005A87 RID: 23175
		public IXUISprite m_CharacterDummyFrame;

		// Token: 0x04005A88 RID: 23176
		public IXUISprite m_PetDummyFrame;

		// Token: 0x04005A89 RID: 23177
		public GameObject m_OriginalRank;

		// Token: 0x04005A8A RID: 23178
		public Transform m_FlowerRankRoot;

		// Token: 0x04005A8B RID: 23179
		public IXUIButton m_DragonGuildHelp;
	}
}
