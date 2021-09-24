using System;
using XUtliPoolLib;

namespace XMainClient
{

	internal sealed class XSecurityStatistics
	{

		public bool bValid
		{
			get
			{
				return this._bInited;
			}
		}

		public XSecurityDamageInfo DamageStatistics
		{
			get
			{
				return this._DamageInfo;
			}
		}

		public XSecurityAttributeInfo AttributeStatistics
		{
			get
			{
				return this._AttributeInfo;
			}
		}

		public XSecurityBuffInfo BuffStatistics
		{
			get
			{
				return this._BuffInfo;
			}
		}

		public XSecuritySkillInfo SkillStatistics
		{
			get
			{
				return this._SkillInfo;
			}
		}

		public XSecurityMobInfo MobStatistics
		{
			get
			{
				return this._MobInfo;
			}
		}

		public XSecurityAIInfo AIInfo
		{
			get
			{
				return this._AIInfo;
			}
		}

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

		public void OnReceiveDamage(HurtInfo rawInput, ProjectDamageResult result)
		{
			bool flag = !result.Accept;
			if (!flag)
			{
				this._DamageInfo.OnReceiveDamage(rawInput, result);
			}
		}

		public void OnAttributeChange(XAttributeDefine attr, double oldValue, double delta)
		{
			bool flag = this._AttributeInfo != null && this._AttributeInfo.IsUsefulAttr(attr);
			if (flag)
			{
				this._AttributeInfo.OnAttributeChange(attr, delta);
			}
		}

		public bool IsUsefulAttr(XAttributeDefine attr)
		{
			return this._AttributeInfo != null && this._AttributeInfo.IsUsefulAttr(attr);
		}

		public void OnMobCast()
		{
		}

		public void OnMobMonster()
		{
		}

		public void OnMove(float distance)
		{
			this._Distance += distance;
		}

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

		public float _Distance;

		public float _InitHp;

		public float _InitMp;

		public float _FinalHp;

		public float _FinalMp;

		private bool _bInited = false;

		private XSecurityDamageInfo _DamageInfo = new XSecurityDamageInfo();

		private XSecurityAttributeInfo _AttributeInfo;

		private XSecurityBuffInfo _BuffInfo;

		private XSecuritySkillInfo _SkillInfo;

		private XSecurityMobInfo _MobInfo;

		public XSecurityAIInfo _AIInfo;

		private XEntity m_Entity;
	}
}
