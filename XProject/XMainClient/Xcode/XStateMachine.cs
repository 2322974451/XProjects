using System;
using XUtliPoolLib;

namespace XMainClient
{

	internal sealed class XStateMachine : XComponent, IAnimStateMachine
	{

		public override uint ID
		{
			get
			{
				return XStateMachine.uuID;
			}
		}

		public override void OnAttachToHost(XObject host)
		{
			base.OnAttachToHost(host);
			this.BuildStateMap();
			bool flag = host is XEntity;
			if (flag)
			{
				XEntity xentity = host as XEntity;
				bool flag2 = xentity.Ator != null;
				if (flag2)
				{
					xentity.Ator.SetStateMachine(this);
				}
			}
		}

		public void SetDefaultState(IXStateTransform def)
		{
			this._default = def;
			this._current = def;
			this._previous = def;
			def.OnGetPermission();
		}

		public IXStateTransform State
		{
			get
			{
				return this._current;
			}
		}

		public XStateDefine Current
		{
			get
			{
				return this._current.SelfState;
			}
		}

		public XStateDefine Previous
		{
			get
			{
				return this._previous.SelfState;
			}
		}

		public XStateDefine Default
		{
			get
			{
				return this._default.SelfState;
			}
		}

		public long ActionToken
		{
			get
			{
				return this._current.Token;
			}
		}

		public int CollisionLayer
		{
			get
			{
				return this._current.CollisionLayer;
			}
		}

		public bool CanAct(XStateDefine state)
		{
			bool flag = (base.Enabled && this._current.IsPermitted(state)) || state == XStateDefine.XState_Death;
			return flag && (!this._entity.IsMounted || !this._entity.IsCopilotMounted);
		}

		public bool CanAct(IXStateTransform next)
		{
			return this.CanAct(next.SelfState);
		}

		public bool StatePermitted(XStateDefine src, XStateDefine des)
		{
			bool flag = XStateMachine._bStateMap == null;
			return !flag && XStateMachine._bStateMap[(int)src, (int)des];
		}

		public void ForceToDefaultState(bool ignoredeath)
		{
			bool flag = ignoredeath || this._current.SelfState != XStateDefine.XState_Death;
			if (flag)
			{
				bool flag2 = this._current != this._default;
				if (flag2)
				{
					this._current.Stop(this._default.SelfState);
					this.TransferToDefaultState();
				}
			}
		}

		public void Stop()
		{
			this._current.Stop(this._default.SelfState);
		}

		public override void Update(float fDeltaT)
		{
			this._current.StateUpdate(fDeltaT);
			bool isFinished = this._current.IsFinished;
			if (isFinished)
			{
				bool syncPredicted = this._current.SyncPredicted;
				if (syncPredicted)
				{
					this.TransferToDefaultState();
				}
			}
		}

		public override void PostUpdate(float fDeltaT)
		{
			bool flag = this._bTrigger && this._entity.Ator != null && !this._entity.Ator.IsInTransition(0);
			if (flag)
			{
				this._pre_command = this._current.TriggerAnim(this._pre_command);
				this.AnimationUpdate(this._entity, this._pre_command);
				this._bTrigger = false;
			}
		}

		private void AnimationUpdate(XEntity entity, string pre_command)
		{
			entity = (entity.IsTransform ? entity.Transformer : entity);
			float transitionDuration = (this._current.SelfState == XStateDefine.XState_Idle) ? 0.5f : 0.05f;
			for (int i = 0; i < entity.Affiliates.Count; i++)
			{
				bool flag = entity.Affiliates[i].MirrorState && entity.Affiliates[i].Ator != null;
				if (flag)
				{
					entity.Affiliates[i].Ator.CrossFade(this._current.PresentName, transitionDuration, 0, 0f);
				}
			}
			bool flag2 = entity.IsMounted && !entity.IsCopilotMounted;
			if (flag2)
			{
				bool flag3 = entity.Mount.Ator != null;
				if (flag3)
				{
					entity.Mount.Ator.CrossFade(this._current.PresentName, transitionDuration, 0, 0f);
				}
				bool flag4 = entity.Mount.Copilot != null;
				if (flag4)
				{
					this.AnimationUpdate(entity.Mount.Copilot, pre_command);
				}
			}
		}

		public void OnAnimationOverrided()
		{
			bool flag = this._default != null;
			if (flag)
			{
				this._pre_command = this._default.PresentCommand;
			}
		}

		public void TriggerPresent()
		{
			this._bTrigger = true;
		}

		public void SetAnimationSpeed(float speed)
		{
			bool flag = this._entity.Ator != null && this._entity.Skill != null && !this._entity.Skill.IsCasting();
			if (flag)
			{
				this._entity.Ator.speed = speed;
			}
		}

		public bool TryTransferToState(IXStateTransform next)
		{
			bool flag = this.CanAct(next.SelfState);
			bool result;
			if (flag)
			{
				result = this.TransferToState(next);
			}
			else
			{
				next.OnRejected(this._current.SelfState);
				result = false;
			}
			return result;
		}

		public bool TransferToState(IXStateTransform next)
		{
			bool flag = this._current.SelfState != next.SelfState || next.SelfState != XStateDefine.XState_Move;
			if (flag)
			{
				this._current.Stop(next.SelfState);
			}
			this._previous = this._current;
			this._current = next;
			this._current.OnGetPermission();
			bool flag2 = this._previous.SelfState != this._current.SelfState || !this._bTrigger;
			if (flag2)
			{
				this._bTrigger = this._current.ShouldBePresent;
			}
			return true;
		}

		private void TransferToDefaultState()
		{
			XIdleEventArgs @event = XEventPool<XIdleEventArgs>.GetEvent();
			@event.Firer = this._host;
			XSingleton<XEventMgr>.singleton.FireEvent(@event);
		}

		private void BuildStateMap()
		{
			bool flag = XStateMachine._bStateMap == null;
			if (flag)
			{
				XStateMachine._bStateMap = new bool[,]
				{
					{
						false,
						true,
						true,
						true,
						true,
						true,
						true,
						true
					},
					{
						true,
						true,
						true,
						true,
						true,
						true,
						true,
						true
					},
					{
						false,
						false,
						false,
						true,
						true,
						true,
						true,
						false
					},
					{
						false,
						false,
						false,
						false,
						true,
						true,
						true,
						false
					},
					{
						false,
						false,
						false,
						false,
						true,
						false,
						true,
						false
					},
					{
						false,
						false,
						false,
						false,
						true,
						true,
						true,
						false
					},
					{
						false,
						false,
						false,
						false,
						false,
						false,
						false,
						false
					},
					{
						false,
						true,
						false,
						false,
						true,
						true,
						true,
						true
					}
				};
			}
		}

		public void UpdateCollisionLayer()
		{
			this._entity.SetCollisionLayer(this._current.CollisionLayer);
		}

		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("StateMachine");

		private IXStateTransform _current = null;

		private IXStateTransform _default = null;

		private IXStateTransform _previous = null;

		private string _pre_command = null;

		private static bool[,] _bStateMap = null;

		private bool _bTrigger = false;

		public static bool _EnableAtor = true;
	}
}
