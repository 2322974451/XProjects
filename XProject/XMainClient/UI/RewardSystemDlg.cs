using System;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x0200190C RID: 6412
	internal class RewardSystemDlg : TabDlgBase<RewardSystemDlg>
	{
		// Token: 0x17003ACF RID: 15055
		// (get) Token: 0x06010C2A RID: 68650 RVA: 0x00433948 File Offset: 0x00431B48
		public override string fileName
		{
			get
			{
				return "GameSystem/RewardDlg";
			}
		}

		// Token: 0x17003AD0 RID: 15056
		// (get) Token: 0x06010C2B RID: 68651 RVA: 0x00433960 File Offset: 0x00431B60
		public override int group
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x17003AD1 RID: 15057
		// (get) Token: 0x06010C2C RID: 68652 RVA: 0x00433974 File Offset: 0x00431B74
		protected override bool bHorizontal
		{
			get
			{
				return false;
			}
		}

		// Token: 0x06010C2D RID: 68653 RVA: 0x00433987 File Offset: 0x00431B87
		protected override void Init()
		{
			base.Init();
			base.RegisterSubSysRedPointMgr(XSysDefine.XSys_Reward);
		}

		// Token: 0x06010C2E RID: 68654 RVA: 0x0043399C File Offset: 0x00431B9C
		protected override void OnLoad()
		{
			base.OnLoad();
			this._bg = base.uiBehaviour.transform.FindChild("Bg");
			this.m_AchievementPanel = base.uiBehaviour.transform.FindChild("Bg/AchievementFrame").gameObject;
			this.m_AchievementPanel.SetActive(false);
			this.m_TargetRewardPanel = base.uiBehaviour.transform.FindChild("Bg/TargetReward").gameObject;
			this.m_TargetRewardPanel.SetActive(false);
			this.m_LevelRewardPanel = base.uiBehaviour.transform.FindChild("Bg/LevelFrame").gameObject;
			this.m_LevelRewardPanel.SetActive(false);
			this.m_ServerActivePanel = base.uiBehaviour.transform.Find("Bg/ServerActivityFrame").gameObject;
			this.m_ServerActivePanel.SetActive(false);
			this._sharePanel = base.uiBehaviour.transform.FindChild("Bg/ShareFrame").gameObject;
			this._sharePanel.SetActive(false);
			this.m_dragonPanel = base.uiBehaviour.transform.FindChild("Bg/DragonFrame").gameObject;
			this.m_dragonPanel.SetActive(false);
		}

		// Token: 0x06010C2F RID: 68655 RVA: 0x00433ADC File Offset: 0x00431CDC
		protected override void OnUnload()
		{
			DlgHandlerBase.EnsureUnload<XAchieveView>(ref this._AchieveView);
			DlgHandlerBase.EnsureUnload<XTargetRewardView>(ref this._TargetRewardView);
			DlgHandlerBase.EnsureUnload<XServerActivityView>(ref this._ServerActivityView);
			DlgHandlerBase.EnsureUnload<XRewardLevelView>(ref this._LevelRewardView);
			DlgHandlerBase.EnsureUnload<WeekShareRewardHandler>(ref this._shareHandler);
			DlgHandlerBase.EnsureUnload<XDragonRwdHandler>(ref this._DragonView);
			base.OnUnload();
		}

		// Token: 0x06010C30 RID: 68656 RVA: 0x00433B3C File Offset: 0x00431D3C
		public override void SetupHandlers(XSysDefine sys)
		{
			XSysDefine xsysDefine = sys;
			if (xsysDefine <= XSysDefine.XSys_WeekShareReward)
			{
				if (xsysDefine == XSysDefine.XSys_ServerActivity)
				{
					base._AddActiveHandler(DlgHandlerBase.EnsureCreate<XServerActivityView>(ref this._ServerActivityView, this.m_ServerActivePanel, this, true));
					return;
				}
				if (xsysDefine == XSysDefine.XSys_LevelReward)
				{
					base._AddActiveHandler(DlgHandlerBase.EnsureCreate<XRewardLevelView>(ref this._LevelRewardView, this.m_LevelRewardPanel, this, true));
					return;
				}
				if (xsysDefine == XSysDefine.XSys_WeekShareReward)
				{
					base._AddActiveHandler(DlgHandlerBase.EnsureCreate<WeekShareRewardHandler>(ref this._shareHandler, this._sharePanel, this, true));
					return;
				}
			}
			else
			{
				if (xsysDefine == XSysDefine.XSys_Design_Achieve)
				{
					base._AddActiveHandler(DlgHandlerBase.EnsureCreate<XAchieveView>(ref this._AchieveView, this.m_AchievementPanel, this, true));
					return;
				}
				if (xsysDefine == XSysDefine.XSys_Reward_Dragon)
				{
					base._AddActiveHandler(DlgHandlerBase.EnsureCreate<XDragonRwdHandler>(ref this._DragonView, this.m_dragonPanel, this, true));
					return;
				}
				if (xsysDefine == XSysDefine.XSys_Reward_Target)
				{
					base._AddActiveHandler(DlgHandlerBase.EnsureCreate<XTargetRewardView>(ref this._TargetRewardView, this.m_TargetRewardPanel, this, true));
					return;
				}
			}
			XSingleton<XDebug>.singleton.AddErrorLog("System has not finished:", sys.ToString(), null, null, null, null);
		}

		// Token: 0x04007ABF RID: 31423
		public XAchieveView _AchieveView;

		// Token: 0x04007AC0 RID: 31424
		public XTargetRewardView _TargetRewardView;

		// Token: 0x04007AC1 RID: 31425
		public XRewardLevelView _LevelRewardView;

		// Token: 0x04007AC2 RID: 31426
		public XServerActivityView _ServerActivityView;

		// Token: 0x04007AC3 RID: 31427
		public XDragonRwdHandler _DragonView;

		// Token: 0x04007AC4 RID: 31428
		private Transform _bg;

		// Token: 0x04007AC5 RID: 31429
		public GameObject m_AchievementPanel;

		// Token: 0x04007AC6 RID: 31430
		public GameObject m_TargetRewardPanel;

		// Token: 0x04007AC7 RID: 31431
		public GameObject m_LevelRewardPanel;

		// Token: 0x04007AC8 RID: 31432
		public GameObject m_ServerActivePanel;

		// Token: 0x04007AC9 RID: 31433
		public GameObject m_dragonPanel;

		// Token: 0x04007ACA RID: 31434
		private GameObject _sharePanel;

		// Token: 0x04007ACB RID: 31435
		private WeekShareRewardHandler _shareHandler;
	}
}
