using System;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XSecurityDamageInfo
	{

		public void Reset()
		{
			this._AttackTotal = 0f;
			this._AttackMax = 0f;
			this._AttackMin = float.MaxValue;
			this._AttackCount = 0;
			this._CriticalAttackCount = 0;
			this._InvalidAttackCount = 0;
			this._HurtTotal = 0f;
			this._HurtMax = 0f;
			this._HurtMin = float.MaxValue;
		}

		public void OnCastDamage(HurtInfo rawInput, ProjectDamageResult result)
		{
			bool flag = result.Value >= 0.0;
			if (flag)
			{
				this._AttackCount++;
				this._AttackTotal += (float)result.Value;
				this._AttackMax = Math.Max((float)result.Value, this._AttackMax);
				bool flag2 = result.Value > 0.0;
				if (flag2)
				{
					this._AttackMin = Math.Min((float)result.Value, this._AttackMin);
				}
				bool flag3 = (result.Flag & XFastEnumIntEqualityComparer<DamageFlag>.ToInt(DamageFlag.DMGFLAG_CRITICAL)) != 0;
				if (flag3)
				{
					this._CriticalAttackCount++;
				}
				bool flag4 = result.Result == ProjectResultType.PJRES_IMMORTAL;
				if (flag4)
				{
					this._InvalidAttackCount++;
				}
			}
		}

		public void OnReceiveDamage(HurtInfo rawInput, ProjectDamageResult result)
		{
			bool flag = result.Value >= 0.0;
			if (flag)
			{
				this._HurtTotal += (float)result.Value;
				this._HurtMax = Math.Max((float)result.Value, this._HurtMax);
				bool flag2 = result.Value > 0.0;
				if (flag2)
				{
					this._HurtMin = Math.Min((float)result.Value, this._HurtMin);
				}
			}
		}

		public void Merge(XSecurityDamageInfo other)
		{
			bool flag = other == null;
			if (!flag)
			{
				this._AttackTotal += other._AttackTotal;
				this._AttackMax = Math.Max(this._AttackMax, other._AttackMax);
				this._AttackMin = Math.Min(this._AttackMin, other._AttackMin);
				this._AttackCount += other._AttackCount;
				this._CriticalAttackCount += other._CriticalAttackCount;
				this._InvalidAttackCount += other._InvalidAttackCount;
				this._HurtTotal += other._HurtTotal;
				this._HurtMax = Math.Max(this._HurtMax, other._HurtMax);
				this._HurtMin = Math.Min(this._HurtMin, other._HurtMin);
			}
		}

		public static void SendPlayerData(XSecurityDamageInfo info)
		{
			XStaticSecurityStatistics.Append("PlayerDpsCount", (float)info._AttackCount);
			XStaticSecurityStatistics.Append("PlayerAtkMissTotal", (float)info._InvalidAttackCount);
			XStaticSecurityStatistics.Append("PlayerCritCount", (float)info._CriticalAttackCount);
			XStaticSecurityStatistics.Append("PlayerDamageMax", info._AttackMax);
			XStaticSecurityStatistics.Append("PlayerDamageMin", info._AttackMin);
			XStaticSecurityStatistics.Append("PlayerDpsTotal", info._AttackTotal);
		}

		public static void SendEnemyData(XSecurityDamageInfo info, string keywords)
		{
			XStaticSecurityStatistics.Append(string.Format("{0}MissCount", keywords), (float)info._InvalidAttackCount);
			XStaticSecurityStatistics.Append(string.Format("{0}AttackMax", keywords), info._AttackMax);
			XStaticSecurityStatistics.Append(string.Format("{0}AttackMin", keywords), info._AttackMin);
			XStaticSecurityStatistics.Append(string.Format("{0}AttackTotal", keywords), info._AttackTotal);
			XStaticSecurityStatistics.Append(string.Format("{0}DamageMax", keywords), info._HurtMax);
			XStaticSecurityStatistics.Append(string.Format("{0}DamageMin", keywords), info._HurtMin);
			XStaticSecurityStatistics.Append(string.Format("{0}DamageTotal", keywords), info._HurtTotal);
		}

		public float _AttackTotal;

		public float _AttackMax;

		public float _AttackMin;

		public int _AttackCount;

		public int _CriticalAttackCount;

		public int _InvalidAttackCount;

		public float _HurtTotal;

		public float _HurtMax;

		public float _HurtMin;
	}
}
