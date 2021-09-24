using System;

namespace XMainClient
{

	internal struct BuffDesc
	{

		public void Reset()
		{
			this.BuffID = 0;
			this.BuffLevel = 0;
			this.CasterID = 0UL;
			this.DelayTime = 0f;
			this.EffectTime = BuffDesc.DEFAULT_TIME;
			this.SkillID = 0U;
		}

		public int BuffID;

		public int BuffLevel;

		public ulong CasterID;

		public float DelayTime;

		public float EffectTime;

		public uint SkillID;

		public static float DEFAULT_TIME = -1f;
	}
}
