using System;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{

	internal sealed class XJumpComponent : XActionStateComponent<XJumpEventArgs>
	{

		public override uint ID
		{
			get
			{
				return XJumpComponent.uuID;
			}
		}

		protected override void EventSubscribe()
		{
			base.RegisterEvent(XEventDefine.XEvent_Jump, new XComponent.XEventHandler(base.OnActionEvent));
		}

		public override void OnAttachToHost(XObject host)
		{
			base.OnAttachToHost(host);
			this._selfState = XStateDefine.XState_Jump;
		}

		protected override void Cancel(XStateDefine next)
		{
			this._jumpState = false;
			this._jumptime = 0f;
		}

		public override bool IsUsingCurve
		{
			get
			{
				return false;
			}
		}

		protected override bool OnGetEvent(XJumpEventArgs e, XStateDefine last)
		{
			this._hvelocity = e.Hvelocity;
			this._jumpforce = e.Vvelocity;
			this._gravity = e.Gravity;
			return true;
		}

		protected override void Begin()
		{
			this._jumpState = true;
			this._jumptime = 0f;
		}

		protected override void ActionUpdate(float deltaTime)
		{
			Vector3 vector = Vector3.zero;
			this._jumpState = !this.CollisionOnTop();
			bool jumpState = this._jumpState;
			if (jumpState)
			{
				this._jumptime += deltaTime;
				float num = this._gravity * this._jumptime * this._jumptime / 2f;
				num += this._jumpforce * this._jumptime;
				bool flag = XSingleton<XCommon>.singleton.IsGreater(this._jumptime, this._jumpforce / -this._gravity);
				if (flag)
				{
					this._jumpState = false;
					this.SwithToFall();
				}
				vector.y += num;
				Vector3 vector2 = XSingleton<XCommon>.singleton.Horizontal(this._entity.EngineObject.Forward);
				vector += deltaTime * this._hvelocity * vector2;
				this._entity.ApplyMove(vector);
			}
			else
			{
				this.SwithToFall();
			}
		}

		public override void OnRejected(XStateDefine current)
		{
		}

		private void SwithToFall()
		{
			XFallEventArgs @event = XEventPool<XFallEventArgs>.GetEvent();
			@event.HVelocity = this._hvelocity;
			@event.Gravity = this._gravity;
			@event.Firer = this._host;
			XSingleton<XEventMgr>.singleton.FireEvent(@event);
			base.Finish();
		}

		private bool CollisionOnTop()
		{
			return false;
		}

		public override string PresentCommand
		{
			get
			{
				return "ToJump";
			}
		}

		public override string PresentName
		{
			get
			{
				return "Jump";
			}
		}

		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("Basic_Jump");

		private bool _jumpState = false;

		private float _hvelocity = 0f;

		private float _jumpforce = 4f;

		private float _gravity = -9.8f;

		private float _jumptime = 0f;
	}
}
