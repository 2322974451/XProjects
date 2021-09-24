using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class MilitaryRankBehaviour : DlgBehaviourBase
	{

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

		public IXUIButton m_Close;

		public IUIDummy m_snapshotTransfrom;

		public IXUILabel m_MilitaryValue;

		public IXUILabel m_MilitaryRange;

		public IXUILabel m_NextMilitary;

		public IXUISprite m_NextMilitaryIcon;

		public IXUILabel m_MilitaryName;

		public IXUISprite m_MilitaryIcon;

		public IXUISprite m_RewardBtn;

		public IXUISprite m_RecordBtn;

		public IXUILabel m_DateTime;

		public GameObject m_RewardFrame;

		public IXUISprite m_RewardCloseBtn;

		public IXUICheckBox m_RewardSeasonIcb;

		public IXUICheckBox m_RewardResultIcb;

		public GameObject m_RewardSeasonFrame;

		public GameObject m_RewardResultFrame;

		public XUIPool m_RewardSeasonPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		public XUIPool m_RewardResultPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		public XUIPool m_RewardItemPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		public GameObject m_BattleRecordFrame;

		public IXUICheckBox m_RecordHBtab;

		public IXUICheckBox m_RecordCPtab;

		public IXUIWrapContent m_WrapContent;

		public IXUIScrollView m_ScrollView;

		public Transform m_MyRank;

		public GameObject m_EmptyRank;
	}
}
