using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000C06 RID: 3078
	internal class XGuildDonateBehavior : DlgBehaviourBase
	{
		// Token: 0x0600AF00 RID: 44800 RVA: 0x00210CA4 File Offset: 0x0020EEA4
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

		// Token: 0x04004290 RID: 17040
		public IXUIWrapContent RankContent;

		// Token: 0x04004291 RID: 17041
		public IXUIWrapContent DonationContent;

		// Token: 0x04004292 RID: 17042
		public IXUICheckBox HistoryTab;

		// Token: 0x04004293 RID: 17043
		public IXUICheckBox TodayTab;

		// Token: 0x04004294 RID: 17044
		public IXUIButton CloseBtn;

		// Token: 0x04004295 RID: 17045
		public Transform MyRankItem;

		// Token: 0x04004296 RID: 17046
		public Transform EmptyRank;

		// Token: 0x04004297 RID: 17047
		public IXUIScrollView LeftScrollView;

		// Token: 0x04004298 RID: 17048
		public IXUIScrollView RightScrollView;

		// Token: 0x04004299 RID: 17049
		public Transform RankRoot;

		// Token: 0x0400429A RID: 17050
		public IXUIButton RankBtn;

		// Token: 0x0400429B RID: 17051
		public IXUIButton RankCloseBtn;

		// Token: 0x0400429C RID: 17052
		public IXUICheckBox dailyTab;

		// Token: 0x0400429D RID: 17053
		public IXUICheckBox WeeklyTab;

		// Token: 0x0400429E RID: 17054
		public IXUICheckBox GrowthTab;

		// Token: 0x0400429F RID: 17055
		public Transform m_DonateFrame;

		// Token: 0x040042A0 RID: 17056
		public Transform m_GrowthFrame;

		// Token: 0x040042A1 RID: 17057
		public IXUIButton m_GrowthRecordBtn;

		// Token: 0x040042A2 RID: 17058
		public IXUIButton m_GrowthRecordCloseBtn;

		// Token: 0x040042A3 RID: 17059
		public Transform m_GrowthRecordList;

		// Token: 0x040042A4 RID: 17060
		public GameObject m_GrowthRecordEmpty;

		// Token: 0x040042A5 RID: 17061
		public XUIPool m_GrowthDonatePool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x040042A6 RID: 17062
		public XUIPool m_GrowthRecordPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x040042A7 RID: 17063
		public IXUILabel m_GrowthWeekTimes;
	}
}
