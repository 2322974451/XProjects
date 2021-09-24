using System;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XInheritComponent : XComponent
	{

		public override uint ID
		{
			get
			{
				return XInheritComponent.uuID;
			}
		}

		public override void OnAttachToHost(XObject host)
		{
			base.OnAttachToHost(host);
			bool flag = this.m_xfxObj == null;
			if (flag)
			{
				this.m_xfxObj = XSingleton<XFxMgr>.singleton.CreateFx("Effects/FX_Particle/UIfx/UI_cg_st", null, true);
				this.m_xfxObj.Play(this._entity.EngineObject, Vector3.zero, Vector3.one, 1f, true, false, "", 0f);
			}
			bool isPlayer = this._entity.IsPlayer;
			if (isPlayer)
			{
				XCameraActionEventArgs @event = XEventPool<XCameraActionEventArgs>.GetEvent();
				@event.XRotate = XSingleton<XScene>.singleton.GameCamera.Root_R_X_Default;
				float angle = float.Parse(XSingleton<XGlobalConfig>.singleton.GetValue("GuildInheritCameraDesdir"));
				float degree = float.Parse(XSingleton<XGlobalConfig>.singleton.GetValue("GuildInheritCameraDegree"));
				@event.YRotate = XSingleton<XCommon>.singleton.AngleToFloat(XSingleton<XCommon>.singleton.HorizontalRotateVetor3(XSingleton<XCommon>.singleton.FloatToAngle(angle), degree, true));
				@event.Firer = XSingleton<XScene>.singleton.GameCamera;
				XSingleton<XEventMgr>.singleton.FireEvent(@event);
			}
		}

		public override void OnDetachFromHost()
		{
			bool flag = this.m_xfxObj != null;
			if (flag)
			{
				XSingleton<XFxMgr>.singleton.DestroyFx(this.m_xfxObj, true);
				this.m_xfxObj = null;
			}
			bool flag2 = this._entity != null && this._entity.IsPlayer;
			if (flag2)
			{
				XRole xrole = this._entity as XRole;
				xrole.PlayStateBack();
				XCameraMotionEndEventArgs @event = XEventPool<XCameraMotionEndEventArgs>.GetEvent();
				@event.Target = this._entity;
				@event.Firer = XSingleton<XScene>.singleton.GameCamera;
				XSingleton<XEventMgr>.singleton.FireEvent(@event);
			}
			base.OnDetachFromHost();
		}

		public override void Update(float fDeltaT)
		{
			base.Update(fDeltaT);
			bool flag = this.m_timerToken > 0f;
			if (flag)
			{
				this.m_timerToken -= fDeltaT;
			}
			else
			{
				bool inInherit = this.m_inInherit;
				if (inInherit)
				{
					this.StopInheritAction();
				}
				else
				{
					this.StartInheritAction();
				}
			}
		}

		private void StartInheritAction()
		{
			XRole xrole = this._entity as XRole;
			int randomNumber = this.GetRandomNumber(2, 0);
			string targetName = this.GetTargetName(randomNumber);
			bool flag = !string.IsNullOrEmpty(targetName);
			if (flag)
			{
				this.m_timerToken = xrole.PlaySpecifiedAnimationGetLength(this.GetTargetName(randomNumber));
			}
			else
			{
				this.m_timerToken = 5f;
			}
			this.m_inInherit = true;
		}

		private void StopInheritAction()
		{
			this.m_inInherit = false;
			this.m_timerToken = (float)this.GetRandomNumber(5, 2);
			XRole xrole = this._entity as XRole;
			xrole.PlayStateBack();
		}

		private int GetRandomNumber(int max, int min = 0)
		{
			System.Random random = new System.Random();
			int num = random.Next(min, max);
			return num + 1;
		}

		private string GetTargetName(int index)
		{
			string result = this._entity.Present.PresentLib.InheritActionOne;
			if (index != 1)
			{
				if (index == 2)
				{
					result = this._entity.Present.PresentLib.InheritActionTwo;
				}
			}
			else
			{
				result = this._entity.Present.PresentLib.InheritActionOne;
			}
			return result;
		}

		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("XInheritComponent");

		private float m_timerToken;

		private XFx m_xfxObj;

		private bool m_inInherit = false;
	}
}
