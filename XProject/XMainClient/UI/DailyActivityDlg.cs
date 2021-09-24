using System;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class DailyActivityDlg : TabDlgBase<DailyActivityDlg>
	{

		public ActivityHandler ActivityHandler
		{
			get
			{
				return this.m_activityHandler;
			}
		}

		public override string fileName
		{
			get
			{
				return "GameSystem/DailyActivity/DailyActivityDlg";
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
			base.RegisterSubSysRedPointMgr(XSysDefine.XSys_DailyAcitivity);
		}

		protected override void OnLoad()
		{
			base.OnLoad();
			this.parent = base.uiBehaviour.transform.FindChild("Bg");
		}

		protected override void OnUnload()
		{
			base.OnUnload();
			DlgHandlerBase.EnsureUnload<ActivityHandler>(ref this.m_activityHandler);
			DlgHandlerBase.EnsureUnload<XDailyActivitiesView>(ref this._livenessActivityHandler);
		}

		public override void SetupHandlers(XSysDefine sys)
		{
			XSysDefine xsysDefine = sys;
			if (xsysDefine != XSysDefine.XSys_Activity)
			{
				if (xsysDefine != XSysDefine.XSys_Reward_Activity)
				{
					XSingleton<XDebug>.singleton.AddErrorLog("System has not finished:", sys.ToString(), null, null, null, null);
				}
				else
				{
					base._AddActiveHandler(DlgHandlerBase.EnsureCreate<XDailyActivitiesView>(ref this._livenessActivityHandler, this.parent, true, this));
				}
			}
			else
			{
				base._AddActiveHandler(DlgHandlerBase.EnsureCreate<ActivityHandler>(ref this.m_activityHandler, this.parent, true, this));
			}
		}

		public void ShowSubSystem(XSysDefine sys)
		{
			bool flag = !base.IsLoaded();
			if (flag)
			{
				base.Load();
			}
			base.ShowSubGamsSystem(sys);
		}

		private ActivityHandler m_activityHandler;

		public XDailyActivitiesView _livenessActivityHandler;

		private Transform parent;
	}
}
