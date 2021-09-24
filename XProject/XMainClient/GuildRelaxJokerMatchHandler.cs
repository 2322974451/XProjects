using System;
using UILib;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{

	internal class GuildRelaxJokerMatchHandler : GuildRelaxChildHandler
	{

		protected override void Init()
		{
			base.Init();
			this.m_moduleID = XFastEnumIntEqualityComparer<XSysDefine>.ToInt(XSysDefine.XSys_GuildRelax_JokerMatch);
			this._Doc = XDocuments.GetSpecificDocument<XGuildJockerMatchDocument>(XGuildJockerMatchDocument.uuID);
			this.m_qa.SetActive(true);
			this.m_enterButton = (base.transform.Find("QA/Enter").GetComponent("XUIButton") as IXUIButton);
			this.m_enterLabel = (base.transform.FindChild("QA/Enter/T1").GetComponent("XUILabel") as IXUILabel);
			this.m_enterLabel.SetText(XStringDefineProxy.GetString("GUILD_JOCKER_MATCH_JOIN"));
			this.m_openButton = (base.transform.Find("QA/Open").GetComponent("XUIButton") as IXUIButton);
			this.m_openLabel = (base.transform.FindChild("QA/Open/T1").GetComponent("XUILabel") as IXUILabel);
			this.m_openLabel.SetText(XStringDefineProxy.GetString("GUILD_JOCKER_MATCH_BEGION"));
			this.m_timeLabel = (base.transform.Find("QA/Time").GetComponent("XUILabel") as IXUILabel);
			this.m_timeTips = (base.transform.Find("QA/Time/Tips").GetComponent("XUILabel") as IXUILabel);
			this.m_topLabel = (base.transform.Find("QA/top").GetComponent("XUILabel") as IXUILabel);
			this.m_centerLabel = (base.transform.Find("QA/center").GetComponent("XUILabel") as IXUILabel);
		}

		public override void RegisterEvent()
		{
			base.RegisterEvent();
			this.m_enterButton.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnEnterGameClick));
			this.m_openButton.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnOpenGameClick));
		}

		private bool OnOpenGameClick(IXUIButton btn)
		{
			this._Doc.SendJokerMatchBegion();
			return false;
		}

		private bool OnEnterGameClick(IXUIButton btn)
		{
			this._Doc.SendJokerMatchJoin();
			return false;
		}

		protected override void OnShow()
		{
			base.OnShow();
			this._Doc.SendJokerMatchQuery();
		}

		public override void StackRefresh()
		{
			base.StackRefresh();
			this._Doc.SendJokerMatchQuery();
		}

		public override void SetUnLockLevel()
		{
			base.SetUnLockLevel();
			this.m_qa.SetActive(true);
			this.m_tip.SetVisible(false);
			this.SetUnEnable();
			bool isBegin = this._Doc.IsBegin;
			if (isBegin)
			{
				this.m_enterButton.SetVisible(true);
			}
			else
			{
				bool isCanBegin = this._Doc.IsCanBegin;
				if (isCanBegin)
				{
					XGuildDocument specificDocument = XDocuments.GetSpecificDocument<XGuildDocument>(XGuildDocument.uuID);
					this.m_openButton.SetVisible(specificDocument.Position == GuildPosition.GPOS_LEADER || specificDocument.Position == GuildPosition.GPOS_VICELEADER);
					this.m_centerLabel.SetVisible(specificDocument.Position != GuildPosition.GPOS_LEADER && specificDocument.Position != GuildPosition.GPOS_VICELEADER);
					this.m_centerLabel.SetText(XStringDefineProxy.GetString("GUILD_JOCKER_MATCH_STEP2"));
				}
				else
				{
					bool flag = this._Doc.TimeLeft > 0.0;
					if (flag)
					{
						this.m_timeLabel.SetVisible(true);
						this.m_timeLabel.SetText(XSingleton<UiUtility>.singleton.TimeFormatString((int)this._Doc.TimeLeft, 3, 3, 4, false, true));
						this.m_repositionNow = true;
					}
					else
					{
						this.m_centerLabel.SetVisible(true);
						this.m_centerLabel.SetText(XStringDefineProxy.GetString("GUILD_JOCKER_MATCH_STEP1"));
					}
				}
			}
		}

		private void SetUnEnable()
		{
			this.m_enterButton.SetVisible(false);
			this.m_openButton.SetVisible(false);
			this.m_timeLabel.SetVisible(false);
			this.m_timeTips.SetVisible(false);
			this.m_topLabel.SetVisible(false);
			this.m_centerLabel.SetVisible(false);
			this.m_repositionNow = false;
		}

		public override void RefreshRedPoint()
		{
			this.m_redPoint.SetActive(this._Doc.bAvaiableIconWhenShow);
		}

		public override void OnUpdate()
		{
			base.OnUpdate();
			bool flag = !this.m_repositionNow;
			if (!flag)
			{
				bool flag2 = this._Doc.TimeLeft > 0.0;
				if (flag2)
				{
					this.m_timeLabel.SetText(XSingleton<UiUtility>.singleton.TimeFormatString((int)this._Doc.TimeLeft, 3, 3, 4, false, true));
				}
				else
				{
					this.RefreshData();
				}
			}
		}

		private XGuildJockerMatchDocument _Doc;

		private IXUIButton m_enterButton;

		private IXUIButton m_openButton;

		private IXUILabel m_timeLabel;

		private IXUILabel m_timeTips;

		private IXUILabel m_topLabel;

		private IXUILabel m_centerLabel;

		private IXUILabel m_enterLabel;

		private IXUILabel m_openLabel;

		private bool m_repositionNow = false;
	}
}
