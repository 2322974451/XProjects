using System;
using KKSG;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{

	internal sealed class XFreezeComponent : XActionStateComponent<XFreezeEventArgs>
	{

		public override uint ID
		{
			get
			{
				return XFreezeComponent.uuID;
			}
		}

		public override void OnAttachToHost(XObject host)
		{
			base.OnAttachToHost(host);
			this._selfState = XStateDefine.XState_Freeze;
			this._freeze_time = 0f;
			this._present = false;
			this._elapsed = 0f;
			bool isNotEmptyObject = this._entity.EngineObject.IsNotEmptyObject;
			if (isNotEmptyObject)
			{
				this._entity.OverrideAnimClip("Freezed", this._entity.Present.PresentLib.Freeze, true, false);
			}
		}

		public override void OnDetachFromHost()
		{
			this.DestroyFx(ref this._hit_fx);
			this.DestroyFx(ref this._hit_freeze_fx);
			base.OnDetachFromHost();
		}

		public override string TriggerAnim(string pre)
		{
			bool flag = this._entity.Ator != null;
			if (flag)
			{
				bool present = this._present;
				if (present)
				{
					this._entity.Ator.speed = 1f;
					this._entity.Ator.SetTrigger(this.PresentCommand);
					pre = this.PresentCommand;
				}
				else
				{
					this._entity.Ator.speed = 0f;
				}
			}
			return pre;
		}

		protected override void Cancel(XStateDefine next)
		{
			bool flag = this._entity.Ator != null;
			if (flag)
			{
				this._entity.Ator.speed = 1f;
			}
			this.DestroyFx(ref this._hit_fx);
			this.DestroyFx(ref this._hit_freeze_fx);
			this.TrytoTirggerQTE(true);
		}

		protected override void EventSubscribe()
		{
			base.RegisterEvent(XEventDefine.XEvent_Freeze, new XComponent.XEventHandler(base.OnActionEvent));
		}

		protected override bool OnGetEvent(XFreezeEventArgs e, XStateDefine last)
		{
			this._freeze_time = ((e.HitData != null) ? e.HitData.FreezeDuration : e.Duration);
			this._present = ((e.HitData != null) ? e.HitData.FreezePresent : e.Present);
			bool flag = e.HitData != null;
			if (flag)
			{
				bool flag2 = !string.IsNullOrEmpty(e.HitData.Fx);
				if (flag2)
				{
					this.PlayHitFx(e.HitData.Fx, e.HitData.Fx_Follow, ref this._hit_fx);
				}
				bool flag3 = this._present && !string.IsNullOrEmpty(this._entity.Present.PresentLib.FreezeFx);
				if (flag3)
				{
					this.PlayHitFx(this._entity.Present.PresentLib.FreezeFx, true, ref this._hit_freeze_fx);
				}
			}
			XEndureEventArgs @event = XEventPool<XEndureEventArgs>.GetEvent();
			@event.Firer = this._entity;
			@event.Dir = e.Dir;
			XSingleton<XEventMgr>.singleton.FireEvent(@event);
			return true;
		}

		protected override void Begin()
		{
			this._elapsed = 0f;
			this._height_drop = this._entity.EngineObject.Position.y - ((this._entity.Fly != null) ? (XSingleton<XScene>.singleton.TerrainY(this._entity.EngineObject.Position) + this._entity.Fly.CurrentHeight) : XSingleton<XScene>.singleton.TerrainY(this._entity.EngineObject.Position));
			bool flag = this._height_drop < 0f;
			if (flag)
			{
				this._height_drop = 0f;
			}
			this.TrytoTirggerQTE(false);
			bool flag2 = !XSingleton<XGame>.singleton.SyncMode && this._freeze_time <= 0f;
			if (flag2)
			{
				base.Finish();
			}
		}

		public override void OnRejected(XStateDefine current)
		{
		}

		protected override void ActionUpdate(float deltaTime)
		{
			bool flag = base.IsFinished || XSingleton<XGame>.singleton.SyncMode;
			if (!flag)
			{
				this._elapsed += deltaTime;
				float num = deltaTime * (this._height_drop / this._freeze_time);
				this._entity.ApplyMove(0f, -num, 0f);
				bool flag2 = this._elapsed > this._freeze_time;
				if (flag2)
				{
					base.Finish();
				}
				bool flag3 = this._entity.Ator != null && !this._present;
				if (flag3)
				{
					this._entity.Ator.speed = 0f;
				}
			}
		}

		public override bool IsUsingCurve
		{
			get
			{
				return false;
			}
		}

		private void TrytoTirggerQTE(bool bEnd = false)
		{
			bool flag = !this._entity.Destroying && this._entity.QTE != null;
			if (flag)
			{
				XQTEState en = XQTEState.QTE_None;
				bool flag2 = !bEnd;
				if (flag2)
				{
					en = XQTEState.QTE_HitFreeze;
				}
				XSkillQTEEventArgs @event = XEventPool<XSkillQTEEventArgs>.GetEvent();
				@event.Firer = this._entity;
				@event.On = !bEnd;
				@event.State = (uint)XFastEnumIntEqualityComparer<XQTEState>.ToInt(en);
				XSingleton<XEventMgr>.singleton.FireEvent(@event);
			}
		}

		private void PlayHitFx(string fx, bool follow, ref XFx xfx)
		{
			bool flag = xfx != null && xfx.FxName != fx;
			if (flag)
			{
				this.DestroyFx(ref xfx);
			}
			bool flag2 = XEntity.FilterFx(this._entity, XFxMgr.FilterFxDis1);
			if (!flag2)
			{
				bool flag3 = xfx == null;
				if (flag3)
				{
					xfx = XSingleton<XFxMgr>.singleton.CreateFx(fx, null, true);
				}
				xfx.Play(this._entity.EngineObject, Vector3.zero, ((this._entity.Radius > 0.5f) ? (this._entity.Radius * 2f) : 1f) * Vector3.one, 1f, follow, false, "", this._entity.Height * 0.5f);
			}
		}

		private void DestroyFx(ref XFx xfx)
		{
			bool flag = xfx != null;
			if (flag)
			{
				XSingleton<XFxMgr>.singleton.DestroyFx(xfx, true);
				xfx = null;
			}
		}

		public override string PresentCommand
		{
			get
			{
				return "ToFreezed";
			}
		}

		public override string PresentName
		{
			get
			{
				return "Freezed";
			}
		}

		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("Freezing_Presentation");

		private float _freeze_time = 0f;

		private bool _present = false;

		private float _elapsed = 0f;

		private float _height_drop = 0f;

		private XFx _hit_fx = null;

		private XFx _hit_freeze_fx = null;
	}
}
