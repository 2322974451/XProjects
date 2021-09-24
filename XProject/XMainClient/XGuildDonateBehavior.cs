using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XGuildDonateBehavior : DlgBehaviourBase
	{

		private void Awake()
		{
			this.DonationContent = (base.transform.Find("DonateFrame/Panel/WrapContent").GetComponent("XUIWrapContent") as IXUIWrapContent);
			this.RightScrollView = (this.DonationContent.gameObject.transform.parent.GetComponent("XUIScrollView") as IXUIScrollView);
			this.RankContent = (base.transform.Find("Rank/RankDlg/ScrollView/WrapContent").GetComponent("XUIWrapContent") as IXUIWrapContent);
			this.LeftScrollView = (this.RankContent.gameObject.transform.parent.GetComponent("XUIScrollView") as IXUIScrollView);
			this.TodayTab = (base.transform.Find("Rank/RankDlg/Select/All").GetComponent("XUICheckBox") as IXUICheckBox);
			this.HistoryTab = (base.transform.Find("Rank/RankDlg/Select/Self").GetComponent("XUICheckBox") as IXUICheckBox);
			this.CloseBtn = (base.transform.Find("Close").GetComponent("XUIButton") as IXUIButton);
			this.MyRankItem = base.transform.Find("Rank/RankDlg/MyRank");
			this.EmptyRank = base.transform.Find("Rank/RankDlg/EmptyRank");
			this.RankRoot = base.transform.Find("Rank");
			this.dailyTab = (base.transform.Find("Tabs/DailyDonation").GetComponent("XUICheckBox") as IXUICheckBox);
			this.WeeklyTab = (base.transform.Find("Tabs/WeeklyDonation").GetComponent("XUICheckBox") as IXUICheckBox);
			this.GrowthTab = (base.transform.Find("Tabs/GrowthDonation").GetComponent("XUICheckBox") as IXUICheckBox);
			this.RankBtn = (base.transform.Find("DonateFrame/RankBtn").GetComponent("XUIButton") as IXUIButton);
			this.RankCloseBtn = (this.RankRoot.Find("RankDlg/Close").GetComponent("XUIButton") as IXUIButton);
			this.m_DonateFrame = base.transform.Find("DonateFrame");
			this.m_GrowthFrame = base.transform.Find("GrowthFrame");
			this.m_GrowthRecordBtn = (this.m_GrowthFrame.Find("RecordBtn").GetComponent("XUIButton") as IXUIButton);
			this.m_GrowthRecordList = this.m_GrowthFrame.Find("RecordDlg");
			this.m_GrowthRecordCloseBtn = (this.m_GrowthRecordList.Find("Close").GetComponent("XUIButton") as IXUIButton);
			this.m_GrowthRecordEmpty = this.m_GrowthRecordList.Find("EmptyRank").gameObject;
			Transform transform = this.m_GrowthFrame.Find("List/MemberTpl");
			this.m_GrowthDonatePool.SetupPool(transform.parent.gameObject, transform.gameObject, 5U, false);
			transform = this.m_GrowthRecordList.Find("ScrollView/RankTpl");
			this.m_GrowthRecordPool.SetupPool(transform.parent.gameObject, transform.gameObject, 5U, false);
			this.m_GrowthWeekTimes = (this.m_GrowthFrame.Find("time").GetComponent("XUILabel") as IXUILabel);
		}

		public IXUIWrapContent RankContent;

		public IXUIWrapContent DonationContent;

		public IXUICheckBox HistoryTab;

		public IXUICheckBox TodayTab;

		public IXUIButton CloseBtn;

		public Transform MyRankItem;

		public Transform EmptyRank;

		public IXUIScrollView LeftScrollView;

		public IXUIScrollView RightScrollView;

		public Transform RankRoot;

		public IXUIButton RankBtn;

		public IXUIButton RankCloseBtn;

		public IXUICheckBox dailyTab;

		public IXUICheckBox WeeklyTab;

		public IXUICheckBox GrowthTab;

		public Transform m_DonateFrame;

		public Transform m_GrowthFrame;

		public IXUIButton m_GrowthRecordBtn;

		public IXUIButton m_GrowthRecordCloseBtn;

		public Transform m_GrowthRecordList;

		public GameObject m_GrowthRecordEmpty;

		public XUIPool m_GrowthDonatePool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		public XUIPool m_GrowthRecordPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		public IXUILabel m_GrowthWeekTimes;
	}
}
