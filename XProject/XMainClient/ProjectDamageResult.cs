using System;
using XUtliPoolLib;

namespace XMainClient
{

	internal class ProjectDamageResult : XDataBase
	{

		public double DefOriginalRatio { get; set; }

		public CombatEffectHelper EffectHelper
		{
			get
			{
				return this._EffectHelper;
			}
		}

		public double TrueDamage
		{
			get
			{
				return this.m_TrueDamage;
			}
			set
			{
				this.m_Value -= this.m_TrueDamage;
				this.m_TrueDamage = value;
				bool flag = this.m_TrueDamage < 0.0;
				if (flag)
				{
					this.m_TrueDamage = 0.0;
				}
				this.m_Value += this.m_TrueDamage;
			}
		}

		public double AbsorbDamage
		{
			get
			{
				return this.m_AbsorbDamage;
			}
			set
			{
				this.m_Value += this.m_AbsorbDamage;
				this.m_AbsorbDamage = value;
				bool flag = this.Value > this.m_AbsorbDamage;
				if (flag)
				{
					this.Value -= this.m_AbsorbDamage;
				}
				else
				{
					this.Value = 0.0;
				}
			}
		}

		public double Value
		{
			get
			{
				return this.m_Value;
			}
			set
			{
				bool flag = value < this.m_Value && this.TrueDamage > 0.0;
				if (flag)
				{
					this.TrueDamage -= this.m_Value - value;
				}
				this.m_Value = value;
			}
		}

		public double BasicDamage
		{
			get
			{
				return this.Value - this.TrueDamage;
			}
		}

		public int Flag { get; set; }

		public DamageType Type { get; set; }

		public DamageElement ElementType { get; set; }

		public bool IsTargetDead { get; set; }

		public ulong Caster { get; set; }

		public int ComboCount { get; set; }

		public bool IsCritical()
		{
			int num = XFastEnumIntEqualityComparer<DamageFlag>.ToInt(DamageFlag.DMGFLAG_CRITICAL);
			return (this.Flag & num) != 0;
		}

		public ProjectDamageResult()
		{
			this.Init();
		}

		public void SetResult(ProjectResultType r)
		{
			bool flag = r < this.Result;
			if (flag)
			{
				this.Result = r;
			}
		}

		public override void Init()
		{
			base.Init();
			this.Accept = true;
			this.Result = ProjectResultType.PJRES_BEHIT;
			this.Type = DamageType.DMG_INVALID;
			this.Value = 0.0;
			this.AbsorbDamage = 0.0;
			this.TrueDamage = 0.0;
			this.IsTargetDead = false;
			this.Flag = XFastEnumIntEqualityComparer<DamageFlag>.ToInt(DamageFlag.DMGFLAG_NONE);
			this.Caster = 0UL;
			this.ComboCount = 0;
			this._EffectHelper = XDataPool<CombatEffectHelper>.GetData();
		}

		public override void Recycle()
		{
			this._EffectHelper.Recycle();
			XDataPool<ProjectDamageResult>.Recycle(this);
		}

		public bool Accept;

		public ProjectResultType Result;

		private CombatEffectHelper _EffectHelper;

		private double m_TrueDamage;

		private double m_AbsorbDamage;

		private double m_Value;
	}
}
