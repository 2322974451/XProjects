using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000C4C RID: 3148
	internal class MilitaryRankBehaviour : DlgBehaviourBase
	{
		// Token: 0x0600B2B0 RID: 45744 RVA: 0x00228E90 File Offset: 0x00227090
		private void Awake()
		{
			this.m_Close = (base.transform.Find("Bg/Close").GetComponent("XUIButton") as IXUIButton);
			Transform transform = base.transform.Find("Bg/Bg/CharacterInfoFrame");
			this.m_MilitaryValue = (transform.Find("CharacterFrame/MilitaryValue").GetComponent("XUILabel") as IXUILabel);
			this.m_MilitaryRange = (transform.Find("CharacterFrame/MilitaryRange").GetComponent("XUILabel") as IXUILabel);
			this.m_NextMilitary = (transform.Find("CharacterFrame/Next/Text").GetComponent("XUILabel") as IXUILabel);
			this.m_NextMilitaryIcon = (transform.Find("CharacterFrame/Next/Icon").GetComponent("XUISprite") as IXUISprite);
			this.m_MilitaryName = (transform.Find("CharacterFrame/MilitaryName").GetComponent("XUILabel") as IXUILabel);
			this.m_MilitaryIcon = (transform.Find("CharacterFrame/MilitaryIcon").GetComponent("XUISprite") as IXUISprite);
			this.m_RewardBtn = (transform.Find("CharacterFrame/RewardBtn").GetComponent("XUISprite") as IXUISprite);
			this.m_RecordBtn = (transform.Find("CharacterFrame/RecordBtn").GetComponent("XUISprite") as IXUISprite);
			this.m_snapshotTransfrom = (transform.FindChild("CharacterFrame/Snapshot").GetComponent("UIDummy") as IUIDummy);
			this.m_DateTime = (base.transform.Find("Bg/Bg/CharacterInfoFrame/TitleFrame/Date").GetComponent("XUILabel") as IXUILabel);
			this.m_RewardFrame = base.transform.Find("Bg/RewardFrame").gameObject;
			this.m_RewardCloseBtn = (this.m_RewardFrame.transform.Find("Close").GetComponent("XUISprite") as IXUISprite);
			this.m_RewardSeasonIcb = (this.m_RewardFrame.transform.Find("ToggleSeason").GetComponent("XUICheckBox") as IXUICheckBox);
			this.m_RewardResultIcb = (this.m_RewardFrame.transform.Find("ToggleResult").GetComponent("XUICheckBox") as IXUICheckBox);
			this.m_RewardSeasonFrame = this.m_RewardFrame.transform.Find("SeasonPanel").gameObject;
			this.m_RewardResultFrame = this.m_RewardFrame.transform.Find("ResultPanel").gameObject;
			Transform transform2 = this.m_RewardFrame.transform.Find("SeasonPanel/Panel/Tpl");
			this.m_RewardSeasonPool.SetupPool(transform2.parent.gameObject, transform2.gameObject, 10U, false);
			transform2 = this.m_RewardFrame.transform.Find("ResultPanel/Panel/Tpl");
			this.m_RewardResultPool.SetupPool(transform2.parent.gameObject, transform2.gameObject, 10U, false);
			transform2 = this.m_RewardFrame.transform.Find("SeasonPanel/Panel/ItemTpl");
			this.m_RewardItemPool.SetupPool(transform2.parent.gameObject, transform2.gameObject, 30U, false);
			this.m_BattleRecordFrame = base.transform.Find("Bg/BattleRecordFrame").gameObject;
			this.m_RecordHBtab = (base.transform.Find("Bg/BattleRecordFrame/HeroBattleTab").GetComponent("XUICheckBox") as IXUICheckBox);
			this.m_RecordCPtab = (base.transform.Find("Bg/BattleRecordFrame/CaptainTab").GetComponent("XUICheckBox") as IXUICheckBox);
			this.m_WrapContent = (base.transform.Find("Bg/Bg/Panel/BaseList").GetComponent("XUIWrapContent") as IXUIWrapContent);
			this.m_ScrollView = (base.transform.Find("Bg/Bg/Panel").GetComponent("XUIScrollView") as IXUIScrollView);
			this.m_MyRank = base.transform.Find("Bg/Bg/MyRankFrame/Tpl");
			this.m_EmptyRank = base.transform.Find("Bg/Bg/EmptyRank").gameObject;
		}

		// Token: 0x040044D2 RID: 17618
		public IXUIButton m_Close;

		// Token: 0x040044D3 RID: 17619
		public IUIDummy m_snapshotTransfrom;

		// Token: 0x040044D4 RID: 17620
		public IXUILabel m_MilitaryValue;

		// Token: 0x040044D5 RID: 17621
		public IXUILabel m_MilitaryRange;

		// Token: 0x040044D6 RID: 17622
		public IXUILabel m_NextMilitary;

		// Token: 0x040044D7 RID: 17623
		public IXUISprite m_NextMilitaryIcon;

		// Token: 0x040044D8 RID: 17624
		public IXUILabel m_MilitaryName;

		// Token: 0x040044D9 RID: 17625
		public IXUISprite m_MilitaryIcon;

		// Token: 0x040044DA RID: 17626
		public IXUISprite m_RewardBtn;

		// Token: 0x040044DB RID: 17627
		public IXUISprite m_RecordBtn;

		// Token: 0x040044DC RID: 17628
		public IXUILabel m_DateTime;

		// Token: 0x040044DD RID: 17629
		public GameObject m_RewardFrame;

		// Token: 0x040044DE RID: 17630
		public IXUISprite m_RewardCloseBtn;

		// Token: 0x040044DF RID: 17631
		public IXUICheckBox m_RewardSeasonIcb;

		// Token: 0x040044E0 RID: 17632
		public IXUICheckBox m_RewardResultIcb;

		// Token: 0x040044E1 RID: 17633
		public GameObject m_RewardSeasonFrame;

		// Token: 0x040044E2 RID: 17634
		public GameObject m_RewardResultFrame;

		// Token: 0x040044E3 RID: 17635
		public XUIPool m_RewardSeasonPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x040044E4 RID: 17636
		public XUIPool m_RewardResultPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x040044E5 RID: 17637
		public XUIPool m_RewardItemPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x040044E6 RID: 17638
		public GameObject m_BattleRecordFrame;

		// Token: 0x040044E7 RID: 17639
		public IXUICheckBox m_RecordHBtab;

		// Token: 0x040044E8 RID: 17640
		public IXUICheckBox m_RecordCPtab;

		// Token: 0x040044E9 RID: 17641
		public IXUIWrapContent m_WrapContent;

		// Token: 0x040044EA RID: 17642
		public IXUIScrollView m_ScrollView;

		// Token: 0x040044EB RID: 17643
		public Transform m_MyRank;

		// Token: 0x040044EC RID: 17644
		public GameObject m_EmptyRank;
	}
}
