using System;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000F2D RID: 3885
	internal sealed class XMoveComponent : XActionStateComponent<XMoveEventArgs>
	{
		// Token: 0x170035E1 RID: 13793
		// (get) Token: 0x0600CDE4 RID: 52708 RVA: 0x002F953C File Offset: 0x002F773C
		public override uint ID
		{
			get
			{
				return XMoveComponent.uuID;
			}
		}

		// Token: 0x170035E2 RID: 13794
		// (get) Token: 0x0600CDE5 RID: 52709 RVA: 0x002F9554 File Offset: 0x002F7754
		public override float Speed
		{
			get
			{
				return this._begin_inertia ? 0f : this._speed;
			}
		}

		// Token: 0x170035E3 RID: 13795
		// (get) Token: 0x0600CDE6 RID: 52710 RVA: 0x002F957C File Offset: 0x002F777C
		// (set) Token: 0x0600CDE7 RID: 52711 RVA: 0x002F9594 File Offset: 0x002F7794
		public float AnimSpeed
		{
			get
			{
				return this._anim_speed;
			}
			set
			{
				this._anim_speed = value;
			}
		}

		// Token: 0x0600CDE8 RID: 52712 RVA: 0x002F95A0 File Offset: 0x002F77A0
		public XMoveComponent()
		{
			this._playTrackFxCb = new XTimerMgr.ElapsedEventHandler(this.PlayTrackFx);
		}

		// Token: 0x170035E4 RID: 13796
		// (get) Token: 0x0600CDE9 RID: 52713 RVA: 0x002F965C File Offset: 0x002F785C
		public override bool IsUsingCurve
		{
			get
			{
				return false;
			}
		}

		// Token: 0x0600CDEA RID: 52714 RVA: 0x002F966F File Offset: 0x002F786F
		public override void OnAttachToHost(XObject host)
		{
			base.OnAttachToHost(host);
			this._selfState = XStateDefine.XState_Move;
			this._speed = 0f;
			this._last_speed = 0f;
			this._acceleration = 0f;
			this.PrepareAnimations();
		}

		// Token: 0x0600CDEB RID: 52715 RVA: 0x002F96AC File Offset: 0x002F78AC
		protected override void EventSubscribe()
		{
			base.RegisterEvent(XEventDefine.XEvent_Move, new XComponent.XEventHandler(base.OnActionEvent));
			base.RegisterEvent(XEventDefine.XEvent_OnMounted, new XComponent.XEventHandler(base.OnMountEvent));
			base.RegisterEvent(XEventDefine.XEvent_OnUnMounted, new XComponent.XEventHandler(base.OnMountEvent));
		}

		// Token: 0x170035E5 RID: 13797
		// (get) Token: 0x0600CDEC RID: 52716 RVA: 0x002F9700 File Offset: 0x002F7900
		public override bool SyncPredicted
		{
			get
			{
				return this._entity.IsClientPredicted || base.SyncPredicted;
			}
		}

		// Token: 0x0600CDED RID: 52717 RVA: 0x002F9728 File Offset: 0x002F7928
		protected override bool InnerPermitted(XStateDefine state)
		{
			bool flag = !this._entity.IsPlayer && this.SyncPredicted;
			bool result;
			if (flag)
			{
				result = (state != XStateDefine.XState_Idle || this._stoppage);
			}
			else
			{
				result = (base.IsFinished || base.InnerPermitted(state));
			}
			return result;
		}

		// Token: 0x0600CDEE RID: 52718 RVA: 0x002F9778 File Offset: 0x002F7978
		protected override void Cancel(XStateDefine next)
		{
			bool flag = next != XStateDefine.XState_Move;
			if (flag)
			{
				XEntity xentity = this._entity.IsTransform ? this._entity.Transformer : this._entity;
				xentity.Machine.SetAnimationSpeed(1f);
				for (int i = 0; i < xentity.Affiliates.Count; i++)
				{
					bool flag2 = xentity.Affiliates[i].Ator != null;
					if (flag2)
					{
						xentity.Affiliates[i].Ator.speed = xentity.Ator.speed;
					}
				}
				bool flag3 = xentity.IsMounted && xentity.Mount.Ator != null;
				if (flag3)
				{
					xentity.Mount.Ator.speed = xentity.Ator.speed;
				}
				this._speed = 0f;
				this._last_speed = 0f;
				this._acceleration = 0f;
				bool flag4 = this._track_fx_1 > 0U;
				if (flag4)
				{
					XSingleton<XTimerMgr>.singleton.KillTimer(this._track_fx_1);
				}
				bool flag5 = this._track_fx_2 > 0U;
				if (flag5)
				{
					XSingleton<XTimerMgr>.singleton.KillTimer(this._track_fx_2);
				}
				this._track_fx_1 = 0U;
				this._track_fx_2 = 0U;
				this._anim_speed = 0f;
				bool flag6 = !this._entity.IsPlayer && this.SyncPredicted;
				if (flag6)
				{
					this._entity.Net.ReportRotateAction(XSingleton<XCommon>.singleton.FloatToAngle(this._stoppage_dir));
				}
			}
		}

		// Token: 0x0600CDEF RID: 52719 RVA: 0x002F9918 File Offset: 0x002F7B18
		protected override void Cease()
		{
			this._begin_inertia = false;
		}

		// Token: 0x0600CDF0 RID: 52720 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public override void OnRejected(XStateDefine current)
		{
		}

		// Token: 0x0600CDF1 RID: 52721 RVA: 0x002F9924 File Offset: 0x002F7B24
		public override string TriggerAnim(string pre)
		{
			bool isPlayer = this._entity.IsPlayer;
			if (isPlayer)
			{
				bool flag = this._track_fx_1 == 0U;
				if (flag)
				{
					this._track_fx_1 = XSingleton<XTimerMgr>.singleton.SetTimer(0.144f, this._playTrackFxCb, null);
				}
				bool flag2 = this._track_fx_2 == 0U;
				if (flag2)
				{
					this._track_fx_2 = XSingleton<XTimerMgr>.singleton.SetTimer(0.426f, this._playTrackFxCb, this);
				}
			}
			string text = (base.IsFinished && this._entity.IsPlayer) ? "ToStand" : this.PresentCommand;
			bool flag3 = pre != text;
			if (flag3)
			{
				bool flag4 = this._entity.Ator != null;
				if (flag4)
				{
					this._entity.Ator.SetTrigger(text);
				}
			}
			return text;
		}

		// Token: 0x0600CDF2 RID: 52722 RVA: 0x002F99F4 File Offset: 0x002F7BF4
		protected override void ActionUpdate(float deltaTime)
		{
			this._last_speed = this._speed;
			bool isFinished = base.IsFinished;
			if (!isFinished)
			{
				bool flag = this._speed == 0f && this._target_speed == 0f;
				if (flag)
				{
					base.Finish();
				}
				else
				{
					this._speed += deltaTime * this._acceleration;
					bool flag2 = (this._speed - this._target_speed) * this._acceleration > 0f;
					if (flag2)
					{
						this._speed = this._target_speed;
						this._acceleration = 0f;
					}
					bool begin_inertia = this._begin_inertia;
					if (!begin_inertia)
					{
						Vector3 movement = this._move_dir * ((this._speed + this._last_speed) * 0.5f) * deltaTime;
						bool flag3 = this._entity.Buffs != null && this._entity.Buffs.IsBuffStateOn(XBuffType.XBuffType_LockFoot);
						if (flag3)
						{
							movement = Vector3.zero;
						}
						this.CheckMove(ref movement);
						bool flag4 = this._entity.IsPlayer || this._entity.IsEnemy;
						if (flag4)
						{
							XSecurityStatistics xsecurityStatistics = XSecurityStatistics.TryGetStatistics(this._entity);
							bool flag5 = xsecurityStatistics != null;
							if (flag5)
							{
								xsecurityStatistics.OnMove(movement.magnitude);
							}
						}
						this._entity.ApplyMove(movement);
					}
				}
				this._anim_speed = this._speed;
			}
		}

		// Token: 0x0600CDF3 RID: 52723 RVA: 0x002F9B70 File Offset: 0x002F7D70
		public override void PostUpdate(float fDeltaT)
		{
			bool flag = this._entity.Machine.Current != XStateDefine.XState_Move;
			if (!flag)
			{
				XEntity xentity = this._entity.IsTransform ? this._entity.Transformer : this._entity;
				bool flag2 = xentity.Ator == null;
				if (!flag2)
				{
					bool flag3 = XSingleton<XCommon>.singleton.IsLess(this._anim_speed, this._entity.Attributes.WalkSpeed);
					if (flag3)
					{
						xentity.Machine.SetAnimationSpeed(Mathf.Max(0.5f, this._anim_speed / this._entity.Attributes.WalkSpeed));
					}
					else
					{
						bool flag4 = XSingleton<XCommon>.singleton.IsGreater(this._anim_speed, this._entity.Attributes.RunSpeed);
						if (flag4)
						{
							xentity.Machine.SetAnimationSpeed(this._anim_speed / this._entity.Attributes.RunSpeed);
						}
						else
						{
							xentity.Machine.SetAnimationSpeed(1f);
						}
					}
					float value = this._anim_speed / this._entity.Attributes.RunSpeed;
					bool flag5 = xentity.IsMounted && xentity.Mount.Ator != null;
					if (flag5)
					{
						bool hasTurnPresetation = xentity.Mount.HasTurnPresetation;
						if (hasTurnPresetation)
						{
							float num = xentity.Rotate.Angular();
							this._last_angular += (num - this._last_angular) * Mathf.Min(1f, fDeltaT * (float)xentity.Mount.AngularSpeed);
						}
						else
						{
							this._last_angular = 0f;
						}
						xentity.Ator.SetFloat("MoveFactor", value);
						xentity.Ator.SetFloat("AngleFactor", this._last_angular);
						for (int i = 0; i < xentity.Affiliates.Count; i++)
						{
							bool flag6 = xentity.Affiliates[i].Ator != null;
							if (flag6)
							{
								xentity.Affiliates[i].Ator.speed = xentity.Ator.speed;
								xentity.Affiliates[i].Ator.SetFloat("MoveFactor", value);
								xentity.Affiliates[i].Ator.SetFloat("AngleFactor", this._last_angular);
							}
						}
						bool flag7 = xentity.IsMounted && xentity.Mount.Ator != null;
						if (flag7)
						{
							xentity.Mount.Ator.speed = xentity.Ator.speed;
							xentity.Mount.Ator.SetFloat("MoveFactor", value);
							xentity.Mount.Ator.SetFloat("AngleFactor", this._last_angular);
						}
					}
					else
					{
						this._last_angular = 0f;
						xentity.Ator.SetFloat("MoveFactor", value);
						xentity.Ator.SetFloat("AngleFactor", 0f);
						for (int j = 0; j < xentity.Affiliates.Count; j++)
						{
							bool flag8 = xentity.Affiliates[j].Ator != null;
							if (flag8)
							{
								xentity.Affiliates[j].Ator.speed = xentity.Ator.speed;
								xentity.Affiliates[j].Ator.SetFloat("MoveFactor", value);
								xentity.Affiliates[j].Ator.SetFloat("AngleFactor", 0f);
							}
						}
					}
				}
			}
		}

		// Token: 0x170035E6 RID: 13798
		// (get) Token: 0x0600CDF4 RID: 52724 RVA: 0x002F9F48 File Offset: 0x002F8148
		public override bool ShouldBePresent
		{
			get
			{
				return this._entity.Machine.Previous != XStateDefine.XState_Move;
			}
		}

		// Token: 0x0600CDF5 RID: 52725 RVA: 0x002F9F70 File Offset: 0x002F8170
		protected override bool OnGetEvent(XMoveEventArgs e, XStateDefine last)
		{
			this._stoppage = e.Stoppage;
			this._stoppage_dir = e.StopTowards;
			this._inertia = e.Inertia;
			this._target_speed = e.Speed;
			this._destination = e.Destination;
			this._move_dir = this._destination - this._entity.MoveObj.Position;
			this._move_dir.y = 0f;
			float sqrMagnitude = this._move_dir.sqrMagnitude;
			bool flag = sqrMagnitude == 0f || ((double)sqrMagnitude < 0.001 && this._entity.IsPlayer) || (sqrMagnitude < 0.1f && !this._entity.IsPlayer && this.SyncPredicted && this._stoppage);
			if (flag)
			{
				this._move_dir = this._entity.MoveObj.Forward;
				this._target_speed = 0f;
			}
			this._move_dir.Normalize();
			bool flag2 = this._entity.Fly != null;
			if (flag2)
			{
				float num = XSingleton<XScene>.singleton.TerrainY(this._destination);
				bool flag3 = this._destination.y - num < this._entity.Fly.MinHeight;
				if (flag3)
				{
					this._destination.y = num + (this._entity.Fly.MinHeight + this._entity.Fly.MaxHeight) * 0.5f;
				}
			}
			bool flag4 = this._entity.IsPlayer && XSingleton<XGame>.singleton.CurrentStage.Stage == EXStage.Hall;
			if (flag4)
			{
				XMoveEventArgs @event = XEventPool<XMoveEventArgs>.GetEvent();
				@event.Speed = this._target_speed;
				@event.Destination = this._destination;
				@event.Inertia = this._inertia;
				@event.Firer = XSingleton<XGame>.singleton.Doc;
				XSingleton<XEventMgr>.singleton.FireEvent(@event);
			}
			return true;
		}

		// Token: 0x0600CDF6 RID: 52726 RVA: 0x002FA174 File Offset: 0x002F8374
		protected override void Begin()
		{
			this._begin_inertia = false;
			bool flag = this._target_speed != this._speed;
			if (flag)
			{
				bool flag2 = this._target_speed > this._speed;
				if (flag2)
				{
					this._acceleration = this._entity.Attributes.RunSpeed * 5f;
				}
				else
				{
					this._acceleration = -this._entity.Attributes.RunSpeed * 6f;
				}
			}
			else
			{
				this._acceleration = 0f;
			}
			this._entity.Net.ReportRotateAction(this._move_dir);
			this._overlapped = false;
			Vector3 zero = Vector3.zero;
			this.CheckMove(ref zero);
		}

		// Token: 0x0600CDF7 RID: 52727 RVA: 0x002FA228 File Offset: 0x002F8428
		protected override void OnMount(XMount mount)
		{
			bool flag = mount != null;
			if (flag)
			{
				this._entity.OverrideAnimClip("Walk", this._entity.Present.PresentLib.AnimLocation.Replace('/', '_') + mount.Present.PresentLib.Walk + (this._entity.IsCopilotMounted ? "_follow" : ""), true, false);
				this._entity.OverrideAnimClip("Run", this._entity.Present.PresentLib.AnimLocation.Replace('/', '_') + mount.Present.PresentLib.Run + (this._entity.IsCopilotMounted ? "_follow" : ""), true, false);
				bool hasTurnPresetation = mount.HasTurnPresetation;
				if (hasTurnPresetation)
				{
					this._entity.OverrideAnimClip("RunLeft", this._entity.Present.PresentLib.AnimLocation.Replace('/', '_') + mount.Present.PresentLib.RunLeft + (this._entity.IsCopilotMounted ? "_follow" : ""), true, false);
					this._entity.OverrideAnimClip("RunRight", this._entity.Present.PresentLib.AnimLocation.Replace('/', '_') + mount.Present.PresentLib.RunRight + (this._entity.IsCopilotMounted ? "_follow" : ""), true, false);
				}
			}
			else
			{
				this.PrepareAnimations();
			}
			this._entity.Machine.TriggerPresent();
		}

		// Token: 0x0600CDF8 RID: 52728 RVA: 0x002FA3EC File Offset: 0x002F85EC
		private void CheckMove(ref Vector3 movement)
		{
			bool flag = !this._overlapped;
			if (flag)
			{
				this._overlapped = this.Overlapped(ref movement);
				bool overlapped = this._overlapped;
				if (overlapped)
				{
					this._target_speed = 0f;
					bool flag2 = this._inertia && this._speed > 0f;
					if (flag2)
					{
						this._acceleration = -this._entity.Attributes.RunSpeed * 6f;
						this._begin_inertia = true;
					}
					else
					{
						this._acceleration = 0f;
						base.Finish();
					}
				}
			}
		}

		// Token: 0x0600CDF9 RID: 52729 RVA: 0x002FA488 File Offset: 0x002F8688
		private bool Overlapped(ref Vector3 movement)
		{
			Vector3 vector = this._entity.MoveObj.Position + movement;
			vector.y = 0f;
			Vector3 destination = this._destination;
			destination.y = 0f;
			Vector3 vector2 = destination - vector;
			bool flag = vector2.sqrMagnitude > 0f;
			bool result;
			if (flag)
			{
				float num = Vector3.Angle(vector2, this._move_dir);
				bool flag2 = num >= 90f;
				if (flag2)
				{
					movement = this._destination - this._entity.MoveObj.Position;
					bool flag3 = this._entity.Fly != null;
					if (flag3)
					{
						movement.y = 0f;
					}
					result = true;
				}
				else
				{
					result = false;
				}
			}
			else
			{
				result = true;
			}
			return result;
		}

		// Token: 0x170035E7 RID: 13799
		// (get) Token: 0x0600CDFA RID: 52730 RVA: 0x002FA560 File Offset: 0x002F8760
		public override string PresentCommand
		{
			get
			{
				return "ToMove";
			}
		}

		// Token: 0x170035E8 RID: 13800
		// (get) Token: 0x0600CDFB RID: 52731 RVA: 0x002FA578 File Offset: 0x002F8778
		public override string PresentName
		{
			get
			{
				return "Move";
			}
		}

		// Token: 0x0600CDFC RID: 52732 RVA: 0x002FA590 File Offset: 0x002F8790
		private void PlayTrackFx(object o)
		{
			bool flag = string.IsNullOrEmpty(this._entity.Present.PresentLib.MoveFx);
			if (!flag)
			{
				uint num = XSingleton<XTimerMgr>.singleton.SetTimer(0.533f, this._playTrackFxCb, o);
				bool flag2 = o == null;
				if (flag2)
				{
					this._track_fx_1 = num;
				}
				else
				{
					this._track_fx_2 = num;
				}
				XSingleton<XFxMgr>.singleton.CreateAndPlay(this._entity.Present.PresentLib.MoveFx, this._entity.MoveObj, Vector3.zero, Vector3.one, 1f, false, 0.5f, true);
				XSingleton<XAudioMgr>.singleton.PlaySound(this._entity, AudioChannel.Motion, XAudioStateDefine.XState_Audio_Move);
			}
		}

		// Token: 0x0600CDFD RID: 52733 RVA: 0x002FA644 File Offset: 0x002F8844
		private void PrepareAnimations()
		{
			bool isNotEmptyObject = this._entity.EngineObject.IsNotEmptyObject;
			if (isNotEmptyObject)
			{
				bool flag = XSingleton<XGame>.singleton.CurrentStage.Stage == EXStage.World && !string.IsNullOrEmpty(this._entity.Present.PresentLib.AttackIdle);
				if (flag)
				{
					this._entity.OverrideAnimClip("Walk", this._entity.Present.PresentLib.AttackWalk, true, false);
					this._entity.OverrideAnimClip("Run", this._entity.Present.PresentLib.AttackRun, true, false);
					this._entity.OverrideAnimClip("RunLeft", this._entity.Present.PresentLib.AttackRunLeft, true, false);
					this._entity.OverrideAnimClip("RunRight", this._entity.Present.PresentLib.AttackRunRight, true, false);
				}
				else
				{
					this._entity.OverrideAnimClip("Walk", this._entity.Present.PresentLib.Walk, true, false);
					this._entity.OverrideAnimClip("Run", this._entity.Present.PresentLib.Run, true, false);
					this._entity.OverrideAnimClip("RunLeft", this._entity.Present.PresentLib.RunLeft, true, false);
					this._entity.OverrideAnimClip("RunRight", this._entity.Present.PresentLib.RunRight, true, false);
				}
			}
		}

		// Token: 0x04005BBB RID: 23483
		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("Basic_Move");

		// Token: 0x04005BBC RID: 23484
		private bool _begin_inertia = false;

		// Token: 0x04005BBD RID: 23485
		private bool _stoppage = true;

		// Token: 0x04005BBE RID: 23486
		private float _speed = 0f;

		// Token: 0x04005BBF RID: 23487
		private float _last_speed = 0f;

		// Token: 0x04005BC0 RID: 23488
		private float _target_speed = 0f;

		// Token: 0x04005BC1 RID: 23489
		private float _anim_speed = 0f;

		// Token: 0x04005BC2 RID: 23490
		private float _stoppage_dir = 0f;

		// Token: 0x04005BC3 RID: 23491
		private float _acceleration = 0f;

		// Token: 0x04005BC4 RID: 23492
		private float _last_angular = 0f;

		// Token: 0x04005BC5 RID: 23493
		private Vector3 _move_dir = Vector3.forward;

		// Token: 0x04005BC6 RID: 23494
		private Vector3 _destination = Vector3.zero;

		// Token: 0x04005BC7 RID: 23495
		private bool _inertia = false;

		// Token: 0x04005BC8 RID: 23496
		private bool _overlapped = false;

		// Token: 0x04005BC9 RID: 23497
		private uint _track_fx_1 = 0U;

		// Token: 0x04005BCA RID: 23498
		private uint _track_fx_2 = 0U;

		// Token: 0x04005BCB RID: 23499
		private XTimerMgr.ElapsedEventHandler _playTrackFxCb = null;
	}
}
