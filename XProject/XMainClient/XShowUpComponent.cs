using System;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000FE2 RID: 4066
	internal class XShowUpComponent : XComponent
	{
		// Token: 0x170036DE RID: 14046
		// (get) Token: 0x0600D34B RID: 54091 RVA: 0x00318538 File Offset: 0x00316738
		public override uint ID
		{
			get
			{
				return XShowUpComponent.uuID;
			}
		}

		// Token: 0x170036DF RID: 14047
		// (get) Token: 0x0600D34C RID: 54092 RVA: 0x00318550 File Offset: 0x00316750
		public XCameraEx ShowCamera
		{
			get
			{
				return this._show_camera;
			}
		}

		// Token: 0x0600D34D RID: 54093 RVA: 0x00318568 File Offset: 0x00316768
		protected override void EventSubscribe()
		{
			base.RegisterEvent(XEventDefine.XEvent_AttackShowBegin, new XComponent.XEventHandler(this.Begin));
			base.RegisterEvent(XEventDefine.XEvent_AttackShow, new XComponent.XEventHandler(this.Act));
			base.RegisterEvent(XEventDefine.XEvent_AttackShowEnd, new XComponent.XEventHandler(this.ActEnd));
		}

		// Token: 0x0600D34E RID: 54094 RVA: 0x003185B5 File Offset: 0x003167B5
		public override void OnAttachToHost(XObject host)
		{
			base.OnAttachToHost(host);
			this._show_camera = new XCameraEx();
		}

		// Token: 0x0600D34F RID: 54095 RVA: 0x003185CB File Offset: 0x003167CB
		public override void OnDetachFromHost()
		{
			this._show_camera = null;
			base.OnDetachFromHost();
		}

		// Token: 0x0600D350 RID: 54096 RVA: 0x003185DC File Offset: 0x003167DC
		public bool Begin(XEventArgs e)
		{
			this._spot_on = true;
			this._cast_on = false;
			XAttackShowBeginArgs xattackShowBeginArgs = e as XAttackShowBeginArgs;
			this._show_camera.PreInstall(xattackShowBeginArgs.XCamera, false);
			XSingleton<XComponentMgr>.singleton.CreateComponent(this._show_camera, XCameraMotionComponent.uuID);
			XSingleton<XComponentMgr>.singleton.CreateComponent(this._show_camera, XCameraShakeComponent.uuID);
			this._show_camera.Installed();
			this._show_camera.Target = this._entity;
			this._show_camera.Root_R_Y = this._entity.EngineObject.Rotation.eulerAngles.y;
			XSingleton<XScene>.singleton.AssociatedCamera = this._show_camera.UnityCamera;
			return true;
		}

		// Token: 0x0600D351 RID: 54097 RVA: 0x003186A0 File Offset: 0x003168A0
		public bool Act(XEventArgs e)
		{
			bool cast_on = this._cast_on;
			if (cast_on)
			{
				this.StopCurrentShow();
			}
			XSingleton<XBulletMgr>.singleton.ClearBullets();
			XAttackShowArgs xattackShowArgs = e as XAttackShowArgs;
			XSkillCore xskillCore = this._entity.SkillMgr.GetSkill(XSingleton<XCommon>.singleton.XHash(xattackShowArgs.name));
			bool flag = xskillCore == null;
			if (flag)
			{
				xskillCore = XSingleton<XSkillFactory>.singleton.Build(this._entity.Present.SkillPrefix, xattackShowArgs.name, this._entity);
			}
			this._entity.SkillMgr.AttachSkill(xskillCore, true);
			XAttackEventArgs @event = XEventPool<XAttackEventArgs>.GetEvent();
			@event.Identify = xskillCore.ID;
			@event.Target = null;
			@event.Demonstration = true;
			@event.AffectCamera = this._show_camera;
			@event.Firer = this._entity;
			XSingleton<XEventMgr>.singleton.FireEvent(@event);
			this._cast_on = true;
			return true;
		}

		// Token: 0x0600D352 RID: 54098 RVA: 0x0031878C File Offset: 0x0031698C
		public bool ActEnd(XEventArgs e)
		{
			XAttackShowEndArgs xattackShowEndArgs = e as XAttackShowEndArgs;
			bool forceQuit = xattackShowEndArgs.ForceQuit;
			if (forceQuit)
			{
				this.StopCurrentShow();
				this._spot_on = false;
				this._show_camera.Uninitilize();
				XSingleton<XScene>.singleton.AssociatedCamera = XSingleton<XScene>.singleton.GameCamera.UnityCamera;
			}
			else
			{
				bool cast_on = this._cast_on;
				if (cast_on)
				{
					XAttackShowEndArgs @event = XEventPool<XAttackShowEndArgs>.GetEvent();
					@event.Firer = XSingleton<XGame>.singleton.Doc;
					XSingleton<XEventMgr>.singleton.FireEvent(@event);
				}
			}
			this._cast_on = false;
			return true;
		}

		// Token: 0x0600D353 RID: 54099 RVA: 0x00318824 File Offset: 0x00316A24
		public override void Update(float fDeltaT)
		{
			bool spot_on = this._spot_on;
			if (spot_on)
			{
				this._show_camera.Update(fDeltaT);
			}
		}

		// Token: 0x0600D354 RID: 54100 RVA: 0x0031884C File Offset: 0x00316A4C
		public override void PostUpdate(float fDeltaT)
		{
			bool spot_on = this._spot_on;
			if (spot_on)
			{
				this._show_camera.PostUpdate(fDeltaT);
			}
		}

		// Token: 0x0600D355 RID: 54101 RVA: 0x00318871 File Offset: 0x00316A71
		private void StopCurrentShow()
		{
			this._cast_on = false;
			this._entity.Skill.EndSkill(true, true);
			XSingleton<XBulletMgr>.singleton.ClearBullets();
		}

		// Token: 0x0400600C RID: 24588
		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("ShowUp");

		// Token: 0x0400600D RID: 24589
		private XCameraEx _show_camera = null;

		// Token: 0x0400600E RID: 24590
		private bool _spot_on = false;

		// Token: 0x0400600F RID: 24591
		private bool _cast_on = false;
	}
}
