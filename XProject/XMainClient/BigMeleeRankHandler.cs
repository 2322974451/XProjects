using System;
using UILib;
using UnityEngine;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000B99 RID: 2969
	internal class BigMeleeRankHandler : DlgHandlerBase
	{
		// Token: 0x1700303E RID: 12350
		// (get) Token: 0x0600AA63 RID: 43619 RVA: 0x001E7C98 File Offset: 0x001E5E98
		protected override string FileName
		{
			get
			{
				return "GameSystem/BigMelee/BigMeleeRank";
			}
		}

		// Token: 0x0600AA64 RID: 43620 RVA: 0x001E7CB0 File Offset: 0x001E5EB0
		protected override void Init()
		{
			base.Init();
			this.entDoc = XDocuments.GetSpecificDocument<XBigMeleeEntranceDocument>(XBigMeleeEntranceDocument.uuID);
			this.batDoc = XDocuments.GetSpecificDocument<XBigMeleeBattleDocument>(XBigMeleeBattleDocument.uuID);
			this.entDoc.RankHandler = this;
			this.m_Close = (base.transform.Find("Close").GetComponent("XUIButton") as IXUIButton);
			this.m_Congratulate = (base.transform.Find("Congratulate").GetComponent("XUILabel") as IXUILabel);
			this.m_Title = (base.transform.Find("Title").GetComponent("XUILabel") as IXUILabel);
			this.m_Empty = base.transform.Find("Empty");
			this.m_ScrollView = (base.transform.Find("Panel").GetComponent("XUIScrollView") as IXUIScrollView);
			this.m_WrapContent = (base.transform.Find("Panel/WrapContent").GetComponent("XUIWrapContent") as IXUIWrapContent);
			this.m_MyRankFrame = base.transform.Find("MyRankFrame");
		}

		// Token: 0x0600AA65 RID: 43621 RVA: 0x001E7DD6 File Offset: 0x001E5FD6
		public override void RegisterEvent()
		{
			base.RegisterEvent();
			this.m_WrapContent.RegisterItemUpdateEventHandler(new WrapItemUpdateEventHandler(this.WrapListUpdated));
			this.m_Close.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnCloseClicked));
		}

		// Token: 0x0600AA66 RID: 43622 RVA: 0x001E7E10 File Offset: 0x001E6010
		public bool OnCloseClicked(IXUIButton btn)
		{
			base.SetVisible(false);
			return true;
		}

		// Token: 0x0600AA67 RID: 43623 RVA: 0x001E7E2B File Offset: 0x001E602B
		protected override void OnShow()
		{
			base.OnShow();
			this.entDoc.ReqRankData(0);
			this.InitShow();
		}

		// Token: 0x0600AA68 RID: 43624 RVA: 0x0019EF07 File Offset: 0x0019D107
		public override void OnUnload()
		{
			base.OnUnload();
		}

		// Token: 0x0600AA69 RID: 43625 RVA: 0x001E7E49 File Offset: 0x001E6049
		private void InitShow()
		{
			this.RefreshList(true);
		}

		// Token: 0x0600AA6A RID: 43626 RVA: 0x001E7E54 File Offset: 0x001E6054
		public void WrapListUpdated(Transform t, int index)
		{
			bool flag = index < 0 || index >= this.entDoc.RankList.rankList.Count;
			if (!flag)
			{
				this.SetRankTpl(t, index, false);
			}
		}

		// Token: 0x0600AA6B RID: 43627 RVA: 0x001E7E94 File Offset: 0x001E6094
		public void SetRankTpl(Transform t, int index, bool isMy)
		{
			XBigMeleeRankInfo xbigMeleeRankInfo = (isMy ? this.entDoc.RankList.myRankInfo : this.entDoc.RankList.rankList[index]) as XBigMeleeRankInfo;
			bool flag = xbigMeleeRankInfo == null;
			if (!flag)
			{
				IXUILabel ixuilabel = t.Find("Detail/Name").GetComponent("XUILabel") as IXUILabel;
				IXUILabel ixuilabel2 = t.Find("Detail/Server").GetComponent("XUILabel") as IXUILabel;
				IXUISprite ixuisprite = t.Find("Detail/Avatar").GetComponent("XUISprite") as IXUISprite;
				IXUISprite sp = t.Find("Rank/RankImage").GetComponent("XUISprite") as IXUISprite;
				IXUILabel label = t.Find("Rank/RankNum").GetComponent("XUILabel") as IXUILabel;
				IXUILabel ixuilabel3 = t.Find("Kill").GetComponent("XUILabel") as IXUILabel;
				IXUILabel ixuilabel4 = t.Find("Point").GetComponent("XUILabel") as IXUILabel;
				uint rank = xbigMeleeRankInfo.rank;
				ixuilabel.SetText(xbigMeleeRankInfo.name);
				ixuilabel2.SetText(xbigMeleeRankInfo.serverName);
				ixuisprite.SetSprite(XSingleton<XProfessionSkillMgr>.singleton.GetProfHeadIcon((int)xbigMeleeRankInfo.profession));
				XSingleton<UiUtility>.singleton.ShowRank(sp, label, (int)(rank + 1U));
				ixuilabel3.SetText(xbigMeleeRankInfo.kill.ToString());
				ixuilabel4.SetText(xbigMeleeRankInfo.value.ToString());
			}
		}

		// Token: 0x0600AA6C RID: 43628 RVA: 0x001E8018 File Offset: 0x001E6218
		public void RefreshList(bool bResetPosition = true)
		{
			this.SetRankTpl(this.m_MyRankFrame, 0, true);
			this.m_WrapContent.SetContentCount(this.entDoc.RankList.rankList.Count, false);
			this.m_Empty.gameObject.SetActive(this.entDoc.RankList.rankList.Count == 0);
			if (bResetPosition)
			{
				this.m_ScrollView.ResetPosition();
			}
			else
			{
				this.m_WrapContent.RefreshAllVisibleContents();
			}
		}

		// Token: 0x0600AA6D RID: 43629 RVA: 0x001E809F File Offset: 0x001E629F
		public void SetType(bool isRank)
		{
			this.IsRank = isRank;
			this.m_Congratulate.gameObject.SetActive(false);
			this.m_Title.gameObject.SetActive(isRank);
		}

		// Token: 0x0600AA6E RID: 43630 RVA: 0x001E80D0 File Offset: 0x001E62D0
		public void SetCongratulate()
		{
			bool flag = this.entDoc.RankList.rankList.Count == 0;
			if (!flag)
			{
				this.m_Congratulate.gameObject.SetActive(true);
				this.m_Congratulate.SetText(string.Format(XStringDefineProxy.GetString("BIG_MELEE_CONGRATULATE"), this.entDoc.RankList.rankList[0].name, this.entDoc.GroupID));
			}
		}

		// Token: 0x04003F23 RID: 16163
		private XBigMeleeEntranceDocument entDoc = null;

		// Token: 0x04003F24 RID: 16164
		private XBigMeleeBattleDocument batDoc = null;

		// Token: 0x04003F25 RID: 16165
		public bool IsRank;

		// Token: 0x04003F26 RID: 16166
		private IXUIButton m_Close;

		// Token: 0x04003F27 RID: 16167
		private IXUILabel m_Congratulate;

		// Token: 0x04003F28 RID: 16168
		private IXUILabel m_Title;

		// Token: 0x04003F29 RID: 16169
		private Transform m_Empty;

		// Token: 0x04003F2A RID: 16170
		private Transform m_MyRankFrame;

		// Token: 0x04003F2B RID: 16171
		private IXUIScrollView m_ScrollView;

		// Token: 0x04003F2C RID: 16172
		private IXUIWrapContent m_WrapContent;
	}
}
