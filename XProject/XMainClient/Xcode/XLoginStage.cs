using System;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XLoginStage : XStage
	{

		public XLoginStage() : base(EXStage.Login)
		{
		}

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

		public override void OnLeaveStage(EXStage eNew)
		{
			base.OnLeaveStage(eNew);
			XSingleton<XGameUI>.singleton.UnloadLoginUI();
			CombineMeshTask.s_CombineMatType = ECombineMatType.ECombined;
			XSingleton<XResourceLoaderMgr>.singleton.DelayLoad = true;
		}

		public override void OnEnterScene(uint sceneid, bool transfer)
		{
			base.OnEnterScene(sceneid, transfer);
			CombineMeshTask.s_CombineMatType = ECombineMatType.EIndependent;
			XSingleton<XResourceLoaderMgr>.singleton.DelayLoad = false;
			XSingleton<XCutScene>.singleton.Start("CutScene/first_slash_show", false, true);
		}

		public override void Play()
		{
			this._ready = true;
		}

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

		private EXStage _eOld = EXStage.Null;

		private bool _login_ready = false;

		private bool _ready = false;
	}
}
