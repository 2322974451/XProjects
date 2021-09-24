using System;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{

	internal sealed class XMoveComponent : XActionStateComponent<XMoveEventArgs>
	{

		public override uint ID
		{
			get
			{
				return XMoveComponent.uuID;
			}
		}

		public override float Speed
		{
			get
			{
				return this._begin_inertia ? 0f : this._speed;
			}
		}

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

		public XMoveComponent()
		{
			this._playTrackFxCb = new XTimerMgr.ElapsedEventHandler(this.PlayTrackFx);
		}

		public override bool IsUsingCurve
		{
			get
			{
				return false;
			}
		}

		public override void OnAttachToHost(XObject host)
		{
			base.OnAttachToHost(host);
			this._selfState = XStateDefine.XState_Move;
			this._speed = 0f;
			this._last_speed = 0f;
			this._acceleration = 0f;
			this.PrepareAnimations();
		}

		protected override void EventSubscribe()
		{
			base.RegisterEvent(XEventDefine.XEvent_Move, new XComponent.XEventHandler(base.OnActionEvent));
			base.RegisterEvent(XEventDefine.XEvent_OnMounted, new XComponent.XEventHandler(base.OnMountEvent));
			base.RegisterEvent(XEventDefine.XEvent_OnUnMounted, new XComponent.XEventHandler(base.OnMountEvent));
		}

		public override bool SyncPredicted
		{
			get
			{
				return this._entity.IsClientPredicted || base.SyncPredicted;
			}
		}

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

		protected override void Cease()
		{
			this._begin_inertia = false;
		}

		public override void OnRejected(XStateDefine current)
		{
		}

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

		public override bool ShouldBePresent
		{
			get
			{
				return this._entity.Machine.Previous != XStateDefine.XState_Move;
			}
		}

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

		public override string PresentCommand
		{
			get
			{
				return "ToMove";
			}
		}

		public override string PresentName
		{
			get
			{
				return "Move";
			}
		}

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

		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("Basic_Move");

		private bool _begin_inertia = false;

		private bool _stoppage = true;

		private float _speed = 0f;

		private float _last_speed = 0f;

		private float _target_speed = 0f;

		private float _anim_speed = 0f;

		private float _stoppage_dir = 0f;

		private float _acceleration = 0f;

		private float _last_angular = 0f;

		private Vector3 _move_dir = Vector3.forward;

		private Vector3 _destination = Vector3.zero;

		private bool _inertia = false;

		private bool _overlapped = false;

		private uint _track_fx_1 = 0U;

		private uint _track_fx_2 = 0U;

		private XTimerMgr.ElapsedEventHandler _playTrackFxCb = null;
	}
}
