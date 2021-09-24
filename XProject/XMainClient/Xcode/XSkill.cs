using System;
using System.Collections.Generic;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{

	internal abstract class XSkill
	{

		public XSkill()
		{
			this._TimerCallback = new XTimerMgr.ElapsedIDEventHandler(this.ProcessTimer);
		}

		public virtual void Initialize(XEntity firer)
		{
			this._firer = firer;
			this._skillmgr = this._firer.SkillMgr;
			this._logical_token.debugName = "XSkill._logical_token";
			this._present_token.debugName = "XSkill._present_token";
			XSingleton<BufferPoolMgr>.singleton.GetSmallBuffer(ref this._logical_token, 16, 0);
			XSingleton<BufferPoolMgr>.singleton.GetSmallBuffer(ref this._present_token, 16, 0);
		}

		public virtual void Uninitialize()
		{
			this._firer = null;
			this._target = null;
			this._skillmgr = null;
			bool flag = this._logical_token.Count != 0 || this._present_token.Count != 0;
			if (flag)
			{
				XSingleton<XDebug>.singleton.AddErrorLog("skill token not null", null, null, null, null, null);
			}
			XSingleton<BufferPoolMgr>.singleton.ReturnSmallBuffer(ref this._logical_token);
			XSingleton<BufferPoolMgr>.singleton.ReturnSmallBuffer(ref this._present_token);
		}

		public virtual int SkillType
		{
			get
			{
				return -1;
			}
		}

		public long Token
		{
			get
			{
				return this._token;
			}
		}

		public bool AnimInit { get; set; }

		public bool DemonstrationMode
		{
			get
			{
				return this._demonstration;
			}
		}

		public float MultipleDirectionFactorByServer
		{
			get
			{
				return this._multiple_direction_factor;
			}
			set
			{
				this._multiple_direction_factor = value;
			}
		}

		public Vector3 SkillTowardsTo
		{
			get
			{
				return this._skill_forward;
			}
			set
			{
				this._skill_forward = value;
			}
		}

		public XSkillCore Core
		{
			get
			{
				return this._core;
			}
		}

		public virtual XSkillCore MainCore
		{
			get
			{
				return this._core;
			}
		}

		public virtual void TriggerAnim()
		{
			bool flag = this._firer.Ator != null;
			if (flag)
			{
				string triggerToken = this.Core.TriggerToken;
				bool multipleAttackSupported = this.MainCore.Soul.MultipleAttackSupported;
				if (multipleAttackSupported)
				{
					bool flag2 = triggerToken != this._last_anim_token;
					if (flag2)
					{
						this._firer.Ator.SetTrigger(triggerToken);
					}
					this._firer.Ator.SetFloat("MultipleDirFactor", XSingleton<XGame>.singleton.SyncMode ? this._multiple_direction_factor : this.MainCore.GetMultipleDirectionFactor());
					this._last_anim_token = triggerToken;
				}
				else
				{
					this._firer.Ator.SetTrigger(triggerToken);
					this._last_anim_token = null;
				}
			}
		}

		public abstract string AnimClipName { get; }

		public XEntity Firer
		{
			get
			{
				return this._firer;
			}
		}

		public XEntity Target
		{
			get
			{
				return this.HasValidTarget() ? this._target : null;
			}
		}

		public int SlotPos
		{
			get
			{
				return this._slot_pos;
			}
		}

		public bool Casting
		{
			get
			{
				return this._casting;
			}
		}

		public float TimeElapsed
		{
			get
			{
				return this._timeElapsed / this._time_scale;
			}
		}

		public float TimeScale
		{
			get
			{
				return 1f / this._time_scale;
			}
		}

		protected virtual bool InnerProcessTimer(object param, int id)
		{
			bool flag = id == 1;
			bool result;
			if (flag)
			{
				this.ExternalExecute(param);
				result = true;
			}
			else
			{
				result = false;
			}
			return result;
		}

		private void ProcessTimer(object param, int id)
		{
			this.InnerProcessTimer(param, id);
		}

		public void UpdateCollisionLayer(float velocity)
		{
			this._firer.SetCollisionLayer((this.MainCore.Soul.IgnoreCollision || (!this._firer.IsRole && this._core.Offset > 1.5f && velocity > this._firer.Attributes.RunSpeed)) ? 14 : this._firer.DefaultLayer);
		}

		protected void CalcForward()
		{
			bool flag = !this.MainCore.Soul.MultipleAttackSupported;
			if (flag)
			{
				this._skill_forward = ((this._firer.Rotate == null) ? this._firer.EngineObject.Forward : this._firer.Rotate.GetMeaningfulFaceVector3());
			}
		}

		protected abstract void Result(XResultData data);

		protected void OnResult(object o)
		{
			bool flag = true;
			bool flag2 = this._result_method != null;
			if (flag2)
			{
				flag = this._result_method(this);
			}
			bool flag3 = flag;
			if (flag3)
			{
				bool flag4 = this._firer.Attributes != null;
				if (flag4)
				{
					this._firer.Attributes.CombatAppendTime();
				}
				this.Result(o as XResultData);
			}
		}

		protected void AddedTimerToken(uint token, bool logical)
		{
			if (logical)
			{
				this._logical_token.Add(token);
			}
			else
			{
				this._present_token.Add(token);
			}
		}

		protected abstract bool Present();

		protected virtual void Start()
		{
			this.Reflection();
		}

		protected virtual bool Launch(XSkillCore core)
		{
			return true;
		}

		protected virtual void Stop(bool cleanUp)
		{
		}

		protected virtual void KillTimerAll()
		{
			for (int i = 0; i < this._present_token.Count; i++)
			{
				uint token = this._present_token[i];
				XSingleton<XTimerMgr>.singleton.KillTimer(token);
			}
			for (int j = 0; j < this._logical_token.Count; j++)
			{
				uint token2 = this._logical_token[j];
				XSingleton<XTimerMgr>.singleton.KillTimer(token2);
			}
			this._present_token.Clear();
			this._logical_token.Clear();
		}

		public virtual uint GetCombinedId()
		{
			return 0U;
		}

		public bool Update(float fDeltaT)
		{
			bool flag = this._casting;
			bool flag2 = this._casting && this._execute;
			if (flag2)
			{
				bool flag3 = !XSingleton<XGame>.singleton.SyncMode;
				if (flag3)
				{
					this.CalcForward();
				}
				this._timeElapsed += fDeltaT;
				flag = this.Present();
				bool flag4 = flag;
				if (flag4)
				{
					bool flag5 = this._update_method != null;
					if (flag5)
					{
						this._update_method(this);
					}
				}
			}
			bool animInit = this.AnimInit;
			if (animInit)
			{
				this.Execute();
			}
			this.AnimInit = false;
			return flag;
		}

		public void Execute()
		{
			bool flag = this._casting && !this._execute;
			if (flag)
			{
				bool flag2 = this._core.ID == this._skillmgr.GetAppearIdentity();
				if (flag2)
				{
					XSingleton<XEntityMgr>.singleton.Puppets(this._firer, false, false);
					bool flag3 = this._firer.Ator != null;
					if (flag3)
					{
						this._firer.Ator.cullingMode = 0;
					}
				}
				this._execute = true;
				this.CalcForward();
				this._core.Execute(this);
				bool flag4 = this._firer.Ator != null;
				if (flag4)
				{
					this._firer.Ator.speed = this.TimeScale;
				}
				this.Start();
				bool flag5 = this._start_method != null;
				if (flag5)
				{
					this._start_method(this);
				}
			}
		}

		public bool Fire(XEntity target, XSkillCore core, XAttackEventArgs args)
		{
			bool flag = !this._casting || !this._execute;
			bool result;
			if (flag)
			{
				this._demonstration = args.Demonstration;
				bool flag2 = core == null || !core.Fire(this);
				if (flag2)
				{
					result = false;
				}
				else
				{
					this._affect_camera = args.AffectCamera;
					this._time_scale = 1f / args.TimeScale;
					this._target = target;
					this._token = ((args.SyncSequence == 0U) ? XSingleton<XCommon>.singleton.UniqueToken : ((long)((ulong)args.SyncSequence)));
					bool flag3 = core.Soul.TypeToken == 3;
					if (flag3)
					{
						bool flag4 = !this.Launch(core);
						if (flag4)
						{
							return false;
						}
					}
					else
					{
						this._core = core;
						this._data = this._core.Soul;
					}
					bool flag5 = this._firer.Attributes != null;
					if (flag5)
					{
						this._firer.Attributes.CombatMarkTimeBaseLine();
					}
					this._timeElapsed = 0f;
					this._slot_pos = args.Slot;
					bool flag6 = !this.MainCore.Soul.Logical.Association || !this.MainCore.Soul.Logical.MoveType;
					if (flag6)
					{
						this._firer.Machine.ForceToDefaultState(false);
					}
					this._casting = true;
					this._execute = false;
					this.AnimInit = false;
					this._last_anim_token = null;
					this._multiple_direction_factor = 1f;
					this.FocusTarget(this.Target);
					bool isPlayer = this._firer.IsPlayer;
					if (isPlayer)
					{
						this.Manual();
					}
					bool flag7 = !this._demonstration;
					if (flag7)
					{
						XSkill.ProcessStart(this._token, this.MainCore.ID, this._firer, this.Target, new SkillExternalCallback(this.ExternalCallback));
						bool flag8 = this.Casting && (this._firer.IsPlayer || this._firer.IsEnemy);
						if (flag8)
						{
							XSecuritySkillInfo xsecuritySkillInfo = XSecuritySkillInfo.TryGetStatistics(this._firer);
							bool flag9 = xsecuritySkillInfo != null;
							if (flag9)
							{
								xsecuritySkillInfo.OnCast(this.MainCore.ID);
							}
						}
					}
					else
					{
						XSkill.ProcessDemonstrationStart(this._token, this.MainCore.ID, this._firer, this.Casting ? this.Target : null, new SkillExternalCallback(this.ExternalCallback));
					}
					result = this.Casting;
				}
			}
			else
			{
				result = false;
			}
			return result;
		}

		public void Puppetize(bool cleanUp = false)
		{
			bool flag = this._core != null;
			if (flag)
			{
				bool flag2 = this._core.ID == this._skillmgr.GetAppearIdentity();
				if (flag2)
				{
					this._firer.Present.OnReadyFight(null);
					bool flag3 = this._firer.Ator != null;
					if (flag3)
					{
						this._firer.Ator.cullingMode = (AnimatorCullingMode)1;
					}
				}
			}
			bool execute = this._execute;
			if (execute)
			{
				this._execute = false;
				this.KillTimerAll();
				this.Stop(cleanUp);
				bool flag4 = this._firer.Ator != null;
				if (flag4)
				{
					this._firer.Ator.speed = 1f;
				}
				bool flag5 = this._update_method != null;
				if (flag5)
				{
					this._update_method(this);
				}
				bool flag6 = this._stop_method != null && this.MainCore.Soul.TypeToken != 3;
				if (flag6)
				{
					this._stop_method(this);
				}
				this._core.Halt();
				bool flag7 = this._target != null;
				if (flag7)
				{
					this._target = null;
				}
			}
		}

		public void Cease(bool cleanUp = false)
		{
			bool casting = this._casting;
			if (casting)
			{
				this._casting = false;
				this.Puppetize(cleanUp);
				XCombinedSkill xcombinedSkill = this as XCombinedSkill;
				bool flag = xcombinedSkill != null;
				if (flag)
				{
					xcombinedSkill.CombinedKillTimerAll();
					xcombinedSkill.CombinedStop(cleanUp);
				}
				bool flag2 = this._firer.Attributes != null && this.MainCore.Soul.Result.Count > 0;
				if (flag2)
				{
					this._firer.Attributes.CombatMarkTimEndLine();
				}
				this.MainCore.Halt();
				bool flag3 = this._firer.Machine.ActionToken == this._token;
				if (flag3)
				{
					bool flag4 = !this.MainCore.Soul.Logical.Association || !this.MainCore.Soul.Logical.MoveType;
					if (flag4)
					{
						this._firer.Machine.ForceToDefaultState(false);
					}
				}
				this._timeElapsed = 0f;
				this._time_scale = 1f;
				this._affect_camera = null;
				bool flag5 = !this._demonstration;
				if (flag5)
				{
					XSkill.ProcessEnd(this._token, this.MainCore.ID, this._firer, this.Target);
				}
			}
			bool flag6 = this._target != null;
			if (flag6)
			{
				this._target = null;
			}
			this._core = null;
			this._start_method = null;
			this._update_method = null;
			this._result_method = null;
			this._stop_method = null;
		}

		public virtual bool CanPerformAction(XStateDefine state, long token)
		{
			bool flag = !this._casting;
			bool result;
			if (flag)
			{
				result = true;
			}
			else
			{
				bool flag2 = token > 0L && this._token == token;
				if (flag2)
				{
					result = true;
				}
				else
				{
					bool flag3 = XStateDefine.XState_Death == state;
					if (flag3)
					{
						this.Cease(false);
						result = true;
					}
					else
					{
						result = (this.MainCore == null || this.MainCore.CanAct(state));
					}
				}
			}
			return result;
		}

		public void FocusTarget(XEntity target)
		{
			bool flag = !XEntity.ValideEntity(target) || XSingleton<XGame>.singleton.SyncMode;
			if (!flag)
			{
				this._firer.Net.ReportRotateAction(XSingleton<XCommon>.singleton.Horizontal(target.RadiusCenter - this._firer.EngineObject.Position), this._firer.Attributes.AutoRotateSpeed, this._token);
			}
		}

		public bool HasValidTarget()
		{
			return this.MainCore != null && this.MainCore.Soul.NeedTarget && XEntity.ValideEntity(this._target);
		}

		public bool ExternalCallback(XSkillExternalArgs args)
		{
			bool flag = this is XCombinedSkill;
			if (flag)
			{
				(this as XCombinedSkill).AddedCombinedTimerToken(XSingleton<XTimerMgr>.singleton.SetTimer<XSkill.ESkillTimerCb>(args.delay, this._TimerCallback, args, XSkill.ESkillTimerCb.EExternalExecute));
			}
			else
			{
				this.AddedTimerToken(XSingleton<XTimerMgr>.singleton.SetTimer<XSkill.ESkillTimerCb>(args.delay, this._TimerCallback, args, XSkill.ESkillTimerCb.EExternalExecute), true);
			}
			return true;
		}

		protected void Manual()
		{
			bool flag = XSingleton<XGame>.singleton.SyncMode || this.MainCore.Soul.MultipleAttackSupported;
			if (!flag)
			{
				bool feeding = XSingleton<XVirtualTab>.singleton.Feeding;
				if (feeding)
				{
					this._firer.Net.ReportRotateAction(XSingleton<XVirtualTab>.singleton.Direction, this._firer.Attributes.AutoRotateSpeed, 0L);
				}
				else
				{
					bool flag2 = this.MainCore.ID == this._skillmgr.GetDashIdentity();
					if (flag2)
					{
						this._firer.Net.ReportRotateAction(-this._firer.Rotate.GetMeaningfulFaceVector3(), this._firer.Attributes.AutoRotateSpeed, 0L);
					}
				}
			}
		}

		private void Reflection()
		{
			this._start_method = null;
			this._update_method = null;
			this._result_method = null;
			this._stop_method = null;
			bool flag = this._data != null && this._data.Script != null;
			if (flag)
			{
				bool flag2 = !string.IsNullOrEmpty(this._data.Script.Start_Name);
				if (flag2)
				{
					XSingleton<ScriptCode>.singleton.GetSkillDo(this._data.Name + this._data.Script.Start_Name, out this._start_method);
				}
				bool flag3 = !string.IsNullOrEmpty(this._data.Script.Update_Name);
				if (flag3)
				{
					XSingleton<ScriptCode>.singleton.GetSkillDo(this._data.Name + this._data.Script.Update_Name, out this._update_method);
				}
				bool flag4 = !string.IsNullOrEmpty(this._data.Script.Result_Name);
				if (flag4)
				{
					XSingleton<ScriptCode>.singleton.GetSkillDo(this._data.Name + this._data.Script.Result_Name, out this._result_method);
				}
				bool flag5 = !string.IsNullOrEmpty(this._data.Script.Stop_Name);
				if (flag5)
				{
					XSingleton<ScriptCode>.singleton.GetSkillDo(this._data.Name + this._data.Script.Stop_Name, out this._stop_method);
				}
			}
		}

		private void ExternalExecute(object o)
		{
			XSkillExternalArgs xskillExternalArgs = o as XSkillExternalArgs;
			xskillExternalArgs.callback(xskillExternalArgs);
		}

		public static void SkillResult(long token, XEntity firer, XSkillCore core, XBullet bullet, int triggerTime, uint resultID, int resultTime, Vector3 hitdir, XEntity target)
		{
			bool flag = (bullet == null) ? core.IsHurtEntity(target.ID, triggerTime) : bullet.IsHurtEntity(target.ID);
			if (!flag)
			{
				bool isShowUp = target.Present.IsShowUp;
				if (!isShowUp)
				{
					XStrickenResponse xstrickenResponse = target.Skill.IsCasting() ? target.Skill.CurrentSkill.MainCore.Soul.Logical.StrickenMask : XStrickenResponse.Cease;
					bool flag2 = xstrickenResponse == XStrickenResponse.Cease || core.CarrierID == XSkill.XUltraSkillHash || (xstrickenResponse == XStrickenResponse.Half_Endure && target.Skill.IsOverResults());
					if (flag2)
					{
						xstrickenResponse = XStrickenResponse.Cease;
					}
					bool flag3 = xstrickenResponse == XStrickenResponse.Invincible;
					if (!flag3)
					{
						bool flag4 = !core.Soul.Logical.AttackOnHitDown && target.Machine.Current == XStateDefine.XState_BeHit && target.BeHit.LaidOnGround();
						if (!flag4)
						{
							ProjectDamageResult dResult = XSkill.ProcessHurt(token, resultID, firer, target, resultTime);
							bool flag5 = triggerTime >= core.Soul.Hit.Count;
							if (flag5)
							{
								XSingleton<XDebug>.singleton.AddErrorLog("skill ", core.Soul.Name, "'s hit point is not matched with results.", null, null, null);
							}
							else
							{
								XSkill.SkillResult_TakeEffect(firer, target, dResult, core.Soul.Hit[triggerTime], hitdir, xstrickenResponse, target.StandOn, (float)(1.0 + (firer.Attributes.ParalyzeAttribute - target.Attributes.ParalyzeDefenseAttribute)), Vector3.zero);
								bool flag6 = bullet == null;
								if (flag6)
								{
									core.AddHurtTarget(target.ID, triggerTime);
								}
								else
								{
									bullet.OnResult(target);
								}
							}
						}
					}
				}
			}
		}

		public static void SkillResult(XBullet bullet, Vector3 forward, Vector3 position, bool bulletcycle)
		{
			bool syncMode = XSingleton<XGame>.singleton.SyncMode;
			if (!syncMode)
			{
				XBulletCore bulletCore = bullet.BulletCore;
				List<XEntity> opponent = XSingleton<XEntityMgr>.singleton.GetOpponent(bulletCore.Firer);
				for (int i = 0; i < opponent.Count; i++)
				{
					XEntity xentity = opponent[i];
					bool flag = !XEntity.ValideEntity(xentity) || (bulletCore.SkillCore.Soul.Result[bulletCore.Sequnce].Attack_Only_Target && xentity != bulletCore.Target);
					if (!flag)
					{
						bool flag2 = bulletCore.SkillCore.IsInAttckField(bulletCore.Sequnce, position, forward, xentity);
						if (flag2)
						{
							Vector3 hitdir = (bulletCore.SkillCore.Soul.Result[bulletCore.Sequnce].Affect_Direction == XResultAffectDirection.AttackDir) ? (xentity.EngineObject.Position - position) : bulletCore.Firer.Rotate.GetMeaningfulFaceVector3();
							hitdir.y = 0f;
							hitdir.Normalize();
							bool syncMode2 = XSingleton<XGame>.singleton.SyncMode;
							if (!syncMode2)
							{
								XSkill.SkillResult(bulletCore.Token, bulletCore.Firer, bulletCore.SkillCore, bulletcycle ? bullet : null, bulletCore.Sequnce, bulletCore.ResultID, bulletCore.ResultTime, hitdir, xentity);
							}
						}
					}
				}
			}
		}

		public static void SkillResult(long token, XEntity firer, XSkillCore core, int triggerTime, uint resultID, int resultTime, Vector3 forward, Vector3 position)
		{
			bool syncMode = XSingleton<XGame>.singleton.SyncMode;
			if (!syncMode)
			{
				List<XEntity> opponent = XSingleton<XEntityMgr>.singleton.GetOpponent(firer);
				for (int i = 0; i < opponent.Count; i++)
				{
					XEntity xentity = opponent[i];
					bool flag = !XEntity.ValideEntity(xentity) || (core.Soul.Result[triggerTime].Attack_Only_Target && xentity != core.Carrier.Target);
					if (!flag)
					{
						bool flag2 = core.IsInAttckField(triggerTime, position, forward, xentity);
						if (flag2)
						{
							Vector3 hitdir = (core.Soul.Result[triggerTime].Affect_Direction == XResultAffectDirection.AttackDir) ? (xentity.EngineObject.Position - position) : firer.Rotate.GetMeaningfulFaceVector3();
							hitdir.y = 0f;
							hitdir.Normalize();
							bool syncMode2 = XSingleton<XGame>.singleton.SyncMode;
							if (!syncMode2)
							{
								XSkill.SkillResult(token, firer, core, null, triggerTime, resultID, resultTime, hitdir, xentity);
							}
						}
					}
				}
			}
		}

		public static void SkillResult_TakeEffect(XEntity firer, XEntity target, ProjectDamageResult dResult, XHitData data, Vector3 hurtDiretion, XStrickenResponse rps, bool standOn, float paralyzeFactor, Vector3 error)
		{
			bool accept = dResult.Accept;
			if (accept)
			{
				bool flag = firer != null;
				if (flag)
				{
					bool isPlayer = firer.IsPlayer;
					if (isPlayer)
					{
						bool syncMode = XSingleton<XGame>.singleton.SyncMode;
						if (syncMode)
						{
							XSingleton<XLevelStatistics>.singleton.OnHitEnemy(dResult.ComboCount);
						}
						else
						{
							XSingleton<XLevelStatistics>.singleton.OnHitEnemy(-1);
						}
					}
					else
					{
						XSingleton<XLevelStatistics>.singleton.OnEnemyHitEnemy(firer);
					}
				}
				bool isPlayer2 = target.IsPlayer;
				if (isPlayer2)
				{
					XSingleton<XLevelStatistics>.singleton.OnPlayerBeHit();
				}
				bool flag2 = rps == XStrickenResponse.Half_Endure || rps == XStrickenResponse.Full_Endure;
				if (flag2)
				{
					XEndureEventArgs @event = XEventPool<XEndureEventArgs>.GetEvent();
					@event.Firer = target;
					@event.Fx = ((data.State == XBeHitState.Hit_Freezed) ? null : data.Fx);
					@event.Dir = hurtDiretion;
					@event.HitFrom = firer;
					XSingleton<XEventMgr>.singleton.FireEvent(@event);
					XHitEventArgs event2 = XEventPool<XHitEventArgs>.GetEvent();
					event2.Firer = target;
					XSingleton<XEventMgr>.singleton.FireEvent(event2);
				}
				else
				{
					bool flag3 = !dResult.IsTargetDead;
					if (flag3)
					{
						switch (dResult.Result)
						{
						case ProjectResultType.PJRES_BATI:
						{
							XEndureEventArgs event3 = XEventPool<XEndureEventArgs>.GetEvent();
							event3.Firer = target;
							event3.Fx = ((data.State == XBeHitState.Hit_Freezed) ? null : data.Fx);
							event3.Dir = hurtDiretion;
							event3.HitFrom = firer;
							XSingleton<XEventMgr>.singleton.FireEvent(event3);
							XRenderComponent.OnHit(target);
							break;
						}
						case ProjectResultType.PJRES_STUN:
						{
							bool flag4 = !XSingleton<XGame>.singleton.SyncMode;
							if (flag4)
							{
								XFreezeEventArgs event4 = XEventPool<XFreezeEventArgs>.GetEvent();
								event4.HitData = null;
								event4.Dir = hurtDiretion;
								event4.Duration = XSingleton<XGlobalConfig>.singleton.StunTime;
								event4.Firer = target;
								XSingleton<XEventMgr>.singleton.FireEvent(event4);
							}
							break;
						}
						case ProjectResultType.PJRES_BEHIT:
						{
							bool flag5 = !XSingleton<XGame>.singleton.SyncMode;
							if (flag5)
							{
								bool flag6 = rps == XStrickenResponse.Cease;
								if (flag6)
								{
									target.Skill.EndSkill(true, false);
								}
								bool flag7 = data.State != XBeHitState.Hit_Free;
								if (flag7)
								{
									bool flag8 = data.State == XBeHitState.Hit_Freezed;
									if (flag8)
									{
										XFreezeEventArgs event5 = XEventPool<XFreezeEventArgs>.GetEvent();
										event5.HitData = data;
										event5.Dir = hurtDiretion;
										event5.Firer = target;
										XSingleton<XEventMgr>.singleton.FireEvent(event5);
									}
									else
									{
										bool flag9 = target.CurState == XStateDefine.XState_Freeze;
										if (flag9)
										{
											XEndureEventArgs event6 = XEventPool<XEndureEventArgs>.GetEvent();
											event6.Firer = target;
											event6.Fx = data.Fx;
											event6.Dir = hurtDiretion;
											event6.HitFrom = firer;
											XSingleton<XEventMgr>.singleton.FireEvent(event6);
										}
										else
										{
											XBeHitEventArgs event7 = XEventPool<XBeHitEventArgs>.GetEvent();
											event7.DepracatedPass = true;
											event7.HitDirection = hurtDiretion;
											event7.HitData = data;
											event7.Firer = target;
											event7.HitFrom = firer;
											event7.Paralyze = paralyzeFactor;
											event7.ForceToFlyHit = ((data.State == XBeHitState.Hit_Back || data.State == XBeHitState.Hit_Roll) && !standOn);
											XSingleton<XEventMgr>.singleton.FireEvent(event7);
										}
									}
								}
							}
							break;
						}
						}
					}
				}
				bool flag10 = dResult.Value != 0.0 || dResult.Result == ProjectResultType.PJRES_IMMORTAL || dResult.Result == ProjectResultType.PJRES_MISS || dResult.AbsorbDamage != 0.0;
				if (flag10)
				{
					XHUDAddEventArgs event8 = XEventPool<XHUDAddEventArgs>.GetEvent();
					event8.DepracatedPass = true;
					event8.damageResult = dResult;
					event8.caster = firer;
					event8.Firer = target;
					XSingleton<XEventMgr>.singleton.FireEvent(event8);
				}
				XProjectDamageEventArgs event9 = XEventPool<XProjectDamageEventArgs>.GetEvent();
				event9.Damage = dResult;
				event9.Receiver = target;
				event9.Firer = XSingleton<XGame>.singleton.Doc;
				XSingleton<XEventMgr>.singleton.FireEvent(event9);
			}
			dResult.Recycle();
		}

		public static void ProcessDemonstrationStart(long token, uint skillId, XEntity firer, XEntity target, SkillExternalCallback callback)
		{
			HurtInfo data = XDataPool<HurtInfo>.GetData();
			data.Caster = firer;
			data.Target = target;
			data.SkillID = skillId;
			data.SkillToken = token;
			data.Callback = callback;
			XSingleton<XCombat>.singleton.ProjectDemonstrationStart(data);
			data.Recycle();
		}

		public static void ProcessStart(long token, uint skillId, XEntity firer, XEntity target, SkillExternalCallback callback)
		{
			bool syncMode = XSingleton<XGame>.singleton.SyncMode;
			if (!syncMode)
			{
				HurtInfo data = XDataPool<HurtInfo>.GetData();
				data.Caster = firer;
				data.Target = target;
				data.SkillID = skillId;
				data.SkillToken = token;
				data.Callback = callback;
				XSingleton<XCombat>.singleton.ProjectStart(data);
				data.Recycle();
			}
		}

		public static ProjectDamageResult ProcessHurt(long token, uint skillId, XEntity firer, XEntity target, int hitCount)
		{
			bool syncMode = XSingleton<XGame>.singleton.SyncMode;
			ProjectDamageResult result;
			if (syncMode)
			{
				result = null;
			}
			else
			{
				HurtInfo data = XDataPool<HurtInfo>.GetData();
				data.Caster = firer;
				data.Target = target;
				data.HitPoint = hitCount;
				data.SkillID = skillId;
				data.SkillToken = token;
				ProjectDamageResult projectDamageResult = XSingleton<XCombat>.singleton.ProjectDamage(data);
				data.Recycle();
				result = projectDamageResult;
			}
			return result;
		}

		public static void ProcessEnd(long token, uint skillId, XEntity firer, XEntity target)
		{
			bool syncMode = XSingleton<XGame>.singleton.SyncMode;
			if (!syncMode)
			{
				HurtInfo data = XDataPool<HurtInfo>.GetData();
				data.Caster = firer;
				data.Target = target;
				data.SkillID = skillId;
				data.SkillToken = token;
				XSingleton<XCombat>.singleton.ProjectEnd(data);
				data.Recycle();
			}
		}

		public static readonly int XJAComboSkillHash = 0;

		public static readonly int XArtsSkillHash = 1;

		public static readonly int XUltraSkillHash = 2;

		public static readonly int XCombinedSkillHash = 3;

		private string _last_anim_token = null;

		private bool _casting = false;

		private bool _execute = false;

		protected float _time_scale = 1f;

		protected float _multiple_direction_factor = 1f;

		protected bool _demonstration = false;

		protected XCameraEx _affect_camera = null;

		protected SmallBuffer<uint> _logical_token;

		protected SmallBuffer<uint> _present_token;

		protected SkillDo _start_method = null;

		protected SkillDo _update_method = null;

		protected SkillDo _result_method = null;

		protected SkillDo _stop_method = null;

		protected XEntity _target = null;

		protected XEntity _firer = null;

		protected XSkillMgr _skillmgr = null;

		protected long _token = 0L;

		protected int _slot_pos = -1;

		protected float _timeElapsed = 0f;

		protected XSkillCore _core = null;

		protected XSkillData _data = null;

		private Vector3 _skill_forward = Vector3.forward;

		protected XTimerMgr.ElapsedIDEventHandler _TimerCallback = null;

		protected enum ESkillTimerCb
		{

			EExternalExecute = 1,

			ESkillNum
		}
	}
}
