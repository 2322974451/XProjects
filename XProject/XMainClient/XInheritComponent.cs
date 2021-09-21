using System;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000F31 RID: 3889
	internal class XInheritComponent : XComponent
	{
		// Token: 0x170035F9 RID: 13817
		// (get) Token: 0x0600CE39 RID: 52793 RVA: 0x002FBB8C File Offset: 0x002F9D8C
		public override uint ID
		{
			get
			{
				return XInheritComponent.uuID;
			}
		}

		// Token: 0x0600CE3A RID: 52794 RVA: 0x002FBBA4 File Offset: 0x002F9DA4
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

		// Token: 0x0600CE3B RID: 52795 RVA: 0x002FBCB4 File Offset: 0x002F9EB4
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

		// Token: 0x0600CE3C RID: 52796 RVA: 0x002FBD50 File Offset: 0x002F9F50
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

		// Token: 0x0600CE3D RID: 52797 RVA: 0x002FBDAC File Offset: 0x002F9FAC
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

		// Token: 0x0600CE3E RID: 52798 RVA: 0x002FBE10 File Offset: 0x002FA010
		private void StopInheritAction()
		{
			this.m_inInherit = false;
			this.m_timerToken = (float)this.GetRandomNumber(5, 2);
			XRole xrole = this._entity as XRole;
			xrole.PlayStateBack();
		}

		// Token: 0x0600CE3F RID: 52799 RVA: 0x002FBE48 File Offset: 0x002FA048
		private int GetRandomNumber(int max, int min = 0)
		{
			System.Random random = new System.Random();
			int num = random.Next(min, max);
			return num + 1;
		}

		// Token: 0x0600CE40 RID: 52800 RVA: 0x002FBE6C File Offset: 0x002FA06C
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

		// Token: 0x04005BE9 RID: 23529
		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("XInheritComponent");

		// Token: 0x04005BEA RID: 23530
		private float m_timerToken;

		// Token: 0x04005BEB RID: 23531
		private XFx m_xfxObj;

		// Token: 0x04005BEC RID: 23532
		private bool m_inInherit = false;
	}
}
