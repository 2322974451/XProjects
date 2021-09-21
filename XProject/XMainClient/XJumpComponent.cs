using System;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000F2B RID: 3883
	internal sealed class XJumpComponent : XActionStateComponent<XJumpEventArgs>
	{
		// Token: 0x170035DC RID: 13788
		// (get) Token: 0x0600CDCC RID: 52684 RVA: 0x002F8FDC File Offset: 0x002F71DC
		public override uint ID
		{
			get
			{
				return XJumpComponent.uuID;
			}
		}

		// Token: 0x0600CDCD RID: 52685 RVA: 0x002F8FF3 File Offset: 0x002F71F3
		protected override void EventSubscribe()
		{
			base.RegisterEvent(XEventDefine.XEvent_Jump, new XComponent.XEventHandler(base.OnActionEvent));
		}

		// Token: 0x0600CDCE RID: 52686 RVA: 0x002F900A File Offset: 0x002F720A
		public override void OnAttachToHost(XObject host)
		{
			base.OnAttachToHost(host);
			this._selfState = XStateDefine.XState_Jump;
		}

		// Token: 0x0600CDCF RID: 52687 RVA: 0x002F901C File Offset: 0x002F721C
		protected override void Cancel(XStateDefine next)
		{
			this._jumpState = false;
			this._jumptime = 0f;
		}

		// Token: 0x170035DD RID: 13789
		// (get) Token: 0x0600CDD0 RID: 52688 RVA: 0x002F9034 File Offset: 0x002F7234
		public override bool IsUsingCurve
		{
			get
			{
				return false;
			}
		}

		// Token: 0x0600CDD1 RID: 52689 RVA: 0x002F9048 File Offset: 0x002F7248
		protected override bool OnGetEvent(XJumpEventArgs e, XStateDefine last)
		{
			this._hvelocity = e.Hvelocity;
			this._jumpforce = e.Vvelocity;
			this._gravity = e.Gravity;
			return true;
		}

		// Token: 0x0600CDD2 RID: 52690 RVA: 0x002F907F File Offset: 0x002F727F
		protected override void Begin()
		{
			this._jumpState = true;
			this._jumptime = 0f;
		}

		// Token: 0x0600CDD3 RID: 52691 RVA: 0x002F9094 File Offset: 0x002F7294
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

		// Token: 0x0600CDD4 RID: 52692 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public override void OnRejected(XStateDefine current)
		{
		}

		// Token: 0x0600CDD5 RID: 52693 RVA: 0x002F9188 File Offset: 0x002F7388
		private void SwithToFall()
		{
			XFallEventArgs @event = XEventPool<XFallEventArgs>.GetEvent();
			@event.HVelocity = this._hvelocity;
			@event.Gravity = this._gravity;
			@event.Firer = this._host;
			XSingleton<XEventMgr>.singleton.FireEvent(@event);
			base.Finish();
		}

		// Token: 0x0600CDD6 RID: 52694 RVA: 0x002F91D8 File Offset: 0x002F73D8
		private bool CollisionOnTop()
		{
			return false;
		}

		// Token: 0x170035DE RID: 13790
		// (get) Token: 0x0600CDD7 RID: 52695 RVA: 0x002F91EC File Offset: 0x002F73EC
		public override string PresentCommand
		{
			get
			{
				return "ToJump";
			}
		}

		// Token: 0x170035DF RID: 13791
		// (get) Token: 0x0600CDD8 RID: 52696 RVA: 0x002F9204 File Offset: 0x002F7404
		public override string PresentName
		{
			get
			{
				return "Jump";
			}
		}

		// Token: 0x04005BB3 RID: 23475
		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("Basic_Jump");

		// Token: 0x04005BB4 RID: 23476
		private bool _jumpState = false;

		// Token: 0x04005BB5 RID: 23477
		private float _hvelocity = 0f;

		// Token: 0x04005BB6 RID: 23478
		private float _jumpforce = 4f;

		// Token: 0x04005BB7 RID: 23479
		private float _gravity = -9.8f;

		// Token: 0x04005BB8 RID: 23480
		private float _jumptime = 0f;
	}
}
