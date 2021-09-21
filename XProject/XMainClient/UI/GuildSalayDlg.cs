using System;
using System.Collections.Generic;
using KKSG;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x0200176F RID: 5999
	internal class GuildSalayDlg : DlgBase<GuildSalayDlg, GuildSalayBehavior>
	{
		// Token: 0x17003818 RID: 14360
		// (get) Token: 0x0600F7A3 RID: 63395 RVA: 0x00386DA0 File Offset: 0x00384FA0
		public override string fileName
		{
			get
			{
				return "Guild/GuildSalaryDlg";
			}
		}

		// Token: 0x17003819 RID: 14361
		// (get) Token: 0x0600F7A4 RID: 63396 RVA: 0x00386DB8 File Offset: 0x00384FB8
		public override int layer
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x1700381A RID: 14362
		// (get) Token: 0x0600F7A5 RID: 63397 RVA: 0x00386DCC File Offset: 0x00384FCC
		public override int group
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x1700381B RID: 14363
		// (get) Token: 0x0600F7A6 RID: 63398 RVA: 0x00386DE0 File Offset: 0x00384FE0
		public override bool pushstack
		{
			get
			{
				return true;
			}
		}

		// Token: 0x1700381C RID: 14364
		// (get) Token: 0x0600F7A7 RID: 63399 RVA: 0x00386DF4 File Offset: 0x00384FF4
		public override bool hideMainMenu
		{
			get
			{
				return true;
			}
		}

		// Token: 0x1700381D RID: 14365
		// (get) Token: 0x0600F7A8 RID: 63400 RVA: 0x00386E08 File Offset: 0x00385008
		public override bool fullscreenui
		{
			get
			{
				return true;
			}
		}

		// Token: 0x1700381E RID: 14366
		// (get) Token: 0x0600F7A9 RID: 63401 RVA: 0x00386E1C File Offset: 0x0038501C
		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		// Token: 0x0600F7AA RID: 63402 RVA: 0x00386E30 File Offset: 0x00385030
		protected override void Init()
		{
			base.Init();
			this._Doc = XDocuments.GetSpecificDocument<XGuildSalaryDocument>(XGuildSalaryDocument.uuID);
			base.uiBehaviour.m_WrapContent.RegisterItemUpdateEventHandler(new WrapItemUpdateEventHandler(this.OnRewardWrapUpdate));
			base.uiBehaviour.m_DropWrapContent.RegisterItemUpdateEventHandler(new WrapItemUpdateEventHandler(this.OnNextRewardUpdate));
			base.uiBehaviour.m_CanNot.SetText(XStringDefineProxy.GetString("GuildSalaryMessage"));
		}

		// Token: 0x0600F7AB RID: 63403 RVA: 0x00386EAA File Offset: 0x003850AA
		protected override void OnShow()
		{
			base.OnShow();
			this._Doc.SendAskGuildWageInfo();
			this.Refresh();
		}

		// Token: 0x0600F7AC RID: 63404 RVA: 0x00386EC8 File Offset: 0x003850C8
		public void Refresh()
		{
			this.SetSalaryInfo();
			this.RefreshTopPlayers();
			bool flag = this._Doc.RewardState == WageRewardState.notreward;
			if (flag)
			{
				this.SetLastWeekBaseInfo();
			}
			else
			{
				this.SetThisWeekInfo();
			}
		}

		// Token: 0x0600F7AD RID: 63405 RVA: 0x00386F0C File Offset: 0x0038510C
		private void SetLastWeekBaseInfo()
		{
			base.uiBehaviour.m_GuildLevel.SetText(this._Doc.LastLevel.ToString());
			base.uiBehaviour.m_TitleLabel.SetText(XStringDefineProxy.GetString("GUILD_SALAY_LASTWEEK"));
			base.uiBehaviour.m_GuildPosition.SetText(XGuildDocument.GuildPP.GetPositionName(this._Doc.LastPosition, false));
			bool flag = this._Doc.LastGrade < 1U;
			if (flag)
			{
				base.uiBehaviour.m_LastWeekGrade.SetTexturePath("atlas/UI/GameSystem/Activity/pj_0");
			}
			else
			{
				base.uiBehaviour.m_LastWeekGrade.SetTexturePath(string.Format("atlas/UI/GameSystem/Activity/pj_{0}", this._Doc.LastGrade - 1U));
			}
			base.uiBehaviour.m_LastWeekScore.SetText(this._Doc.LastScore.ToString());
			this.m_GuildSalayList = this._Doc.GetGuildSalayList(this._Doc.LastLevel, this._Doc.LastPosition, this._Doc.LastGrade);
			base.uiBehaviour.m_WrapContent.SetContentCount((this.m_GuildSalayList.Count > 0) ? this.m_GuildSalayList.Count : 0, false);
			base.uiBehaviour.m_RewardScrollView.ResetPosition();
			this.SetNextRewardTemp(this._Doc.LastGrade, this._Doc.MulMaxScore);
			base.uiBehaviour.m_GetButton.SetVisible(true);
		}

		// Token: 0x0600F7AE RID: 63406 RVA: 0x003870A0 File Offset: 0x003852A0
		private void SetThisWeekInfo()
		{
			XGuildDocument specificDocument = XDocuments.GetSpecificDocument<XGuildDocument>(XGuildDocument.uuID);
			base.uiBehaviour.m_TitleLabel.SetText(XStringDefineProxy.GetString("GUILD_SALAY_THISWEEK"));
			base.uiBehaviour.m_GuildLevel.SetText(specificDocument.BasicData.level.ToString());
			base.uiBehaviour.m_GuildPosition.SetText(XGuildDocument.GuildPP.GetPositionName(specificDocument.Position, false));
			bool flag = this._Doc.CurGrade < 1U;
			if (flag)
			{
				base.uiBehaviour.m_LastWeekGrade.SetTexturePath("atlas/UI/GameSystem/Activity/pj_0");
			}
			else
			{
				base.uiBehaviour.m_LastWeekGrade.SetTexturePath(string.Format("atlas/UI/GameSystem/Activity/pj_{0}", this._Doc.CurGrade - 1U));
			}
			base.uiBehaviour.m_LastWeekScore.SetText(this._Doc.CurScore.ToString());
			this.m_GuildSalayList = this._Doc.GetGuildSalayList(specificDocument.BasicData.level, specificDocument.Position, this._Doc.CurGrade);
			this.SetNextRewardTemp(this._Doc.CurGrade, this._Doc.CurMulScore);
			base.uiBehaviour.m_WrapContent.SetContentCount((this.m_GuildSalayList.Count > 0) ? this.m_GuildSalayList.Count : 0, false);
			base.uiBehaviour.m_RewardScrollView.ResetPosition();
			base.uiBehaviour.m_GetButton.SetVisible(false);
			base.uiBehaviour.m_DropView.gameObject.SetActive(false);
		}

		// Token: 0x0600F7AF RID: 63407 RVA: 0x00387248 File Offset: 0x00385448
		private void SetSalaryInfo()
		{
			bool flag = this._Doc.CurGrade < 1U;
			if (flag)
			{
				base.uiBehaviour.m_thisWeekGrade.SetTexturePath("atlas/UI/GameSystem/Activity/pj_0");
			}
			else
			{
				base.uiBehaviour.m_thisWeekGrade.SetTexturePath(string.Format("atlas/UI/GameSystem/Activity/pj_{0}", this._Doc.CurGrade - 1U));
			}
			base.uiBehaviour.m_thisWeekScore.SetText(this._Doc.CurScore.ToString());
			base.uiBehaviour.m_BottomInfo.SetInfo(this._Doc.RoleNum.Score, this._Doc.RoleNum.Value);
			base.uiBehaviour.m_radarMap.SetSite(0, this._Doc.RoleNum.Percent);
			base.uiBehaviour.m_LeftInfo.SetInfo(this._Doc.Prestige.Score, this._Doc.Prestige.Value);
			base.uiBehaviour.m_radarMap.SetSite(2, this._Doc.Prestige.Percent);
			base.uiBehaviour.m_UpInfo.SetInfo(this._Doc.Activity.Score, this._Doc.Activity.Value);
			base.uiBehaviour.m_radarMap.SetSite(3, this._Doc.Activity.Percent);
			base.uiBehaviour.m_RightInfo.SetInfo(this._Doc.Exp.Score, this._Doc.Exp.Value);
			base.uiBehaviour.m_radarMap.SetSite(1, this._Doc.Exp.Percent);
		}

		// Token: 0x0600F7B0 RID: 63408 RVA: 0x00387424 File Offset: 0x00385624
		private void RefreshTopPlayers()
		{
			List<GuildActivityRole> topPlayers = this._Doc.TopPlayers;
			int num = (topPlayers == null) ? 0 : topPlayers.Count;
			int i = 0;
			int num2 = base.uiBehaviour.topPlayers.Length;
			while (i < num2)
			{
				bool flag = i < num;
				if (flag)
				{
					base.uiBehaviour.topPlayers[i].SetVisible(true);
					base.uiBehaviour.topPlayers[i].SetText(topPlayers[i].name);
					IXUILabel ixuilabel = base.uiBehaviour.topPlayers[i].gameObject.transform.Find("t1").GetComponent("XUILabel") as IXUILabel;
					ixuilabel.SetText(topPlayers[i].score.ToString());
				}
				else
				{
					base.uiBehaviour.topPlayers[i].SetVisible(false);
				}
				i++;
			}
		}

		// Token: 0x0600F7B1 RID: 63409 RVA: 0x0038751C File Offset: 0x0038571C
		public override void RegisterEvent()
		{
			base.RegisterEvent();
			base.uiBehaviour.m_Close.RegisterClickEventHandler(new ButtonClickEventHandler(this.ClickClose));
			base.uiBehaviour.m_GetButton.RegisterClickEventHandler(new ButtonClickEventHandler(this.ClickGet));
			base.uiBehaviour.m_BottomInfo.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnClickDescHandler));
			base.uiBehaviour.m_UpInfo.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnClickDescHandler));
			base.uiBehaviour.m_LeftInfo.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnClickDescHandler));
			base.uiBehaviour.m_RightInfo.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnClickDescHandler));
			base.uiBehaviour.m_DropClose.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnClickNextHandler));
			base.uiBehaviour.m_ShowNextReward.RegisterLabelClickEventHandler(new LabelClickEventHandler(this.OnShowNextReward));
		}

		// Token: 0x0600F7B2 RID: 63410 RVA: 0x0038761C File Offset: 0x0038581C
		private void SetNextRewardTemp(uint grade, uint mul)
		{
			bool flag = grade > 1U && grade <= 5U;
			base.uiBehaviour.m_ShowNextReward.SetVisible(flag);
			base.uiBehaviour.m_LastScoreLabel.SetVisible(flag);
			bool flag2 = flag;
			if (flag2)
			{
				string nextGradeString = this.GetNextGradeString(grade);
				base.uiBehaviour.m_ShowNextReward.SetText(XStringDefineProxy.GetString("GuildSalaryNextReward", new object[]
				{
					nextGradeString
				}));
				base.uiBehaviour.m_LastScoreLabel.SetText(XStringDefineProxy.GetString("GuildSalaryMulDesc", new object[]
				{
					nextGradeString,
					mul
				}));
			}
		}

		// Token: 0x0600F7B3 RID: 63411 RVA: 0x003876C0 File Offset: 0x003858C0
		private string GetNextGradeString(uint grade)
		{
			string result = "S";
			switch (grade)
			{
			case 2U:
				result = "S";
				break;
			case 3U:
				result = "A";
				break;
			case 4U:
				result = "B";
				break;
			case 5U:
				result = "C";
				break;
			}
			return result;
		}

		// Token: 0x0600F7B4 RID: 63412 RVA: 0x00387718 File Offset: 0x00385918
		protected override void OnHide()
		{
			base.OnHide();
			bool flag = this.m_DescHandler != null;
			if (flag)
			{
				this.m_DescHandler.SetVisible(false);
			}
		}

		// Token: 0x0600F7B5 RID: 63413 RVA: 0x00387747 File Offset: 0x00385947
		protected override void OnUnload()
		{
			base.uiBehaviour.m_thisWeekGrade.SetTexturePath("");
			base.uiBehaviour.m_LastWeekGrade.SetTexturePath("");
			base.OnUnload();
		}

		// Token: 0x0600F7B6 RID: 63414 RVA: 0x00387780 File Offset: 0x00385980
		protected override void OnLoad()
		{
			bool flag = this.m_DescHandler != null;
			if (flag)
			{
				DlgHandlerBase.EnsureUnload<GuildSalaryDescHandler>(ref this.m_DescHandler);
			}
			base.OnLoad();
		}

		// Token: 0x0600F7B7 RID: 63415 RVA: 0x003877B0 File Offset: 0x003859B0
		private bool OnClickDescHandler(IXUIButton sprite)
		{
			this._Doc.SelectTabs = (int)sprite.ID;
			DlgHandlerBase.EnsureCreate<GuildSalaryDescHandler>(ref this.m_DescHandler, base.uiBehaviour.m_Root, true, null);
			return true;
		}

		// Token: 0x0600F7B8 RID: 63416 RVA: 0x003877F0 File Offset: 0x003859F0
		private bool ClickClose(IXUIButton btn)
		{
			this.SetVisibleWithAnimation(false, null);
			return true;
		}

		// Token: 0x0600F7B9 RID: 63417 RVA: 0x0038780C File Offset: 0x00385A0C
		private bool ClickGet(IXUIButton btn)
		{
			this._Doc.SendGuildWageReward();
			return true;
		}

		// Token: 0x0600F7BA RID: 63418 RVA: 0x0038782C File Offset: 0x00385A2C
		private void OnRewardWrapUpdate(Transform t, int index)
		{
			bool flag = index >= this.m_GuildSalayList.Count;
			if (!flag)
			{
				this.SetWrapContent(t, this.m_GuildSalayList[index, 0], this.m_GuildSalayList[index, 1]);
			}
		}

		// Token: 0x0600F7BB RID: 63419 RVA: 0x00387874 File Offset: 0x00385A74
		private void OnNextRewardUpdate(Transform t, int index)
		{
			bool flag = index >= this.m_NextGuildSalayList.Count;
			if (!flag)
			{
				this.SetWrapContent(t, this.m_NextGuildSalayList[index, 0], this.m_NextGuildSalayList[index, 1]);
			}
		}

		// Token: 0x0600F7BC RID: 63420 RVA: 0x003878BB File Offset: 0x00385ABB
		private void OnClickNextHandler(IXUISprite sprite)
		{
			base.uiBehaviour.m_DropView.gameObject.SetActive(false);
		}

		// Token: 0x0600F7BD RID: 63421 RVA: 0x003878D8 File Offset: 0x00385AD8
		private void OnShowNextReward(IXUILabel label)
		{
			base.uiBehaviour.m_DropView.gameObject.SetActive(true);
			bool flag = this._Doc.RewardState == WageRewardState.notreward;
			if (flag)
			{
				this.m_NextGuildSalayList = this._Doc.GetGuildSalayList(this._Doc.LastLevel, this._Doc.LastPosition, this._Doc.LastGrade - 1U);
			}
			else
			{
				XGuildDocument specificDocument = XDocuments.GetSpecificDocument<XGuildDocument>(XGuildDocument.uuID);
				this.m_NextGuildSalayList = this._Doc.GetGuildSalayList(specificDocument.BasicData.level, specificDocument.Position, this._Doc.CurGrade - 1U);
			}
			base.uiBehaviour.m_DropWrapContent.SetContentCount((this.m_NextGuildSalayList.Count > 0) ? this.m_GuildSalayList.Count : 0, false);
			base.uiBehaviour.m_DropScrollView.ResetPosition();
		}

		// Token: 0x0600F7BE RID: 63422 RVA: 0x003879C4 File Offset: 0x00385BC4
		private void SetWrapContent(Transform t, uint seq0, uint seq1)
		{
			XSingleton<XItemDrawerMgr>.singleton.normalItemDrawer.DrawItem(t.gameObject, (int)seq0, (int)seq1, false);
			IXUISprite ixuisprite = t.FindChild("Icon").GetComponent("XUISprite") as IXUISprite;
			ixuisprite.ID = (ulong)seq0;
			ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(XSingleton<UiUtility>.singleton.OnItemClick));
		}

		// Token: 0x04006BF9 RID: 27641
		private XGuildSalaryDocument _Doc;

		// Token: 0x04006BFA RID: 27642
		private GuildSalaryDescHandler m_DescHandler;

		// Token: 0x04006BFB RID: 27643
		private SeqListRef<uint> m_GuildSalayList;

		// Token: 0x04006BFC RID: 27644
		private SeqListRef<uint> m_NextGuildSalayList;
	}
}
