using System;
using UILib;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000C3E RID: 3134
	internal class GuildRelaxJokerMatchHandler : GuildRelaxChildHandler
	{
		// Token: 0x0600B18F RID: 45455 RVA: 0x00221384 File Offset: 0x0021F584
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

		// Token: 0x0600B190 RID: 45456 RVA: 0x0022151A File Offset: 0x0021F71A
		public override void RegisterEvent()
		{
			base.RegisterEvent();
			this.m_enterButton.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnEnterGameClick));
			this.m_openButton.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnOpenGameClick));
		}

		// Token: 0x0600B191 RID: 45457 RVA: 0x00221554 File Offset: 0x0021F754
		private bool OnOpenGameClick(IXUIButton btn)
		{
			this._Doc.SendJokerMatchBegion();
			return false;
		}

		// Token: 0x0600B192 RID: 45458 RVA: 0x00221574 File Offset: 0x0021F774
		private bool OnEnterGameClick(IXUIButton btn)
		{
			this._Doc.SendJokerMatchJoin();
			return false;
		}

		// Token: 0x0600B193 RID: 45459 RVA: 0x00221593 File Offset: 0x0021F793
		protected override void OnShow()
		{
			base.OnShow();
			this._Doc.SendJokerMatchQuery();
		}

		// Token: 0x0600B194 RID: 45460 RVA: 0x002215A9 File Offset: 0x0021F7A9
		public override void StackRefresh()
		{
			base.StackRefresh();
			this._Doc.SendJokerMatchQuery();
		}

		// Token: 0x0600B195 RID: 45461 RVA: 0x002215C0 File Offset: 0x0021F7C0
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

		// Token: 0x0600B196 RID: 45462 RVA: 0x00221714 File Offset: 0x0021F914
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

		// Token: 0x0600B197 RID: 45463 RVA: 0x00221777 File Offset: 0x0021F977
		public override void RefreshRedPoint()
		{
			this.m_redPoint.SetActive(this._Doc.bAvaiableIconWhenShow);
		}

		// Token: 0x0600B198 RID: 45464 RVA: 0x00221794 File Offset: 0x0021F994
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

		// Token: 0x0400446A RID: 17514
		private XGuildJockerMatchDocument _Doc;

		// Token: 0x0400446B RID: 17515
		private IXUIButton m_enterButton;

		// Token: 0x0400446C RID: 17516
		private IXUIButton m_openButton;

		// Token: 0x0400446D RID: 17517
		private IXUILabel m_timeLabel;

		// Token: 0x0400446E RID: 17518
		private IXUILabel m_timeTips;

		// Token: 0x0400446F RID: 17519
		private IXUILabel m_topLabel;

		// Token: 0x04004470 RID: 17520
		private IXUILabel m_centerLabel;

		// Token: 0x04004471 RID: 17521
		private IXUILabel m_enterLabel;

		// Token: 0x04004472 RID: 17522
		private IXUILabel m_openLabel;

		// Token: 0x04004473 RID: 17523
		private bool m_repositionNow = false;
	}
}
