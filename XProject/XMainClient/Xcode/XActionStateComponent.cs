using System;
using XUtliPoolLib;

namespace XMainClient
{

	internal abstract class XActionStateComponent<T> : XComponent, IXStateTransform, IXInterface where T : XActionArgs
	{

		public override void OnDetachFromHost()
		{
			bool flag = this.SelfState != XStateDefine.XState_Idle && this._entity.Machine.Current == this.SelfState;
			if (flag)
			{
				this._entity.Machine.ForceToDefaultState(true);
			}
			base.OnDetachFromHost();
		}

		public bool IsPermitted(XStateDefine state)
		{
			bool flag = this.IsFinished && this._selfState != XStateDefine.XState_Move;
			return flag || this.InnerPermitted(state);
		}

		public virtual bool SyncPredicted
		{
			get
			{
				return !XSingleton<XGame>.singleton.SyncMode;
			}
		}

		public virtual float Speed
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		public virtual void OnRejected(XStateDefine current)
		{
		}

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

		private void Start()
		{
			this.Begin();
		}

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

		public virtual void OnGetPermission()
		{
			this._bStopped = false;
			this._bFinished = false;
		}

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

		public XStateDefine SelfState
		{
			get
			{
				return this._selfState;
			}
		}

		public bool IsStopped
		{
			get
			{
				return this._bStopped;
			}
		}

		public bool IsFinished
		{
			get
			{
				return this._bFinished || this._bStopped;
			}
		}

		public virtual bool ShouldBePresent
		{
			get
			{
				return true;
			}
		}

		public long Token
		{
			get
			{
				return this._stateToken;
			}
		}

		protected long SelfToken
		{
			get
			{
				return this._selfToken;
			}
		}

		public virtual int CollisionLayer
		{
			get
			{
				return this._entity.DefaultLayer;
			}
		}

		protected void Finish()
		{
			bool flag = !this._bFinished;
			if (flag)
			{
				this._bFinished = true;
				this.Cease();
			}
		}

		protected virtual void Cease()
		{
		}

		protected virtual void Begin()
		{
		}

		protected virtual void Cancel(XStateDefine next)
		{
		}

		protected virtual void OnMount(XMount mount)
		{
		}

		protected virtual bool SelfCheck(T args)
		{
			return true;
		}

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

		public abstract string PresentCommand { get; }

		public abstract string PresentName { get; }

		protected virtual bool InnerPermitted(XStateDefine state)
		{
			return this._entity.Machine.StatePermitted(this._selfState, state);
		}

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

		protected abstract bool OnGetEvent(T e, XStateDefine last);

		protected virtual void ActionUpdate(float deltaTime)
		{
		}

		public bool Deprecated { get; set; }

		public abstract bool IsUsingCurve { get; }

		protected XStateDefine _selfState = XStateDefine.XState_Idle;

		private bool _bFinished = true;

		private bool _bStopped = false;

		private long _stateToken = 0L;

		private long _selfToken = 0L;
	}
}
