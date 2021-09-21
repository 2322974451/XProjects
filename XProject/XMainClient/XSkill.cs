using System;
using System.Collections.Generic;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000EE3 RID: 3811
	internal abstract class XSkill
	{
		// Token: 0x0600CA08 RID: 51720 RVA: 0x002DB28C File Offset: 0x002D948C
		public XSkill()
		{
			this._TimerCallback = new XTimerMgr.ElapsedIDEventHandler(this.ProcessTimer);
		}

		// Token: 0x0600CA09 RID: 51721 RVA: 0x002DB358 File Offset: 0x002D9558
		public virtual void Initialize(XEntity firer)
		{
			this._firer = firer;
			this._skillmgr = this._firer.SkillMgr;
			this._logical_token.debugName = "XSkill._logical_token";
			this._present_token.debugName = "XSkill._present_token";
			XSingleton<BufferPoolMgr>.singleton.GetSmallBuffer(ref this._logical_token, 16, 0);
			XSingleton<BufferPoolMgr>.singleton.GetSmallBuffer(ref this._present_token, 16, 0);
		}

		// Token: 0x0600CA0A RID: 51722 RVA: 0x002DB3C8 File Offset: 0x002D95C8
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

		// Token: 0x1700353A RID: 13626
		// (get) Token: 0x0600CA0B RID: 51723 RVA: 0x002DB448 File Offset: 0x002D9648
		public virtual int SkillType
		{
			get
			{
				return -1;
			}
		}

		// Token: 0x1700353B RID: 13627
		// (get) Token: 0x0600CA0C RID: 51724 RVA: 0x002DB45C File Offset: 0x002D965C
		public long Token
		{
			get
			{
				return this._token;
			}
		}

		// Token: 0x1700353C RID: 13628
		// (get) Token: 0x0600CA0D RID: 51725 RVA: 0x002DB474 File Offset: 0x002D9674
		// (set) Token: 0x0600CA0E RID: 51726 RVA: 0x002DB47C File Offset: 0x002D967C
		public bool AnimInit { get; set; }

		// Token: 0x1700353D RID: 13629
		// (get) Token: 0x0600CA0F RID: 51727 RVA: 0x002DB488 File Offset: 0x002D9688
		public bool DemonstrationMode
		{
			get
			{
				return this._demonstration;
			}
		}

		// Token: 0x1700353E RID: 13630
		// (get) Token: 0x0600CA10 RID: 51728 RVA: 0x002DB4A0 File Offset: 0x002D96A0
		// (set) Token: 0x0600CA11 RID: 51729 RVA: 0x002DB4B8 File Offset: 0x002D96B8
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

		// Token: 0x1700353F RID: 13631
		// (get) Token: 0x0600CA12 RID: 51730 RVA: 0x002DB4C4 File Offset: 0x002D96C4
		// (set) Token: 0x0600CA13 RID: 51731 RVA: 0x002DB4DC File Offset: 0x002D96DC
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

		// Token: 0x17003540 RID: 13632
		// (get) Token: 0x0600CA14 RID: 51732 RVA: 0x002DB4E8 File Offset: 0x002D96E8
		public XSkillCore Core
		{
			get
			{
				return this._core;
			}
		}

		// Token: 0x17003541 RID: 13633
		// (get) Token: 0x0600CA15 RID: 51733 RVA: 0x002DB500 File Offset: 0x002D9700
		public virtual XSkillCore MainCore
		{
			get
			{
				return this._core;
			}
		}

		// Token: 0x0600CA16 RID: 51734 RVA: 0x002DB518 File Offset: 0x002D9718
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

		// Token: 0x17003542 RID: 13634
		// (get) Token: 0x0600CA17 RID: 51735
		public abstract string AnimClipName { get; }

		// Token: 0x17003543 RID: 13635
		// (get) Token: 0x0600CA18 RID: 51736 RVA: 0x002DB5DC File Offset: 0x002D97DC
		public XEntity Firer
		{
			get
			{
				return this._firer;
			}
		}

		// Token: 0x17003544 RID: 13636
		// (get) Token: 0x0600CA19 RID: 51737 RVA: 0x002DB5F4 File Offset: 0x002D97F4
		public XEntity Target
		{
			get
			{
				return this.HasValidTarget() ? this._target : null;
			}
		}

		// Token: 0x17003545 RID: 13637
		// (get) Token: 0x0600CA1A RID: 51738 RVA: 0x002DB618 File Offset: 0x002D9818
		public int SlotPos
		{
			get
			{
				return this._slot_pos;
			}
		}

		// Token: 0x17003546 RID: 13638
		// (get) Token: 0x0600CA1B RID: 51739 RVA: 0x002DB630 File Offset: 0x002D9830
		public bool Casting
		{
			get
			{
				return this._casting;
			}
		}

		// Token: 0x17003547 RID: 13639
		// (get) Token: 0x0600CA1C RID: 51740 RVA: 0x002DB648 File Offset: 0x002D9848
		public float TimeElapsed
		{
			get
			{
				return this._timeElapsed / this._time_scale;
			}
		}

		// Token: 0x17003548 RID: 13640
		// (get) Token: 0x0600CA1D RID: 51741 RVA: 0x002DB668 File Offset: 0x002D9868
		public float TimeScale
		{
			get
			{
				return 1f / this._time_scale;
			}
		}

		// Token: 0x0600CA1E RID: 51742 RVA: 0x002DB688 File Offset: 0x002D9888
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

		// Token: 0x0600CA1F RID: 51743 RVA: 0x002DB6B0 File Offset: 0x002D98B0
		private void ProcessTimer(object param, int id)
		{
			this.InnerProcessTimer(param, id);
		}

		// Token: 0x0600CA20 RID: 51744 RVA: 0x002DB6BC File Offset: 0x002D98BC
		public void UpdateCollisionLayer(float velocity)
		{
			this._firer.SetCollisionLayer((this.MainCore.Soul.IgnoreCollision || (!this._firer.IsRole && this._core.Offset > 1.5f && velocity > this._firer.Attributes.RunSpeed)) ? 14 : this._firer.DefaultLayer);
		}

		// Token: 0x0600CA21 RID: 51745 RVA: 0x002DB72C File Offset: 0x002D992C
		protected void CalcForward()
		{
			bool flag = !this.MainCore.Soul.MultipleAttackSupported;
			if (flag)
			{
				this._skill_forward = ((this._firer.Rotate == null) ? this._firer.EngineObject.Forward : this._firer.Rotate.GetMeaningfulFaceVector3());
			}
		}

		// Token: 0x0600CA22 RID: 51746
		protected abstract void Result(XResultData data);

		// Token: 0x0600CA23 RID: 51747 RVA: 0x002DB788 File Offset: 0x002D9988
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

		// Token: 0x0600CA24 RID: 51748 RVA: 0x002DB7EC File Offset: 0x002D99EC
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

		// Token: 0x0600CA25 RID: 51749
		protected abstract bool Present();

		// Token: 0x0600CA26 RID: 51750 RVA: 0x002DB81B File Offset: 0x002D9A1B
		protected virtual void Start()
		{
			this.Reflection();
		}

		// Token: 0x0600CA27 RID: 51751 RVA: 0x002DB828 File Offset: 0x002D9A28
		protected virtual bool Launch(XSkillCore core)
		{
			return true;
		}

		// Token: 0x0600CA28 RID: 51752 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		protected virtual void Stop(bool cleanUp)
		{
		}

		// Token: 0x0600CA29 RID: 51753 RVA: 0x002DB83C File Offset: 0x002D9A3C
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

		// Token: 0x0600CA2A RID: 51754 RVA: 0x002DB8D0 File Offset: 0x002D9AD0
		public virtual uint GetCombinedId()
		{
			return 0U;
		}

		// Token: 0x0600CA2B RID: 51755 RVA: 0x002DB8E4 File Offset: 0x002D9AE4
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

		// Token: 0x0600CA2C RID: 51756 RVA: 0x002DB984 File Offset: 0x002D9B84
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

		// Token: 0x0600CA2D RID: 51757 RVA: 0x002DBA6C File Offset: 0x002D9C6C
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

		// Token: 0x0600CA2E RID: 51758 RVA: 0x002DBD04 File Offset: 0x002D9F04
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

		// Token: 0x0600CA2F RID: 51759 RVA: 0x002DBE38 File Offset: 0x002DA038
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

		// Token: 0x0600CA30 RID: 51760 RVA: 0x002DBFC0 File Offset: 0x002DA1C0
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

		// Token: 0x0600CA31 RID: 51761 RVA: 0x002DC028 File Offset: 0x002DA228
		public void FocusTarget(XEntity target)
		{
			bool flag = !XEntity.ValideEntity(target) || XSingleton<XGame>.singleton.SyncMode;
			if (!flag)
			{
				this._firer.Net.ReportRotateAction(XSingleton<XCommon>.singleton.Horizontal(target.RadiusCenter - this._firer.EngineObject.Position), this._firer.Attributes.AutoRotateSpeed, this._token);
			}
		}

		// Token: 0x0600CA32 RID: 51762 RVA: 0x002DC0A0 File Offset: 0x002DA2A0
		public bool HasValidTarget()
		{
			return this.MainCore != null && this.MainCore.Soul.NeedTarget && XEntity.ValideEntity(this._target);
		}

		// Token: 0x0600CA33 RID: 51763 RVA: 0x002DC0DC File Offset: 0x002DA2DC
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

		// Token: 0x0600CA34 RID: 51764 RVA: 0x002DC144 File Offset: 0x002DA344
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

		// Token: 0x0600CA35 RID: 51765 RVA: 0x002DC214 File Offset: 0x002DA414
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

		// Token: 0x0600CA36 RID: 51766 RVA: 0x002DC3A0 File Offset: 0x002DA5A0
		private void ExternalExecute(object o)
		{
			XSkillExternalArgs xskillExternalArgs = o as XSkillExternalArgs;
			xskillExternalArgs.callback(xskillExternalArgs);
		}

		// Token: 0x0600CA37 RID: 51767 RVA: 0x002DC3C4 File Offset: 0x002DA5C4
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

		// Token: 0x0600CA38 RID: 51768 RVA: 0x002DC584 File Offset: 0x002DA784
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

		// Token: 0x0600CA39 RID: 51769 RVA: 0x002DC704 File Offset: 0x002DA904
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

		// Token: 0x0600CA3A RID: 51770 RVA: 0x002DC824 File Offset: 0x002DAA24
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

		// Token: 0x0600CA3B RID: 51771 RVA: 0x002DCC28 File Offset: 0x002DAE28
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

		// Token: 0x0600CA3C RID: 51772 RVA: 0x002DCC78 File Offset: 0x002DAE78
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

		// Token: 0x0600CA3D RID: 51773 RVA: 0x002DCCD8 File Offset: 0x002DAED8
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

		// Token: 0x0600CA3E RID: 51774 RVA: 0x002DCD40 File Offset: 0x002DAF40
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

		// Token: 0x04005950 RID: 22864
		public static readonly int XJAComboSkillHash = 0;

		// Token: 0x04005951 RID: 22865
		public static readonly int XArtsSkillHash = 1;

		// Token: 0x04005952 RID: 22866
		public static readonly int XUltraSkillHash = 2;

		// Token: 0x04005953 RID: 22867
		public static readonly int XCombinedSkillHash = 3;

		// Token: 0x04005954 RID: 22868
		private string _last_anim_token = null;

		// Token: 0x04005955 RID: 22869
		private bool _casting = false;

		// Token: 0x04005956 RID: 22870
		private bool _execute = false;

		// Token: 0x04005957 RID: 22871
		protected float _time_scale = 1f;

		// Token: 0x04005958 RID: 22872
		protected float _multiple_direction_factor = 1f;

		// Token: 0x04005959 RID: 22873
		protected bool _demonstration = false;

		// Token: 0x0400595A RID: 22874
		protected XCameraEx _affect_camera = null;

		// Token: 0x0400595B RID: 22875
		protected SmallBuffer<uint> _logical_token;

		// Token: 0x0400595C RID: 22876
		protected SmallBuffer<uint> _present_token;

		// Token: 0x0400595D RID: 22877
		protected SkillDo _start_method = null;

		// Token: 0x0400595E RID: 22878
		protected SkillDo _update_method = null;

		// Token: 0x0400595F RID: 22879
		protected SkillDo _result_method = null;

		// Token: 0x04005960 RID: 22880
		protected SkillDo _stop_method = null;

		// Token: 0x04005961 RID: 22881
		protected XEntity _target = null;

		// Token: 0x04005962 RID: 22882
		protected XEntity _firer = null;

		// Token: 0x04005963 RID: 22883
		protected XSkillMgr _skillmgr = null;

		// Token: 0x04005964 RID: 22884
		protected long _token = 0L;

		// Token: 0x04005965 RID: 22885
		protected int _slot_pos = -1;

		// Token: 0x04005966 RID: 22886
		protected float _timeElapsed = 0f;

		// Token: 0x04005967 RID: 22887
		protected XSkillCore _core = null;

		// Token: 0x04005968 RID: 22888
		protected XSkillData _data = null;

		// Token: 0x04005969 RID: 22889
		private Vector3 _skill_forward = Vector3.forward;

		// Token: 0x0400596A RID: 22890
		protected XTimerMgr.ElapsedIDEventHandler _TimerCallback = null;

		// Token: 0x020019E5 RID: 6629
		protected enum ESkillTimerCb
		{
			// Token: 0x0400808A RID: 32906
			EExternalExecute = 1,
			// Token: 0x0400808B RID: 32907
			ESkillNum
		}
	}
}
