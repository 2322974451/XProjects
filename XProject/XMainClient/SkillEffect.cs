using System;
using System.Collections.Generic;

namespace XMainClient
{

	internal class SkillEffect
	{

		public DamageElement DamageElementType;

		public double PhyRatio;

		public double PhyFixed;

		public double MagRatio;

		public double MagFixed;

		public double PercentDamage;

		public float DecSuperArmor;

		public List<BuffDesc> Buffs;

		public uint ExclusiveMask;
	}
}
