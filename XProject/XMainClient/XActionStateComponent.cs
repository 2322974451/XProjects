using System;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000F23 RID: 3875
	internal abstract class XActionStateComponent<T> : XComponent, IXStateTransform, IXInterface where T : XActionArgs
	{
		// Token: 0x0600CD34 RID: 52532 RVA: 0x002F478C File Offset: 0x002F298C
		public override void OnDetachFromHost()
		{
			bool flag = this.SelfState != XStateDefine.XState_Idle && this._entity.Machine.Current == this.SelfState;
			if (flag)
			{
				this._entity.Machine.ForceToDefaultState(true);
			}
			base.OnDetachFromHost();
		}

		// Token: 0x0600CD35 RID: 52533 RVA: 0x002F47DC File Offset: 0x002F29DC
		public bool IsPermitted(XStateDefine state)
		{
			bool flag = this.IsFinished && this._selfState != XStateDefine.XState_Move;
			return flag || this.InnerPermitted(state);
		}

		// Token: 0x170035AC RID: 13740
		// (get) Token: 0x0600CD36 RID: 52534 RVA: 0x002F4818 File Offset: 0x002F2A18
		public virtual bool SyncPredicted
		{
			get
			{
				return !XSingleton<XGame>.singleton.SyncMode;
			}
		}

		// Token: 0x170035AD RID: 13741
		// (get) Token: 0x0600CD37 RID: 52535 RVA: 0x002F4837 File Offset: 0x002F2A37
		public virtual float Speed
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		// Token: 0x0600CD38 RID: 52536 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public virtual void OnRejected(XStateDefine current)
		{
		}

		// Token: 0x0600CD39 RID: 52537 RVA: 0x002F4840 File Offset: 0x002F2A40
		public void StateUpdate(float deltaTime)
		{
			bool flag = this.SelfState != this._entity.Machine.Default && this.IsFinished;
			if (flag)
			{
				this.Finish();
			}
			else
			{
				this.ActionUpdate(deltaTime);
			}
		}

		// Token: 0x0600CD3A RID: 52538 RVA: 0x002F4884 File Offset: 0x002F2A84
		private void Start()
		{
			this.Begin();
		}

		// Token: 0x0600CD3B RID: 52539 RVA: 0x002F4890 File Offset: 0x002F2A90
		public void Stop(XStateDefine next)
		{
			bool flag = !this._bStopped;
			if (flag)
			{
				this._bStopped = true;
				this.Finish();
				this.Cancel(next);
			}
		}

		// Token: 0x0600CD3C RID: 52540 RVA: 0x002F48C3 File Offset: 0x002F2AC3
		public virtual void OnGetPermission()
		{
			this._bStopped = false;
			this._bFinished = false;
		}

		// Token: 0x0600CD3D RID: 52541 RVA: 0x002F48D4 File Offset: 0x002F2AD4
		public virtual string TriggerAnim(string pre)
		{
			string presentCommand = this.PresentCommand;
			bool flag = pre != presentCommand;
			if (flag)
			{
				bool flag2 = this._entity.Ator != null;
				if (flag2)
				{
					this._entity.Ator.SetTrigger(presentCommand);
				}
			}
			return presentCommand;
		}

		// Token: 0x170035AE RID: 13742
		// (get) Token: 0x0600CD3E RID: 52542 RVA: 0x002F4920 File Offset: 0x002F2B20
		public XStateDefine SelfState
		{
			get
			{
				return this._selfState;
			}
		}

		// Token: 0x170035AF RID: 13743
		// (get) Token: 0x0600CD3F RID: 52543 RVA: 0x002F4938 File Offset: 0x002F2B38
		public bool IsStopped
		{
			get
			{
				return this._bStopped;
			}
		}

		// Token: 0x170035B0 RID: 13744
		// (get) Token: 0x0600CD40 RID: 52544 RVA: 0x002F4950 File Offset: 0x002F2B50
		public bool IsFinished
		{
			get
			{
				return this._bFinished || this._bStopped;
			}
		}

		// Token: 0x170035B1 RID: 13745
		// (get) Token: 0x0600CD41 RID: 52545 RVA: 0x002F4974 File Offset: 0x002F2B74
		public virtual bool ShouldBePresent
		{
			get
			{
				return true;
			}
		}

		// Token: 0x170035B2 RID: 13746
		// (get) Token: 0x0600CD42 RID: 52546 RVA: 0x002F4988 File Offset: 0x002F2B88
		public long Token
		{
			get
			{
				return this._stateToken;
			}
		}

		// Token: 0x170035B3 RID: 13747
		// (get) Token: 0x0600CD43 RID: 52547 RVA: 0x002F49A0 File Offset: 0x002F2BA0
		protected long SelfToken
		{
			get
			{
				return this._selfToken;
			}
		}

		// Token: 0x170035B4 RID: 13748
		// (get) Token: 0x0600CD44 RID: 52548 RVA: 0x002F49B8 File Offset: 0x002F2BB8
		public virtual int CollisionLayer
		{
			get
			{
				return this._entity.DefaultLayer;
			}
		}

		// Token: 0x0600CD45 RID: 52549 RVA: 0x002F49D8 File Offset: 0x002F2BD8
		protected void Finish()
		{
			bool flag = !this._bFinished;
			if (flag)
			{
				this._bFinished = true;
				this.Cease();
			}
		}

		// Token: 0x0600CD46 RID: 52550 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		protected virtual void Cease()
		{
		}

		// Token: 0x0600CD47 RID: 52551 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		protected virtual void Begin()
		{
		}

		// Token: 0x0600CD48 RID: 52552 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		protected virtual void Cancel(XStateDefine next)
		{
		}

		// Token: 0x0600CD49 RID: 52553 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		protected virtual void OnMount(XMount mount)
		{
		}

		// Token: 0x0600CD4A RID: 52554 RVA: 0x002F4A04 File Offset: 0x002F2C04
		protected virtual bool SelfCheck(T args)
		{
			return true;
		}

		// Token: 0x0600CD4B RID: 52555 RVA: 0x002F4A18 File Offset: 0x002F2C18
		protected bool GetPermission(T e)
		{
			bool flag = (this._entity.Skill == null || this._entity.Skill.CanPerformAction(this.SelfState, e)) && (this._entity.Machine == null || this._entity.Machine.TryTransferToState(this));
			bool flag2 = flag;
			if (flag2)
			{
				this._stateToken = e.Token;
				this._selfToken = XSingleton<XCommon>.singleton.UniqueToken;
			}
			return flag;
		}

		// Token: 0x170035B5 RID: 13749
		// (get) Token: 0x0600CD4C RID: 52556
		public abstract string PresentCommand { get; }

		// Token: 0x170035B6 RID: 13750
		// (get) Token: 0x0600CD4D RID: 52557
		public abstract string PresentName { get; }

		// Token: 0x0600CD4E RID: 52558 RVA: 0x002F4AA8 File Offset: 0x002F2CA8
		protected virtual bool InnerPermitted(XStateDefine state)
		{
			return this._entity.Machine.StatePermitted(this._selfState, state);
		}

		// Token: 0x0600CD4F RID: 52559 RVA: 0x002F4AD4 File Offset: 0x002F2CD4
		protected bool OnActionEvent(XEventArgs e)
		{
			T e2 = e as T;
			XStateDefine last = this._entity.Machine.Current;
			bool permission = this.GetPermission(e2);
			if (permission)
			{
				this.OnGetEvent(e2, last);
				this.Start();
			}
			return true;
		}

		// Token: 0x0600CD50 RID: 52560 RVA: 0x002F4B24 File Offset: 0x002F2D24
		protected bool OnMountEvent(XEventArgs e)
		{
			bool flag = e is XOnMountedEventArgs;
			if (flag)
			{
				this.OnMount(this._entity.Mount);
			}
			else
			{
				bool flag2 = e is XOnUnMountedEventArgs;
				if (flag2)
				{
					this.OnMount(null);
				}
			}
			return true;
		}

		// Token: 0x0600CD51 RID: 52561
		protected abstract bool OnGetEvent(T e, XStateDefine last);

		// Token: 0x0600CD52 RID: 52562 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		protected virtual void ActionUpdate(float deltaTime)
		{
		}

		// Token: 0x170035B7 RID: 13751
		// (get) Token: 0x0600CD53 RID: 52563 RVA: 0x002F4B71 File Offset: 0x002F2D71
		// (set) Token: 0x0600CD54 RID: 52564 RVA: 0x002F4B79 File Offset: 0x002F2D79
		public bool Deprecated { get; set; }

		// Token: 0x170035B8 RID: 13752
		// (get) Token: 0x0600CD55 RID: 52565
		public abstract bool IsUsingCurve { get; }

		// Token: 0x04005B40 RID: 23360
		protected XStateDefine _selfState = XStateDefine.XState_Idle;

		// Token: 0x04005B41 RID: 23361
		private bool _bFinished = true;

		// Token: 0x04005B42 RID: 23362
		private bool _bStopped = false;

		// Token: 0x04005B43 RID: 23363
		private long _stateToken = 0L;

		// Token: 0x04005B44 RID: 23364
		private long _selfToken = 0L;
	}
}
