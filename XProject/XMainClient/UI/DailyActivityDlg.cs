using System;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x02001709 RID: 5897
	internal class DailyActivityDlg : TabDlgBase<DailyActivityDlg>
	{
		// Token: 0x17003788 RID: 14216
		// (get) Token: 0x0600F378 RID: 62328 RVA: 0x00365B04 File Offset: 0x00363D04
		public ActivityHandler ActivityHandler
		{
			get
			{
				return this.m_activityHandler;
			}
		}

		// Token: 0x17003789 RID: 14217
		// (get) Token: 0x0600F379 RID: 62329 RVA: 0x00365B1C File Offset: 0x00363D1C
		public override string fileName
		{
			get
			{
				return "GameSystem/DailyActivity/DailyActivityDlg";
			}
		}

		// Token: 0x1700378A RID: 14218
		// (get) Token: 0x0600F37A RID: 62330 RVA: 0x00365B34 File Offset: 0x00363D34
		public override int group
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x1700378B RID: 14219
		// (get) Token: 0x0600F37B RID: 62331 RVA: 0x00365B48 File Offset: 0x00363D48
		protected override bool bHorizontal
		{
			get
			{
				return false;
			}
		}

		// Token: 0x0600F37C RID: 62332 RVA: 0x00365B5B File Offset: 0x00363D5B
		protected override void Init()
		{
			base.Init();
			base.RegisterSubSysRedPointMgr(XSysDefine.XSys_DailyAcitivity);
		}

		// Token: 0x0600F37D RID: 62333 RVA: 0x00365B6E File Offset: 0x00363D6E
		protected override void OnLoad()
		{
			base.OnLoad();
			this.parent = base.uiBehaviour.transform.FindChild("Bg");
		}

		// Token: 0x0600F37E RID: 62334 RVA: 0x00365B93 File Offset: 0x00363D93
		protected override void OnUnload()
		{
			base.OnUnload();
			DlgHandlerBase.EnsureUnload<ActivityHandler>(ref this.m_activityHandler);
			DlgHandlerBase.EnsureUnload<XDailyActivitiesView>(ref this._livenessActivityHandler);
		}

		// Token: 0x0600F37F RID: 62335 RVA: 0x00365BB8 File Offset: 0x00363DB8
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

		// Token: 0x0600F380 RID: 62336 RVA: 0x00365C38 File Offset: 0x00363E38
		public void ShowSubSystem(XSysDefine sys)
		{
			bool flag = !base.IsLoaded();
			if (flag)
			{
				base.Load();
			}
			base.ShowSubGamsSystem(sys);
		}

		// Token: 0x0400688A RID: 26762
		private ActivityHandler m_activityHandler;

		// Token: 0x0400688B RID: 26763
		public XDailyActivitiesView _livenessActivityHandler;

		// Token: 0x0400688C RID: 26764
		private Transform parent;
	}
}
