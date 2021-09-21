using System;
using System.Collections.Generic;
using KKSG;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000FDB RID: 4059
	internal class XNetComponent : XComponent
	{
		// Token: 0x170036CD RID: 14029
		// (get) Token: 0x0600D2CA RID: 53962 RVA: 0x00315420 File Offset: 0x00313620
		public override uint ID
		{
			get
			{
				return XNetComponent.uuID;
			}
		}

		// Token: 0x170036CE RID: 14030
		// (get) Token: 0x0600D2CB RID: 53963 RVA: 0x00315438 File Offset: 0x00313638
		public uint SyncSequence
		{
			get
			{
				return this._sync_sequence;
			}
		}

		// Token: 0x0600D2CC RID: 53964 RVA: 0x00315450 File Offset: 0x00313650
		public XNetComponent()
		{
			this._IdledCb = new XTimerMgr.ElapsedEventHandler(this.Idled);
		}

		// Token: 0x170036CF RID: 14031
		// (get) Token: 0x0600D2CD RID: 53965 RVA: 0x003154E8 File Offset: 0x003136E8
		// (set) Token: 0x0600D2CE RID: 53966 RVA: 0x00315500 File Offset: 0x00313700
		public uint LastReqSkill
		{
			get
			{
				return this._last_req_skill;
			}
			set
			{
				this._last_req_skill = value;
			}
		}

		// Token: 0x170036D0 RID: 14032
		// (get) Token: 0x0600D2CF RID: 53967 RVA: 0x0031550C File Offset: 0x0031370C
		// (set) Token: 0x0600D2D0 RID: 53968 RVA: 0x00315524 File Offset: 0x00313724
		public bool Pause
		{
			get
			{
				return this._pause;
			}
			set
			{
				this._pause = value;
			}
		}

		// Token: 0x0600D2D1 RID: 53969 RVA: 0x0031552E File Offset: 0x0031372E
		public override void OnAttachToHost(XObject host)
		{
			base.OnAttachToHost(host);
			this._sync_sequence = 0U;
		}

		// Token: 0x0600D2D2 RID: 53970 RVA: 0x00315540 File Offset: 0x00313740
		public override void Attached()
		{
			bool flag = !this._entity.IsPlayer;
			if (flag)
			{
				this.CorrectNet(this._entity.MoveObj.Position, this._entity.MoveObj.Forward, 0U, true);
			}
			this._locate = (this._entity.IsPlayer ? (this._entity.GetXComponent(XLocateTargetComponent.uuID) as XLocateTargetComponent) : null);
			this._move = (this._entity.GetXComponent(XMoveComponent.uuID) as XMoveComponent);
		}

		// Token: 0x0600D2D3 RID: 53971 RVA: 0x003155CF File Offset: 0x003137CF
		public override void OnDetachFromHost()
		{
			this.KillIdle();
			base.OnDetachFromHost();
		}

		// Token: 0x0600D2D4 RID: 53972 RVA: 0x003155E0 File Offset: 0x003137E0
		public override void Update(float fDeltaT)
		{
			bool flag = !XSingleton<XGame>.singleton.SyncMode || this._entity.IsCopilotMounted;
			if (!flag)
			{
				Vector3 position = this._entity.MoveObj.Position;
				bool flag2 = this._entity.Machine.State.SyncPredicted && (this._entity.Skill == null || !this._entity.Skill.IsCasting());
				if (flag2)
				{
					this._magic = position - this._pos_target;
					this._magic.y = 0f;
					this._force_sync = (this._magic.sqrMagnitude > 4f);
					bool force_sync = this._force_sync;
					if (force_sync)
					{
						this._magic = Vector3.zero;
					}
				}
				else
				{
					bool flag3 = !this._pause;
					if (flag3)
					{
						Vector3 vector = (this._force_sync || this._entity.IsPassive) ? this._pos_target : (this._pos_target + this._magic);
						XStateDefine xstateDefine = this._entity.Machine.Current;
						if (xstateDefine != XStateDefine.XState_Move)
						{
							if (xstateDefine != XStateDefine.XState_Charge)
							{
								this._entity.SyncServerMove((vector - position) * 0.2f);
							}
							else
							{
								bool isUsingCurve = this._entity.Machine.State.IsUsingCurve;
								if (isUsingCurve)
								{
									this._entity.SyncServerMove((vector - position) * 0.2f);
								}
								else
								{
									float num = Mathf.Abs(this._entity.Machine.State.Speed * fDeltaT);
									Vector3 delta = vector - position;
									delta.y = 0f;
									float magnitude = delta.magnitude;
									bool flag4 = magnitude == 0f;
									if (flag4)
									{
										this._entity.SyncServerMove(delta);
									}
									else
									{
										this._entity.SyncServerMove(Mathf.Min(magnitude, num) * delta.normalized);
									}
								}
							}
						}
						else
						{
							float num2 = Mathf.Abs(this._move_anim_speed_target * fDeltaT);
							Vector3 delta2 = vector - position;
							delta2.y = 0f;
							float magnitude2 = delta2.magnitude;
							bool flag5 = magnitude2 == 0f;
							if (flag5)
							{
								this._entity.SyncServerMove(delta2);
							}
							else
							{
								this._entity.SyncServerMove(Mathf.Min(magnitude2, num2) * delta2.normalized);
							}
						}
						bool flag6 = this._entity.Rotate != null;
						if (flag6)
						{
							this._entity.Rotate.Cancel();
						}
						float num3 = Vector3.Angle(this._entity.MoveObj.Forward, this._face_target);
						float num4 = 0.2f;
						bool flag7 = this._entity.Skill != null && this._entity.Skill.IsCasting();
						if (flag7)
						{
							num4 = (this._entity.Skill.CurrentSkill.MainCore.Soul.Logical.Rotate_Server_Sync ? 1f : (this._entity.IsRole ? 0.2f : 0.5f));
						}
						bool flag8 = !XSingleton<XCommon>.singleton.Clockwise(this._entity.MoveObj.Forward, this._face_target);
						if (flag8)
						{
							num3 = -num3;
						}
						this._entity.MoveObj.Forward = XSingleton<XCommon>.singleton.HorizontalRotateVetor3(this._entity.MoveObj.Forward, num3 * num4, true);
					}
				}
				bool isPlayer = this._entity.IsPlayer;
				if (isPlayer)
				{
					XSingleton<XActionSender>.singleton.Flush(false);
				}
			}
		}

		// Token: 0x0600D2D5 RID: 53973 RVA: 0x003159B0 File Offset: 0x00313BB0
		public override void PostUpdate(float fDeltaT)
		{
			bool flag = !XSingleton<XGame>.singleton.SyncMode;
			if (!flag)
			{
				bool flag2 = !this._pause && !this._entity.Machine.State.SyncPredicted;
				if (flag2)
				{
					XStateDefine xstateDefine = this._entity.Machine.Current;
					if (xstateDefine == XStateDefine.XState_Move)
					{
						bool flag3 = this._move == null;
						if (!flag3)
						{
							this._move_anim_speed += (this._move_anim_speed_target - this._move_anim_speed) * Mathf.Min(1f, fDeltaT * 20f);
							this._move.AnimSpeed = this._move_anim_speed;
						}
					}
				}
			}
		}

		// Token: 0x0600D2D6 RID: 53974 RVA: 0x00315A68 File Offset: 0x00313C68
		public bool OnDeathNotify(DeathInfo data)
		{
			XSingleton<XDeath>.singleton.DeathDetect(this._entity, XSingleton<XEntityMgr>.singleton.GetEntity(data.Killer), true);
			return true;
		}

		// Token: 0x0600D2D7 RID: 53975 RVA: 0x00315AA0 File Offset: 0x00313CA0
		public void OnAttributeChangedNotify(ChangedAttribute changedAttribute)
		{
			for (int i = 0; i < changedAttribute.AttrID.Count; i++)
			{
				bool flag = changedAttribute.AttrID[i] == 14;
				if (flag)
				{
					bool flag2 = changedAttribute.showHUD && (changedAttribute.CasterID == XSingleton<XAttributeMgr>.singleton.XPlayerData.RoleID || this._entity is XPlayer);
					if (flag2)
					{
						double attr = this._entity.Attributes.GetAttr(XAttributeDefine.XAttr_CurrentHP_Basic);
						this._entity.Attributes.SetAttrFromServer(changedAttribute.AttrID[i], changedAttribute.AttrValue[i]);
						ProjectDamageResult data = XDataPool<ProjectDamageResult>.GetData();
						data.Accept = true;
						data.ElementType = DamageElement.DE_NONE;
						data.Value = attr - this._entity.Attributes.GetAttr(XAttributeDefine.XAttr_CurrentHP_Basic);
						data.Caster = changedAttribute.CasterID;
						XHUDAddEventArgs @event = XEventPool<XHUDAddEventArgs>.GetEvent();
						@event.damageResult = data;
						@event.Firer = this._entity;
						XSingleton<XEventMgr>.singleton.FireEvent(@event);
						data.Recycle();
					}
					else
					{
						this._entity.Attributes.SetAttrFromServer(changedAttribute.AttrID[i], changedAttribute.AttrValue[i]);
					}
				}
				else
				{
					this._entity.Attributes.SetAttrFromServer(changedAttribute.AttrID[i], changedAttribute.AttrValue[i]);
				}
			}
		}

		// Token: 0x0600D2D8 RID: 53976 RVA: 0x00315C34 File Offset: 0x00313E34
		public void OnIdle()
		{
			this.KillIdle();
			bool flag = this._entity.Machine.Current == XStateDefine.XState_Idle;
			if (!flag)
			{
				bool isPassive = this._entity.IsPassive;
				if (isPassive)
				{
					this.Idled(null);
				}
				else
				{
					float interval = (this._entity.Nav != null && this._entity.Nav.IsOnNav) ? 0.5f : 0.1f;
					this._idle_timer_token = XSingleton<XTimerMgr>.singleton.SetTimer(interval, this._IdledCb, null);
				}
			}
		}

		// Token: 0x0600D2D9 RID: 53977 RVA: 0x00315CC3 File Offset: 0x00313EC3
		public void KillIdle()
		{
			XSingleton<XTimerMgr>.singleton.KillTimer(this._idle_timer_token);
			this._idle_timer_token = 0U;
		}

		// Token: 0x0600D2DA RID: 53978 RVA: 0x00315CDE File Offset: 0x00313EDE
		private void Idled(object o)
		{
			this._entity.Machine.ForceToDefaultState(true);
		}

		// Token: 0x0600D2DB RID: 53979 RVA: 0x00315CF3 File Offset: 0x00313EF3
		public void CorrectMoveSpeed(float speed)
		{
			this._move_anim_speed_target = speed;
		}

		// Token: 0x0600D2DC RID: 53980 RVA: 0x00315CFD File Offset: 0x00313EFD
		public void SetHallSequence()
		{
			this._sync_sequence = 2U;
		}

		// Token: 0x0600D2DD RID: 53981 RVA: 0x00315D08 File Offset: 0x00313F08
		public void CorrectNet(Vector3 pos, Vector3 face, uint sequence, bool updatesequence = true)
		{
			bool flag = sequence == 0U;
			if (flag)
			{
				this._entity.CorrectMe(pos, face, false, false);
			}
			bool syncMode = XSingleton<XGame>.singleton.SyncMode;
			if (syncMode)
			{
				this._pos_target = pos;
				this._face_target = face;
			}
			this._last_req_skill = 0U;
			if (updatesequence)
			{
				this._sync_sequence = sequence;
			}
		}

		// Token: 0x0600D2DE RID: 53982 RVA: 0x00315D64 File Offset: 0x00313F64
		public void CorrectNet(Vector3 pos)
		{
			bool syncMode = XSingleton<XGame>.singleton.SyncMode;
			if (syncMode)
			{
				this._pos_target = pos;
			}
		}

		// Token: 0x0600D2DF RID: 53983 RVA: 0x00315D89 File Offset: 0x00313F89
		public void ReportRotateAction(Vector3 dir)
		{
			this.ReportRotateAction(dir, this._entity.Attributes.RotateSpeed, 0L);
		}

		// Token: 0x0600D2E0 RID: 53984 RVA: 0x00315DA8 File Offset: 0x00313FA8
		public void ReportRotateAction(Vector3 dir, float palstance, long token = 0L)
		{
			XRotationEventArgs @event = XEventPool<XRotationEventArgs>.GetEvent();
			@event.TargetDir = dir;
			@event.Firer = this._entity;
			@event.Palstance = palstance;
			@event.Token = token;
			XSingleton<XEventMgr>.singleton.FireEvent(@event);
		}

		// Token: 0x0600D2E1 RID: 53985 RVA: 0x00315DEC File Offset: 0x00313FEC
		public void ReportNavAction(Vector3 dir, bool inertia, float speedratio = 1f)
		{
			bool flag = dir.sqrMagnitude > 0f;
			if (flag)
			{
				this.ReportMoveAction(dir, this._entity.Attributes.RunSpeed * speedratio, inertia);
			}
			else
			{
				this.ReportMoveAction(this._entity.MoveObj.Position, 0f, true, false, false, 0f);
			}
		}

		// Token: 0x0600D2E2 RID: 53986 RVA: 0x00315E50 File Offset: 0x00314050
		public void ReportMoveAction(Vector3 des, float speed, bool inertia = false, bool nav = false, bool force2server = false, float stopage_dir = 0f)
		{
			bool flag = !nav && this._entity.Nav != null;
			if (flag)
			{
				this._entity.Nav.Interrupt();
			}
			bool syncMode = XSingleton<XGame>.singleton.SyncMode;
			if (syncMode)
			{
				XSingleton<XActionSender>.singleton.SendMoveAction(this._entity, des, speed, inertia, force2server);
			}
			XMoveEventArgs @event = XEventPool<XMoveEventArgs>.GetEvent();
			@event.Speed = ((speed == 0f) ? this._entity.Attributes.RunSpeed : speed);
			@event.Destination = des;
			@event.Inertia = inertia;
			@event.Firer = this._entity;
			@event.StopTowards = stopage_dir;
			XSingleton<XEventMgr>.singleton.FireEvent(@event);
		}

		// Token: 0x0600D2E3 RID: 53987 RVA: 0x00315F04 File Offset: 0x00314104
		public void ReportMoveAction(Vector3 dir, double stopage_dir = 0.0)
		{
			bool flag = dir.sqrMagnitude > 0f;
			if (flag)
			{
				this.ReportMoveAction(dir, this._entity.Attributes.RunSpeed, true);
			}
			else
			{
				this.ReportMoveAction(this._entity.MoveObj.Position, 0f, true, false, false, (float)stopage_dir);
			}
		}

		// Token: 0x0600D2E4 RID: 53988 RVA: 0x00315F60 File Offset: 0x00314160
		private void ReportMoveAction(Vector3 dir, float speed, bool inertia)
		{
			bool syncMode = XSingleton<XGame>.singleton.SyncMode;
			if (syncMode)
			{
				XSingleton<XActionSender>.singleton.SendMoveAction(this._entity, XSingleton<XCommon>.singleton.AngleToFloat(dir), speed, inertia);
			}
			XMoveEventArgs @event = XEventPool<XMoveEventArgs>.GetEvent();
			@event.Speed = speed;
			@event.Destination = this._entity.MoveObj.Position + dir * @event.Speed;
			@event.Inertia = true;
			@event.Firer = this._entity;
			XSingleton<XEventMgr>.singleton.FireEvent(@event);
		}

		// Token: 0x0600D2E5 RID: 53989 RVA: 0x00315FF0 File Offset: 0x003141F0
		public void ReportSkillAction(XEntity target, int slot)
		{
			bool flag = this._locate != null && target == null;
			if (flag)
			{
				target = this._locate.Locate(this._entity.EngineObject.Forward, this._entity.EngineObject.Position, false);
			}
			XSingleton<XActionSender>.singleton.SendSkillAction(this._entity, target, slot);
		}

		// Token: 0x0600D2E6 RID: 53990 RVA: 0x00316054 File Offset: 0x00314254
		public bool ReportSkillAction(XEntity target, uint skillid, int slot = -1)
		{
			bool flag = this._entity.Nav != null;
			if (flag)
			{
				this._entity.Nav.Interrupt();
			}
			bool syncMode = XSingleton<XGame>.singleton.SyncMode;
			bool result;
			if (syncMode)
			{
				this._last_req_skill = skillid;
				bool flag2 = this._locate != null && target == null;
				if (flag2)
				{
					target = this._locate.Locate(this._entity.EngineObject.Forward, this._entity.EngineObject.Position, false);
				}
				XSingleton<XActionSender>.singleton.SendSkillAction(this._entity, target, skillid, slot);
				result = true;
			}
			else
			{
				XSkillCore skill = this._entity.SkillMgr.GetSkill(skillid);
				bool flag3 = skill == null;
				if (flag3)
				{
					XSingleton<XDebug>.singleton.AddErrorLog(skillid.ToString(), " not found when casting.", null, null, null, null);
					result = false;
				}
				else
				{
					XAttackEventArgs @event = XEventPool<XAttackEventArgs>.GetEvent();
					@event.Target = target;
					@event.Identify = skillid;
					@event.Firer = this._entity;
					@event.Slot = slot;
					@event.TimeScale = skill.GetTimeScale();
					result = XSingleton<XEventMgr>.singleton.FireEvent(@event);
				}
			}
			return result;
		}

		// Token: 0x04005FC8 RID: 24520
		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("Net_Component");

		// Token: 0x04005FC9 RID: 24521
		private static List<ulong> _targets = new List<ulong>();

		// Token: 0x04005FCA RID: 24522
		private bool _pause = false;

		// Token: 0x04005FCB RID: 24523
		private bool _force_sync = false;

		// Token: 0x04005FCC RID: 24524
		private uint _sync_sequence = 0U;

		// Token: 0x04005FCD RID: 24525
		private uint _idle_timer_token = 0U;

		// Token: 0x04005FCE RID: 24526
		private uint _last_req_skill = 0U;

		// Token: 0x04005FCF RID: 24527
		private XLocateTargetComponent _locate = null;

		// Token: 0x04005FD0 RID: 24528
		private XMoveComponent _move = null;

		// Token: 0x04005FD1 RID: 24529
		private Vector3 _pos_target = Vector3.zero;

		// Token: 0x04005FD2 RID: 24530
		private Vector3 _magic = Vector3.zero;

		// Token: 0x04005FD3 RID: 24531
		private Vector3 _face_target = Vector3.forward;

		// Token: 0x04005FD4 RID: 24532
		private float _move_anim_speed_target = 0f;

		// Token: 0x04005FD5 RID: 24533
		private float _move_anim_speed = 0f;

		// Token: 0x04005FD6 RID: 24534
		private XTimerMgr.ElapsedEventHandler _IdledCb = null;
	}
}
