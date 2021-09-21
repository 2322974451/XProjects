using System;
using UnityEngine;

namespace XMainClient
{
	// Token: 0x02000B0E RID: 2830
	internal class XSecurityAIInfo
	{
		// Token: 0x0600A6A9 RID: 42665 RVA: 0x001D5439 File Offset: 0x001D3639
		public void Reset()
		{
			this._PhysicalAttackNum = 0;
			this._SkillAttackNum = 0;
			this._LifeTime = 0f;
			this._BossCallMonsterTotal = 0;
			this._BossCallMonsterCount = 0;
		}

		// Token: 0x0600A6AA RID: 42666 RVA: 0x001D5464 File Offset: 0x001D3664
		public void Merge(XSecurityAIInfo other)
		{
			bool flag = other == null;
			if (!flag)
			{
				this._PhysicalAttackNum += other._PhysicalAttackNum;
				this._SkillAttackNum += other._SkillAttackNum;
				this._LifeTime += other._LifeTime;
				this._BossCallMonsterTotal += other._BossCallMonsterTotal;
				this._BossCallMonsterCount += other._BossCallMonsterCount;
			}
		}

		// Token: 0x0600A6AB RID: 42667 RVA: 0x001D54DB File Offset: 0x001D36DB
		public void OnMobCast()
		{
			this._BossCallMonsterCount++;
		}

		// Token: 0x0600A6AC RID: 42668 RVA: 0x001D54EC File Offset: 0x001D36EC
		public void OnMobMonster()
		{
			this._BossCallMonsterTotal++;
		}

		// Token: 0x0600A6AD RID: 42669 RVA: 0x001D54FD File Offset: 0x001D36FD
		public void OnPhysicalAttack()
		{
			this._PhysicalAttackNum++;
		}

		// Token: 0x0600A6AE RID: 42670 RVA: 0x001D550E File Offset: 0x001D370E
		public void OnSkillAttack()
		{
			this._SkillAttackNum++;
		}

		// Token: 0x0600A6AF RID: 42671 RVA: 0x001D5520 File Offset: 0x001D3720
		public void OnCallMonster(XEntity entity)
		{
			this._BossCallMonsterTotal++;
			bool flag = Time.time - entity.AI.LastCallMonsterTime > 1f;
			if (flag)
			{
				this._BossCallMonsterCount++;
				entity.AI.LastCallMonsterTime = Time.time;
			}
		}

		// Token: 0x0600A6B0 RID: 42672 RVA: 0x001D5579 File Offset: 0x001D3779
		public void OnExternalCallMonster()
		{
			this._BossCallMonsterTotal++;
			this._BossCallMonsterCount++;
		}

		// Token: 0x0600A6B1 RID: 42673 RVA: 0x001D5598 File Offset: 0x001D3798
		public void SetLifeTime(float life)
		{
			this._LifeTime = life;
		}

		// Token: 0x0600A6B2 RID: 42674 RVA: 0x001D55A4 File Offset: 0x001D37A4
		public static XSecurityAIInfo TryGetStatistics(XEntity entity)
		{
			XSecurityStatistics xsecurityStatistics = XSecurityStatistics.TryGetStatistics(entity);
			bool flag = xsecurityStatistics == null;
			XSecurityAIInfo result;
			if (flag)
			{
				result = null;
			}
			else
			{
				result = xsecurityStatistics.AIInfo;
			}
			return result;
		}

		// Token: 0x0600A6B3 RID: 42675 RVA: 0x001D55D0 File Offset: 0x001D37D0
		public static void SendBossData(XSecurityAIInfo info, string keywords)
		{
			XStaticSecurityStatistics.Append("BossAttackCount", (float)info._PhysicalAttackNum);
			XStaticSecurityStatistics.Append("BossUseSkillCount", (float)info._SkillAttackNum);
			XStaticSecurityStatistics.Append("BossTimeTotal", (float)((int)(info._LifeTime * 1000f)));
			XStaticSecurityStatistics.Append("BossCallCount", (float)info._BossCallMonsterCount);
			XStaticSecurityStatistics.Append("BossCallTotal", (float)info._BossCallMonsterTotal);
		}

		// Token: 0x0600A6B4 RID: 42676 RVA: 0x001D563F File Offset: 0x001D383F
		public static void SendEnemyData(XSecurityAIInfo info, string keywords)
		{
			XStaticSecurityStatistics.Append("MonsterAttackCount", (float)info._PhysicalAttackNum);
			XStaticSecurityStatistics.Append("MonsterSkillCount", (float)info._SkillAttackNum);
			XStaticSecurityStatistics.Append("MonsterTimeTotal", info._LifeTime);
		}

		// Token: 0x04003D43 RID: 15683
		public int _PhysicalAttackNum;

		// Token: 0x04003D44 RID: 15684
		public int _SkillAttackNum;

		// Token: 0x04003D45 RID: 15685
		public float _LifeTime;

		// Token: 0x04003D46 RID: 15686
		public int _BossCallMonsterTotal;

		// Token: 0x04003D47 RID: 15687
		public int _BossCallMonsterCount;
	}
}
