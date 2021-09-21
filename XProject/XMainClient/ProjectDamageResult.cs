using System;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000FF3 RID: 4083
	internal class ProjectDamageResult : XDataBase
	{
		// Token: 0x1700370E RID: 14094
		// (get) Token: 0x0600D446 RID: 54342 RVA: 0x0031FD65 File Offset: 0x0031DF65
		// (set) Token: 0x0600D447 RID: 54343 RVA: 0x0031FD6D File Offset: 0x0031DF6D
		public double DefOriginalRatio { get; set; }

		// Token: 0x1700370F RID: 14095
		// (get) Token: 0x0600D448 RID: 54344 RVA: 0x0031FD78 File Offset: 0x0031DF78
		public CombatEffectHelper EffectHelper
		{
			get
			{
				return this._EffectHelper;
			}
		}

		// Token: 0x17003710 RID: 14096
		// (get) Token: 0x0600D449 RID: 54345 RVA: 0x0031FD90 File Offset: 0x0031DF90
		// (set) Token: 0x0600D44A RID: 54346 RVA: 0x0031FDA8 File Offset: 0x0031DFA8
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

		// Token: 0x17003711 RID: 14097
		// (get) Token: 0x0600D44B RID: 54347 RVA: 0x0031FE08 File Offset: 0x0031E008
		// (set) Token: 0x0600D44C RID: 54348 RVA: 0x0031FE20 File Offset: 0x0031E020
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

		// Token: 0x17003712 RID: 14098
		// (get) Token: 0x0600D44D RID: 54349 RVA: 0x0031FE80 File Offset: 0x0031E080
		// (set) Token: 0x0600D44E RID: 54350 RVA: 0x0031FE98 File Offset: 0x0031E098
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

		// Token: 0x17003713 RID: 14099
		// (get) Token: 0x0600D44F RID: 54351 RVA: 0x0031FEE8 File Offset: 0x0031E0E8
		public double BasicDamage
		{
			get
			{
				return this.Value - this.TrueDamage;
			}
		}

		// Token: 0x17003714 RID: 14100
		// (get) Token: 0x0600D450 RID: 54352 RVA: 0x0031FF07 File Offset: 0x0031E107
		// (set) Token: 0x0600D451 RID: 54353 RVA: 0x0031FF0F File Offset: 0x0031E10F
		public int Flag { get; set; }

		// Token: 0x17003715 RID: 14101
		// (get) Token: 0x0600D452 RID: 54354 RVA: 0x0031FF18 File Offset: 0x0031E118
		// (set) Token: 0x0600D453 RID: 54355 RVA: 0x0031FF20 File Offset: 0x0031E120
		public DamageType Type { get; set; }

		// Token: 0x17003716 RID: 14102
		// (get) Token: 0x0600D454 RID: 54356 RVA: 0x0031FF29 File Offset: 0x0031E129
		// (set) Token: 0x0600D455 RID: 54357 RVA: 0x0031FF31 File Offset: 0x0031E131
		public DamageElement ElementType { get; set; }

		// Token: 0x17003717 RID: 14103
		// (get) Token: 0x0600D456 RID: 54358 RVA: 0x0031FF3A File Offset: 0x0031E13A
		// (set) Token: 0x0600D457 RID: 54359 RVA: 0x0031FF42 File Offset: 0x0031E142
		public bool IsTargetDead { get; set; }

		// Token: 0x17003718 RID: 14104
		// (get) Token: 0x0600D458 RID: 54360 RVA: 0x0031FF4B File Offset: 0x0031E14B
		// (set) Token: 0x0600D459 RID: 54361 RVA: 0x0031FF53 File Offset: 0x0031E153
		public ulong Caster { get; set; }

		// Token: 0x17003719 RID: 14105
		// (get) Token: 0x0600D45A RID: 54362 RVA: 0x0031FF5C File Offset: 0x0031E15C
		// (set) Token: 0x0600D45B RID: 54363 RVA: 0x0031FF64 File Offset: 0x0031E164
		public int ComboCount { get; set; }

		// Token: 0x0600D45C RID: 54364 RVA: 0x0031FF70 File Offset: 0x0031E170
		public bool IsCritical()
		{
			int num = XFastEnumIntEqualityComparer<DamageFlag>.ToInt(DamageFlag.DMGFLAG_CRITICAL);
			return (this.Flag & num) != 0;
		}

		// Token: 0x0600D45D RID: 54365 RVA: 0x0031FF94 File Offset: 0x0031E194
		public ProjectDamageResult()
		{
			this.Init();
		}

		// Token: 0x0600D45E RID: 54366 RVA: 0x0031FFA8 File Offset: 0x0031E1A8
		public void SetResult(ProjectResultType r)
		{
			bool flag = r < this.Result;
			if (flag)
			{
				this.Result = r;
			}
		}

		// Token: 0x0600D45F RID: 54367 RVA: 0x0031FFCC File Offset: 0x0031E1CC
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

		// Token: 0x0600D460 RID: 54368 RVA: 0x00320058 File Offset: 0x0031E258
		public override void Recycle()
		{
			this._EffectHelper.Recycle();
			XDataPool<ProjectDamageResult>.Recycle(this);
		}

		// Token: 0x040060E0 RID: 24800
		public bool Accept;

		// Token: 0x040060E1 RID: 24801
		public ProjectResultType Result;

		// Token: 0x040060E3 RID: 24803
		private CombatEffectHelper _EffectHelper;

		// Token: 0x040060E4 RID: 24804
		private double m_TrueDamage;

		// Token: 0x040060E5 RID: 24805
		private double m_AbsorbDamage;

		// Token: 0x040060E6 RID: 24806
		private double m_Value;
	}
}
