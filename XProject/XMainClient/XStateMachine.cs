using System;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000EF1 RID: 3825
	internal sealed class XStateMachine : XComponent, IAnimStateMachine
	{
		// Token: 0x1700356C RID: 13676
		// (get) Token: 0x0600CAFB RID: 51963 RVA: 0x002E0B6C File Offset: 0x002DED6C
		public override uint ID
		{
			get
			{
				return XStateMachine.uuID;
			}
		}

		// Token: 0x0600CAFC RID: 51964 RVA: 0x002E0B84 File Offset: 0x002DED84
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

		// Token: 0x0600CAFD RID: 51965 RVA: 0x002E0BD3 File Offset: 0x002DEDD3
		public void SetDefaultState(IXStateTransform def)
		{
			this._default = def;
			this._current = def;
			this._previous = def;
			def.OnGetPermission();
		}

		// Token: 0x1700356D RID: 13677
		// (get) Token: 0x0600CAFE RID: 51966 RVA: 0x002E0BF4 File Offset: 0x002DEDF4
		public IXStateTransform State
		{
			get
			{
				return this._current;
			}
		}

		// Token: 0x1700356E RID: 13678
		// (get) Token: 0x0600CAFF RID: 51967 RVA: 0x002E0C0C File Offset: 0x002DEE0C
		public XStateDefine Current
		{
			get
			{
				return this._current.SelfState;
			}
		}

		// Token: 0x1700356F RID: 13679
		// (get) Token: 0x0600CB00 RID: 51968 RVA: 0x002E0C2C File Offset: 0x002DEE2C
		public XStateDefine Previous
		{
			get
			{
				return this._previous.SelfState;
			}
		}

		// Token: 0x17003570 RID: 13680
		// (get) Token: 0x0600CB01 RID: 51969 RVA: 0x002E0C4C File Offset: 0x002DEE4C
		public XStateDefine Default
		{
			get
			{
				return this._default.SelfState;
			}
		}

		// Token: 0x17003571 RID: 13681
		// (get) Token: 0x0600CB02 RID: 51970 RVA: 0x002E0C6C File Offset: 0x002DEE6C
		public long ActionToken
		{
			get
			{
				return this._current.Token;
			}
		}

		// Token: 0x17003572 RID: 13682
		// (get) Token: 0x0600CB03 RID: 51971 RVA: 0x002E0C8C File Offset: 0x002DEE8C
		public int CollisionLayer
		{
			get
			{
				return this._current.CollisionLayer;
			}
		}

		// Token: 0x0600CB04 RID: 51972 RVA: 0x002E0CAC File Offset: 0x002DEEAC
		public bool CanAct(XStateDefine state)
		{
			bool flag = (base.Enabled && this._current.IsPermitted(state)) || state == XStateDefine.XState_Death;
			return flag && (!this._entity.IsMounted || !this._entity.IsCopilotMounted);
		}

		// Token: 0x0600CB05 RID: 51973 RVA: 0x002E0D04 File Offset: 0x002DEF04
		public bool CanAct(IXStateTransform next)
		{
			return this.CanAct(next.SelfState);
		}

		// Token: 0x0600CB06 RID: 51974 RVA: 0x002E0D24 File Offset: 0x002DEF24
		public bool StatePermitted(XStateDefine src, XStateDefine des)
		{
			bool flag = XStateMachine._bStateMap == null;
			return !flag && XStateMachine._bStateMap[(int)src, (int)des];
		}

		// Token: 0x0600CB07 RID: 51975 RVA: 0x002E0D58 File Offset: 0x002DEF58
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

		// Token: 0x0600CB08 RID: 51976 RVA: 0x002E0DB8 File Offset: 0x002DEFB8
		public void Stop()
		{
			this._current.Stop(this._default.SelfState);
		}

		// Token: 0x0600CB09 RID: 51977 RVA: 0x002E0DD4 File Offset: 0x002DEFD4
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

		// Token: 0x0600CB0A RID: 51978 RVA: 0x002E0E18 File Offset: 0x002DF018
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

		// Token: 0x0600CB0B RID: 51979 RVA: 0x002E0E8C File Offset: 0x002DF08C
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

		// Token: 0x0600CB0C RID: 51980 RVA: 0x002E0FB4 File Offset: 0x002DF1B4
		public void OnAnimationOverrided()
		{
			bool flag = this._default != null;
			if (flag)
			{
				this._pre_command = this._default.PresentCommand;
			}
		}

		// Token: 0x0600CB0D RID: 51981 RVA: 0x002E0FE0 File Offset: 0x002DF1E0
		public void TriggerPresent()
		{
			this._bTrigger = true;
		}

		// Token: 0x0600CB0E RID: 51982 RVA: 0x002E0FEC File Offset: 0x002DF1EC
		public void SetAnimationSpeed(float speed)
		{
			bool flag = this._entity.Ator != null && this._entity.Skill != null && !this._entity.Skill.IsCasting();
			if (flag)
			{
				this._entity.Ator.speed = speed;
			}
		}

		// Token: 0x0600CB0F RID: 51983 RVA: 0x002E1040 File Offset: 0x002DF240
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

		// Token: 0x0600CB10 RID: 51984 RVA: 0x002E1084 File Offset: 0x002DF284
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

		// Token: 0x0600CB11 RID: 51985 RVA: 0x002E1128 File Offset: 0x002DF328
		private void TransferToDefaultState()
		{
			XIdleEventArgs @event = XEventPool<XIdleEventArgs>.GetEvent();
			@event.Firer = this._host;
			XSingleton<XEventMgr>.singleton.FireEvent(@event);
		}

		// Token: 0x0600CB12 RID: 51986 RVA: 0x002E1158 File Offset: 0x002DF358
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

		// Token: 0x0600CB13 RID: 51987 RVA: 0x002E118B File Offset: 0x002DF38B
		public void UpdateCollisionLayer()
		{
			this._entity.SetCollisionLayer(this._current.CollisionLayer);
		}

		// Token: 0x040059C1 RID: 22977
		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("StateMachine");

		// Token: 0x040059C2 RID: 22978
		private IXStateTransform _current = null;

		// Token: 0x040059C3 RID: 22979
		private IXStateTransform _default = null;

		// Token: 0x040059C4 RID: 22980
		private IXStateTransform _previous = null;

		// Token: 0x040059C5 RID: 22981
		private string _pre_command = null;

		// Token: 0x040059C6 RID: 22982
		private static bool[,] _bStateMap = null;

		// Token: 0x040059C7 RID: 22983
		private bool _bTrigger = false;

		// Token: 0x040059C8 RID: 22984
		public static bool _EnableAtor = true;
	}
}
