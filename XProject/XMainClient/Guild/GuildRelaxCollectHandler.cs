using System;
using UILib;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{

	internal class GuildRelaxCollectHandler : GuildRelaxChildHandler
	{

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

		public override void RegisterEvent()
		{
			base.RegisterEvent();
		}

		protected override void OnShow()
		{
			base.OnShow();
		}

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

		private void SetUnEnable()
		{
			this.m_enterButton.SetVisible(false);
			this.m_openButton.SetVisible(false);
			this.m_timeLabel.SetVisible(false);
			this.m_timeTips.SetVisible(false);
			this.m_topLabel.SetVisible(false);
			this.m_centerLabel.SetVisible(false);
		}

		public override void RefreshRedPoint()
		{
			this.m_redPoint.SetActive(false);
		}

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

		private XGuildCollectDocument _doc;

		private IXUIButton m_enterButton;

		private IXUIButton m_openButton;

		private IXUILabel m_timeLabel;

		private IXUILabel m_timeTips;

		private IXUILabel m_topLabel;

		private IXUILabel m_RefreshTime = null;

		private IXUILabel m_centerLabel;

		private IXUILabel m_enterLabel;

		private IXUILabel m_openLabel;
	}
}
