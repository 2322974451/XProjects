using System;
using System.Collections.Generic;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000DB1 RID: 3505
	internal class XBuff
	{
		// Token: 0x1700333D RID: 13117
		// (get) Token: 0x0600BDEC RID: 48620 RVA: 0x00277D14 File Offset: 0x00275F14
		public int ID
		{
			get
			{
				return this._buffInfo.BuffID;
			}
		}

		// Token: 0x1700333E RID: 13118
		// (get) Token: 0x0600BDED RID: 48621 RVA: 0x00277D34 File Offset: 0x00275F34
		// (set) Token: 0x0600BDEE RID: 48622 RVA: 0x00277D4C File Offset: 0x00275F4C
		public ulong CasterID
		{
			get
			{
				return this._casterID;
			}
			set
			{
				this._casterID = value;
			}
		}

		// Token: 0x1700333F RID: 13119
		// (get) Token: 0x0600BDEF RID: 48623 RVA: 0x00277D58 File Offset: 0x00275F58
		public int Level
		{
			get
			{
				return (int)this._buffInfo.BuffLevel;
			}
		}

		// Token: 0x17003340 RID: 13120
		// (get) Token: 0x0600BDF0 RID: 48624 RVA: 0x00277D78 File Offset: 0x00275F78
		public string BuffIcon
		{
			get
			{
				return this._buffInfo.BuffIcon;
			}
		}

		// Token: 0x17003341 RID: 13121
		// (get) Token: 0x0600BDF1 RID: 48625 RVA: 0x00277D98 File Offset: 0x00275F98
		public double HP
		{
			get
			{
				return this._HP;
			}
		}

		// Token: 0x17003342 RID: 13122
		// (get) Token: 0x0600BDF2 RID: 48626 RVA: 0x00277DB0 File Offset: 0x00275FB0
		public double MaxHP
		{
			get
			{
				return this._MaxHP;
			}
		}

		// Token: 0x17003343 RID: 13123
		// (get) Token: 0x0600BDF3 RID: 48627 RVA: 0x00277DC8 File Offset: 0x00275FC8
		public uint StackCount
		{
			get
			{
				return this._StackCount;
			}
		}

		// Token: 0x17003344 RID: 13124
		// (get) Token: 0x0600BDF4 RID: 48628 RVA: 0x00277DE0 File Offset: 0x00275FE0
		public XBuffMergeType MergeType
		{
			get
			{
				return (XBuffMergeType)this._buffInfo.BuffMergeType;
			}
		}

		// Token: 0x17003345 RID: 13125
		// (get) Token: 0x0600BDF5 RID: 48629 RVA: 0x00277E00 File Offset: 0x00276000
		public int TargetType
		{
			get
			{
				return (int)this._buffInfo.TargetType;
			}
		}

		// Token: 0x17003346 RID: 13126
		// (get) Token: 0x0600BDF6 RID: 48630 RVA: 0x00277E20 File Offset: 0x00276020
		public BuffTable.RowData BuffInfo
		{
			get
			{
				return this._buffInfo;
			}
		}

		// Token: 0x17003347 RID: 13127
		// (get) Token: 0x0600BDF7 RID: 48631 RVA: 0x00277E38 File Offset: 0x00276038
		public float Duration
		{
			get
			{
				return this._TimeDuration;
			}
		}

		// Token: 0x17003348 RID: 13128
		// (get) Token: 0x0600BDF8 RID: 48632 RVA: 0x00277E50 File Offset: 0x00276050
		public float OriginalDuration
		{
			get
			{
				return this._OriginalDuration;
			}
		}

		// Token: 0x17003349 RID: 13129
		// (get) Token: 0x0600BDF9 RID: 48633 RVA: 0x00277E68 File Offset: 0x00276068
		public float ActualDuration
		{
			get
			{
				return Time.time - this._StartTime;
			}
		}

		// Token: 0x1700334A RID: 13130
		// (get) Token: 0x0600BDFA RID: 48634 RVA: 0x00277E88 File Offset: 0x00276088
		public bool Valid
		{
			get
			{
				return this._valid;
			}
		}

		// Token: 0x1700334B RID: 13131
		// (get) Token: 0x0600BDFB RID: 48635 RVA: 0x00277EA0 File Offset: 0x002760A0
		public byte ClearType
		{
			get
			{
				return this._buffInfo.BuffClearType;
			}
		}

		// Token: 0x1700334C RID: 13132
		// (get) Token: 0x0600BDFC RID: 48636 RVA: 0x00277EC0 File Offset: 0x002760C0
		public XBuffEffectData EffectData
		{
			get
			{
				return this._EffectData;
			}
		}

		// Token: 0x1700334D RID: 13133
		// (get) Token: 0x0600BDFD RID: 48637 RVA: 0x00277ED8 File Offset: 0x002760D8
		public uint SkillID
		{
			get
			{
				return this._SkillID;
			}
		}

		// Token: 0x1700334E RID: 13134
		// (get) Token: 0x0600BDFE RID: 48638 RVA: 0x00277EF0 File Offset: 0x002760F0
		public XBuffComponent BuffComponent
		{
			get
			{
				return this._component;
			}
		}

		// Token: 0x1700334F RID: 13135
		// (get) Token: 0x0600BDFF RID: 48639 RVA: 0x00277F08 File Offset: 0x00276108
		public UIBuffInfo UIBuff
		{
			get
			{
				return this._UIBuff;
			}
		}

		// Token: 0x17003350 RID: 13136
		// (get) Token: 0x0600BE00 RID: 48640 RVA: 0x00277F20 File Offset: 0x00276120
		public HashSet<uint> RelevantSkills
		{
			get
			{
				return this._RelevantSkills;
			}
		}

		// Token: 0x17003351 RID: 13137
		// (get) Token: 0x0600BE01 RID: 48641 RVA: 0x00277F38 File Offset: 0x00276138
		public XBuffExclusive ExclusiveData
		{
			get
			{
				return this._Exclusive;
			}
		}

		// Token: 0x0600BE02 RID: 48642 RVA: 0x00277F50 File Offset: 0x00276150
		public XBuff(CombatEffectHelper pEffectHelper, ref BuffDesc desc)
		{
			this._buffInfo = pEffectHelper.BuffInfo;
			bool flag = desc.EffectTime <= 0f;
			if (flag)
			{
				this._OriginalDuration = this._buffInfo.BuffDuration;
			}
			else
			{
				this._OriginalDuration = desc.EffectTime;
			}
			this._OriginalDuration += pEffectHelper.GetBuffDuration();
			this._TimeDuration = this._OriginalDuration;
			this._SkillID = desc.SkillID;
			this._timeCb = new XTimerMgr.ElapsedEventHandler(this.OnBuffTimeEnd);
			this._StartTime = Time.time;
			this._UIBuff = UIBuffInfo.Create(this);
			bool flag2 = this._buffInfo.RelevantSkills != null && this._buffInfo.RelevantSkills.Length != 0;
			if (flag2)
			{
				this._RelevantSkills = HashPool<uint>.Get();
				for (int i = 0; i < this._buffInfo.RelevantSkills.Length; i++)
				{
					this._RelevantSkills.Add(XSingleton<XCommon>.singleton.XHash(this._buffInfo.RelevantSkills[i]));
				}
			}
			this._Exclusive.Set(this._buffInfo);
		}

		// Token: 0x0600BE03 RID: 48643 RVA: 0x00278118 File Offset: 0x00276318
		protected void _CreateEffects(CombatEffectHelper pEffectHelper, bool bIncludeTrigger = true)
		{
			XBuffChangeAttribute.TryCreate(pEffectHelper, this);
			XBuffSpecialState.TryCreate(this._buffInfo, this);
			XBuffRegenerate.TryCreate(pEffectHelper, this);
			XBuffLifeAddAttack.TryCreate(this._buffInfo, this);
			XBuffDamageDistanceScale.TryCreate(this._buffInfo, this);
			XBuffAuraCheck.TryCreate(this._buffInfo, this);
			XBuffReduceDamage.TryCreate(this._buffInfo, this);
			XBuffDamageReflection.TryCreate(this._buffInfo, this);
			XBuffMob.TryCreate(this._buffInfo, this);
			XBuffChangeFightGroup.TryCreate(this._buffInfo, this);
			XBuffLifeSteal.TryCreate(this._buffInfo, this);
			XBuffReduceSkillCD.TryCreate(pEffectHelper, this);
			XBuffTargetLifeAddAttack.TryCreate(this._buffInfo, this);
			XBuffManipulate.TryCreate(this._buffInfo, this);
			XBuffSkillsReplace.TryCreate(this._buffInfo, this);
			XBuffKill.TryCreate(this._buffInfo, this);
			this._buffModifies.TryCreate(pEffectHelper, this);
			if (bIncludeTrigger)
			{
				XBuffTrigger.TryCreate(this._buffInfo, this);
			}
		}

		// Token: 0x0600BE04 RID: 48644 RVA: 0x00278208 File Offset: 0x00276408
		public void AddEffect(BuffEffect eff)
		{
			bool flag = eff == null;
			if (!flag)
			{
				this._buffEffects.Add(eff);
			}
		}

		// Token: 0x0600BE05 RID: 48645 RVA: 0x00278230 File Offset: 0x00276430
		public double ModifySkillCost()
		{
			return this._buffModifies.ModifySkillCost();
		}

		// Token: 0x0600BE06 RID: 48646 RVA: 0x00278250 File Offset: 0x00276450
		public double ModifySkillDamage()
		{
			return this._buffModifies.ModifySkillDamage();
		}

		// Token: 0x0600BE07 RID: 48647 RVA: 0x00278270 File Offset: 0x00276470
		public double IncReceivedDamage()
		{
			return this._buffModifies.IncReceivedDamage();
		}

		// Token: 0x0600BE08 RID: 48648 RVA: 0x00278290 File Offset: 0x00276490
		public double DecReceivedDamage()
		{
			return this._buffModifies.DecReceivedDamage();
		}

		// Token: 0x0600BE09 RID: 48649 RVA: 0x002782B0 File Offset: 0x002764B0
		public double ChangeSkillDamage(uint skillID)
		{
			return this._buffModifies.ChangeSkillDamage(skillID);
		}

		// Token: 0x0600BE0A RID: 48650 RVA: 0x002782D0 File Offset: 0x002764D0
		public void OnAttributeChanged(XBuffComponent component, XAttrChangeEventArgs e)
		{
			for (int i = 0; i < this._buffEffects.Count; i++)
			{
				bool flag = !this.Valid;
				if (flag)
				{
					break;
				}
				this._buffEffects[i].OnAttributeChanged(e);
			}
		}

		// Token: 0x0600BE0B RID: 48651 RVA: 0x0027831C File Offset: 0x0027651C
		public void OnQTEStateChanged(XBuffComponent component, XSkillQTEEventArgs e)
		{
			for (int i = 0; i < this._buffEffects.Count; i++)
			{
				bool flag = !this.Valid;
				if (flag)
				{
					break;
				}
				this._buffEffects[i].OnQTEStateChanged(e);
			}
		}

		// Token: 0x0600BE0C RID: 48652 RVA: 0x00278368 File Offset: 0x00276568
		public void OnRealDead(XRealDeadEventArgs e)
		{
			for (int i = 0; i < this._buffEffects.Count; i++)
			{
				bool flag = !this.Valid;
				if (flag)
				{
					break;
				}
				this._buffEffects[i].OnRealDead(e);
			}
		}

		// Token: 0x0600BE0D RID: 48653 RVA: 0x002783B4 File Offset: 0x002765B4
		public void OnComboChange(uint comboCount)
		{
			for (int i = 0; i < this._buffEffects.Count; i++)
			{
				bool flag = !this.Valid;
				if (flag)
				{
					break;
				}
				this._buffEffects[i].OnComboChange(comboCount);
			}
		}

		// Token: 0x0600BE0E RID: 48654 RVA: 0x00278400 File Offset: 0x00276600
		private void _AppendHP(float param0, float param1)
		{
			bool flag = param1 != 0f;
			if (flag)
			{
				int num = (int)param0;
				bool flag2 = num == 0;
				if (flag2)
				{
					this._MaxHP += (double)param1;
				}
				else
				{
					XEntity entity = XSingleton<XEntityMgr>.singleton.GetEntity(this.CasterID);
					bool flag3 = entity != null && !entity.Deprecated;
					if (flag3)
					{
						this._MaxHP += entity.Attributes.GetAttr((XAttributeDefine)num) * (double)param1 / 100.0;
					}
				}
			}
		}

		// Token: 0x0600BE0F RID: 48655 RVA: 0x00278490 File Offset: 0x00276690
		protected void _InitHP(CombatEffectHelper pEffectHelper)
		{
			bool flag = this._component == null;
			if (!flag)
			{
				this._MaxHP = 0.0;
				this._AppendHP(this._buffInfo.BuffHP[0], this._buffInfo.BuffHP[1]);
				bool flag2 = pEffectHelper.bHasEffect(CombatEffectType.CET_Buff_HP);
				if (flag2)
				{
					SequenceList<float> sequenceList = CommonObjectPool<SequenceList<float>>.Get();
					pEffectHelper.GetBuffHP(sequenceList);
					for (int i = 0; i < sequenceList.Count; i++)
					{
						this._AppendHP(sequenceList[i, 0], sequenceList[i, 1]);
					}
					CommonObjectPool<SequenceList<float>>.Release(sequenceList);
				}
				bool flag3 = this._MaxHP == 0.0;
				if (flag3)
				{
					this._MaxHP = 100.0;
				}
				this._HP = this._MaxHP;
			}
		}

		// Token: 0x0600BE10 RID: 48656 RVA: 0x0027856C File Offset: 0x0027676C
		public void OnAdd(XBuffComponent component, CombatEffectHelper pEffectHelper)
		{
			bool flag = XSingleton<XCommon>.singleton.IsGreater(this._TimeDuration, 0f);
			if (flag)
			{
				this._TimerToken = XSingleton<XTimerMgr>.singleton.SetTimer(this._TimeDuration, this._timeCb, component);
			}
			this._component = component;
			this._InitHP(pEffectHelper);
			this._CreateEffects(pEffectHelper, true);
			this._buffEffects.Sort();
			for (int i = 0; i < this._buffEffects.Count; i++)
			{
				this._buffEffects[i].bValid = true;
				this._buffEffects[i].OnAdd(component.Entity, pEffectHelper);
			}
			this._UIBuff.Set(this);
		}

		// Token: 0x0600BE11 RID: 48657 RVA: 0x0027862C File Offset: 0x0027682C
		public bool Append(XBuffComponent component, CombatEffectHelper pEffectHelper)
		{
			bool flag = this._TimerToken > 0U;
			if (flag)
			{
				XSingleton<XTimerMgr>.singleton.KillTimer(this._TimerToken);
			}
			bool flag2 = XSingleton<XCommon>.singleton.IsGreater(this._TimeDuration, 0f);
			if (flag2)
			{
				this._TimerToken = XSingleton<XTimerMgr>.singleton.SetTimer(this._TimeDuration, this._timeCb, component);
			}
			this._HP = this._MaxHP;
			bool flag3 = (uint)this._buffInfo.StackMaxCount <= this._StackCount;
			bool result;
			if (flag3)
			{
				this._UIBuff.Set(this);
				result = false;
			}
			else
			{
				int count = this._buffEffects.Count;
				this._CreateEffects(pEffectHelper, false);
				for (int i = count; i < this._buffEffects.Count; i++)
				{
					this._buffEffects[i].bValid = true;
					this._buffEffects[i].OnAdd(component.Entity, pEffectHelper);
				}
				this._buffEffects.Sort();
				this._StackCount += 1U;
				this._UIBuff.Set(this);
				result = true;
			}
			return result;
		}

		// Token: 0x0600BE12 RID: 48658 RVA: 0x00278764 File Offset: 0x00276964
		public void OnAppend(XBuffComponent component)
		{
			for (int i = 0; i < this._buffEffects.Count; i++)
			{
				bool flag = !this.Valid;
				if (flag)
				{
					break;
				}
				this._buffEffects[i].OnAppend(component.Entity);
			}
		}

		// Token: 0x0600BE13 RID: 48659 RVA: 0x002787B8 File Offset: 0x002769B8
		public float GetLeftTime()
		{
			bool flag = this._TimerToken == 0U;
			float result;
			if (flag)
			{
				result = -1f;
			}
			else
			{
				float num = (float)XSingleton<XTimerMgr>.singleton.TimeLeft(this._TimerToken);
				bool flag2 = num == 0f;
				if (flag2)
				{
					result = -1f;
				}
				else
				{
					result = num;
				}
			}
			return result;
		}

		// Token: 0x0600BE14 RID: 48660 RVA: 0x00278808 File Offset: 0x00276A08
		public void OnRemove(XBuffComponent component, bool IsReplaced)
		{
			bool valid = this._valid;
			if (valid)
			{
				this._valid = false;
				bool flag = this._TimerToken > 0U;
				if (flag)
				{
					XSingleton<XTimerMgr>.singleton.KillTimer(this._TimerToken);
					this._TimerToken = 0U;
				}
				for (int i = 0; i < this._buffEffects.Count; i++)
				{
					this._buffEffects[i].bValid = false;
					this._buffEffects[i].OnRemove(component.Entity, IsReplaced);
				}
				this._buffModifies.OnRemove(this);
			}
			this._component = null;
			this.Destroy();
		}

		// Token: 0x0600BE15 RID: 48661 RVA: 0x002788B8 File Offset: 0x00276AB8
		public void OnBattleEnd(XBuffComponent component)
		{
			bool valid = this._valid;
			if (valid)
			{
				for (int i = 0; i < this._buffEffects.Count; i++)
				{
					this._buffEffects[i].OnBattleEnd(component.Entity);
				}
				this._buffModifies.OnBattleEnd(this);
			}
		}

		// Token: 0x0600BE16 RID: 48662 RVA: 0x00278914 File Offset: 0x00276B14
		private void OnBuffTimeEnd(object args)
		{
			this._TimerToken = 0U;
			XBuffComponent xbuffComponent = args as XBuffComponent;
			XBuffRemoveEventArgs @event = XEventPool<XBuffRemoveEventArgs>.GetEvent();
			@event.xBuffID = this.ID;
			@event.Firer = xbuffComponent.Entity;
			XSingleton<XEventMgr>.singleton.FireEvent(@event);
		}

		// Token: 0x0600BE17 RID: 48663 RVA: 0x0027895C File Offset: 0x00276B5C
		public void Destroy()
		{
			bool flag = this._RelevantSkills != null;
			if (flag)
			{
				HashPool<uint>.Release(this._RelevantSkills);
				this._RelevantSkills = null;
			}
			ListPool<BuffEffect>.Release(this._buffEffects);
			this._buffModifies.Destroy();
			this._Exclusive.Destroy();
		}

		// Token: 0x0600BE18 RID: 48664 RVA: 0x002789B0 File Offset: 0x00276BB0
		public void OnBuffEffect(HurtInfo rawInput, ProjectDamageResult result, XBuff.BuffEffectDelegate func)
		{
			int count = this._buffEffects.Count;
			bool flag = XBuff.EffectEnumeratorPriorityCur == XBuffEffectPrioriy.BEP_START;
			if (flag)
			{
				this.m_EffectEnumeratorIndex = 0;
			}
			while (this.m_EffectEnumeratorIndex < this._buffEffects.Count)
			{
				BuffEffect buffEffect = this._buffEffects[this.m_EffectEnumeratorIndex];
				XBuffEffectPrioriy priority = buffEffect.Priority;
				bool flag2 = priority > XBuff.EffectEnumeratorPriorityCur;
				if (flag2)
				{
					bool flag3 = priority < XBuff.EffectEnumeratorPriorityNext;
					if (flag3)
					{
						XBuff.EffectEnumeratorPriorityNext = priority;
					}
					break;
				}
				func(buffEffect, rawInput, result);
				this.m_EffectEnumeratorIndex++;
			}
		}

		// Token: 0x0600BE19 RID: 48665 RVA: 0x00278A54 File Offset: 0x00276C54
		public static void OnHurt(BuffEffect effect, HurtInfo rawInput, ProjectDamageResult result)
		{
			effect.OnBuffEffect(rawInput, result);
		}

		// Token: 0x0600BE1A RID: 48666 RVA: 0x00278A60 File Offset: 0x00276C60
		public static void OnCastDamage(BuffEffect effect, HurtInfo rawInput, ProjectDamageResult result)
		{
			effect.OnCastDamage(rawInput, result);
		}

		// Token: 0x0600BE1B RID: 48667 RVA: 0x00278A6C File Offset: 0x00276C6C
		public void OnCastSkill(HurtInfo rawInput)
		{
			for (int i = 0; i < this._buffEffects.Count; i++)
			{
				bool flag = !this.Valid;
				if (flag)
				{
					break;
				}
				this._buffEffects[i].OnCastSkill(rawInput);
			}
		}

		// Token: 0x0600BE1C RID: 48668 RVA: 0x00278ABC File Offset: 0x00276CBC
		public bool ResetTime(XBuffComponent component)
		{
			bool flag = this._TimerToken == 0U;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				XSingleton<XTimerMgr>.singleton.KillTimer(this._TimerToken);
				bool flag2 = XSingleton<XCommon>.singleton.IsGreater(this._TimeDuration, 0f);
				if (flag2)
				{
					this._TimerToken = XSingleton<XTimerMgr>.singleton.SetTimer(this._TimeDuration, this._timeCb, component);
				}
				this._UIBuff.Set(this);
				result = true;
			}
			return result;
		}

		// Token: 0x0600BE1D RID: 48669 RVA: 0x00278B38 File Offset: 0x00276D38
		public void AddBuffTime(float extendTime, XBuffComponent component)
		{
			bool flag = this._TimerToken == 0U;
			if (!flag)
			{
				float num = (float)XSingleton<XTimerMgr>.singleton.TimeLeft(this._TimerToken);
				this._TimeDuration = num + extendTime;
				XSingleton<XTimerMgr>.singleton.KillTimer(this._TimerToken);
				bool flag2 = XSingleton<XCommon>.singleton.IsGreater(this._TimeDuration, 0f);
				if (flag2)
				{
					this._TimerToken = XSingleton<XTimerMgr>.singleton.SetTimer(this._TimeDuration, this._timeCb, component);
				}
				this._UIBuff.Set(this);
			}
		}

		// Token: 0x0600BE1E RID: 48670 RVA: 0x00278BC8 File Offset: 0x00276DC8
		public void Update()
		{
			for (int i = 0; i < this._buffEffects.Count; i++)
			{
				bool flag = !this.Valid;
				if (flag)
				{
					break;
				}
				this._buffEffects[i].OnUpdate();
			}
		}

		// Token: 0x0600BE1F RID: 48671 RVA: 0x00278C14 File Offset: 0x00276E14
		public double ChangeBuffHP(double deltaHP)
		{
			this._HP += deltaHP;
			bool flag = this.Valid && this._component != null;
			if (flag)
			{
				bool flag2 = this._HP <= 0.0;
				if (flag2)
				{
					deltaHP -= this._HP;
					XBuffRemoveEventArgs @event = XEventPool<XBuffRemoveEventArgs>.GetEvent();
					@event.xBuffID = this.ID;
					@event.Firer = this._component.Entity;
					XSingleton<XEventMgr>.singleton.FireEvent(@event);
				}
				this._UIBuff.HP = this._HP;
			}
			return deltaHP;
		}

		// Token: 0x0600BE20 RID: 48672 RVA: 0x00278CB4 File Offset: 0x00276EB4
		public static bool HasTag(BuffTable.RowData data, XBuffTag tag)
		{
			bool flag = data == null || data.Tags == null;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				for (int i = 0; i < data.Tags.Length; i++)
				{
					bool flag2 = (XBuffTag)data.Tags[i] == tag;
					if (flag2)
					{
						return true;
					}
				}
				result = false;
			}
			return result;
		}

		// Token: 0x04004D86 RID: 19846
		public static readonly int InfinityTime = -1;

		// Token: 0x04004D87 RID: 19847
		protected float _StartTime = 0f;

		// Token: 0x04004D88 RID: 19848
		protected float _TimeDuration = 0f;

		// Token: 0x04004D89 RID: 19849
		protected float _OriginalDuration = 0f;

		// Token: 0x04004D8A RID: 19850
		protected uint _TimerToken = 0U;

		// Token: 0x04004D8B RID: 19851
		protected BuffTable.RowData _buffInfo = null;

		// Token: 0x04004D8C RID: 19852
		protected List<BuffEffect> _buffEffects = ListPool<BuffEffect>.Get();

		// Token: 0x04004D8D RID: 19853
		protected XBuffModifyEffect _buffModifies = default(XBuffModifyEffect);

		// Token: 0x04004D8E RID: 19854
		protected HashSet<uint> _RelevantSkills = null;

		// Token: 0x04004D8F RID: 19855
		protected bool _valid = true;

		// Token: 0x04004D90 RID: 19856
		protected ulong _casterID = 0UL;

		// Token: 0x04004D91 RID: 19857
		protected XBuffEffectData _EffectData = new XBuffEffectData();

		// Token: 0x04004D92 RID: 19858
		protected double _HP = 100.0;

		// Token: 0x04004D93 RID: 19859
		protected double _MaxHP = 100.0;

		// Token: 0x04004D94 RID: 19860
		protected uint _StackCount = 1U;

		// Token: 0x04004D95 RID: 19861
		protected XBuffComponent _component = null;

		// Token: 0x04004D96 RID: 19862
		protected UIBuffInfo _UIBuff;

		// Token: 0x04004D97 RID: 19863
		protected uint _SkillID;

		// Token: 0x04004D98 RID: 19864
		private XTimerMgr.ElapsedEventHandler _timeCb = null;

		// Token: 0x04004D99 RID: 19865
		protected XBuffExclusive _Exclusive;

		// Token: 0x04004D9A RID: 19866
		public static XBuffEffectPrioriy EffectEnumeratorPriorityCur = XBuffEffectPrioriy.BEP_START;

		// Token: 0x04004D9B RID: 19867
		public static XBuffEffectPrioriy EffectEnumeratorPriorityNext = XBuffEffectPrioriy.BEP_END;

		// Token: 0x04004D9C RID: 19868
		private int m_EffectEnumeratorIndex;

		// Token: 0x020019BD RID: 6589
		// (Invoke) Token: 0x0601106B RID: 69739
		public delegate void BuffEffectDelegate(BuffEffect effect, HurtInfo rawInput, ProjectDamageResult result);
	}
}
