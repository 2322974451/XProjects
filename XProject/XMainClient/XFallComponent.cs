using System;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000F27 RID: 3879
	internal sealed class XFallComponent : XActionStateComponent<XFallEventArgs>
	{
		// Token: 0x170035CA RID: 13770
		// (get) Token: 0x0600CD95 RID: 52629 RVA: 0x002F8200 File Offset: 0x002F6400
		public override uint ID
		{
			get
			{
				return XFallComponent.uuID;
			}
		}

		// Token: 0x0600CD96 RID: 52630 RVA: 0x002F8217 File Offset: 0x002F6417
		protected override void EventSubscribe()
		{
			base.RegisterEvent(XEventDefine.XEvent_Fall, new XComponent.XEventHandler(base.OnActionEvent));
		}

		// Token: 0x0600CD97 RID: 52631 RVA: 0x002F822E File Offset: 0x002F642E
		public override void OnAttachToHost(XObject host)
		{
			base.OnAttachToHost(host);
			this._selfState = XStateDefine.XState_Fall;
		}

		// Token: 0x0600CD98 RID: 52632 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		protected override void Cancel(XStateDefine next)
		{
		}

		// Token: 0x0600CD99 RID: 52633 RVA: 0x002F8240 File Offset: 0x002F6440
		protected override bool OnGetEvent(XFallEventArgs e, XStateDefine last)
		{
			this._hvelocity = e.HVelocity;
			this._gravity = e.Gravity;
			return true;
		}

		// Token: 0x0600CD9A RID: 52634 RVA: 0x002F826B File Offset: 0x002F646B
		protected override void Begin()
		{
			this._elapsed = 0f;
		}

		// Token: 0x170035CB RID: 13771
		// (get) Token: 0x0600CD9B RID: 52635 RVA: 0x002F827C File Offset: 0x002F647C
		public override bool IsUsingCurve
		{
			get
			{
				return false;
			}
		}

		// Token: 0x0600CD9C RID: 52636 RVA: 0x002F8290 File Offset: 0x002F6490
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

		// Token: 0x0600CD9D RID: 52637 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public override void OnRejected(XStateDefine current)
		{
		}

		// Token: 0x170035CC RID: 13772
		// (get) Token: 0x0600CD9E RID: 52638 RVA: 0x002F8358 File Offset: 0x002F6558
		public override bool ShouldBePresent
		{
			get
			{
				bool isDead = this._entity.IsDead;
				return !isDead && base.ShouldBePresent;
			}
		}

		// Token: 0x170035CD RID: 13773
		// (get) Token: 0x0600CD9F RID: 52639 RVA: 0x002F8384 File Offset: 0x002F6584
		public override string PresentCommand
		{
			get
			{
				return "ToFall";
			}
		}

		// Token: 0x170035CE RID: 13774
		// (get) Token: 0x0600CDA0 RID: 52640 RVA: 0x002F839C File Offset: 0x002F659C
		public override string PresentName
		{
			get
			{
				return "Fall";
			}
		}

		// Token: 0x04005BA2 RID: 23458
		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("Basic_Fall");

		// Token: 0x04005BA3 RID: 23459
		private float _hvelocity = 0f;

		// Token: 0x04005BA4 RID: 23460
		private float _gravity = -9.8f;

		// Token: 0x04005BA5 RID: 23461
		private float _elapsed = 0f;
	}
}
