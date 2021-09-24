using System;
using UnityEngine;

namespace XMainClient
{

	internal class XSecurityAIInfo
	{

		public void Reset()
		{
			this._PhysicalAttackNum = 0;
			this._SkillAttackNum = 0;
			this._LifeTime = 0f;
			this._BossCallMonsterTotal = 0;
			this._BossCallMonsterCount = 0;
		}

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

		public void OnMobCast()
		{
			this._BossCallMonsterCount++;
		}

		public void OnMobMonster()
		{
			this._BossCallMonsterTotal++;
		}

		public void OnPhysicalAttack()
		{
			this._PhysicalAttackNum++;
		}

		public void OnSkillAttack()
		{
			this._SkillAttackNum++;
		}

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

		public void OnExternalCallMonster()
		{
			this._BossCallMonsterTotal++;
			this._BossCallMonsterCount++;
		}

		public void SetLifeTime(float life)
		{
			this._LifeTime = life;
		}

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

		public static void SendBossData(XSecurityAIInfo info, string keywords)
		{
			XStaticSecurityStatistics.Append("BossAttackCount", (float)info._PhysicalAttackNum);
			XStaticSecurityStatistics.Append("BossUseSkillCount", (float)info._SkillAttackNum);
			XStaticSecurityStatistics.Append("BossTimeTotal", (float)((int)(info._LifeTime * 1000f)));
			XStaticSecurityStatistics.Append("BossCallCount", (float)info._BossCallMonsterCount);
			XStaticSecurityStatistics.Append("BossCallTotal", (float)info._BossCallMonsterTotal);
		}

		public static void SendEnemyData(XSecurityAIInfo info, string keywords)
		{
			XStaticSecurityStatistics.Append("MonsterAttackCount", (float)info._PhysicalAttackNum);
			XStaticSecurityStatistics.Append("MonsterSkillCount", (float)info._SkillAttackNum);
			XStaticSecurityStatistics.Append("MonsterTimeTotal", info._LifeTime);
		}

		public int _PhysicalAttackNum;

		public int _SkillAttackNum;

		public float _LifeTime;

		public int _BossCallMonsterTotal;

		public int _BossCallMonsterCount;
	}
}
