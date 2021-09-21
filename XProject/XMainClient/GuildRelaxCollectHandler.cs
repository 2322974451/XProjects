using System;
using UILib;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000C11 RID: 3089
	internal class GuildRelaxCollectHandler : GuildRelaxChildHandler
	{
		// Token: 0x0600AF7D RID: 44925 RVA: 0x00214374 File Offset: 0x00212574
		protected override void Init()
		{
			base.Init();
			this.m_moduleID = XFastEnumIntEqualityComparer<XSysDefine>.ToInt(XSysDefine.XSys_GuildCollect);
			this._doc = XDocuments.GetSpecificDocument<XGuildCollectDocument>(XGuildCollectDocument.uuID);
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

		// Token: 0x0600AF7E RID: 44926 RVA: 0x0021450A File Offset: 0x0021270A
		public override void RegisterEvent()
		{
			base.RegisterEvent();
		}

		// Token: 0x0600AF7F RID: 44927 RVA: 0x00214514 File Offset: 0x00212714
		protected override void OnShow()
		{
			base.OnShow();
		}

		// Token: 0x0600AF80 RID: 44928 RVA: 0x00214520 File Offset: 0x00212720
		public override void SetUnLockLevel()
		{
			base.SetUnLockLevel();
			this.m_qa.SetActive(true);
			this.m_tip.SetVisible(false);
			this.SetUnEnable();
			this.m_centerLabel.SetVisible(true);
			this.m_timeTips.SetVisible(true);
			bool activityState = this._doc.ActivityState;
			if (activityState)
			{
				this.m_centerLabel.SetText(XStringDefineProxy.GetString("ActivityRunning"));
				this.m_timeLabel.SetVisible(true);
				this.m_timeTips.SetText(string.Format(XStringDefineProxy.GetString("GuildCollectRewardTimeTips"), ""));
				this.m_RefreshTime = this.m_timeLabel;
			}
			else
			{
				XActivityDocument doc = XActivityDocument.Doc;
				MultiActivityList.RowData byID = doc.MulActivityTable.GetByID(17);
				this.m_centerLabel.SetText(byID.OpenDayTips);
				this.m_timeLabel.SetVisible(false);
				this.m_RefreshTime = null;
			}
		}

		// Token: 0x0600AF81 RID: 44929 RVA: 0x00214610 File Offset: 0x00212810
		private void SetUnEnable()
		{
			this.m_enterButton.SetVisible(false);
			this.m_openButton.SetVisible(false);
			this.m_timeLabel.SetVisible(false);
			this.m_timeTips.SetVisible(false);
			this.m_topLabel.SetVisible(false);
			this.m_centerLabel.SetVisible(false);
		}

		// Token: 0x0600AF82 RID: 44930 RVA: 0x0021466C File Offset: 0x0021286C
		public override void RefreshRedPoint()
		{
			this.m_redPoint.SetActive(false);
		}

		// Token: 0x0600AF83 RID: 44931 RVA: 0x0021467C File Offset: 0x0021287C
		public override void OnUpdate()
		{
			base.OnUpdate();
			bool flag = this.m_RefreshTime == null;
			if (!flag)
			{
				XGuildCollectDocument specificDocument = XDocuments.GetSpecificDocument<XGuildCollectDocument>(XGuildCollectDocument.uuID);
				bool flag2 = !specificDocument.ActivityState;
				if (!flag2)
				{
					int num = (int)(XSingleton<UiUtility>.singleton.GetMachineTime() - specificDocument.SignTime);
					num = (int)(specificDocument.LeftTime - (uint)num);
					bool flag3 = num < 0;
					if (flag3)
					{
						num = 0;
					}
					this.m_RefreshTime.SetText(XSingleton<UiUtility>.singleton.TimeFormatString(num, 3, 3, 4, false, true));
				}
			}
		}

		// Token: 0x040042DD RID: 17117
		private XGuildCollectDocument _doc;

		// Token: 0x040042DE RID: 17118
		private IXUIButton m_enterButton;

		// Token: 0x040042DF RID: 17119
		private IXUIButton m_openButton;

		// Token: 0x040042E0 RID: 17120
		private IXUILabel m_timeLabel;

		// Token: 0x040042E1 RID: 17121
		private IXUILabel m_timeTips;

		// Token: 0x040042E2 RID: 17122
		private IXUILabel m_topLabel;

		// Token: 0x040042E3 RID: 17123
		private IXUILabel m_RefreshTime = null;

		// Token: 0x040042E4 RID: 17124
		private IXUILabel m_centerLabel;

		// Token: 0x040042E5 RID: 17125
		private IXUILabel m_enterLabel;

		// Token: 0x040042E6 RID: 17126
		private IXUILabel m_openLabel;
	}
}
