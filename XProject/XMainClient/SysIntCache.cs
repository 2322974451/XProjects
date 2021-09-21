using System;

namespace XMainClient
{
	// Token: 0x02000DC9 RID: 3529
	public class SysIntCache
	{
		// Token: 0x0600C017 RID: 49175 RVA: 0x002853B8 File Offset: 0x002835B8
		public SysIntCache(int sysCount)
		{
			int num = sysCount / 32;
			int num2 = sysCount % 32;
			bool flag = num2 > 0;
			if (flag)
			{
				num++;
			}
			this.flags = new uint[num];
		}

		// Token: 0x0600C018 RID: 49176 RVA: 0x002853F8 File Offset: 0x002835F8
		public void SetFlag(int flag, bool add)
		{
			int num = flag / 32;
			bool flag2 = num >= 0 && num < this.flags.Length;
			if (flag2)
			{
				flag -= num * 4 * 8;
				if (add)
				{
					this.flags[num] |= 1U << flag;
				}
				else
				{
					this.flags[num] &= ~(1U << flag);
				}
			}
		}

		// Token: 0x0600C019 RID: 49177 RVA: 0x00285464 File Offset: 0x00283664
		public bool IsFlag(int flag)
		{
			int num = flag / 32;
			bool flag2 = num >= 0 && num < this.flags.Length;
			bool result;
			if (flag2)
			{
				flag -= num * 4 * 8;
				result = ((this.flags[num] & 1U << flag) > 0U);
			}
			else
			{
				result = false;
			}
			return result;
		}

		// Token: 0x0600C01A RID: 49178 RVA: 0x002854B4 File Offset: 0x002836B4
		public void Clear()
		{
			for (int i = 0; i < this.flags.Length; i++)
			{
				this.flags[i] = 0U;
			}
		}

		// Token: 0x0400504A RID: 20554
		public uint[] flags = null;
	}
}
