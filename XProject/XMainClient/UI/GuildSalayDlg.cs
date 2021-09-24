using System;
using System.Collections.Generic;
using KKSG;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class GuildSalayDlg : DlgBase<GuildSalayDlg, GuildSalayBehavior>
	{

		public override string fileName
		{
			get
			{
				return "Guild/GuildSalaryDlg";
			}
		}

		public override int layer
		{
			get
			{
				return 1;
			}
		}

		public override int group
		{
			get
			{
				return 1;
			}
		}

		public override bool pushstack
		{
			get
			{
				return true;
			}
		}

		public override bool hideMainMenu
		{
			get
			{
				return true;
			}
		}

		public override bool fullscreenui
		{
			get
			{
				return true;
			}
		}

		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		protected override void Init()
		{
			base.Init();
			this._Doc = XDocuments.GetSpecificDocument<XGuildSalaryDocument>(XGuildSalaryDocument.uuID);
			base.uiBehaviour.m_WrapContent.RegisterItemUpdateEventHandler(new WrapItemUpdateEventHandler(this.OnRewardWrapUpdate));
			base.uiBehaviour.m_DropWrapContent.RegisterItemUpdateEventHandler(new WrapItemUpdateEventHandler(this.OnNextRewardUpdate));
			base.uiBehaviour.m_CanNot.SetText(XStringDefineProxy.GetString("GuildSalaryMessage"));
		}

		protected override void OnShow()
		{
			base.OnShow();
			this._Doc.SendAskGuildWageInfo();
			this.Refresh();
		}

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

		protected override void OnHide()
		{
			base.OnHide();
			bool flag = this.m_DescHandler != null;
			if (flag)
			{
				this.m_DescHandler.SetVisible(false);
			}
		}

		protected override void OnUnload()
		{
			base.uiBehaviour.m_thisWeekGrade.SetTexturePath("");
			base.uiBehaviour.m_LastWeekGrade.SetTexturePath("");
			base.OnUnload();
		}

		protected override void OnLoad()
		{
			bool flag = this.m_DescHandler != null;
			if (flag)
			{
				DlgHandlerBase.EnsureUnload<GuildSalaryDescHandler>(ref this.m_DescHandler);
			}
			base.OnLoad();
		}

		private bool OnClickDescHandler(IXUIButton sprite)
		{
			this._Doc.SelectTabs = (int)sprite.ID;
			DlgHandlerBase.EnsureCreate<GuildSalaryDescHandler>(ref this.m_DescHandler, base.uiBehaviour.m_Root, true, null);
			return true;
		}

		private bool ClickClose(IXUIButton btn)
		{
			this.SetVisibleWithAnimation(false, null);
			return true;
		}

		private bool ClickGet(IXUIButton btn)
		{
			this._Doc.SendGuildWageReward();
			return true;
		}

		private void OnRewardWrapUpdate(Transform t, int index)
		{
			bool flag = index >= this.m_GuildSalayList.Count;
			if (!flag)
			{
				this.SetWrapContent(t, this.m_GuildSalayList[index, 0], this.m_GuildSalayList[index, 1]);
			}
		}

		private void OnNextRewardUpdate(Transform t, int index)
		{
			bool flag = index >= this.m_NextGuildSalayList.Count;
			if (!flag)
			{
				this.SetWrapContent(t, this.m_NextGuildSalayList[index, 0], this.m_NextGuildSalayList[index, 1]);
			}
		}

		private void OnClickNextHandler(IXUISprite sprite)
		{
			base.uiBehaviour.m_DropView.gameObject.SetActive(false);
		}

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

		private void SetWrapContent(Transform t, uint seq0, uint seq1)
		{
			XSingleton<XItemDrawerMgr>.singleton.normalItemDrawer.DrawItem(t.gameObject, (int)seq0, (int)seq1, false);
			IXUISprite ixuisprite = t.FindChild("Icon").GetComponent("XUISprite") as IXUISprite;
			ixuisprite.ID = (ulong)seq0;
			ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(XSingleton<UiUtility>.singleton.OnItemClick));
		}

		private XGuildSalaryDocument _Doc;

		private GuildSalaryDescHandler m_DescHandler;

		private SeqListRef<uint> m_GuildSalayList;

		private SeqListRef<uint> m_NextGuildSalayList;
	}
}
