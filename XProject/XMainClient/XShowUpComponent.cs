using System;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XShowUpComponent : XComponent
	{

		public override uint ID
		{
			get
			{
				return XShowUpComponent.uuID;
			}
		}

		public XCameraEx ShowCamera
		{
			get
			{
				return this._show_camera;
			}
		}

		protected override void EventSubscribe()
		{
			base.RegisterEvent(XEventDefine.XEvent_AttackShowBegin, new XComponent.XEventHandler(this.Begin));
			base.RegisterEvent(XEventDefine.XEvent_AttackShow, new XComponent.XEventHandler(this.Act));
			base.RegisterEvent(XEventDefine.XEvent_AttackShowEnd, new XComponent.XEventHandler(this.ActEnd));
		}

		public override void OnAttachToHost(XObject host)
		{
			base.OnAttachToHost(host);
			this._show_camera = new XCameraEx();
		}

		public override void OnDetachFromHost()
		{
			this._show_camera = null;
			base.OnDetachFromHost();
		}

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

		public override void Update(float fDeltaT)
		{
			bool spot_on = this._spot_on;
			if (spot_on)
			{
				this._show_camera.Update(fDeltaT);
			}
		}

		public override void PostUpdate(float fDeltaT)
		{
			bool spot_on = this._spot_on;
			if (spot_on)
			{
				this._show_camera.PostUpdate(fDeltaT);
			}
		}

		private void StopCurrentShow()
		{
			this._cast_on = false;
			this._entity.Skill.EndSkill(true, true);
			XSingleton<XBulletMgr>.singleton.ClearBullets();
		}

		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("ShowUp");

		private XCameraEx _show_camera = null;

		private bool _spot_on = false;

		private bool _cast_on = false;
	}
}
