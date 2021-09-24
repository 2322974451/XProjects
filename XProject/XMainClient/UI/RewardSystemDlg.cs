using System;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class RewardSystemDlg : TabDlgBase<RewardSystemDlg>
	{

		public override string fileName
		{
			get
			{
				return "GameSystem/RewardDlg";
			}
		}

		public override int group
		{
			get
			{
				return 1;
			}
		}

		protected override bool bHorizontal
		{
			get
			{
				return false;
			}
		}

		protected override void Init()
		{
			base.Init();
			base.RegisterSubSysRedPointMgr(XSysDefine.XSys_Reward);
		}

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

		public XAchieveView _AchieveView;

		public XTargetRewardView _TargetRewardView;

		public XRewardLevelView _LevelRewardView;

		public XServerActivityView _ServerActivityView;

		public XDragonRwdHandler _DragonView;

		private Transform _bg;

		public GameObject m_AchievementPanel;

		public GameObject m_TargetRewardPanel;

		public GameObject m_LevelRewardPanel;

		public GameObject m_ServerActivePanel;

		public GameObject m_dragonPanel;

		private GameObject _sharePanel;

		private WeekShareRewardHandler _shareHandler;
	}
}
