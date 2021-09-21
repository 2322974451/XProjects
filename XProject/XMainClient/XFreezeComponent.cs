using System;
using KKSG;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000F29 RID: 3881
	internal sealed class XFreezeComponent : XActionStateComponent<XFreezeEventArgs>
	{
		// Token: 0x170035D3 RID: 13779
		// (get) Token: 0x0600CDAD RID: 52653 RVA: 0x002F86D4 File Offset: 0x002F68D4
		public override uint ID
		{
			get
			{
				return XFreezeComponent.uuID;
			}
		}

		// Token: 0x0600CDAE RID: 52654 RVA: 0x002F86EC File Offset: 0x002F68EC
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

		// Token: 0x0600CDAF RID: 52655 RVA: 0x002F8762 File Offset: 0x002F6962
		public override void OnDetachFromHost()
		{
			this.DestroyFx(ref this._hit_fx);
			this.DestroyFx(ref this._hit_freeze_fx);
			base.OnDetachFromHost();
		}

		// Token: 0x0600CDB0 RID: 52656 RVA: 0x002F8788 File Offset: 0x002F6988
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

		// Token: 0x0600CDB1 RID: 52657 RVA: 0x002F880C File Offset: 0x002F6A0C
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

		// Token: 0x0600CDB2 RID: 52658 RVA: 0x002F8864 File Offset: 0x002F6A64
		protected override void EventSubscribe()
		{
			base.RegisterEvent(XEventDefine.XEvent_Freeze, new XComponent.XEventHandler(base.OnActionEvent));
		}

		// Token: 0x0600CDB3 RID: 52659 RVA: 0x002F887C File Offset: 0x002F6A7C
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

		// Token: 0x0600CDB4 RID: 52660 RVA: 0x002F899C File Offset: 0x002F6B9C
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

		// Token: 0x0600CDB5 RID: 52661 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public override void OnRejected(XStateDefine current)
		{
		}

		// Token: 0x0600CDB6 RID: 52662 RVA: 0x002F8A74 File Offset: 0x002F6C74
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

		// Token: 0x170035D4 RID: 13780
		// (get) Token: 0x0600CDB7 RID: 52663 RVA: 0x002F8B24 File Offset: 0x002F6D24
		public override bool IsUsingCurve
		{
			get
			{
				return false;
			}
		}

		// Token: 0x0600CDB8 RID: 52664 RVA: 0x002F8B38 File Offset: 0x002F6D38
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

		// Token: 0x0600CDB9 RID: 52665 RVA: 0x002F8BB0 File Offset: 0x002F6DB0
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

		// Token: 0x0600CDBA RID: 52666 RVA: 0x002F8C7C File Offset: 0x002F6E7C
		private void DestroyFx(ref XFx xfx)
		{
			bool flag = xfx != null;
			if (flag)
			{
				XSingleton<XFxMgr>.singleton.DestroyFx(xfx, true);
				xfx = null;
			}
		}

		// Token: 0x170035D5 RID: 13781
		// (get) Token: 0x0600CDBB RID: 52667 RVA: 0x002F8CA8 File Offset: 0x002F6EA8
		public override string PresentCommand
		{
			get
			{
				return "ToFreezed";
			}
		}

		// Token: 0x170035D6 RID: 13782
		// (get) Token: 0x0600CDBC RID: 52668 RVA: 0x002F8CC0 File Offset: 0x002F6EC0
		public override string PresentName
		{
			get
			{
				return "Freezed";
			}
		}

		// Token: 0x04005BAB RID: 23467
		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("Freezing_Presentation");

		// Token: 0x04005BAC RID: 23468
		private float _freeze_time = 0f;

		// Token: 0x04005BAD RID: 23469
		private bool _present = false;

		// Token: 0x04005BAE RID: 23470
		private float _elapsed = 0f;

		// Token: 0x04005BAF RID: 23471
		private float _height_drop = 0f;

		// Token: 0x04005BB0 RID: 23472
		private XFx _hit_fx = null;

		// Token: 0x04005BB1 RID: 23473
		private XFx _hit_freeze_fx = null;
	}
}
