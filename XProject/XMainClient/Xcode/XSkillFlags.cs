using System;
using System.Collections.Generic;

namespace XMainClient
{

	internal class XSkillFlags
	{

		public bool IsFlagSet(uint flag)
		{
			return (this.m_Flag & 1UL << (int)flag) > 0UL;
		}

		public void SetFlag(List<uint> flags)
		{
			for (int i = 0; i < flags.Count; i++)
			{
				this.SetFlag(flags[i]);
			}
		}

		public void SetFlag(short[] flags)
		{
			bool flag = flags != null;
			if (flag)
			{
				for (int i = 0; i < flags.Length; i++)
				{
					this.SetFlag((uint)flags[i]);
				}
			}
		}

		public void SetFlag(uint flag)
		{
			this.m_Flag |= 1UL << (int)flag;
		}

		public void Reset()
		{
			this.m_Flag = 1UL;
		}

		private ulong m_Flag = 1UL;
	}
}
