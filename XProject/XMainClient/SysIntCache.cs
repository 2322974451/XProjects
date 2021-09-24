using System;

namespace XMainClient
{

	public class SysIntCache
	{

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

		public void Clear()
		{
			for (int i = 0; i < this.flags.Length; i++)
			{
				this.flags[i] = 0U;
			}
		}

		public uint[] flags = null;
	}
}
