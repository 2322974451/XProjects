using System;
using System.Collections.Generic;

namespace XMainClient
{
	// Token: 0x02000DCC RID: 3532
	internal class XSkillFlags
	{
		// Token: 0x0600C060 RID: 49248 RVA: 0x0028AE70 File Offset: 0x00289070
		public bool IsFlagSet(uint flag)
		{
			return (this.m_Flag & 1UL << (int)flag) > 0UL;
		}

		// Token: 0x0600C061 RID: 49249 RVA: 0x0028AE94 File Offset: 0x00289094
		public void SetFlag(List<uint> flags)
		{
			for (int i = 0; i < flags.Count; i++)
			{
				this.SetFlag(flags[i]);
			}
		}

		// Token: 0x0600C062 RID: 49250 RVA: 0x0028AEC8 File Offset: 0x002890C8
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

		// Token: 0x0600C063 RID: 49251 RVA: 0x0028AEFE File Offset: 0x002890FE
		public void SetFlag(uint flag)
		{
			this.m_Flag |= 1UL << (int)flag;
		}

		// Token: 0x0600C064 RID: 49252 RVA: 0x0028AF15 File Offset: 0x00289115
		public void Reset()
		{
			this.m_Flag = 1UL;
		}

		// Token: 0x04005061 RID: 20577
		private ulong m_Flag = 1UL;
	}
}
