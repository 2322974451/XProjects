using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XCaptainPVPBehaviour : DlgBehaviourBase
	{

		private void Awake()
		{
			this.m_Close = (base.transform.Find("Bg/Close").GetComponent("XUIButton") as IXUIButton);
			this.m_Help = (base.transform.Find("Bg/Help").GetComponent("XUIButton") as IXUIButton);
			this.m_BtnShop = (base.transform.Find("Bg/Right/BtnShop").GetComponent("XUIButton") as IXUIButton);
			this.m_BtnRecord = (base.transform.Find("Bg/Right/BtnRecord").GetComponent("XUIButton") as IXUIButton);
			this.m_BtnStartSingle = (base.transform.Find("Bg/Right/BtnStartSingle").GetComponent("XUIButton") as IXUIButton);
			this.m_BtnStartTeam = (base.transform.Find("Bg/Right/BtnStartTeam").GetComponent("XUIButton") as IXUIButton);
			this.m_BattleRecord = (base.transform.Find("Bg/Left/BattleRecord").GetComponent("XUILabel") as IXUILabel);
			this.m_BoxLabel = (base.transform.Find("Bg/Left/Box/T").GetComponent("XUILabel") as IXUILabel);
			this.m_MatchNum = (base.transform.Find("Bg/Right/MatchNum").GetComponent("XUILabel") as IXUILabel);
			this.m_BtnStartSingleLabel = (base.transform.Find("Bg/Right/BtnStartSingle/T").GetComponent("XUILabel") as IXUILabel);
			this.m_BattleRecordFrame = base.transform.Find("Bg/BattleRecordFrame").gameObject;
			this.m_Bg = base.transform.Find("Bg").gameObject;
			this.m_WeekRewardLabel = (this.m_Bg.transform.Find("WeekReward/T").GetComponent("XUILabel") as IXUILabel);
			this.m_WeekRewardList = this.m_Bg.transform.Find("WeekReward/ListPanel/ItemTpl").gameObject;
			this.m_WeekRewardPool.SetupPool(this.m_WeekRewardList.transform.parent.gameObject, this.m_WeekRewardList, 2U, false);
			this.m_ExRewardLabel = (this.m_Bg.transform.Find("ExReward/T").GetComponent("XUILabel") as IXUILabel);
			this.m_ExRewardList = this.m_Bg.transform.Find("ExReward/ListPanel/ItemTpl").gameObject;
			this.m_ExRewardPool.SetupPool(this.m_ExRewardList.transform.parent.gameObject, this.m_ExRewardList, 2U, false);
		}

		public IXUIButton m_Close;

		public IXUIButton m_Help;

		public IXUIButton m_BtnShop;

		public IXUIButton m_BtnRecord;

		public IXUIButton m_BtnStartSingle;

		public IXUIButton m_BtnStartTeam;

		public IXUILabel m_BattleRecord;

		public IXUILabel m_BoxLabel;

		public IXUILabel m_MatchNum;

		public IXUILabel m_BtnStartSingleLabel;

		public IXUILabel m_WeekRewardLabel;

		public IXUILabel m_ExRewardLabel;

		public GameObject m_BattleRecordFrame;

		public GameObject m_Bg;

		public GameObject m_WeekRewardList;

		public GameObject m_ExRewardList;

		public XUIPool m_ExRewardPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		public XUIPool m_WeekRewardPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);
	}
}
