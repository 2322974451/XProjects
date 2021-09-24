using System;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{

	internal sealed class XFallComponent : XActionStateComponent<XFallEventArgs>
	{

		public override uint ID
		{
			get
			{
				return XFallComponent.uuID;
			}
		}

		protected override void EventSubscribe()
		{
			base.RegisterEvent(XEventDefine.XEvent_Fall, new XComponent.XEventHandler(base.OnActionEvent));
		}

		public override void OnAttachToHost(XObject host)
		{
			base.OnAttachToHost(host);
			this._selfState = XStateDefine.XState_Fall;
		}

		protected override void Cancel(XStateDefine next)
		{
		}

		protected override bool OnGetEvent(XFallEventArgs e, XStateDefine last)
		{
			this._hvelocity = e.HVelocity;
			this._gravity = e.Gravity;
			return true;
		}

		protected override void Begin()
		{
			this._elapsed = 0f;
		}

		public override bool IsUsingCurve
		{
			get
			{
				return false;
			}
		}

		protected override void ActionUpdate(float deltaTime)
		{
			bool flag = !this._entity.StandOn;
			if (flag)
			{
				Vector3 vector = Vector3.zero;
				this._elapsed += deltaTime;
				this._hvelocity += (0f - this._hvelocity) * Mathf.Min(1f, deltaTime * 4f);
				float num = this._gravity * this._elapsed;
				vector.y += num * deltaTime;
				Vector3 vector2 = XSingleton<XCommon>.singleton.Horizontal(this._entity.EngineObject.Forward);
				vector += deltaTime * this._hvelocity * vector2;
				this._entity.ApplyMove(vector);
			}
			else
			{
				base.Finish();
			}
		}

		public override void OnRejected(XStateDefine current)
		{
		}

		public override bool ShouldBePresent
		{
			get
			{
				bool isDead = this._entity.IsDead;
				return !isDead && base.ShouldBePresent;
			}
		}

		public override string PresentCommand
		{
			get
			{
				return "ToFall";
			}
		}

		public override string PresentName
		{
			get
			{
				return "Fall";
			}
		}

		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("Basic_Fall");

		private float _hvelocity = 0f;

		private float _gravity = -9.8f;

		private float _elapsed = 0f;
	}
}
