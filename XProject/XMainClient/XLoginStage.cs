using System;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000EE9 RID: 3817
	internal class XLoginStage : XStage
	{
		// Token: 0x0600CABD RID: 51901 RVA: 0x002DFEFD File Offset: 0x002DE0FD
		public XLoginStage() : base(EXStage.Login)
		{
		}

		// Token: 0x0600CABE RID: 51902 RVA: 0x002DFF20 File Offset: 0x002DE120
		public override void OnEnterStage(EXStage eOld)
		{
			base.OnEnterStage(eOld);
			CombineMeshTask.s_CombineMatType = ECombineMatType.EIndependent;
			XSingleton<XResourceLoaderMgr>.singleton.DelayLoad = false;
			this._ready = false;
			XSingleton<XGameUI>.singleton.LoadLoginUI(this._eStage);
			XSingleton<XLoginDocument>.singleton.LoadAccount();
			this._eOld = eOld;
			this._login_ready = false;
			XSingleton<XCutScene>.singleton.Start("CutScene/first_slash_show", false, true);
			XLoginStep xloginStep = XSingleton<XClientNetwork>.singleton.XLoginStep;
			if (xloginStep != XLoginStep.Begin)
			{
				if (xloginStep == XLoginStep.Login)
				{
					XSingleton<XLoginDocument>.singleton.ShowLoginSelectServerUI();
				}
			}
			else
			{
				XSingleton<XLoginDocument>.singleton.ShowLoginUI();
			}
			XSingleton<XTutorialMgr>.singleton.Uninit();
			XQualitySetting.SetDofFade(0f);
		}

		// Token: 0x0600CABF RID: 51903 RVA: 0x002DFFD0 File Offset: 0x002DE1D0
		public override void OnLeaveStage(EXStage eNew)
		{
			base.OnLeaveStage(eNew);
			XSingleton<XGameUI>.singleton.UnloadLoginUI();
			CombineMeshTask.s_CombineMatType = ECombineMatType.ECombined;
			XSingleton<XResourceLoaderMgr>.singleton.DelayLoad = true;
		}

		// Token: 0x0600CAC0 RID: 51904 RVA: 0x002DFFF7 File Offset: 0x002DE1F7
		public override void OnEnterScene(uint sceneid, bool transfer)
		{
			base.OnEnterScene(sceneid, transfer);
			CombineMeshTask.s_CombineMatType = ECombineMatType.EIndependent;
			XSingleton<XResourceLoaderMgr>.singleton.DelayLoad = false;
			XSingleton<XCutScene>.singleton.Start("CutScene/first_slash_show", false, true);
		}

		// Token: 0x0600CAC1 RID: 51905 RVA: 0x002E0026 File Offset: 0x002DE226
		public override void Play()
		{
			this._ready = true;
		}

		// Token: 0x0600CAC2 RID: 51906 RVA: 0x002E0030 File Offset: 0x002DE230
		public override void Update(float fDeltaT)
		{
			base.Update(fDeltaT);
			XSingleton<XLoginDocument>.singleton.Update();
			bool flag = (XSingleton<XLoginDocument>.singleton.SDKSignOut || !this._login_ready) && XSingleton<XScene>.singleton.SceneReady;
			if (flag)
			{
				bool sdksignOut = XSingleton<XLoginDocument>.singleton.SDKSignOut;
				if (sdksignOut)
				{
					XSingleton<XLoginDocument>.singleton.SetChannelByWakeUp();
				}
				bool flag2 = XSingleton<XLoginDocument>.singleton.Channel == XAuthorizationChannel.XAuthorization_Max;
				if (!flag2)
				{
					XSingleton<XLoginDocument>.singleton.AutoAuthorization(true);
				}
				XSingleton<XLoginDocument>.singleton.SDKSignOut = false;
				this._login_ready = true;
			}
		}

		// Token: 0x0600CAC3 RID: 51907 RVA: 0x002E00CC File Offset: 0x002DE2CC
		public override void PostUpdate(float fDeltaT)
		{
			base.PostUpdate(fDeltaT);
			bool flag = this._ready && XSingleton<XScene>.singleton.SceneReady;
			if (flag)
			{
				this._ready = false;
				XSingleton<XGame>.singleton.SwitchTo(EXStage.SelectChar, 3U);
			}
		}

		// Token: 0x040059A6 RID: 22950
		private EXStage _eOld = EXStage.Null;

		// Token: 0x040059A7 RID: 22951
		private bool _login_ready = false;

		// Token: 0x040059A8 RID: 22952
		private bool _ready = false;
	}
}
