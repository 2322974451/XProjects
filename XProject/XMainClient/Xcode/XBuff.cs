using System;
using System.Collections.Generic;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XBuff
	{

		public int ID
		{
			get
			{
				return this._buffInfo.BuffID;
			}
		}

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

		public int Level
		{
			get
			{
				return (int)this._buffInfo.BuffLevel;
			}
		}

		public string BuffIcon
		{
			get
			{
				return this._buffInfo.BuffIcon;
			}
		}

		public double HP
		{
			get
			{
				return this._HP;
			}
		}

		public double MaxHP
		{
			get
			{
				return this._MaxHP;
			}
		}

		public uint StackCount
		{
			get
			{
				return this._StackCount;
			}
		}

		public XBuffMergeType MergeType
		{
			get
			{
				return (XBuffMergeType)this._buffInfo.BuffMergeType;
			}
		}

		public int TargetType
		{
			get
			{
				return (int)this._buffInfo.TargetType;
			}
		}

		public BuffTable.RowData BuffInfo
		{
			get
			{
				return this._buffInfo;
			}
		}

		public float Duration
		{
			get
			{
				return this._TimeDuration;
			}
		}

		public float OriginalDuration
		{
			get
			{
				return this._OriginalDuration;
			}
		}

		public float ActualDuration
		{
			get
			{
				return Time.time - this._StartTime;
			}
		}

		public bool Valid
		{
			get
			{
				return this._valid;
			}
		}

		public byte ClearType
		{
			get
			{
				return this._buffInfo.BuffClearType;
			}
		}

		public XBuffEffectData EffectData
		{
			get
			{
				return this._EffectData;
			}
		}

		public uint SkillID
		{
			get
			{
				return this._SkillID;
			}
		}

		public XBuffComponent BuffComponent
		{
			get
			{
				return this._component;
			}
		}

		public UIBuffInfo UIBuff
		{
			get
			{
				return this._UIBuff;
			}
		}

		public HashSet<uint> RelevantSkills
		{
			get
			{
				return this._RelevantSkills;
			}
		}

		public XBuffExclusive ExclusiveData
		{
			get
			{
				return this._Exclusive;
			}
		}

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

		public void AddEffect(BuffEffect eff)
		{
			bool flag = eff == null;
			if (!flag)
			{
				this._buffEffects.Add(eff);
			}
		}

		public double ModifySkillCost()
		{
			return this._buffModifies.ModifySkillCost();
		}

		public double ModifySkillDamage()
		{
			return this._buffModifies.ModifySkillDamage();
		}

		public double IncReceivedDamage()
		{
			return this._buffModifies.IncReceivedDamage();
		}

		public double DecReceivedDamage()
		{
			return this._buffModifies.DecReceivedDamage();
		}

		public double ChangeSkillDamage(uint skillID)
		{
			return this._buffModifies.ChangeSkillDamage(skillID);
		}

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

		private void OnBuffTimeEnd(object args)
		{
			this._TimerToken = 0U;
			XBuffComponent xbuffComponent = args as XBuffComponent;
			XBuffRemoveEventArgs @event = XEventPool<XBuffRemoveEventArgs>.GetEvent();
			@event.xBuffID = this.ID;
			@event.Firer = xbuffComponent.Entity;
			XSingleton<XEventMgr>.singleton.FireEvent(@event);
		}

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

		public static void OnHurt(BuffEffect effect, HurtInfo rawInput, ProjectDamageResult result)
		{
			effect.OnBuffEffect(rawInput, result);
		}

		public static void OnCastDamage(BuffEffect effect, HurtInfo rawInput, ProjectDamageResult result)
		{
			effect.OnCastDamage(rawInput, result);
		}

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

		public static readonly int InfinityTime = -1;

		protected float _StartTime = 0f;

		protected float _TimeDuration = 0f;

		protected float _OriginalDuration = 0f;

		protected uint _TimerToken = 0U;

		protected BuffTable.RowData _buffInfo = null;

		protected List<BuffEffect> _buffEffects = ListPool<BuffEffect>.Get();

		protected XBuffModifyEffect _buffModifies = default(XBuffModifyEffect);

		protected HashSet<uint> _RelevantSkills = null;

		protected bool _valid = true;

		protected ulong _casterID = 0UL;

		protected XBuffEffectData _EffectData = new XBuffEffectData();

		protected double _HP = 100.0;

		protected double _MaxHP = 100.0;

		protected uint _StackCount = 1U;

		protected XBuffComponent _component = null;

		protected UIBuffInfo _UIBuff;

		protected uint _SkillID;

		private XTimerMgr.ElapsedEventHandler _timeCb = null;

		protected XBuffExclusive _Exclusive;

		public static XBuffEffectPrioriy EffectEnumeratorPriorityCur = XBuffEffectPrioriy.BEP_START;

		public static XBuffEffectPrioriy EffectEnumeratorPriorityNext = XBuffEffectPrioriy.BEP_END;

		private int m_EffectEnumeratorIndex;

		public delegate void BuffEffectDelegate(BuffEffect effect, HurtInfo rawInput, ProjectDamageResult result);
	}
}
