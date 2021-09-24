using System;
using UILib;
using UnityEngine;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{

	internal class BigMeleeRankHandler : DlgHandlerBase
	{

		protected override string FileName
		{
			get
			{
				return "GameSystem/BigMelee/BigMeleeRank";
			}
		}

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

		public override void RegisterEvent()
		{
			base.RegisterEvent();
			this.m_WrapContent.RegisterItemUpdateEventHandler(new WrapItemUpdateEventHandler(this.WrapListUpdated));
			this.m_Close.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnCloseClicked));
		}

		public bool OnCloseClicked(IXUIButton btn)
		{
			base.SetVisible(false);
			return true;
		}

		protected override void OnShow()
		{
			base.OnShow();
			this.entDoc.ReqRankData(0);
			this.InitShow();
		}

		public override void OnUnload()
		{
			base.OnUnload();
		}

		private void InitShow()
		{
			this.RefreshList(true);
		}

		public void WrapListUpdated(Transform t, int index)
		{
			bool flag = index < 0 || index >= this.entDoc.RankList.rankList.Count;
			if (!flag)
			{
				this.SetRankTpl(t, index, false);
			}
		}

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

		public void SetType(bool isRank)
		{
			this.IsRank = isRank;
			this.m_Congratulate.gameObject.SetActive(false);
			this.m_Title.gameObject.SetActive(isRank);
		}

		public void SetCongratulate()
		{
			bool flag = this.entDoc.RankList.rankList.Count == 0;
			if (!flag)
			{
				this.m_Congratulate.gameObject.SetActive(true);
				this.m_Congratulate.SetText(string.Format(XStringDefineProxy.GetString("BIG_MELEE_CONGRATULATE"), this.entDoc.RankList.rankList[0].name, this.entDoc.GroupID));
			}
		}

		private XBigMeleeEntranceDocument entDoc = null;

		private XBigMeleeBattleDocument batDoc = null;

		public bool IsRank;

		private IXUIButton m_Close;

		private IXUILabel m_Congratulate;

		private IXUILabel m_Title;

		private Transform m_Empty;

		private Transform m_MyRankFrame;

		private IXUIScrollView m_ScrollView;

		private IXUIWrapContent m_WrapContent;
	}
}
