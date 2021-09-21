using System;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000B19 RID: 2841
	internal sealed class XSecurityStatistics
	{
		// Token: 0x17002FFF RID: 12287
		// (get) Token: 0x0600A724 RID: 42788 RVA: 0x001D8480 File Offset: 0x001D6680
		public bool bValid
		{
			get
			{
				return this._bInited;
			}
		}

		// Token: 0x17003000 RID: 12288
		// (get) Token: 0x0600A725 RID: 42789 RVA: 0x001D8498 File Offset: 0x001D6698
		public XSecurityDamageInfo DamageStatistics
		{
			get
			{
				return this._DamageInfo;
			}
		}

		// Token: 0x17003001 RID: 12289
		// (get) Token: 0x0600A726 RID: 42790 RVA: 0x001D84B0 File Offset: 0x001D66B0
		public XSecurityAttributeInfo AttributeStatistics
		{
			get
			{
				return this._AttributeInfo;
			}
		}

		// Token: 0x17003002 RID: 12290
		// (get) Token: 0x0600A727 RID: 42791 RVA: 0x001D84C8 File Offset: 0x001D66C8
		public XSecurityBuffInfo BuffStatistics
		{
			get
			{
				return this._BuffInfo;
			}
		}

		// Token: 0x17003003 RID: 12291
		// (get) Token: 0x0600A728 RID: 42792 RVA: 0x001D84E0 File Offset: 0x001D66E0
		public XSecuritySkillInfo SkillStatistics
		{
			get
			{
				return this._SkillInfo;
			}
		}

		// Token: 0x17003004 RID: 12292
		// (get) Token: 0x0600A729 RID: 42793 RVA: 0x001D84F8 File Offset: 0x001D66F8
		public XSecurityMobInfo MobStatistics
		{
			get
			{
				return this._MobInfo;
			}
		}

		// Token: 0x17003005 RID: 12293
		// (get) Token: 0x0600A72A RID: 42794 RVA: 0x001D8510 File Offset: 0x001D6710
		public XSecurityAIInfo AIInfo
		{
			get
			{
				return this._AIInfo;
			}
		}

		// Token: 0x17003006 RID: 12294
		// (get) Token: 0x0600A72B RID: 42795 RVA: 0x001D8528 File Offset: 0x001D6728
		// (set) Token: 0x0600A72C RID: 42796 RVA: 0x001D8540 File Offset: 0x001D6740
		public XEntity Entity
		{
			get
			{
				return this.m_Entity;
			}
			set
			{
				this.m_Entity = value;
			}
		}

		// Token: 0x0600A72D RID: 42797 RVA: 0x001D854C File Offset: 0x001D674C
		public void OnAttach()
		{
			bool flag = this.m_Entity != null;
			if (flag)
			{
				bool isPlayer = this.m_Entity.IsPlayer;
				if (isPlayer)
				{
					bool flag2 = this._AttributeInfo == null;
					if (flag2)
					{
						this._AttributeInfo = new XSecurityAttributeInfo();
						this._AttributeInfo.Reset();
					}
					bool flag3 = this._SkillInfo == null;
					if (flag3)
					{
						this._SkillInfo = new XSecuritySkillInfo();
						this._SkillInfo.Reset();
					}
					bool flag4 = this._BuffInfo == null;
					if (flag4)
					{
						this._BuffInfo = new XSecurityBuffInfo();
						this._BuffInfo.Reset();
					}
					bool flag5 = this._MobInfo == null;
					if (flag5)
					{
						this._MobInfo = new XSecurityMobInfo();
						this._MobInfo.Reset();
					}
					this._SkillInfo.OnAttach(this.m_Entity);
					this._AttributeInfo.OnAttach(this.m_Entity);
				}
				else
				{
					bool isEnemy = this.m_Entity.IsEnemy;
					if (isEnemy)
					{
						bool flag6 = this._AIInfo == null;
						if (flag6)
						{
							this._AIInfo = new XSecurityAIInfo();
							this._AIInfo.Reset();
						}
					}
				}
			}
		}

		// Token: 0x0600A72F RID: 42799 RVA: 0x001D869C File Offset: 0x001D689C
		public void Dump()
		{
			bool flag = this.Entity == null;
			if (!flag)
			{
				bool flag2 = !this._bInited;
				if (!flag2)
				{
					bool flag3 = !this.Entity.IsPlayer;
					if (flag3)
					{
						this.OnEnd();
					}
					bool isBoss = this.Entity.IsBoss;
					if (isBoss)
					{
						XStaticSecurityStatistics._BossDamageInfo.Merge(this._DamageInfo);
						XStaticSecurityStatistics._BossAIInfo.Merge(this._AIInfo);
						XStaticSecurityStatistics._BossHPInfo.Merge(this._InitHp);
						XStaticSecurityStatistics._BossMoveDistance += this._Distance;
					}
					else
					{
						bool isOpposer = this.Entity.IsOpposer;
						if (isOpposer)
						{
							XStaticSecurityStatistics._MonsterDamageInfo.Merge(this._DamageInfo);
							XStaticSecurityStatistics._MonsterAIInfo.Merge(this._AIInfo);
							XStaticSecurityStatistics._MonsterHPInfo.Merge(this._InitHp);
							XStaticSecurityStatistics._MonsterMoveDistance += this._Distance;
						}
					}
				}
			}
		}

		// Token: 0x0600A730 RID: 42800 RVA: 0x001D8798 File Offset: 0x001D6998
		public void Reset()
		{
			this._DamageInfo.Reset();
			bool flag = this._AttributeInfo != null;
			if (flag)
			{
				this._AttributeInfo.Reset();
			}
			bool flag2 = this._SkillInfo != null;
			if (flag2)
			{
				this._SkillInfo.Reset();
			}
			bool flag3 = this._BuffInfo != null;
			if (flag3)
			{
				this._BuffInfo.Reset();
			}
			bool flag4 = this._AIInfo != null;
			if (flag4)
			{
				this._AIInfo.Reset();
			}
			bool flag5 = this._MobInfo != null;
			if (flag5)
			{
				this._MobInfo.Reset();
			}
			this._InitHp = -1f;
			this._InitMp = -1f;
			this._FinalHp = 0f;
			this._FinalMp = 0f;
			this._Distance = 0f;
			this._bInited = true;
		}

		// Token: 0x0600A731 RID: 42801 RVA: 0x001D8870 File Offset: 0x001D6A70
		public void OnStart()
		{
			this.Reset();
			this.OnAttach();
			bool flag = this.m_Entity != null && this.m_Entity.Attributes != null;
			if (flag)
			{
				this._InitHp = (float)this.m_Entity.Attributes.GetAttr(XAttributeDefine.XAttr_CurrentHP_Basic);
				this._InitMp = (float)this.m_Entity.Attributes.GetAttr(XAttributeDefine.XAttr_CurrentMP_Basic);
			}
		}

		// Token: 0x0600A732 RID: 42802 RVA: 0x001D88E0 File Offset: 0x001D6AE0
		public void OnEnd()
		{
			bool flag = !this._bInited;
			if (!flag)
			{
				bool flag2 = this.m_Entity != null;
				if (flag2)
				{
					bool flag3 = this.m_Entity.Attributes != null;
					if (flag3)
					{
						this._FinalHp = (float)this.m_Entity.Attributes.GetAttr(XAttributeDefine.XAttr_CurrentHP_Basic);
						this._FinalMp = (float)this.m_Entity.Attributes.GetAttr(XAttributeDefine.XAttr_CurrentMP_Basic);
					}
					bool flag4 = this.SkillStatistics != null;
					if (flag4)
					{
						this.SkillStatistics.OnEnd(this.m_Entity);
					}
					bool flag5 = !this.m_Entity.IsPlayer;
					if (flag5)
					{
						this.OnEntityFinish(XSingleton<XEntityMgr>.singleton.Player);
					}
				}
				this._bInited = false;
			}
		}

		// Token: 0x0600A733 RID: 42803 RVA: 0x001D89A8 File Offset: 0x001D6BA8
		public void OnCastDamage(HurtInfo rawInput, ProjectDamageResult result)
		{
			bool flag = !result.Accept;
			if (!flag)
			{
				this._DamageInfo.OnCastDamage(rawInput, result);
				bool flag2 = this._SkillInfo != null;
				if (flag2)
				{
					this._SkillInfo.OnCastDamage(rawInput, result);
				}
			}
		}

		// Token: 0x0600A734 RID: 42804 RVA: 0x001D89F0 File Offset: 0x001D6BF0
		public void OnReceiveDamage(HurtInfo rawInput, ProjectDamageResult result)
		{
			bool flag = !result.Accept;
			if (!flag)
			{
				this._DamageInfo.OnReceiveDamage(rawInput, result);
			}
		}

		// Token: 0x0600A735 RID: 42805 RVA: 0x001D8A1C File Offset: 0x001D6C1C
		public void OnAttributeChange(XAttributeDefine attr, double oldValue, double delta)
		{
			bool flag = this._AttributeInfo != null && this._AttributeInfo.IsUsefulAttr(attr);
			if (flag)
			{
				this._AttributeInfo.OnAttributeChange(attr, delta);
			}
		}

		// Token: 0x0600A736 RID: 42806 RVA: 0x001D8A54 File Offset: 0x001D6C54
		public bool IsUsefulAttr(XAttributeDefine attr)
		{
			return this._AttributeInfo != null && this._AttributeInfo.IsUsefulAttr(attr);
		}

		// Token: 0x0600A737 RID: 42807 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public void OnMobCast()
		{
		}

		// Token: 0x0600A738 RID: 42808 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public void OnMobMonster()
		{
		}

		// Token: 0x0600A739 RID: 42809 RVA: 0x001D8A7D File Offset: 0x001D6C7D
		public void OnMove(float distance)
		{
			this._Distance += distance;
		}

		// Token: 0x0600A73A RID: 42810 RVA: 0x001D8A90 File Offset: 0x001D6C90
		public void OnEntityFinish(XEntity host)
		{
			bool flag = host == null || this.Entity == null || this.Entity.Attributes == null;
			if (!flag)
			{
				bool flag2 = this.Entity.Attributes.HostID != host.ID;
				if (!flag2)
				{
					XSecurityMobInfo xsecurityMobInfo = XSecurityMobInfo.TryGetStatistics(host);
					bool flag3 = xsecurityMobInfo == null;
					if (!flag3)
					{
						xsecurityMobInfo.Append(this.Entity);
					}
				}
			}
		}

		// Token: 0x0600A73B RID: 42811 RVA: 0x001D8B00 File Offset: 0x001D6D00
		public static XSecurityStatistics TryGetStatistics(XEntity entity)
		{
			bool flag = entity == null || entity.Attributes == null;
			XSecurityStatistics result;
			if (flag)
			{
				result = null;
			}
			else
			{
				result = entity.Attributes.SecurityStatistics;
			}
			return result;
		}

		// Token: 0x04003DA1 RID: 15777
		public float _Distance;

		// Token: 0x04003DA2 RID: 15778
		public float _InitHp;

		// Token: 0x04003DA3 RID: 15779
		public float _InitMp;

		// Token: 0x04003DA4 RID: 15780
		public float _FinalHp;

		// Token: 0x04003DA5 RID: 15781
		public float _FinalMp;

		// Token: 0x04003DA6 RID: 15782
		private bool _bInited = false;

		// Token: 0x04003DA7 RID: 15783
		private XSecurityDamageInfo _DamageInfo = new XSecurityDamageInfo();

		// Token: 0x04003DA8 RID: 15784
		private XSecurityAttributeInfo _AttributeInfo;

		// Token: 0x04003DA9 RID: 15785
		private XSecurityBuffInfo _BuffInfo;

		// Token: 0x04003DAA RID: 15786
		private XSecuritySkillInfo _SkillInfo;

		// Token: 0x04003DAB RID: 15787
		private XSecurityMobInfo _MobInfo;

		// Token: 0x04003DAC RID: 15788
		public XSecurityAIInfo _AIInfo;

		// Token: 0x04003DAD RID: 15789
		private XEntity m_Entity;
	}
}
