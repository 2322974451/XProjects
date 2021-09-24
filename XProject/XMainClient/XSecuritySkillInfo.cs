using System;
using System.Collections.Generic;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XSecuritySkillInfo
	{

		private XSecuritySkillInfo.SkillInfo _TryGetSkillInfo(uint skillID)
		{
			XSecuritySkillInfo.SkillInfo data;
			bool flag = !this._SkillInfos.TryGetValue(skillID, out data);
			if (flag)
			{
				data = XDataPool<XSecuritySkillInfo.SkillInfo>.GetData();
				data._SkillID = skillID;
				this._SkillInfos.Add(skillID, data);
				this._SkillInfoList.Add(data);
			}
			return data;
		}

		public void OnCastDamage(uint skillID, double value)
		{
			bool flag = value >= 0.0;
			if (flag)
			{
				bool flag2 = skillID > 0U;
				if (flag2)
				{
					XSecuritySkillInfo.SkillInfo skillInfo = this._TryGetSkillInfo(skillID);
					skillInfo.OnCastDamage(value);
				}
			}
		}

		public void OnCastDamage(HurtInfo rawInput, ProjectDamageResult result)
		{
			bool flag = result.Value >= 0.0;
			if (flag)
			{
				bool flag2 = rawInput.SkillID > 0U;
				if (flag2)
				{
					XSecuritySkillInfo.SkillInfo skillInfo = this._TryGetSkillInfo(rawInput.SkillID);
					skillInfo.OnCastDamage(rawInput, result);
				}
			}
		}

		public void OnCast(uint skillID)
		{
			this.OnCast(skillID, 1);
		}

		public void OnCast(uint skillID, int count)
		{
			XSecuritySkillInfo.SkillInfo skillInfo = this._TryGetSkillInfo(skillID);
			skillInfo.OnCast(count);
		}

		public void Reset()
		{
			for (int i = 0; i < this._SkillInfoList.Count; i++)
			{
				this._SkillInfoList[i].Recycle();
			}
			this._SkillInfoList.Clear();
			this._SkillInfos.Clear();
			this._NormalAttackInfo.Reset();
			bool flag = this._QTEAttackInfo != null;
			if (flag)
			{
				this._QTEAttackInfo.Reset();
			}
		}

		public void Merge(XSecuritySkillInfo other)
		{
			this._NormalAttackInfo.Merge(other._NormalAttackInfo);
			bool flag = this._QTEAttackInfo != null;
			if (flag)
			{
				this._QTEAttackInfo.Merge(other._QTEAttackInfo);
			}
			for (int i = 0; i < other._SkillInfoList.Count; i++)
			{
				XSecuritySkillInfo.SkillInfo skillInfo = this._TryGetSkillInfo(other._SkillInfoList[i]._SkillID);
				skillInfo.Merge(other._SkillInfoList[i]);
			}
		}

		public void OnAttach(XEntity entity)
		{
			bool flag = entity == null;
			if (!flag)
			{
				bool isPlayer = entity.IsPlayer;
				if (isPlayer)
				{
					bool flag2 = this._QTEAttackInfo == null;
					if (flag2)
					{
						this._QTEAttackInfo = new XSecuritySkillInfo.SkillInfo();
						this._QTEAttackInfo.Reset();
					}
				}
			}
		}

		public void OnEnd(XEntity entity)
		{
			this.EndTo(entity, this, true);
		}

		public void EndTo(XEntity entity, XSecuritySkillInfo other, bool bProcessQTE)
		{
			bool flag = entity != null && entity.SkillMgr != null;
			if (flag)
			{
				XSkillMgr skillMgr = entity.SkillMgr;
				foreach (XSecuritySkillInfo.SkillInfo skillInfo in this._SkillInfos.Values)
				{
					bool flag2 = skillMgr.IsPhysicalAttack(skillInfo._SkillID);
					if (flag2)
					{
						other._NormalAttackInfo.Merge(skillInfo);
					}
					else if (bProcessQTE)
					{
						bool flag3 = this._QTEAttackInfo != null && skillMgr.IsQTESkill(skillInfo._SkillID);
						if (flag3)
						{
							other._QTEAttackInfo.Merge(skillInfo);
						}
					}
					else
					{
						XSecuritySkillInfo.SkillInfo skillInfo2 = other._TryGetSkillInfo(skillInfo._SkillID);
						skillInfo2.Merge(skillInfo);
					}
				}
			}
		}

		public List<XSecuritySkillInfo.SkillInfo> SkillInfoList
		{
			get
			{
				return this._SkillInfoList;
			}
		}

		public XSecuritySkillInfo.SkillInfo GetSkillInfoByID(uint skillID)
		{
			XSecuritySkillInfo.SkillInfo result;
			this._SkillInfos.TryGetValue(skillID, out result);
			return result;
		}

		public XSecuritySkillInfo.SkillInfo NormalAttackInfo
		{
			get
			{
				return this._NormalAttackInfo;
			}
		}

		public static XSecuritySkillInfo TryGetStatistics(XEntity entity)
		{
			XSecurityStatistics xsecurityStatistics = XSecurityStatistics.TryGetStatistics(entity);
			bool flag = xsecurityStatistics == null;
			XSecuritySkillInfo result;
			if (flag)
			{
				result = null;
			}
			else
			{
				result = xsecurityStatistics.SkillStatistics;
			}
			return result;
		}

		public static void SendPlayerData(XEntity entity, XSecuritySkillInfo skillInfos)
		{
			bool flag = skillInfos._NormalAttackInfo != null;
			if (flag)
			{
				XStaticSecurityStatistics.Append("PlayerATKMax", skillInfos._NormalAttackInfo._AttackMax);
				XStaticSecurityStatistics.Append("PlayerATKMin", skillInfos._NormalAttackInfo._AttackMin);
				XStaticSecurityStatistics.Append("PlayerCritATKMax", skillInfos._NormalAttackInfo._CriticalAttackMax);
				XStaticSecurityStatistics.Append("PlayerCritATKMin", skillInfos._NormalAttackInfo._CriticalAttackMin);
				XStaticSecurityStatistics.Append("PlayerAtkTotal", skillInfos._NormalAttackInfo._AttackTotal);
				XStaticSecurityStatistics.Append("PlayerAtkCount", (float)skillInfos._NormalAttackInfo._CastCount);
				XStaticSecurityStatistics.Append("PlayerAtkTag", skillInfos._NormalAttackInfo._SingleAttackMaxCount);
			}
			bool flag2 = skillInfos._QTEAttackInfo != null;
			if (flag2)
			{
				XStaticSecurityStatistics.Append("PlayerQTEMax", skillInfos._QTEAttackInfo._AttackMax);
				XStaticSecurityStatistics.Append("PlayerQTEMin", skillInfos._QTEAttackInfo._AttackMin);
				XStaticSecurityStatistics.Append("PlayerCritQTEMax", skillInfos._QTEAttackInfo._CriticalAttackMax);
				XStaticSecurityStatistics.Append("PlayerCritQTEMin", skillInfos._QTEAttackInfo._CriticalAttackMin);
				XStaticSecurityStatistics.Append("PlayerQTEDps", skillInfos._QTEAttackInfo._AttackTotal);
				XStaticSecurityStatistics.Append("PlayerQTECount", (float)skillInfos._QTEAttackInfo._CastCount);
				XStaticSecurityStatistics.Append("PlayerQTEHitCount", (float)skillInfos._QTEAttackInfo._AttackCount);
				XStaticSecurityStatistics.Append("PlayerQTETag", skillInfos._QTEAttackInfo._SingleAttackMaxCount);
			}
			bool flag3 = entity == null;
			if (!flag3)
			{
				XAttributes attributes = entity.Attributes;
				XSkillMgr skillMgr = entity.SkillMgr;
				bool flag4 = attributes == null || skillMgr == null;
				if (!flag4)
				{
					int num = 0;
					XSecuritySkillInfo.SkillInfo skillInfo;
					for (int i = 0; i < attributes.skillSlot.Length; i++)
					{
						bool flag5 = skillMgr.IsPhysicalAttack(attributes.skillSlot[i]);
						if (!flag5)
						{
							bool flag6 = skillMgr.GetDashIdentity() == attributes.skillSlot[i];
							if (!flag6)
							{
								bool flag7 = skillMgr.IsQTESkill(attributes.skillSlot[i]);
								if (!flag7)
								{
									skillInfo = null;
									skillInfos._SkillInfos.TryGetValue(attributes.skillSlot[i], out skillInfo);
									XSecuritySkillInfo.SkillInfo skillInfo2 = skillInfo;
									int num2 = num + 1;
									num = num2;
									XSecuritySkillInfo._SendPlayerData(skillInfo2, num2.ToString());
								}
							}
						}
					}
					skillInfos._SkillInfos.TryGetValue(skillMgr.GetDashIdentity(), out skillInfo);
					XSecuritySkillInfo._SendPlayerData(skillInfo, "10");
				}
			}
		}

		private static void _SendPlayerData(XSecuritySkillInfo.SkillInfo skillInfo, string keywords)
		{
			XStaticSecurityStatistics.Append(string.Format("PlayerSkillMax{0}", keywords), (skillInfo == null) ? 0f : skillInfo._AttackMax);
			XStaticSecurityStatistics.Append(string.Format("PlayerSkillMin{0}", keywords), (skillInfo == null) ? 0f : skillInfo._AttackMin);
			XStaticSecurityStatistics.Append(string.Format("PlayerCritSkillMax{0}", keywords), (skillInfo == null) ? 0f : skillInfo._CriticalAttackMax);
			XStaticSecurityStatistics.Append(string.Format("PlayerCritSkillMin{0}", keywords), (skillInfo == null) ? 0f : skillInfo._CriticalAttackMin);
			XStaticSecurityStatistics.Append(string.Format("PlayerSkillHitCount{0}", keywords), (float)((skillInfo == null) ? 0 : skillInfo._AttackCount));
			XStaticSecurityStatistics.Append(string.Format("PlayerSkillDPS{0}", keywords), (skillInfo == null) ? 0f : skillInfo._AttackTotal);
			XStaticSecurityStatistics.Append(string.Format("PlayerSkillCount{0}", keywords), (float)((skillInfo == null) ? 0 : skillInfo._CastCount));
			XStaticSecurityStatistics.Append(string.Format("PlayerSkillCD{0}", keywords), (skillInfo == null) ? 0U : skillInfo._IntervalMin);
			XStaticSecurityStatistics.Append(string.Format("PlayerSkillTag{0}", keywords), (skillInfo == null) ? 0U : skillInfo._SingleAttackMaxCount);
		}

		private List<XSecuritySkillInfo.SkillInfo> _SkillInfoList = new List<XSecuritySkillInfo.SkillInfo>();

		private Dictionary<uint, XSecuritySkillInfo.SkillInfo> _SkillInfos = new Dictionary<uint, XSecuritySkillInfo.SkillInfo>();

		private XSecuritySkillInfo.SkillInfo _NormalAttackInfo = new XSecuritySkillInfo.SkillInfo();

		private XSecuritySkillInfo.SkillInfo _QTEAttackInfo = null;

		public class SkillInfo : XDataBase
		{

			public void OnCast(int count)
			{
				this._CastCount += count;
				bool flag = this._last_cast > 0U;
				if (flag)
				{
					uint num = (uint)Time.realtimeSinceStartup * 1000U - this._last_cast;
					bool flag2 = num < this._IntervalMin;
					if (flag2)
					{
						this._IntervalMin = num;
					}
				}
				else
				{
					this._last_cast = (uint)Time.realtimeSinceStartup * 1000U;
				}
			}

			public void OnCast()
			{
				this.OnCast(1);
			}

			public void OnCastDamage(double value)
			{
				this._AttackCount++;
				this._AttackTotal += (float)value;
				this._AttackMax = Math.Max((float)value, this._AttackMax);
				bool flag = value > 0.0;
				if (flag)
				{
					this._AttackMin = Math.Min((float)value, this._AttackMin);
				}
			}

			public void OnCastDamage(HurtInfo rawInput, ProjectDamageResult result)
			{
				this._AttackCount++;
				this._AttackTotal += (float)result.Value;
				bool flag = (result.Flag & XFastEnumIntEqualityComparer<DamageFlag>.ToInt(DamageFlag.DMGFLAG_CRITICAL)) != 0;
				if (flag)
				{
					this._CriticalAttackMax = Math.Max((float)result.Value, this._CriticalAttackMax);
					bool flag2 = result.Value > 0.0;
					if (flag2)
					{
						this._CriticalAttackMin = Math.Min((float)result.Value, this._CriticalAttackMin);
					}
				}
				else
				{
					this._AttackMax = Math.Max((float)result.Value, this._AttackMax);
					bool flag3 = result.Value > 0.0;
					if (flag3)
					{
						this._AttackMin = Math.Min((float)result.Value, this._AttackMin);
					}
				}
				bool flag4 = rawInput.SkillToken != this._last_token;
				if (flag4)
				{
					this._last_token = rawInput.SkillToken;
					this._last_single_attack_count = 0U;
				}
				this._last_single_attack_count += 1U;
				bool flag5 = this._last_single_attack_count > this._SingleAttackMaxCount;
				if (flag5)
				{
					this._SingleAttackMaxCount = this._last_single_attack_count;
				}
			}

			public void Reset()
			{
				this._SkillID = 0U;
				this._IntervalMin = uint.MaxValue;
				this._AttackCount = 0;
				this._CastCount = 0;
				this._AttackTotal = 0f;
				this._AttackMax = 0f;
				this._AttackMin = float.MaxValue;
				this._CriticalAttackMax = 0f;
				this._CriticalAttackMin = float.MaxValue;
				this._SingleAttackMaxCount = 0U;
				this._last_cast = 0U;
				this._last_token = 0L;
				this._last_single_attack_count = 0U;
			}

			public void Merge(XSecuritySkillInfo.SkillInfo other)
			{
				bool flag = other == null;
				if (!flag)
				{
					this._AttackCount += other._AttackCount;
					this._AttackTotal += other._AttackTotal;
					this._AttackMax = Math.Max(this._AttackMax, other._AttackMax);
					this._AttackMin = Math.Min(this._AttackMin, other._AttackMin);
					this._CriticalAttackMax = Math.Max(this._CriticalAttackMax, other._CriticalAttackMax);
					this._CriticalAttackMin = Math.Min(this._CriticalAttackMin, other._CriticalAttackMin);
					this._SingleAttackMaxCount = Math.Max(this._SingleAttackMaxCount, other._SingleAttackMaxCount);
					this._CastCount += other._CastCount;
					this._IntervalMin = Math.Min(this._IntervalMin, other._IntervalMin);
				}
			}

			public override void Init()
			{
				base.Init();
				this.Reset();
			}

			public override void Recycle()
			{
				base.Recycle();
				XDataPool<XSecuritySkillInfo.SkillInfo>.Recycle(this);
			}

			public uint _SkillID;

			public uint _IntervalMin;

			public int _CastCount;

			public int _AttackCount;

			public float _AttackTotal;

			public float _AttackMax;

			public float _AttackMin = float.MaxValue;

			public float _CriticalAttackMax;

			public float _CriticalAttackMin = float.MaxValue;

			public uint _SingleAttackMaxCount;

			private uint _last_cast;

			private long _last_token;

			private uint _last_single_attack_count;
		}
	}
}
