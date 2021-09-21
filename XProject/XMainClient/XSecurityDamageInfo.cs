using System;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000B10 RID: 2832
	internal class XSecurityDamageInfo
	{
		// Token: 0x0600A6C3 RID: 42691 RVA: 0x001D5BD8 File Offset: 0x001D3DD8
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

		// Token: 0x0600A6C4 RID: 42692 RVA: 0x001D5C40 File Offset: 0x001D3E40
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

		// Token: 0x0600A6C5 RID: 42693 RVA: 0x001D5D10 File Offset: 0x001D3F10
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

		// Token: 0x0600A6C6 RID: 42694 RVA: 0x001D5D94 File Offset: 0x001D3F94
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

		// Token: 0x0600A6C7 RID: 42695 RVA: 0x001D5E6C File Offset: 0x001D406C
		public static void SendPlayerData(XSecurityDamageInfo info)
		{
			XStaticSecurityStatistics.Append("PlayerDpsCount", (float)info._AttackCount);
			XStaticSecurityStatistics.Append("PlayerAtkMissTotal", (float)info._InvalidAttackCount);
			XStaticSecurityStatistics.Append("PlayerCritCount", (float)info._CriticalAttackCount);
			XStaticSecurityStatistics.Append("PlayerDamageMax", info._AttackMax);
			XStaticSecurityStatistics.Append("PlayerDamageMin", info._AttackMin);
			XStaticSecurityStatistics.Append("PlayerDpsTotal", info._AttackTotal);
		}

		// Token: 0x0600A6C8 RID: 42696 RVA: 0x001D5EE4 File Offset: 0x001D40E4
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

		// Token: 0x04003D52 RID: 15698
		public float _AttackTotal;

		// Token: 0x04003D53 RID: 15699
		public float _AttackMax;

		// Token: 0x04003D54 RID: 15700
		public float _AttackMin;

		// Token: 0x04003D55 RID: 15701
		public int _AttackCount;

		// Token: 0x04003D56 RID: 15702
		public int _CriticalAttackCount;

		// Token: 0x04003D57 RID: 15703
		public int _InvalidAttackCount;

		// Token: 0x04003D58 RID: 15704
		public float _HurtTotal;

		// Token: 0x04003D59 RID: 15705
		public float _HurtMax;

		// Token: 0x04003D5A RID: 15706
		public float _HurtMin;
	}
}
